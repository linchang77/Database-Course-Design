namespace db_course_design.Common
{
    public class PictureUtils
    {
        private string? _defaultPicturePath { get; set; }

        public PictureUtils() { }

        public PictureUtils(string defaultPictureRoute)
        {
            _defaultPicturePath = defaultPictureRoute;
        }

        public async Task<Result<string>> SetPictureAsync(string path, IFormFile picture, FileMode mode=FileMode.Truncate)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var extension = Path.GetExtension(picture.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
                return Result<string>.Error("Invalid file type.");

            if (!extension.Equals(Path.GetExtension(path).ToLowerInvariant()))
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception ex)
                {
                    return Result<string>.Error(ex.Message);
                }
                path = Path.ChangeExtension(path, extension);
                mode = FileMode.Create;
            }

            try
            {
                using (var stream = new FileStream(path, mode))
                    await picture.CopyToAsync(stream);
            }
            catch (Exception ex)
            {
                return Result<string>.Error(ex.Message);
            }

            return Result<string>.Success(path);
        }

        public async Task<Result<string>> SetDefaultPictureAsync(string path)
        {
            if (string.IsNullOrEmpty(_defaultPicturePath))
                return Result<string>.Error("Default picture hasn't been set.");

            var defaultPicture = ConvertPicture(_defaultPicturePath);

            if (defaultPicture.code != 0)
                return Result<string>.Error(defaultPicture.msg);

            return await SetPictureAsync(path, defaultPicture.data, FileMode.Create);
        }

        private Result<IFormFile> ConvertPicture(string path)
        {
            IFormFile picture;

            try
            {
                var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                picture = new FormFile(stream, 0, stream.Length, "picture", Path.GetFileName(path));
            }
            catch (Exception ex)
            {
                return Result<IFormFile>.Error(ex.Message);
            }

            return Result<IFormFile>.Success(picture);
        }
    }
}

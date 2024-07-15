namespace db_course_design.Common
{
    [Serializable]
    /// <summary>
    /// 后端统一返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T>
    {
        /// <summary>
        /// 编码：1成功，0和其它数字为失败
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string? msg { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T? data { get; set; }

        /// <summary>
        /// 成功返回结果
        /// </summary>
        /// <returns></returns>
        public static Result<T> Success()
        {
            var result = new Result<T>();
            result.code = 1;
            return result;
        }

        /// <summary>
        /// 成功返回结果
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static Result<T> Success(T obj)
        {
            var result = new Result<T>();
            result.data = obj;
            result.code = 1;
            return result;
        }

        /// <summary>
        /// 失败返回结果
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result<T> Error(string msg)
        {
            var result = new Result<T>();
            result.msg = msg;
            result.code = 0;
            return result;
        }
    }
}

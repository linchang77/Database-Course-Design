using System;
using System.Security.Cryptography;

namespace db_course_design.Common;
public class SaltedPassword
{
    // 使用盐对密码进行哈希运算
    public static string HashPassword(string password, string salt)
    {
        byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password); // 将密码转换为字节数组
        byte[] saltBytes = Convert.FromBase64String(salt); // 将Base64字符串的盐转换为字节数组

        byte[] combinedBytes = new byte[passwordBytes.Length + saltBytes.Length]; // 创建一个新的字节数组，用于存储密码和盐的组合
        Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length); // 将密码字节数组复制到组合字节数组的起始位置
        Buffer.BlockCopy(saltBytes, 0, combinedBytes, passwordBytes.Length, saltBytes.Length); // 将盐字节数组复制到组合字节数组的密码后面

        using (var sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(combinedBytes); // 使用SHA256算法计算组合字节数组的哈希值
            return Convert.ToBase64String(hashBytes); // 将哈希值字节数组转换为Base64字符串
        }
    }

    // 验证密码是否匹配
    public static bool VerifyPassword(string password, string salt, string hashedPassword)
    {
        string hashedInput = HashPassword(password, salt); // 使用相同的盐和密码进行哈希计算
        return hashedInput == hashedPassword; // 比较计算得到的哈希值与存储的哈希密码是否相等
    }
}
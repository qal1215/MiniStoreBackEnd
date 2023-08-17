using System.Security.Cryptography;
using System.Text;

namespace MiniStore.Utility
{
    public class Ultility
    {
        public static string GenerateEightDigitId()
        {
            Guid guid = Guid.NewGuid();
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(guid.ToString()));
                int intValue = BitConverter.ToInt32(hash, 0);
                int eightDigitValue = Math.Abs(intValue % 100000000); // Ensure 8 digits

                return eightDigitValue.ToString("D8"); // Format as 8 digits
            }
        }

        public static DateTime Parse(int i)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(i).DateTime;
        }
    }
}

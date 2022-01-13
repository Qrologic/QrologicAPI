using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace QroApi.BLL
{
    public class RSA
    {
        private static bool _optimalAsymmetricEncryptionPadding = false;

        //These keys are of 2048byte
        private readonly static string PublicKey = "";
        public readonly static string PrivateKey = "";

        public static string Encrypt(string plainText)
        {
            int keySize = 0;
            string publicKeyXml = "";

            GetKeyFromEncryptionString(PublicKey, out keySize, out publicKeyXml);

            var encrypted = Encrypt(Encoding.UTF8.GetBytes(plainText), keySize, publicKeyXml);

            return Convert.ToBase64String(encrypted);
        }

        private static byte[] Encrypt(byte[] data, int keySize, string publicKeyXml)
        {
            if (data == null || data.Length == 0) throw new ArgumentException("Data are empty", "data");
            int maxLength = GetMaxDataLength(keySize);
            if (data.Length > maxLength) throw new ArgumentException(String.Format("Maximum data length is {0}", maxLength), "data");
            if (!IsKeySizeValid(keySize)) throw new ArgumentException("Key size is not valid", "keySize");
            if (String.IsNullOrEmpty(publicKeyXml)) throw new ArgumentException("Key is null or empty", "publicKeyXml");

            using (var provider = new RSACryptoServiceProvider(keySize))
            {
                provider.FromXmlString(publicKeyXml);
                return provider.Encrypt(data, _optimalAsymmetricEncryptionPadding);
            }
        }

        public static string Decrypt(string encryptedText)
        {

            int keySize = 0;
            string publicAndPrivateKeyXml = "";
            GetKeyFromEncryptionString(PrivateKey, out keySize, out publicAndPrivateKeyXml);

            var decrypted = Decrypt(Convert.FromBase64String(encryptedText), keySize, publicAndPrivateKeyXml);

            return Encoding.UTF8.GetString(decrypted);
        }

        private static byte[] Decrypt(byte[] data, int keySize, string publicAndPrivateKeyXml)
        {
            if (data == null || data.Length == 0) throw new ArgumentException("Data are empty", "data");
            if (!IsKeySizeValid(keySize)) throw new ArgumentException("Key size is not valid", "keySize");
            if (String.IsNullOrEmpty(publicAndPrivateKeyXml)) throw new ArgumentException("Key is null or empty", "publicAndPrivateKeyXml");

            using (var provider = new RSACryptoServiceProvider(keySize))
            {
                provider.FromXmlString(publicAndPrivateKeyXml);
                return provider.Decrypt(data, _optimalAsymmetricEncryptionPadding);
            }
        }

        private static int GetMaxDataLength(int keySize)
        {
            if (_optimalAsymmetricEncryptionPadding)
            {
                return ((keySize - 384) / 8) + 7;
            }
            return ((keySize - 384) / 8) + 37;
        }

        private static bool IsKeySizeValid(int keySize)
        {
            return keySize >= 384 && keySize <= 16384 && keySize % 8 == 0;
        }

        private static void GetKeyFromEncryptionString(string rawkey, out int keySize, out string xmlKey)
        {
            keySize = 0;
            xmlKey = "";

            if (rawkey != null)//&& rawkey.Length > 0
            {

                byte[] keyBytes = Convert.FromBase64String(rawkey);
                var stringKey = Encoding.UTF8.GetString(keyBytes);

                if (stringKey.Contains("!"))
                {
                    var splittedValues = stringKey.Split(new char[] { '!' }, 2);

                }
                try
                {
                    keySize = 4096;
                    xmlKey = "<RSAKeyValue><Modulus>qoHRIA1GWONuOUJ4k/ZAic3w4cjVX7sOdgfQgdYp5WRO9tbjDLn7Ar9zWS0c04l9g1mWu8MiU26X+TR8KjFMyof6jH23nw+WIT6KclLSiTrDY0ORYW2k1CivHgc+qOkWK0Fvt1Wtxzj4DwLFglos5ce2D3sfi8J6ANX4EwQdPJ2+FvFlIiNidKbU0JOKnzE22RHs8b3lXSTN1N959cQQ1ONxs9/StMnjb7oE3SrTGwSO5AOE4Jnh8Mx0dS0kxHPwAc8lCkInPNwRaiCSmUVc5LRCsk5woO1V+3bQNP1vEdd5X/DVT8SM7ORZ8nXGKGne/T4jIkljnI6JXy9mfEtCM1y1vT78xFOhzkNTg0npAvmdaRdc4N9MzFu1ZMsWqMMlXJb+sb57feheNw4Ck7bRTM1TMnf0fYxClYhukOyyAC0kPJMcLgDDFyRjx/eT7o2Gt2QjoDIeQg97wyMvrPA1QJHvxdfrnvsHclGxrU5siCRMRG7hSry99LaeZ0hHgqMC01dI0AMK3HsuuFq6ormxWJe0OvcXn+vL44vKrDwwuA3/h4179Dnm36NlmhQNmvJPKfsfoZPPTAxk8Pxwedj8FmZkU6GYTyBt0rhC7BNZW3lhh43b1biHrfo0eQ4dwz3OBlJFIykI0bZGSEWc71AgBdB4F/v1jHLi9v+UAlz+FwE=</Modulus><Exponent>AQAB</Exponent><P>x9hByDWH9zmu16wPXZr3lVuuNaaAS0s8NHrs1QEY7TIDfhM8pi2NkpKA8ny2uvNQLDXbAl9uJq8ZhV/i7bd9VGYl+EE+ur8EG58MwDGiSKwV3RGxP5Slp2pItLZ+R/HtNEvPJwnrE5Xfhs0L3NtnSwg9VgloWAEq0lvbVLWdARMpaq8n1F7sgPlDByWYcJpSDSruX1myy6hqJAQefLoJndG4lPZbsvpnEGa18ON0vfA6u1ReAWzwdmCVKMbHhC21yrJ5/HyB1770XwT/C3t+QTlrm9KQ8RQISqoYkA+INZsExZFumheYY+BGTa3FnOY/MIGQerh9cgM74W8UQRVszw==</P><Q>2msrMaDZhj0859zG1YIIenOY3ESrxEZ5ZQnaU6Cs+z/vp4DiJMIYDeWgUMk3k54h2Tq98ZxqcUKydcEqY2mc2RRMaz9wwujkKjewuryPGQurmFJRFeEEx2/pZOrD3PmSyAfXaRDCTEkLAR4BltHujVhcxKes4jV71CHPaBpK0AqA3gVzj+TvTUND+rpOKOBe6ScDPhsoFnQYz9HKqHq4KlZddPxm8Rh2wQbD8hqspeo5AaNfC3NCUj958ijyupm6UZnXk0dSD00esiWCzeR0r39czD7oIB50A246w4rkJuNNu6aBMo/IJl59paLpqYvJSnUsC9t3fspwwC3wTbhTLw==</Q><DP>SqH1types7JkHIFSX7fO/IV3ouuif/wB6Ot7ZPT69SI3ca8HeFwMwg9afrSanWjeqRQXzWQMRAAifM/ZdMOQ16MqTPM41Q8fHp2gampe29sAc0X3NvJxhvtHWc3JjV7JIj2piD/I/dB74ODUrE933Oqf1XC/+hW9gz/wwkrs7ojUb9Yn/sTQeD4ejR26N1s6h1ZgHVXnUu17biXnqNblXn4C/AahKk8fjF1/Vw3q/EAp/um8DbY8e0kIi2jo+/ECMkfDDMsGxqa2poG8KfKdrQgfqtrRbGb5zcCGWc6jJLnW512vu3ZSYAJS3xGlejn2oUvRxDMADkMs6rzMCJ5Suw==</DP><DQ>LGYgj6QM07bbDJ7aZEhchNe+uPfUmr9gqeNI2DsPLrueccRHNAWochq9be6ZN46rfsbsGZMcKA3QzRMJFNBBK/duWVa6C0TgLJzJdgwiYor2xK3nAbWODSR4oyT9z4uEBNljNl5LwMoQTJfW5tuhzGWr5eXXxNvuYf7FdHnzvzqDW55sEVIOOvxzcyIwBSsm3+ooRJWsnnPXH1ecBId9rE2GDePI4TWB3lcLuckmU0u7btPQ3Dj/wExa85jTTo81SqUlJzEWQzoABWKOpl/MQGh5aqNW+EB4gMIFe/5dxnHqOTztgmOr4fDPRb5KFUbvEg2jeH2SWtm39bjg4kuXzQ==</DQ><InverseQ>WRhBlKiAi1M55Akf3kf+CCtbAHIieF/dN605nFCkO2SoHkUGoanp/e5tqTWQ75kr12VGpKdO87FRJAk0Ul1q0vNkK8z0zJ1M8bSkiyYFAcvop129mY4xSHZDrZCSdhJLtqA8ntD4ZHPDnV+RkXgCSVKoDX28hKRJbpgBiYEK1k8HM1QZ+3xhtjkSFSdBYWh88YjgCqeFlrto4omM2t+7QL0PmNJX0H5ieInc7C5hI5Q5cDMZE+LXW56vnEWRUf69VWXyoklt7wXHCPQhowDCi8+/kmDk06+1gJg+xbULFlF2vzJBrgq2hne3VlR5f8JqmQ1VtXWfqAeJu9drGd1mrQ==</InverseQ><D>kh3BerglitMLiCJAdnvW/sDvJm4W/HyufdNgiYNgT+ZQDRRFaoiOZOJwFQGl7Fmsp71EgQ9OATWLItIpfXbWGdHBklfB3Ztbyo1v01zKczNacVxb36Q4Vl+vAgqvVcy5ZMQk2nWgAFP/r81uOLDSPO+SQ139wKUeLE0w1Ar4ixOa7MpdIo40N0copL1rU9S27fqAlQFo5xM9GKmSOFyXF/j5XW33gVppfztoI6gpVMPpN9kUK+1zRAnR2wCeu4OnL8W2Nj5OpcbpXYsgVhys6IjZhzfVKPN6dY5yCpcMcbu3ldIq2rrTEcb2leL7t3JS165CKYW+yVEUw+844lcUGM1wXP2FUbm68naCXyZkGjMGpP0JXiuOZohvZQbtJ+LHURsSe3AebW/f6tjcJNtbrT8SHwCLOcDs4mwm+xt7Zr5bYJq/pADycI3jTBNZbO135CV/K+cGyzmqe0I3O6mOQG11ZxECK6oNZ6AwiJjKtG1/PW38Cj8beHg1tZ3HF3O78B1AQH+4hgmvWz6L5B+u9qREOBuKc1RDaIGQDQdLUNa1M9/G2ClPj2fCPMQOQNslhW9qfFpt17bNp8y5qniZmc9xF4T0E80uyTCGqbGY3E4QXg4ihpgXWAPn8yUMnI1k4fHKYDNQhc13e5uTIGWrJqf5vMiwo0ekuyAfI41ou4k=</D></RSAKeyValue>";
                }
                catch (Exception e) { }
                //}
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AltirisDecrypt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: AltirisDecrypt <Base64EncryptedPassword> <Base64Key>");
                Environment.Exit(1);
            }

            try
            {
                if (string.IsNullOrEmpty(args[0]))
                    throw new ArgumentException("Encrypted password argument is null or empty.", nameof(args));
                if (string.IsNullOrEmpty(args[1]))
                    throw new ArgumentException("Key argument is null or empty.", nameof(args));

                byte[] input_data = Convert.FromBase64String(args[0]);
                byte[] key = Convert.FromBase64String(args[1]);

                int encLength = input_data.Length - 64;
                int encryptedBufferSize = encLength - 18;
                if (encryptedBufferSize <= 0)
                    throw new ArgumentException("Encrypted password appears invalid or corrupted.");

                byte[] processedData = new byte[encryptedBufferSize];
                Buffer.BlockCopy(input_data, 18, processedData, 0, encryptedBufferSize);

                // Retrieve the IV from the base64-encoded blob.
                byte[] iv = new byte[16];
                Buffer.BlockCopy(input_data, 2, iv, 0, 16);

                using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    using (ICryptoTransform decryptor = aes.CreateDecryptor())
                    using (MemoryStream msDecrypt = new MemoryStream(processedData))
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        string plaintext = srDecrypt.ReadToEnd();
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < plaintext.Length; i += 2)
                        {
                            sb.Append(plaintext[i]);
                        }
                        Console.WriteLine("Decrypted data: " + sb.ToString());
                    }
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Error: One or more arguments are not valid Base64. " + fe.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Argument Error: " + ae.Message);
            }
            catch (CryptographicException ce)
            {
                Console.WriteLine("Cryptography Error: " + ce.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
        }
    }
}

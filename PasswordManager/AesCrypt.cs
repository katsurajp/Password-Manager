using Password_Manager.Contract;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Password_Manager {
    public class AesCrypt : ICrypt {
        private byte[] _aesKey;
        private byte[] _iv;

        public AesCrypt(byte[] key, byte[] iv) {
            _aesKey = key;
            _iv = iv;
        }

        public string Encrypt(string content) {
            using (Aes aes = CreateAes()) {
                aes.Key = _aesKey;
                aes.IV = _iv;

                using(ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV)) {
                    using(MemoryStream mStream = new MemoryStream()) {
                        using (CryptoStream cStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write)) {
                            using(StreamWriter sWriter = new StreamWriter(cStream)) {
                                var unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                                sWriter.Write($"{unixTimestamp}|{content}");
                            }

                            return Convert.ToBase64String(mStream.ToArray());
                        }
                    }
                }
            }
        }

        public string Decrypt(string encrypted) {
            byte[] toDecrypt = Convert.FromBase64String(encrypted);

            using (Aes aes = CreateAes()) {
                using (ICryptoTransform encryptor = aes.CreateDecryptor(aes.Key, aes.IV)) {
                    using (MemoryStream mStream = new MemoryStream(toDecrypt)) {
                        using (CryptoStream cStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Read)) {
                            using (StreamReader sWriter = new StreamReader(cStream)) {
                                string decrypted = sWriter.ReadToEnd();

                                return decrypted.Substring(decrypted.IndexOf("|") + 1);
                            }
                        }
                    }
                }
            }
        }

        private Aes CreateAes() {
            Aes aes = Aes.Create();
            aes.Key = _aesKey;
            aes.IV = _iv;

            return aes;
        }
    }
}

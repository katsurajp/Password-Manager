using Password_Manager.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Password_Manager {
    public class ByteShifter : ICrypt {
        private readonly int _seed;
        private readonly char[] _key;

        public ByteShifter(int seed, string key) {
            _seed = seed;
            _key = key.ToArray();
        }

        public string Encrypt(string toEncrypt) {
            string base64 = null;

            Random rand = new Random(_seed);
            ICollection<byte> encryptedBytes = new List<byte>();
            int keyIndex = 0;
            byte b;
            int i;
            int offset;

            using (StringReader reader = new StringReader(toEncrypt)) {
                while ((i = reader.Read()) >= 0) {
                    b = (byte)i;
                    offset = _key[++keyIndex % _key.Length];
                    offset += rand.Next(37);
                    b = Convert.ToByte((Convert.ToInt32(b) + offset) % 256);
                    encryptedBytes.Add(b);
                }
            }

            base64 = Convert.ToBase64String(encryptedBytes.ToArray());

            return base64;
        }

        public string Decrypt(string toDecrypt) {
            Random rand = new Random(_seed);
            ICollection<byte> decryptedBytes = new List<byte>();
            int keyIndex = 0;
            byte b;
            int offset;

            byte[] encryptedBytes = Convert.FromBase64String(toDecrypt);

            for (int i = 0; i < encryptedBytes.Length; i++) {
                b = encryptedBytes[i];
                offset = _key[++keyIndex % _key.Length];
                offset += rand.Next(37);
                int result = (Convert.ToInt32(b) - offset) % 256;
                if (result < 0)
                    b = Convert.ToByte(256 - result * -1);
                else
                    b = Convert.ToByte(result);
                decryptedBytes.Add(b);
            }

            return Encoding.Default.GetString(decryptedBytes.ToArray());
        }
    }
}

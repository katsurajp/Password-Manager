using Password_Manager;
using Password_Manager.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Windows.Forms;

namespace PluginServiceApplication {
    public class PwController : ApiController {
        private static byte[] key = null;
        private static byte[] iv = null;

        [HttpGet]
        public SimpleCredential GetCredentials(string u) {
            List<CredentialGroup> credentials = new List<CredentialGroup>();

            if (key == null) {
                PasswordPrompt prompt = new PasswordPrompt();
                DialogResult result = prompt.ShowDialog();
                while (result == DialogResult.OK && key == null) {
                    GetAESKeyAndIV(prompt.Input, out byte[] aesKey, out byte[] aesIv);

                    try {
                        credentials = GetCredentials(aesKey, aesIv);

                        key = aesKey;
                        iv = aesIv;
                    }
                    catch {
                        result = prompt.ShowDialog();
                    }
                }
            }
            else {
                credentials = GetCredentials(key, iv);
            }

            SimpleCredential simpleCredential = new SimpleCredential();

            try {
                string hostname = GetHostName(System.Web.HttpUtility.UrlDecode(u));

                Credential credential = credentials.SelectMany(g => g.Credentials)
                    .Where(c => string.Compare(GetHostName(c.URL), hostname, true) == 0)
                    .FirstOrDefault();

                simpleCredential.Username = credential.Username;
                simpleCredential.Password = credential.Password;
            }
            catch {
                ;
            }

            return simpleCredential;
        }

        private string GetHostName(string url) {
            if (url == null)
                return url;

            try {
                if (!url.Contains("://"))
                    url = "http://" + url;

                var uri = new Uri(url);
                var hostname = uri.Host;

                hostname = hostname.TrimStart("www.".ToCharArray());
                hostname = TrimEndIfMatched(hostname, ".de");
                hostname = TrimEndIfMatched(hostname, ".at");
                hostname = TrimEndIfMatched(hostname, ".com");
                hostname = TrimEndIfMatched(hostname, ".net");
                hostname = TrimEndIfMatched(hostname, ".org");
                hostname = TrimEndIfMatched(hostname, ".gov");
                hostname = TrimEndIfMatched(hostname, ".co.uk");
                hostname = TrimEndIfMatched(hostname, "co.jp");

                return hostname;
            }
            catch {
                return null;
            }
        }

        private string TrimEndIfMatched(string value, string toReplace) {
            if (value.EndsWith(toReplace))
                return value = value.Substring(0, value.Length - toReplace.Length);
            return value;
        }

        private List<CredentialGroup> GetCredentials(byte[] key, byte[] iv) {
            ICrypt aesCrypt = new AesCrypt(key, iv);
            ICrypt byteShift = new ByteShifter(4190, "vmqup4amöovcb86mnoöbsaen");
            ICredentialsStore<ICollection<CredentialGroup>> store = new CredentialFileStore("D6qA5QN31w.dat", new[] { aesCrypt, byteShift });
            return store.Load().ToList();
        }

        private void GetAESKeyAndIV(string password, out byte[] key, out byte[] iv) {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] salt = Encoding.UTF8.GetBytes("aâí?©Êç“­µ¬f}þ¨^x!18");
            var derivedBytes = new Rfc2898DeriveBytes(passwordBytes, salt, 5000);
            key = derivedBytes.GetBytes(32);
            iv = derivedBytes.GetBytes(16);
        }
    }
}

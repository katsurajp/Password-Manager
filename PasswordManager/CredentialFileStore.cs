using Newtonsoft.Json;
using Password_Manager.Contract;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Password_Manager {
    public class CredentialFileStore : ICredentialsStore<ICollection<CredentialGroup>> {
        private readonly ICollection<ICrypt> _crypter;
        private string _storeFile;

        public CredentialFileStore(string storeFile, ICrypt crypter) {
            _storeFile = storeFile;
            _crypter =  new[] { crypter };
        }

        public CredentialFileStore(string storeFile, ICollection<ICrypt> crypter) {
            _storeFile = storeFile;
            _crypter = crypter;
        }

        public ICollection<CredentialGroup> Load() {
            List<CredentialGroup> groups = null;

            if (File.Exists(_storeFile)) {
                string json = File.ReadAllText(_storeFile);
                _crypter?.Reverse()?.ToList().ForEach(c => {
                    json = c.Decrypt(json);
                });

                groups = JsonConvert.DeserializeObject<List<CredentialGroup>>(json);

                if (groups != null && groups.Count > 0) {
                    groups.ToList().ForEach(i => {
                        i.Credentials.ToList().ForEach(c => c.Group = i);
                    });
                }
            }

            return groups;
        }

        public void Save(ICollection<CredentialGroup> data) {
            string encrypted = JsonConvert.SerializeObject(data);
            _crypter?.ToList()?.ForEach(c => {
                encrypted = c.Encrypt(encrypted);
            });
            File.WriteAllText(_storeFile, encrypted);
        }

        public void SetStoreFile(string absolutePath) {
            _storeFile = absolutePath;
        }
    }
}

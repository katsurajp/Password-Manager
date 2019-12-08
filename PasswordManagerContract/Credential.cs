using Newtonsoft.Json;
using System;

namespace Password_Manager.Contract {
    public class Credential : ICloneable {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string URL { get; set; }

        public string Notes { get; set; }

        [JsonIgnore]
        public CredentialGroup Group { get; set; }

        public object Clone() {
            return this.MemberwiseClone();
        }

        public override string ToString() {
            return Name;
        }
    }
}

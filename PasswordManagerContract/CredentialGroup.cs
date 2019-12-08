using System;
using System.Collections.Generic;

namespace Password_Manager.Contract {
    public class CredentialGroup : ICloneable {
        public string Name { get; set; }

        public ICollection<Credential> Credentials { get; set; }

        public CredentialGroup(string name) {
            Credentials = new List<Credential>();
            Name = name;
        }

        public object Clone() {
            return this.MemberwiseClone();
        }

        public override string ToString() {
            return Name;
        }
    }
}

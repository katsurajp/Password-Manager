using Password_Manager.Contract;
using System.Collections.Generic;

namespace Password_Manager.Commands {
    class MoveCredentialCommand : ICommand {
        public bool CanUndo => true;

        private CredentialGroup _sourceGroup { get; set; }

        public Credential Credential { get; set; }

        public CredentialGroup TargetGroup { get; set; }

        public object Execute() {
            _sourceGroup = Credential.Group;

            Credential.Group = TargetGroup;
            TargetGroup.Credentials.Add(Credential);
            _sourceGroup.Credentials.Remove(Credential);

            return Credential;
        }

        public object Redo() {
            return Execute();
        }

        public object Undo() {
            Credential.Group = _sourceGroup;
            _sourceGroup.Credentials.Add(Credential);
            TargetGroup.Credentials.Remove(Credential);

            return Credential;
        }
    }
}

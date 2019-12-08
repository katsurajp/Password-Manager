using Password_Manager.Contract;

namespace Password_Manager.Commands {
    public class RemoveCredentialCommand : ICommand {
        public bool CanUndo => true;

        private CredentialGroup _group { get; set; }

        public Credential CredentialToRemove { get; set; }

        public object Execute() {
            _group = CredentialToRemove.Group;
            _group.Credentials.Remove(CredentialToRemove);
            CredentialToRemove.Group = _group;

            return CredentialToRemove;
        }

        public object Redo() {
            return Execute();
        }

        public object Undo() {
            _group.Credentials.Add(CredentialToRemove);

            return null;
        }
    }
}

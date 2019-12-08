using Password_Manager.Contract;

namespace Password_Manager.Commands {
    public class AddCredentialCommand : ICommand {
        public bool CanUndo => true;

        public CredentialGroup Group { get; set; }

        public Credential CredentialToCreate { get; set; }

        public object Execute() {
            Group.Credentials.Add(CredentialToCreate);
            CredentialToCreate.Group = Group;

            return CredentialToCreate;
        }

        public object Redo() {
            return Execute();
        }

        public object Undo() {
            Group.Credentials.Remove(CredentialToCreate);

            return null;
        }
    }
}

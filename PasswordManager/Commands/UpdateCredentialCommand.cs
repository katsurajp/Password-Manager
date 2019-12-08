using Password_Manager.Contract;

namespace Password_Manager.Commands {
    internal class UpdateCredentialCommand : ICommand {
        public bool CanUndo => true;

        private Credential originalValue { get; set; }

        public Credential ToBeUpdated { get; set; }

        public Credential UpdatedCredential { get; set; }

        public object Execute() {
            originalValue = (Credential)ToBeUpdated.Clone();

            ToBeUpdated.Group = UpdatedCredential.Group;
            ToBeUpdated.Name = UpdatedCredential.Name;
            ToBeUpdated.Username = UpdatedCredential.Username;
            ToBeUpdated.Password = UpdatedCredential.Password;
            ToBeUpdated.URL = UpdatedCredential.URL;
            ToBeUpdated.Notes = UpdatedCredential.Notes;

            return ToBeUpdated;
        }

        public object Redo() {
            return Execute();
        }

        public object Undo() {

            ToBeUpdated.Group = originalValue.Group;
            ToBeUpdated.Name = originalValue.Name;
            ToBeUpdated.Username = originalValue.Username;
            ToBeUpdated.Password = originalValue.Password;
            ToBeUpdated.URL = originalValue.URL;
            ToBeUpdated.Notes = originalValue.Notes;

            return ToBeUpdated;
        }
    }
}

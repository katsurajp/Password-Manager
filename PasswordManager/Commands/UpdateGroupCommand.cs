using Password_Manager.Contract;

namespace Password_Manager.Commands {
    internal class UpdateGroupCommand : ICommand {
        public bool CanUndo => true;

        private CredentialGroup originalValue { get; set; }

        public CredentialGroup ToBeUpdated { get; set; }

        public CredentialGroup UpdatedCredential { get; set; }

        public object Execute() {
            originalValue = (CredentialGroup)ToBeUpdated.Clone();

            ToBeUpdated.Name = UpdatedCredential.Name;

            return ToBeUpdated;
        }

        public object Redo() {
            return Execute();
        }

        public object Undo() {
            ToBeUpdated.Name = originalValue.Name;

            return ToBeUpdated;
        }
    }
}

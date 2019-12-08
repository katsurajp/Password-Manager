using Password_Manager.Contract;
using System.Collections.Generic;

namespace Password_Manager.Commands {
    public class DeleteGroupCommand : ICommand {
        public bool CanUndo => true;

        public List<CredentialGroup> AllGroups { get; set; }

        public CredentialGroup DeletedGroup { get; set; }

        public object Execute() {
            AllGroups.Remove(DeletedGroup);

            return AllGroups;
        }

        public object Redo() {
            return Execute();
        }

        public object Undo() {
            AllGroups.Add(DeletedGroup);

            return AllGroups;
        }
    }
}

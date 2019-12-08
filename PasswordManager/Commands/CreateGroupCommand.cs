using Password_Manager.Contract;
using System.Collections.Generic;

namespace Password_Manager.Commands {
    public class CreateGroupCommand : ICommand {
        public bool CanUndo => true;

        public string GroupName { get; set; }

        public List<CredentialGroup> AllGroups { get; set; }

        public CredentialGroup CreatedGroup { get; set; }

        public object Execute() {
            CreatedGroup = new CredentialGroup(GroupName);
            AllGroups.Add(CreatedGroup);

            return AllGroups;
        }

        public object Redo() {
            AllGroups.Add(CreatedGroup);

            return AllGroups;
        }

        public object Undo() {
            AllGroups.Remove(CreatedGroup);

            return AllGroups;
        }
    }
}

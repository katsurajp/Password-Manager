using Password_Manager.Commands;
using Password_Manager.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Password_Manager {
    public class PasswordSafe : IPasswordSafe {
        private List<CredentialGroup> _currentData;

        private readonly ICredentialsStore<ICollection<CredentialGroup>> _store;

        public bool HasUndoableAction => CommandProcessor.CanUndo;

        public bool HasRedoableAction => CommandProcessor.CanRedo;

        public event EventHandler OnCommandExecuted;

        public PasswordSafe(ICredentialsStore<ICollection<CredentialGroup>> store) {
            _store = store;
            _currentData = new List<CredentialGroup>();
        }

        public CredentialGroup CreateGroup(string groupName) {
            if (_currentData.Any(g => g.Name == groupName))
                throw new InvalidOperationException($"Eine Gruppe mit dem Namen {groupName} existiert bereits.");

            ICommand command = new CreateGroupCommand() {
                AllGroups = _currentData,
                GroupName = groupName
            };

            _currentData = (List<CredentialGroup>)ExecuteCommand(command);

            return _currentData.First(g => g.Name.Equals(groupName));
        }

        public ICollection<CredentialGroup> GetGroups() {
            if (_currentData == null)
                _currentData = _store.Load()?.ToList();

            return _currentData.OrderBy(g => g.Name).ToList();
        }

        public CredentialGroup UpdateGroup(CredentialGroup toBeUpdated, CredentialGroup updated) {
            if (String.IsNullOrWhiteSpace(updated.Name))
                throw new InvalidOperationException("Der Name darf nicht leer sein.");
            else if (_currentData.Any(g => g.Name == updated.Name))
                throw new InvalidOperationException("Eine Gruppe mit diesem Namen existiert bereits.");

            ICommand command = new UpdateGroupCommand() {
                ToBeUpdated = toBeUpdated,
                UpdatedCredential = updated
            };

            toBeUpdated = (CredentialGroup)ExecuteCommand(command);

            return toBeUpdated;
        }

        public CredentialGroup FindGroup(string name) {
            return _currentData.FirstOrDefault(g => g.Name == name);
        }

        public void RemoveGroup(CredentialGroup toBeRemoved) {
            ICommand command = new DeleteGroupCommand() {
                AllGroups = _currentData,
                DeletedGroup = toBeRemoved
            };

            ExecuteCommand(command);
        }

        public Credential AddCredential(CredentialGroup group, Credential credential) {
            if (group == null)
                throw new InvalidOperationException("Es muss eine Gruppe zugeordnet werden.");
            else if (String.IsNullOrWhiteSpace(credential.Name))
                throw new InvalidOperationException("Der Name darf nicht leer sein.");
            else if (_currentData.First(g => g == group).Credentials.Any(c => c.Name == credential.Name))
                throw new InvalidOperationException("Ein Eintrag mit diesem Namen existiert bereits.");

            int id = Convert.ToInt32(_currentData.SelectMany(g => g?.Credentials)?.Max(c => c?.ID)) + 1;
            credential.ID = id;

            ICommand command = new AddCredentialCommand() {
                Group = group,
                CredentialToCreate = credential
            };

            credential = (Credential)ExecuteCommand(command);
            
            return credential;
        }

        public Credential UpdateCredential(Credential toBeUpdated, Credential updated) {
            if (String.IsNullOrWhiteSpace(updated.Name))
                throw new InvalidOperationException("Der Name darf nicht leer sein.");

            ICommand command = new UpdateCredentialCommand() {
                ToBeUpdated = toBeUpdated,
                UpdatedCredential = updated
            };

            toBeUpdated = (Credential)ExecuteCommand(command);

            return toBeUpdated;
        }

        public Credential FindCredentialById(int id) {
            return _currentData.SelectMany(g => g.Credentials)?.FirstOrDefault(c => c.ID == id);
        }

        public void RemoveCredential(Credential toBeRemoved) {
            if (toBeRemoved == null)
                throw new InvalidOperationException("Keine Credentials ausgewählt.");
            if (toBeRemoved.Group == null || !_currentData.Contains(toBeRemoved.Group))
                throw new InvalidOperationException("Inkonsistente Gruppenzuordnung.");

            ICommand command = new RemoveCredentialCommand() {
                CredentialToRemove = toBeRemoved
            };

            ExecuteCommand(command);
        }

        public void MoveCredential(Credential credential, CredentialGroup targetGroup) {
            if (credential == null)
                throw new InvalidOperationException("Keine Credentials ausgewählt.");
            if (targetGroup == null)
                throw new InvalidOperationException("Zielgruppe nicht angegeben.");

            ICommand command = new MoveCredentialCommand() {
                Credential = credential,
                TargetGroup = targetGroup
            };

            ExecuteCommand(command);
        }

        public Credential DuplicateCredential(Credential credential) {
            if(credential == null)
                throw new InvalidOperationException("Keine Credentials ausgewählt.");

            Credential duplicate = (Credential)credential.Clone();
            RenameCopy(duplicate);

            ICommand command = new AddCredentialCommand() {
                CredentialToCreate = duplicate,
                Group = duplicate.Group
            };

            ExecuteCommand(command);

            return duplicate;
        }

        public void Undo() {
            if (CommandProcessor.CanUndo)
                CommandProcessor.Undo();

            OnCommandExecuted?.Invoke(this, null);
        }

        public void Redo() {
            if (CommandProcessor.CanRedo)
                CommandProcessor.Redo();

            OnCommandExecuted?.Invoke(this, null);
        }

        public void Load() {
            ICollection<CredentialGroup> loaded = _store.Load();
            if (loaded != null)
                _currentData = loaded.ToList();
        }

        public void Save() {
            _store.Save(_currentData);
        }

        public void ChangeStoreFile(string absolutePath) {
            _store.SetStoreFile(absolutePath);
        }

        private void RenameCopy(Credential credential) {
            bool success = false;
            string newName;
            int copyNumber = 1;

            while (!success) {
                newName = $"{credential.Name} - Kopie({copyNumber})";
                if (!credential.Group.Credentials.Any(c => c.Name == newName)) {
                    credential.Name = newName;
                    success = true;
                }
                copyNumber++;
            }
        }

        private object ExecuteCommand(ICommand command) {
            object returnValue = CommandProcessor.Execute(command);
            OnCommandExecuted?.Invoke(this, null);
            return returnValue;
        }
    }
}

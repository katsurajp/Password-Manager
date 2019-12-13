using System.Collections.Generic;

namespace Password_Manager.Contract {
    public interface IPasswordSage {
        bool HasUndoableAction { get; }

        bool HasRedoableAction { get; }

        CredentialGroup CreateGroup(string groupName);

        CredentialGroup UpdateGroup(CredentialGroup toBeUpdated, CredentialGroup updated);

        ICollection<CredentialGroup> GetGroups();

        CredentialGroup FindGroup(string name);

        void RemoveGroup(CredentialGroup toBeRemoved);

        Credential AddCredential(CredentialGroup group, Credential credential);

        Credential UpdateCredential(Credential toBeUpdated, Credential updated);

        Credential FindCredentialById(int id);

        void RemoveCredential(Credential toBeremoved);

        void Undo();

        void Redo();

        void Load();

        void Save();

        void ChangeStoreFile(string absolutePath);
    }
}

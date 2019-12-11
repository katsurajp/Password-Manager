namespace Password_Manager.Contract {
    public interface ICredentialsStore<T> {
        T Load();

        void Save(T data);

        void SetStoreFile(string absolutePath);
    }
}

namespace Password_Manager.Contract {
    public interface ICrypt {
        string Encrypt(string toEncrypt);

        string Decrypt(string toDecrypt);
    }
}

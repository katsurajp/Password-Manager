namespace Password_Manager.Contract {
    public interface IPasswordAnalyzer {
        PasswordScore CheckStrength(string password);
    }
}

namespace Password_Manager {
    public class PasswordRules {
        public bool ContainsLowerCaseLetters { get; set; } = true;

        public bool ContainsUpperCaseLetters { get; set; } = true;

        public bool ContainsDigits { get; set; } = true;

        public bool ContainsSpecialCharacters { get; set; } = true;
    }
}

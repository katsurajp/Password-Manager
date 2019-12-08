using Password_Manager.Contract;
using System.Text.RegularExpressions;

namespace Password_Manager {
    public class StandardPasswordAnalyzer : IPasswordAnalyzer {
        public PasswordScore CheckStrength(string password) {
            int score = 0;

            if (password.Length < 1)
                return PasswordScore.Blank;
            if (password.Length < 4)
                return PasswordScore.VeryWeak;

            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"\d", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, "[a-z]", RegexOptions.ECMAScript).Success &&
              Regex.Match(password, "[A-Z]", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"[^a-zA-Z\d\s:]", RegexOptions.ECMAScript).Success)
                score++;

            if (score == 0)
                score = 1;

            return (PasswordScore)score;
        }
    }
}

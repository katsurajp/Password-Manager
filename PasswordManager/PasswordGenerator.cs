using Password_Manager.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Password_Manager {
    public class PasswordGenerator : IPasswordGenerator {
        private readonly PasswordRules _rules;
        private readonly Dictionary<string, char[]> _pool;
        private Random _random;

        public PasswordGenerator(PasswordRules rules, char[] specialCharacters) {
            _rules = rules;
            _pool = new Dictionary<string, char[]>();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string digits = "0123456789";

            if (rules.ContainsLowerCaseLetters)
                _pool.Add("LowerCaseLetters", alphabet.ToCharArray());
            if (rules.ContainsUpperCaseLetters)
                _pool.Add("UpperCaseLetters", alphabet.ToUpper().ToCharArray());
            if (rules.ContainsDigits)
                _pool.Add("Digits", digits.ToArray());
            if (rules.ContainsSpecialCharacters)
                _pool.Add("SpecialCharacters", specialCharacters);
        }

        public string Generate(int length) {
            StringBuilder password = new StringBuilder();
            _random = new Random(DateTime.Now.Millisecond);
            int r;
            string key;

            string[] poolElements = _pool.Keys.ToArray().Shuffle(_random);

            for(int i = 0; i < poolElements.Length; i++) {
                if (password.Length == length)
                    break;

                key = _pool.Keys.ElementAt(i);
                password.Append(GetCharacterFromPool(key));
            }

            while (password.Length < length) {
                r = _random.Next(0, poolElements.Length - 1);
                password.Append(GetCharacterFromPool(poolElements[r]));
            }

            return ShuffleString(password.ToString());
        }

        private string ShuffleString(string value) => string.Join("", value.ToCharArray().Shuffle(_random));

        private char GetCharacterFromPool(string key) {
            char[] characters = _pool[key];
            int r = _random.Next(0, characters.Length - 1);
            return characters[r];
        }
    }
}

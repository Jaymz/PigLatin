using System;

namespace PigLatin {
    public class Word {
        public Word(string word) {
            Original = word;
        }

        public string Original { get; private set; }

        public int VowelIndex {
            get {
                var vowelIndex = Original.IndexOfAny(Config.Vowels);

                if (vowelIndex > 0) {
                    if (vowelIndex > 0 && Original.Substring(vowelIndex - 1, 1) == "q") {
                        vowelIndex++;
                    }

                    return vowelIndex;
                }

                return Original.IndexOfAny(Config.BackupVowels);
            }
        }

        public string ConsonentCluster { get => VowelIndex >= 0 ? Original.Substring(0, VowelIndex) : String.Empty; }

        public string EndOfWord {
            get {
                var endOfWord = VowelIndex >= 0 ? Original.Substring(VowelIndex) : Original;
                if (endOfWord == "y") { // Special case substitution
                    endOfWord = "i";
                }

                return endOfWord;
            }
        }

        public string Suffix {
            get {
                if (VowelIndex > 0) {
                    return "ay";
                }

                return Config.Suffixes[Original.Length % Config.Suffixes.Length];
            }
        }
    }
}

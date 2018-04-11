namespace PigLatin {
    public class WordTranslationService : IWordTranslationService {
        public string Translate(Word word) {
            return $"{word.EndOfWord}-{word.ConsonentCluster}{word.Suffix}";
        }
    }
}

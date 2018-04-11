namespace PigLatin {
    public class WordTranlationService : IWordTranlationService {
        public string Translate(Word word) {
            return $"{word.EndOfWord}-{word.ConsonentCluster}{word.Suffix}";
        }
    }
}

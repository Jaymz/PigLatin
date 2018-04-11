using System;

namespace PigLatin {
    public class PhraseTranslationService : IPhraseTranslationService {
        private readonly IWordTranslationService _wordTranslator;
        public PhraseTranslationService(IWordTranslationService wordTranslator) {
            _wordTranslator = wordTranslator;
        }


        public string Translate(string phrase) {
            var words = phrase.Split(' ');
            var outputWords = new string[words.Length];

            int i = 0;
            foreach (var word in phrase.Split(' ')) {
                outputWords[i++] = _wordTranslator.Translate(new Word(word));
            }

            return String.Join(' ', outputWords);
        }
    }
}

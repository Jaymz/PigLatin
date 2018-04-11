using NUnit.Framework;
using PigLatin;

namespace Translator.Tests {
    [TestFixture]
    public class PhraseTranslationTests {
        private IWordTranslationService _wordTranslator;
        private IPhraseTranslationService _phraseTranslator;

        [SetUp]
        public void Setup()
        {
            _wordTranslator = new WordTranslationService();
            _phraseTranslator = new PhraseTranslationService(_wordTranslator);
        }

        [Test]
        [TestCase("beast", "east-bay")]
        [TestCase("dough", "ough-day")]
        [TestCase("happy", "appy-hay")]
        [TestCase("question", "estion-quay")]
        [TestCase("star", "ar-stay")]
        [TestCase("three", "ee-thray")]
        [TestCase("yes", "es-yay")]
        [TestCase("each", "each-hay")]
        [TestCase("I", "I-hay")]
        [TestCase("my", "i-may")]
        [TestCase("why", "i-whay")]
        public void CanTranslateWord(string word, string expectedResult)
        {
            Assert.AreEqual(expectedResult, _wordTranslator.Translate(new Word(word)));
        }

        [TestCase("star three", "ar-stay ee-thray")]
        [TestCase("beast dough happy question", "east-bay ough-day appy-hay estion-quay")]
        public void CanTranslatePhrase(string phrase, string expectedResult)
        {
            Assert.AreEqual(expectedResult, _phraseTranslator.Translate(phrase));
        }
    }
}

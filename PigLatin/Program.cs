using System;

namespace PigLatin {
    class Program {
        static void Main(string[] args) {
            var translator = new PhraseTranslationService(new WordTranslationService());

            while (true) {
                Console.Write("Enter input: ");
                var input = Console.ReadLine()?.ToLower();

                Console.WriteLine(translator.Translate(input));
            }
        }
    }
}

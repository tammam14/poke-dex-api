namespace Pokedex.Models
{
    public class Translation
    {
        public Success Success { get; set; }
        public TranslationContents Contents { get; set; }
    }

    public class Success
    {
        public int Total { get; set; }
    }

    public class TranslationContents
    {
        public string Translated { get; set; }
        public string Text { get; set; }
        public string Translation { get; set; }
    }
}

namespace Thalus.Contracts
{
    public class TextDTO : IText
    {
        public TextDTO()
        {
        }

        public TextDTO(TextDTO dto)
        {
            Encoding = dto.Encoding;
            Locale = dto.Locale;
            Localized = dto.Localized;
            Invariant = dto.Invariant;
        }

        public string Encoding { get; set; }

        public string Locale { get; set; }

        public string Localized { get; set; }

        public string Invariant { get; set; }
    }
}



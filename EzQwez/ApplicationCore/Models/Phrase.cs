using System;

namespace ApplicationCore.Models
{
    public class Phrase
    {
        private string _english;
        private string _hungarian;
        public int Id { get; set; }

        public string English
        {
            get => _english;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("The value cannot be empty string");
                }
                _english = value.Trim();
            }
        }

        public string Hungarian
        {
            get => _hungarian;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("The value cannot be empty string");
                }
                _hungarian = value.Trim();
            }
        }
    }
}

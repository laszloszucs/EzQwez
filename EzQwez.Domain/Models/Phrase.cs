using System.ComponentModel;

namespace EzQwez.Domain.Models
{
    public class Phrase : IPhrase, INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string English { get; set; }
        public string Hungarian { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

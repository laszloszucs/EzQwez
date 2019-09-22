using EzQwez.Application.Repositories;
using EzQwez.Desktop;
using EzQwez.Domain.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;

namespace EzQwez.Phrases
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollectionEx<Phrase> Phrases { get; set; }

        public MainWindow(IPhraseRepository phraseRepository)
        {
            InitializeComponent();

            var data = phraseRepository.Get();

            //GetData() creates a collection of Customer data from a database
            Phrases = new ObservableCollectionEx<Phrase>(data);
            ((INotifyPropertyChanged)Phrases).PropertyChanged += (x, y) => ReactToChange(x, y);

            //Bind the DataGrid to the customer data
            AppDataGrid.DataContext = Phrases;
        }

        void ReactToChange(object x, object y)
        {
            // TODO EZ NEM A LEGJOBB. KELLENE VALAMI REACTIVE UI megoldás
            // https://reactiveui.net/docs/
            ;
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //Get the sender observable collection
            ObservableCollection<Phrase> obsSender = sender as ObservableCollection<Phrase>;
            ;
            //List<string> editedOrRemovedItems = new List<string>();
            //foreach (string newItem in e.NewItems)
            //{
            //    editedOrRemovedItems.Add(newItem);
            //}

            //foreach (string oldItem in e.OldItems)
            //{
            //    editedOrRemovedItems.Add(oldItem);
            //}

            //Get the action which raised the collection changed event
            NotifyCollectionChangedAction action = e.Action;
        }
    }
}

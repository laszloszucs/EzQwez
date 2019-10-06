using EzQwez.Application.Repositories;
using EzQwez.Application.Services;
using EzQwez.Desktop;
using EzQwez.Domain.Models;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace EzQwez.Phrases
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollectionEx<Phrase> Phrases { get; set; }

        public MainWindow(IUnitOfWork unitOfWork)
        {
            InitializeComponent();

            var data = unitOfWork.PhraseRepository.observablePhrases;
            ;
            AppDataGrid.ItemsSource = data;
            // FillDataGrid();


            ////GetData() creates a collection of Customer data from a database
            //Phrases = new ObservableCollectionEx<Phrase>(data);
            //((INotifyPropertyChanged)Phrases).PropertyChanged += (x, y) => ReactToChange(x, y);

            ////Bind the DataGrid to the customer data
            //AppDataGrid.DataContext = Phrases;
        }

        private void FillDataGrid()
        {
            // string ConString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            // string ConString = "Server=localhost;User Id=postgres;Password=o9gtBXIPvH8e8jMz7BTaowD8BskHqipjp3YcfkWzSSrc9AC5V7hYo26GMiTpSd0;Database=EzQwez";
            //string ConString = "Server=127.0.0.1;Database=EzQwez;User Id=postgres;Password=o9gtBXIPvH8e8jMz7BTaowD8BskHqipjp3YcfkWzSSrc9AC5V7hYo26GMiTpSd0;";

            string ConString = "Host=127.0.0.1;Database=EzQwez;Username=postgres;Password=o9gtBXIPvH8e8jMz7BTaowD8BskHqipjp3YcfkWzSSrc9AC5V7hYo26GMiTpSd0";

            string CmdString = string.Empty;
            


            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT English, Hungarian FROM Phrases";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Phrases");
                sda.Fill(dt);
                AppDataGrid.ItemsSource = dt.DefaultView;
            }
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

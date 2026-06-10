using Airlines_Kilunina.Classes;
using Airlines_Kilunina.Elements;
using System.Windows;
using System.Windows.Controls;

namespace Airlines_Kilunina.Pages
{
    public partial class Ticket : Page
    {
        private string _from;
        private string _to;

        public Ticket(string from, string to)
        {
            InitializeComponent();
            _from = from;
            _to = to;
            LoadFlights();
        }

        public Ticket() : this("", "") { }

        private void LoadFlights()
        {
            spItems.Children.Clear();

            bool hasFrom = !string.IsNullOrWhiteSpace(_from);
            bool hasTo = !string.IsNullOrWhiteSpace(_to);

            foreach (var ticket in MainWindow.mainWindow.ticketClasses)
            {
                bool matchFrom = !hasFrom || ticket.from == _from;
                bool matchTo = !hasTo || ticket.to == _to;

                if (matchFrom && matchTo)
                    spItems.Children.Add(new Item(ticket));
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.OpenPages(MainWindow.pages.main);
        }
    }
}

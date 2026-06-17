using Airlines_Kilunina.Classes;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows;

namespace Airlines_Kilunina
{
    public partial class MainWindow : Window
    {
        public enum pages { 
            main, 
            ticket 
        }

        public List<TicketClass> ticketClasses = new List<TicketClass>();
        public static MainWindow mainWindow;

        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            LoadTickets();
            frame.Navigate(new Pages.Main());
        }

        public void OpenPages(pages page)
        {
            switch (page)
            {
                case pages.main:
                    frame.Navigate(new Pages.Main());
                    break;
                case pages.ticket:
                    frame.Navigate(new Pages.Ticket());
                    break;
            }
        }

        public void LoadTickets()
        {
            ticketClasses.Clear();
            string connection = "server=localhost;port=3307;database=Airlines;uid=root;pwd=;";
            MySqlConnection mySqlConnection = new MySqlConnection(connection);
            mySqlConnection.Open();

            MySqlDataReader ticket_query = WorkingBD.WorkingBD.Query("SELECT * FROM Airlines.Tickets;", mySqlConnection);

            while (ticket_query.Read())
            {
                ticketClasses.Add(new TicketClass(
                    ticket_query.GetValue(3).ToString(),
                    ticket_query.GetValue(1).ToString(),
                    ticket_query.GetValue(2).ToString(),
                    ticket_query.GetValue(4).ToString(),
                    ticket_query.GetValue(5).ToString()
                ));
            }
            mySqlConnection.Close();
        }
    }
}

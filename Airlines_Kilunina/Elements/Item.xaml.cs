using Airlines_Kilunina.Classes;
using System.Windows.Controls;

namespace Airlines_Kilunina.Elements
{
    public partial class Item : UserControl
    {
        public Item(TicketClass ticket)
        {
            InitializeComponent();

            tbPrice.Text = ticket.price + " Р";
            tbCityFrom.Text = ticket.from;
            tbCityTo.Text = ticket.to;
            tbDeparture.Text = ticket.time_start;
            tbDuration.Text = "В пути: " + ticket.time_way;
        }
    }
}

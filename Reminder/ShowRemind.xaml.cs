using System;
using System.Text;
using System.Windows;


namespace Reminder
{
    /// <summary>
    /// Interaction logic for ShowRemind.xaml
    /// </summary>
    public partial class ShowRemind : Window
    {
        public ShowRemind(Remind remind)
        {
            InitializeComponent();
            remind_title.Text = remind.Title;
            remind_discription.Text = remind.Discription;
            remind_date.Text = remind.Date.ToLongDateString() + "  " + remind.Date.ToShortTimeString();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

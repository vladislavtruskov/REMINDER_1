using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Reminder
{
    /// <summary>
    /// Interaction logic for ShowActiveRemind.xaml
    /// </summary>
    public partial class ShowActiveRemind : Window
    {
        private RemindManager _reminder;
        private Remind _remind;
        public ShowActiveRemind(RemindManager reminder, Remind remind)
        {
            InitializeComponent();
            _reminder = reminder;
            _remind = remind;
            remind_title.Text = remind.Title;
            remind_discription.Text = remind.Discription;
            remind_date.Text = remind.Date.ToLongDateString() + "  " + remind.Date.ToShortTimeString();
            delayed_time.SelectedIndex = 0;
        }

        private void remind_expander_Collapsed(object sender, RoutedEventArgs e)
        {
            this.Height = 238;
        }

        private void remind_expander_Expanded(object sender, RoutedEventArgs e)
        {
            this.Height = 580;
        }

        private void btn_delay_Click(object sender, RoutedEventArgs e)
        {
            int index = delayed_time.SelectedIndex;
            DateTime t = _remind.Date;
            switch(index)
            {
                case 0: // 15 минут
                    _remind.Date = t.AddMinutes(15);
                    break;
                case 1: // 30 минут
                    _remind.Date = t.AddMinutes(30);
                    break;
                case 2: // 1 час
                    _remind.Date = t.AddHours(1);
                    break;
                case 3: // 1 день
                    _remind.Date = t.AddDays(1);
                    break;
                case 4: // задать вручную
                    new AddRemind(_remind, _reminder, true).ShowDialog();
                    this.Close();
                    return;
            }
            _reminder.AddCurrentRemind(_remind);
            this.Close();
        }

        private void btn_complete_Click(object sender, RoutedEventArgs e)
        {
            _reminder.CurrentReminds.Remove(_remind);
            _reminder.AddCompletedRemind(_remind);
            this.Close();
        }
    }
}

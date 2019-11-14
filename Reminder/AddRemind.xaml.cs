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
    /// Interaction logic for AddRemind.xaml
    /// </summary>
    public partial class AddRemind : Window
    {
        private RemindManager _reminder;
        private Remind _remind;
        private bool _delay_remind;
        public AddRemind(RemindManager reminder)
        {
            // constructor for add a new remind
            InitializeComponent();
            _reminder = reminder;
            this.Title = "Новое напоминание";
            remind_title.Focus();
            one_day.IsChecked = true;
            timetable_group.IsEnabled = false;
            // 
            for (int i = 0; i < 60; i++)
            {
                if (i < 10)
                    minute_value.Items.Add(String.Format("0{0}", i));
                else
                    minute_value.Items.Add(i.ToString());
            }
            hour_value.SelectedIndex = DateTime.Now.Hour;
            for (int i = 0; i < 24; i++)
            {
                if (i < 10)
                    hour_value.Items.Add(String.Format("0{0}", i));
                else
                    hour_value.Items.Add(i.ToString());
            }
            minute_value.SelectedIndex = DateTime.Now.Minute;
            date_picker.SelectedDate = DateTime.Now;
        }
        public AddRemind(Remind remind, RemindManager reminder, bool delay_remind = false)
        {
            // constructor for edit remind
            InitializeComponent();
            _reminder = reminder;
            _remind = remind;
            _delay_remind = delay_remind;
            this.Title = "Редактировать";
            btn_ok.Content = "Редактировать";
            if(_delay_remind == true)
            {
                btn_cancel.Content = "Завершить";
            }
            remind_title.Focus();
            one_day.IsChecked = true;
            timetable_group.IsEnabled = false;
            for (int i = 0; i < 60; i++)
            {
                if (i < 10)
                    minute_value.Items.Add(String.Format("0{0}", i));
                else
                    minute_value.Items.Add(i.ToString());
            }
            hour_value.SelectedIndex = DateTime.Now.Hour;
            for (int i = 0; i < 24; i++)
            {
                if (i < 10)
                    hour_value.Items.Add(String.Format("0{0}", i));
                else
                    hour_value.Items.Add(i.ToString());
            }
            minute_value.SelectedIndex = DateTime.Now.Minute;
            minute_value.Focus();
            date_picker.SelectedDate = DateTime.Now;
            remind_title.Text = remind.Title;
            remind_discription.Text = remind.Discription;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            if(_delay_remind == true)
            {
                _reminder.CurrentReminds.Remove(_remind);
                _reminder.AddCompletedRemind(_remind);
            }
            this.Close();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            if (remind_title.Text.Equals(String.Empty))
            {
                MessageBox.Show("Заголовок забыл ...", "Ну как, так-то?", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (date_picker.SelectedDate == null)
            {
                MessageBox.Show("Дату забыл ...", "Ну как, так-то?", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (hour_value.SelectedIndex == -1 || minute_value.SelectedIndex == -1)
            {
                MessageBox.Show("Время забыл ...", "Ну как, так-то?", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Remind tmp = new Remind();
            tmp.Title = remind_title.Text;
            tmp.Discription = remind_discription.Text;
            int hour = hour_value.SelectedIndex;
            int min = minute_value.SelectedIndex;
            int month = date_picker.SelectedDate.Value.Month;
            int day = date_picker.SelectedDate.Value.Day;
            int year = date_picker.SelectedDate.Value.Year;
            DateTime t = new DateTime(year, month, day, hour, min, 0);

            if (t < DateTime.Now)
            {
                MessageBox.Show("На вчера это не получится...", "Ну как, так-то?", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            tmp.Date = t;
            //_reminder.CurrentReminds.Remove(_remind);
            _reminder.AddCurrentRemind(tmp);
            this.Close();
        }
    }
}

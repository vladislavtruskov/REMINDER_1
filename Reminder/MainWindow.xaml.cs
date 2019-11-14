using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;

namespace Reminder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RemindManager reminder;
        public MainWindow()
        {
            InitializeComponent();
            reminder = new RemindManager();
            reminder.RemindsFinded += Reminder_RemindsFinded;
            try
            {
                reminder.LoadFiles();
                reminder.FindActiveRemind();
            }
            catch(MyExeption ex)
            {
                MessageBox.Show(ex.Message);
            }

            current_reminds_list.ItemsSource = reminder.CurrentReminds;
            current_reminds_list.DisplayMemberPath = "Title";
            past_reminds_list.ItemsSource = reminder.CompletedReminds;
            past_reminds_list.DisplayMemberPath = "Title";

            delete_remind.IsEnabled = false;
            edit_remind.IsEnabled = false;
            delete_completed_remind.IsEnabled = false;
            reestablish_remind.IsEnabled = false;
        }

        // show all active reminds
        private void Reminder_RemindsFinded()
        {
            if (reminder.ActiveRemind().Count > 0)
            {
                for (int i = 0; i < reminder.ActiveRemind().Count; i++)
                {
                    new ShowActiveRemind(reminder, reminder.ActiveRemind()[i]).ShowDialog(); ;
                }
            }
        }

        // added a new remind
        private void add_remind_Click(object sender, RoutedEventArgs e)
        {
            new AddRemind(reminder).ShowDialog();
        }

        private void current_reminds_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (current_reminds_list.SelectedIndex == -1)
            {
                delete_remind.IsEnabled = false;
                edit_remind.IsEnabled = false;
            }
            else
            {
                delete_remind.IsEnabled = true;
                edit_remind.IsEnabled = true;
                int index = current_reminds_list.SelectedIndex;
                reminds_dates.SelectedDate = reminder.CurrentReminds[index].Date;
            }
        }

        // show selected remind
        private void current_reminds_list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = current_reminds_list.SelectedIndex;
            if (index == -1)
                return;

            new ShowRemind(reminder.CurrentReminds[index]).ShowDialog();
        }

        // check for save files when application closing
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (reminder.IsChanged == true)
            {
                MessageBoxResult res = MessageBox.Show("А сохраниться?", "Уходя, гасите всех...", MessageBoxButton.YesNoCancel);
                switch (res)
                {
                    case MessageBoxResult.Yes:
                        reminder.SaveFiles();
                        break;
                    case MessageBoxResult.No:
                        return;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        // for test anything
        private void test_btn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        // delete current remind
        private void delete_remind_Click(object sender, RoutedEventArgs e)
        {
            int index = current_reminds_list.SelectedIndex;
            if (index == -1)
                return;
            MessageBoxResult res = MessageBox.Show("Do you want to delete this remind?", "Delete remind", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (res)
            {
                case MessageBoxResult.Yes:
                    reminder.DeleteCurrentRemind(index);
                    break;
                case MessageBoxResult.No:
                    return;
            }
        }

        // "save" item in menu
        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {
            reminder.SaveFiles();
        }

        // "exit" item in menu
        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // delete completed remind
        private void delete_completed_remind_Click(object sender, RoutedEventArgs e)
        {
            int index = past_reminds_list.SelectedIndex;
            if (index == -1)
                return;
            reminder.DeleteCompletedRemind(index);
        }

        private void past_reminds_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (past_reminds_list.SelectedIndex == -1)
            {
                delete_completed_remind.IsEnabled = false;
                reestablish_remind.IsEnabled = false;
                return;
            }
            delete_completed_remind.IsEnabled = true;
            reestablish_remind.IsEnabled = true;
        }

        private void edit_remind_Click(object sender, RoutedEventArgs e)
        {
            int index = current_reminds_list.SelectedIndex;
            if (index == -1)
                return;
            new AddRemind(reminder.CurrentReminds[index],reminder);
        }

        private void reestablish_remind_Click(object sender, RoutedEventArgs e)
        {
            int index = past_reminds_list.SelectedIndex;
            if (index == -1)
                return;
            new AddRemind(reminder.CompletedReminds[index],reminder).ShowDialog();
            reminder.CompletedReminds.RemoveAt(index);
        }
    }
}

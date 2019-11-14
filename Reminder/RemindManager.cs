using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Reminder
{
    public class MyExeption : ApplicationException
    {
        public MyExeption() { }
        public MyExeption(string message) : base(message) { Message = message; }
        public string Message { get; set; }
    }

    public class RemindManager
    {
        private bool _timer_installation;
        private List<int> _tempIndex; // Remind's collection witch will nedd to be removed

        // current reminds
        private ObservableCollection<Remind> _currentReminds;

        // completed reminds
        private ObservableCollection<Remind> _completedReminds;
        // active reminds
        private List<Remind> _activeReminds;

        public delegate void ActiveReminders();
        public event ActiveReminders RemindsFinded; // event witch informs when finded active remind

        private string _directoryPath; // folder path where are stored work files
        private string _curRemindsFile; // file for current reminds
        private string _completedRemindsFile; // file for completed reminds

        private DispatcherTimer _timer;

        public RemindManager()
        {
            _timer_installation = true;
            _timer = new DispatcherTimer();
            _timer.Tick += _timer_Tick;
            _tempIndex = new List<int>();
            _currentReminds = new ObservableCollection<Remind>();
            _completedReminds = new ObservableCollection<Remind>();
            _activeReminds = new List<Remind>();
            IsChanged = false;

            _directoryPath = @"D:\Reminder\";
            _curRemindsFile = @"D:\Reminder\currentReminds.bin";
            _completedRemindsFile = @"D:\Reminder\completedReminds.bin";
            InstallationTimer();
        }

        ~RemindManager()
        {
            _timer.Stop();
            GC.Collect();
        }
        // 
        private void _timer_Tick(object sender, EventArgs e)
        {
            if(_timer_installation == true)
            {
                _timer.Stop();
                _timer.Interval = new TimeSpan(0, 1, 0);
                _timer.Start();
                _timer_installation = false;
            }
            FindActiveRemind();
        }

        public bool IsChanged { get; set; }

        // current reminds
        public ObservableCollection<Remind> CurrentReminds
        {
            get
            {
                return _currentReminds;
            }
        }

        // completed reminds
        public ObservableCollection<Remind> CompletedReminds
        {
            get
            {
                return _completedReminds;
            }
        }

        // active reminds
        public List<Remind> ActiveRemind()
        {
            return _activeReminds;
        }

        // add current remind
        public void AddCurrentRemind(Remind remind)
        {
            _currentReminds.Add(remind);
            IsChanged = true;
        }

        // add completed remind
        public void AddCompletedRemind(Remind remind)
        {
            _completedReminds.Add(remind);
            IsChanged = true;
        }

        // save files with current and completed reminds
        public void SaveFiles()
        {

            DirectoryInfo dirInfo = new DirectoryInfo(_directoryPath);
            if (dirInfo.Exists == false)
            {
                dirInfo.Create();
            }

            using (FileStream stream = File.Open(_curRemindsFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, _currentReminds);
            }

            using (FileStream stream = File.Open(_completedRemindsFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, _completedReminds);
            }
            IsChanged = false;
        }

        // Load files with current and completed reminds
        public void LoadFiles()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(_directoryPath);
            if (dirInfo.Exists == false)
            {
                throw new MyExeption("Directory not found!");
            }
            FileInfo f = new FileInfo(_curRemindsFile);
            if (f.Exists == false)
            {
                throw new MyExeption("File of current reminds not found!");
            }

            using (FileStream stream = File.Open(_curRemindsFile, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                _currentReminds = (ObservableCollection<Remind>)bf.Deserialize(stream);
            }

            f = new FileInfo(_completedRemindsFile);
            if (f.Exists == false)
            {
                throw new MyExeption("File of completed reminds not found!");
            }

            using (FileStream stream = File.Open(_completedRemindsFile, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                _completedReminds = (ObservableCollection<Remind>)bf.Deserialize(stream);
            }
        }

        public void RemindCompleted(int index)
        {
            if (_activeReminds.Count == 0)
                throw new IndexOutOfRangeException();

            Remind r = _activeReminds[index];
            _activeReminds.RemoveAt(index);
            _completedReminds.Add(r);
            
            IsChanged = true;
        }

        // delete completed reminds
        private void DeleteByTempIndex()
        {
            if (_tempIndex.Count > 0)
            {
                for (int i = 0; i < _tempIndex.Count; i++)
                {
                    DeleteCurrentRemind(i);
                }
                _tempIndex.Clear();
            }
        }

        // installation timer's settings
        private void InstallationTimer()
        {
            int interval = 60 - DateTime.Now.Second;
            _timer.Interval = new TimeSpan(0,0,interval);
            _timer.Start();
        }

        // find active remind
        public void FindActiveRemind()
        {
            DateTime now_date = DateTime.Now;

            for (int i = 0; i < _currentReminds.Count; i++)
            {
                DateTime item = _currentReminds[i].Date;
                if (item.Year <= now_date.Year)
                {
                    if (item.Month <= now_date.Month)
                    {
                        if (item.Day <= now_date.Day)
                        {
                            if (item.Hour <= now_date.Hour)
                            {
                                if (item.Minute <= now_date.Minute)
                                {
                                    Remind r = _currentReminds[i];
                                    _activeReminds.Add(r);
                                    _tempIndex.Add(i);
                                }
                            }
                        }
                    }
                }
            }
            DeleteByTempIndex();
            if (_activeReminds.Count > 0)
            {
                if (RemindsFinded != null)
                    RemindsFinded();
            }
        }

        public void DeleteCurrentRemind(int index)
        {
            _currentReminds.RemoveAt(index);
            IsChanged = true;
        }

        public void DeleteCompletedRemind(int index)
        {
            _completedReminds.RemoveAt(index);
            IsChanged = true;
        }

    }
}

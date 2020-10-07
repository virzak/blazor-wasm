using Microsoft.Toolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

namespace MvvmPattern
{
    public class MainModel : INotifyPropertyChanged
    {
        public MainModel()
        {
            DecrementCommand = new RelayCommand<bool>(DecrementExecute);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DecrementCommand;
        private int _age = 30;

        private void DecrementExecute(bool decrement)
        {
            if (decrement && Age > 13)
            {
                Age -= 1;
            }
            if (!decrement && Age < 120)
            {
                Age += 1;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value != _age)
                {
                    _age = value;
                    PropertyChanged?.Invoke(value, new PropertyChangedEventArgs(nameof(Age)));
                }
            }
        }

        public int MaximumHeartRate
        {
            get
            {
                return 220 - _age;
            }
        }

        public int TargetHeartRate
        {
            get
            {
                return (int)(0.85 * MaximumHeartRate);
            }
        }
    }
}

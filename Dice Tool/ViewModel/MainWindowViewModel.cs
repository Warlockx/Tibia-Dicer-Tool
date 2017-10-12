using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Dice_Tool.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        private double currentPayout = 0;
        private double currentBet = 0;
        private int betMultiplier = 180;


        public double CurrentPayout
        {
            get
            {
                return currentPayout;
            }

            set
            {
                currentPayout = value;
                OnPropertyChanged("CurrentPayout");
            }
        }      

        public double CurrentBet
        {
            get
            {
                return currentBet;
            }

            set
            {
                currentBet = value;
                OnPropertyChanged("CurrentBet");
            }
        }

        public ICommand CalculatePayout { get; set; }
        public ICommand CopyPayout { get; set; }
        public ICommand Clear { get; set; }

        public int BetMultiplier
        {
            get
            {
                return betMultiplier;
            }

            set
            {
                betMultiplier = value;
                OnPropertyChanged("BetMultiplier");
            }
        }

        public MainWindowViewModel()
        {
            CalculatePayout = new RelayCommand<object>(_calculatePayout, _canCalculatePayout);
            CopyPayout = new RelayCommand<object>(_copyPayout, _canCopyPayout);
            Clear = new RelayCommand<object>(_clear, _canClear);
        }

        private bool _canClear(object arg)
        {
            return CurrentPayout > 0 && CurrentBet > 0;
        }

        private void _clear(object obj)
        {
            CurrentBet = 0;
            CurrentPayout = 0;
        }

        private bool _canCopyPayout(object arg)
        {
            return currentPayout > 0;
        }

        private void _copyPayout(object obj)
        {
            CurrentBet = CurrentPayout;
            CurrentPayout = 0;
        }

        private bool _canCalculatePayout(object arg)
        {
            return CurrentBet > 0;                
        }

        private void _calculatePayout(object obj)
        {           
            CurrentPayout = CurrentBet * ((double)betMultiplier / 100);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }       
    }
}

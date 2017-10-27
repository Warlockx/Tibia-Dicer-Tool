using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Dice_Tool.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        private double _currentPayout = 0;
        private double _currentBet = 0;
        private int _betMultiplier = 180;
        private string _gameName = "H/L";

        public double CurrentPayout
        {
            get
            {
                return _currentPayout;
            }

            set
            {
                _currentPayout = value;
                OnPropertyChanged("CurrentPayout");              
            }
        }      

        public double CurrentBet
        {
            get
            {
                return _currentBet;
            }

            set
            {
                _currentBet = value;
                OnPropertyChanged("CurrentBet");
                _calculatePayout(null);
            }
        }

        public int BetMultiplier
        {
            get
            {
                return _betMultiplier;
            }

            set
            {
                _betMultiplier = value;
                OnPropertyChanged("BetMultiplier");
                _calculatePayout(null);
            }
        }

        public ICommand CalculatePayout { get; set; }
        public ICommand CopyPayout { get; set; }
        public ICommand Clear { get; set; }
        public ICommand ChangeGame { get; set; }

        public string GameName
        {
            get
            {
                return _gameName;
            }

            set
            {
                _gameName = value;
                OnPropertyChanged("GameName");
            }
        }

        public MainWindowViewModel()
        {
            CalculatePayout = new RelayCommand<object>(_calculatePayout, _canCalculatePayout);
            CopyPayout = new RelayCommand<object>(_copyPayout, _canCopyPayout);
            Clear = new RelayCommand<object>(_clear, _canClear);
            ChangeGame = new RelayCommand<object>(_changeGame, _canChangeGame);
        }

        private void _changeGame(object obj)
        {
            if (GameName == "H/L")
            {
                GameName = "Number";
                BetMultiplier = 500;
            }
            else
            {
                GameName = "H/L";
                BetMultiplier = 180;
            }
        }

        private bool _canChangeGame(object arg)
        {
            return true;
        }

        private bool _canClear(object arg)
        {
            return CurrentPayout > 0 || CurrentBet > 0;
        }

        private void _clear(object obj)
        {
            CurrentBet = 0;
            CurrentPayout = 0;
        }

        private bool _canCopyPayout(object arg)
        {
            return CurrentPayout > 0;
        }

        private void _copyPayout(object obj)
        { 
                    
            CurrentBet = CurrentPayout;           
        }

        private bool _canCalculatePayout(object arg)
        {
            return CurrentBet > 0 && BetMultiplier >= 1;                
        }

        private void _calculatePayout(object obj)
        {        
            CurrentPayout = Math.Round(CurrentBet * ((double)BetMultiplier / 100), 2);                    
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }       
    }
}

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Infrastructure.Command;

namespace WPF.ViewModel
{
    internal class MainWindowViewModel : Base.ViewModelBase
    {
        #region Properties
        #region string Title : Заголовок акна
        private string _Title;
        /// <summary>Заголовок акна</summary>
        public string Title
        {
            get { return _Title; }
            set { Set(ref _Title, value); }
        }
        #endregion

        #region int Num1 : число 1
        private int _Num1;
        /// <summary>число 1</summary>
        public int Num1
        {
            get { return _Num1; }
            set { Set(ref _Num1, value); }
        }
        #endregion
        #region int Num2 : число 2
        private int _Num2;
        /// <summary>число 2</summary>
        public int Num2
        {
            get { return _Num2; }
            set { Set(ref _Num2, value); }
        }
        #endregion
        #region int Result : результат
        private int _Result;
        /// <summary>результат</summary>
        public int Result
        {
            get { return _Result; }
            set { Set(ref _Result, value); }
        }
        #endregion


        #region double Progress : прогресс
        private double _Progress;
        /// <summary>прогресс</summary>
        public double Progress
        {
            get { return _Progress; }
            set { if (Set(ref _Progress, value)) if (_Progress >= 1.0) Progress = 0.0; }
        }
        #endregion

        #endregion

        #region Commands
        #region GetSumCommand : вычислить сумму
        /// <summary>вычислить сумму</summary>
        public ICommand GetSumCommand { get; }
        private bool CanGetSumCommandExecute(object p) => true;
        private async void OnGetSumCommandExecuted(object p)
        {
            Result = await Task.Run(() => App.Core.Sum(Num1, Num2, d => Progress = d)).ConfigureAwait(false);
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Properties
            Title = "WPF";
            #endregion

            #region Commands
            GetSumCommand = new LambdaCommand(OnGetSumCommandExecuted, CanGetSumCommandExecute);
            #endregion
        }
    }
}

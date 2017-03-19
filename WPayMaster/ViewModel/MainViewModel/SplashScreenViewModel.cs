using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using PropertyChanged;
using Shared;

namespace ViewModel.MainViewModel
{
    [ImplementPropertyChanged]
    public class SplashScreenViewModel
    {
        private static event Action OnStartUp;
        public Visibility FirstVisibility { get; set; }
        public Visibility SecondVisibility { get; set; }
        public Visibility ThridVisibility { get; set; }
        public Brush BackroundBrushColor { get; set; }

        private Color[] Colors = new Color[]
        {
            Color.FromRgb(33, 150, 243), Color.FromRgb(29, 233, 182), Color.FromRgb(233, 30, 99),
            Color.FromRgb(255, 152, 0), Color.FromRgb(255, 87, 34),Color.FromRgb(96, 125, 139),
            Color.FromRgb(213, 0, 0), Color.FromRgb(103, 58, 183)
        };

        public SplashScreenViewModel()
        {
            //FirstVisibility = Visibility.Hidden;
            //SecondVisibility = Visibility.Hidden;
            //ThridVisibility = Visibility.Hidden;

            FirstVisibility = Visibility.Visible;
            SecondVisibility = Visibility.Visible;
            ThridVisibility = Visibility.Visible;

            ChangeColor();

            //OnStartUp += OnOnStartUp;
        }

        private void OnOnStartUp()
        {
            for (int i = 0; i < 16; i++)
            {

                ChangeColor();

                if (i % 5 == 0 && i != 0)
                {
                    if (FirstVisibility == Visibility.Hidden)
                        FirstVisibility = Visibility.Visible;
                    else
                    {
                        if (SecondVisibility == Visibility.Hidden)
                            SecondVisibility = Visibility.Visible;
                        else
                        {
                            if (ThridVisibility == Visibility.Hidden)
                                ThridVisibility = Visibility.Visible;
                        }
                    }
                }

                Thread.Sleep(400);
            }
        }

        private void ChangeColor()
        {
            Random r = new Random();

            BackroundBrushColor = new SolidColorBrush(Colors[r.Next(1, 9)]);

            LoginViewModel.ThemeBrushColor = BackroundBrushColor;
        }

        public static void DoOnStartUp()
        {
            OnStartUp?.Invoke();
        }
    }
}
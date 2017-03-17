using System;
using System.Windows.Input;
using DataBaseService.Interface;
using PropertyChanged;
using Shared;
using Shared.Enum;
using Shared.Interface;

namespace ViewModel.MainViewModel
{
    [ImplementPropertyChanged]
    public class MakeOrderViewModel
    {
        public Func<object, TypeView, IView> CreateViewAction { get; set; }

        #region Command
        public ICommand OpenColdDrinkListViewCommand { get; set; }
        public ICommand OpenDessertListViewCommand { get; set; }
        public ICommand OpenFishListViewCommand { get; set; }
        public ICommand OpenGarnishListViewCommand { get; set; }
        public ICommand OpenHotDrinkListViewCommand { get; set; }
        public ICommand OpenJuiceListViewCommand { get; set; }
        public ICommand OpenMealListViewCommand { get; set; }
        public ICommand OpenMeatDishListViewCommand { get; set; }
        public ICommand OpenPastaListViewCommand { get; set; }
        public ICommand OpenPizzaListViewCommand { get; set; }
        public ICommand OpenSaladListViewCommand { get; set; }
        public ICommand OpenSauceListViewCommand { get; set; }
        public ICommand OpenSnackListViewCommand { get; set; }
        public ICommand OpenSoupListViewCommand { get; set; }
        #endregion

        public MakeOrderViewModel(Func<object, TypeView, IView> createViewAction)
        {
            CreateViewAction = createViewAction;

            OpenColdDrinkListViewCommand = new CommandHandler(arg => OpenColdDrinkListView());
            OpenDessertListViewCommand = new CommandHandler(arg => OpenDessertListView());
            OpenFishListViewCommand = new CommandHandler(arg => OpenFishListView());
            OpenGarnishListViewCommand = new CommandHandler(arg => OpenGarnishListView());
            OpenHotDrinkListViewCommand = new CommandHandler(arg => OpenHotDrinkListView());
            OpenJuiceListViewCommand = new CommandHandler(arg => OpenJuiceListView());
            OpenMealListViewCommand = new CommandHandler(arg => OpenMealListView());
            OpenMeatDishListViewCommand = new CommandHandler(arg => OpenMeatDishListView());
            OpenPastaListViewCommand = new CommandHandler(arg => OpenPastaListView());
            OpenPizzaListViewCommand = new CommandHandler(arg => OpenPizzaListView());
            OpenSaladListViewCommand = new CommandHandler(arg => OpenSaladListView());
            OpenSauceListViewCommand = new CommandHandler(arg => OpenSauceListView());
            OpenSnackListViewCommand = new CommandHandler(arg => OpenSnackListView());
            OpenSoupListViewCommand = new CommandHandler(arg => OpenSoupListView());
        }

        private void OpenSnackListView()
        {
            CreateViewAction.Invoke(null, TypeView.SnackListView);
        }

        private void OpenSauceListView()
        {
            CreateViewAction.Invoke(null, TypeView.SauceListView);
        }

        private void OpenSaladListView()
        {
            CreateViewAction.Invoke(null, TypeView.SaladListView);
        }

        private void OpenPizzaListView()
        {
            CreateViewAction.Invoke(null, TypeView.PizzaListView);
        }

        private void OpenPastaListView()
        {
            CreateViewAction.Invoke(null, TypeView.PastaListView);
        }

        private void OpenMeatDishListView()
        {
            CreateViewAction.Invoke(null, TypeView.MeatDishListView);
        }

        private void OpenMealListView()
        {
            CreateViewAction.Invoke(null, TypeView.MealListView);
        }

        private void OpenJuiceListView()
        {
            CreateViewAction.Invoke(null, TypeView.JuiceListView);
        }

        private void OpenHotDrinkListView()
        {
            CreateViewAction.Invoke(null, TypeView.HotDrinkListView);
        }

        private void OpenGarnishListView()
        {
            CreateViewAction.Invoke(null, TypeView.GarnishListView);
        }

        private void OpenFishListView()
        {
            CreateViewAction.Invoke(null, TypeView.FishListView);
        }

        private void OpenDessertListView()
        {
            CreateViewAction.Invoke(null, TypeView.DessertListView);
        }

        private void OpenColdDrinkListView()
        {
            CreateViewAction.Invoke(null, TypeView.ColdDrinkListView);
        }

        private void OpenSoupListView()
        {
            CreateViewAction.Invoke(null, TypeView.SoupListView);
        }
    }
}
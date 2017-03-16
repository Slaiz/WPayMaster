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

        public ICommand OpenSoupViewCommand { get; set; }

        public MakeOrderViewModel(Func<object, TypeView, IView> createViewAction)
        {
            CreateViewAction = createViewAction;

            OpenSoupViewCommand = new CommandHandler(arg => OpenSoupView());
        }

        private void OpenSoupView()
        {
            CreateViewAction.Invoke(null, TypeView.SoupView);
        }
    }
}
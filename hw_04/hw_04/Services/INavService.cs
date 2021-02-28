using System;
using System.ComponentModel;
using System.Threading.Tasks;
using hw_04.ViewModels;

namespace hw_04.Services
{
    public interface INavService
    {
        bool CanGoBack { get; }

        Task GoBack();

        Task NavigateTo<TVM>()
            where TVM : BaseViewModel;

        Task NavigateTo<TVM, TParameter>(TParameter parameter)
            where TVM : BaseViewModel;

        void RemoveLastView();

        void ClearBackStack();

        void NavigateToUri(Uri uri);

        event PropertyChangedEventHandler CanGoBackChanged;
    }
}

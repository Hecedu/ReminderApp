using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using hw_04.Services;
using hw_04.ViewModels;

namespace hw_04.Tests
{
    class MockNavService : INavService
    {
        public bool CanGoBack => throw new NotImplementedException();

        public event PropertyChangedEventHandler CanGoBackChanged;

        //test variables
        public bool triedToGoBack { get; set; }
        public bool triedToChangePage { get; set; }

        public void ClearBackStack()
        {
            throw new NotImplementedException();
        }

        public Task GoBack()
        {
            triedToGoBack = true;
            return Task.FromResult(0);
        }

        public Task NavigateTo<TVM>() where TVM : BaseViewModel
        {
            triedToChangePage = true;
            return Task.FromResult(0);
        }

        public Task NavigateTo<TVM, TParameter>(TParameter parameter) where TVM : BaseViewModel
        {
            throw new NotImplementedException();
        }

        public void NavigateToUri(Uri uri)
        {
            throw new NotImplementedException();
        }

        public void RemoveLastView()
        {
            throw new NotImplementedException();
        }
    }
}

using Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Sample
{
    public class BaseContentPage : ContentPage
    {

        public BaseViewModel ViewModel;



        public BaseContentPage(BaseViewModel viewModel = null)
        {
            if (viewModel != null)
            {
                ViewModel = viewModel;
                BindingContext = ViewModel;
            }
        }

    }
}

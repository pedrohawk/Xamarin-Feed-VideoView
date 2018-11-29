using LibVLCSharp.Shared;
using Sample.Models;
using Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.Pages
{
    public partial class testevideopage : ContentPage
    {
        MainViewModel _vm;

        public testevideopage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        

        private void FeedListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            if (e.Item == null)
            {
                return;
            }
        }
    }
}
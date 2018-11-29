using LibVLCSharp.Shared;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Sample.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Feed> MainFeed { get; set; }

        public MainViewModel()
        {
            MainFeed = new ObservableCollection<Feed>
            {
                new Feed
                {
                    Title = "Teste",
                    Media = new Models.Media
                    {
                        Filename = "",
                        Type = "video"
                    }
                },
                new Feed
                {
                    Title = "Teste 2",
                    Media = new Models.Media
                    {
                        Filename = "",
                        Type = "video"
                    }
                },
                new Feed
                {
                    Title = "Teste 3",
                    Media = new Models.Media
                    {
                        Filename = "",
                        Type = "video"
                    }
                },
                new Feed
                {
                    Title = "Teste 4",
                    Media = new Models.Media
                    {
                        Filename = "",
                        Type = "video"
                    }
                },
                new Feed
                {
                    Title = "Teste 5",
                    Media = new Models.Media
                    {
                        Filename = "",
                        Type = "video"
                    }
                },
                new Feed
                {
                    Title = "Teste 6",
                    Media = new Models.Media
                    {
                        Filename = "",
                        Type = "video"
                    }
                }
            };
        }

    }
}

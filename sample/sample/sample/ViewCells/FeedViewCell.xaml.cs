using LibVLCSharp.Shared;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.EventArguments;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedViewCell : ViewCell
    {
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        private Feed CurrentFeed { get; set; }

        LibVLC _libVLC;

        private MediaPlayer _mediaPlayer;
        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            private set => SetProperty(ref _mediaPlayer, value);
        }

        private bool MediaIsLoaded { get; set; }
        private bool StartASAP { get; set; }

        public long MediaTotalTime
        {
            get; set;
        }

        private int _timeleft;
        public int Timeleft
        {
            get { return _timeleft; }
            set { SetProperty(ref _timeleft, value); }
        }

        private bool _showTimeLeft;
        public bool ShowTimeleft
        {
            get { return _showTimeLeft; }
            set { SetProperty(ref _showTimeLeft, value); }
        }

        private int _autoStop;
        public int AutoStop
        {
            get
            {
                return _autoStop;
            }
            set
            {
                if (value != _autoStop)
                {
                    //is visible
                    if (value == 1)
                    {

                    }
                    //is not visible
                    else if (value == 0)
                    {
                        if (MediaPlayer != null && MediaPlayer.CanPause)
                        {
                            MediaPlayer.Pause();
                        }
                    }
                }
            }
        }

        public FeedViewCell()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext == null)
            {
                BindingContext = this;
            }

            videoView.MediaPlayerChanged += VideoView_MediaPlayerChanged;
            videoView.Loaded += VideoView_Loaded;
            videoView.MediaPlayer = MediaPlayer;

            if (MediaPlayer != null && MediaPlayer.State == VLCState.Paused)
            {
                MediaPlayer.Play();
                Play.IsVisible = false;
                Loading.IsVisible = false;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BindingContext = null;

            videoView.MediaPlayerChanged -= VideoView_MediaPlayerChanged;
            videoView.Loaded -= VideoView_Loaded;

            if (MediaPlayer != null && MediaPlayer.IsPlaying)
            {
                MediaPlayer.Pause();
                Play.IsVisible = false;
                Loading.IsVisible = false;
            }

        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null && BindingContext is Feed item)
            {
                if (item.Media == null && string.IsNullOrEmpty(item.Media.Type))
                {
                    return;
                }
                
                CurrentFeed = item;

                switch (item.Media.Type)
                {
                    case "video":   
                        Core.Initialize();

                        _libVLC = new LibVLC();

                        MediaPlayer = new MediaPlayer(_libVLC)
                        {
                            Media = new LibVLCSharp.Shared.Media(_libVLC,
                            "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4",
                            LibVLCSharp.Shared.Media.FromType.FromLocation)
                        };

                        //MediaPlayer.Media.DurationChanged += Media_DurationChanged;
                        //MediaPlayer.TimeChanged += MediaPlayer_TimeChanged;
                        //MediaPlayer.Buffering += MediaPlayer_Buffering;
                        //MediaPlayer.EncounteredError += MediaPlayer_EncounteredError;

                        TapGestureRecognizer tapPlay = new TapGestureRecognizer();
                        tapPlay.Tapped += OnPlayClicked;
                        Play.GestureRecognizers.Add(tapPlay);
                        
                        TapGestureRecognizer tapVideoPlayer = new TapGestureRecognizer();
                        tapVideoPlayer.Tapped += TapVideoPlayer_TappedAsync;
                        videoView.GestureRecognizers.Add(tapVideoPlayer);

                        break;
                    case "image":
                        break;
                    default:
#if DEBUG
                        Debug.WriteLine("No Type!!");
#endif
                        break;
                }
            }
        }

        private void MediaPlayer_EncounteredError(object sender, EventArgs e)
        {
            Debug.WriteLine("MEDIA PLAYER ERROR");
        }

        private void Media_DurationChanged(object sender, MediaDurationChangedEventArgs e)
        {
            Debug.WriteLine("### MEDIA PLAYER DURATION CHANGED: " + e.Duration);
            MediaTotalTime = e.Duration;
            ((Feed)BindingContext).Timeleft = (int)(MediaTotalTime / 1000);
            ((Feed)BindingContext).ShowTimeleft = true;
        }

        private void MediaPlayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            Debug.WriteLine("### MEDIA PLAYER TIME CHANGED: " + e.Time);
            Timeleft = (int)((MediaTotalTime - e.Time) / 1000);
            ((Feed)BindingContext).Timeleft = (int)((MediaTotalTime - e.Time) / 1000);
        }

        private void VideoView_Loaded(object sender, System.EventArgs e)
        {
            MediaIsLoaded = true;
            if (StartASAP)
            {
                MediaPlayer.Play();
                Play.IsVisible = false;
                Loading.IsVisible = false;
            }
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(MediaPlayer)))
                Trace.WriteLine("MediaPlayer change raised from ViewModel.Propertychanged");
        }

        private void VideoView_MediaPlayerChanged(object sender, MediaPlayerChangedEventArgs e)
        {
            Trace.WriteLine("VideoView_MediaPlayerChanged");

        }
        private void TapVideoPlayer_TappedAsync(object sender, EventArgs e)
        {
            switch (MediaPlayer.State)
            {
                case VLCState.Playing:
                    MediaPlayer.Pause();
                    Play.IsVisible = true;
                    break;
                case VLCState.Stopped:
                    MediaPlayer.Play();
                    Play.IsVisible = false;
                    break;
                case VLCState.Paused:
                    MediaPlayer.Play();
                    Play.IsVisible = false;
                    break;
                default:
                    break;
            }
        }
        

        private void OnPauseClicked(object sender, EventArgs e)
        {
            Play.IsVisible = true;
        }

        private void OnStopClicked(object sender, EventArgs e)
        {
            Play.IsVisible = true;
        }

        private void OnPlayClicked(object sender, EventArgs e)
        {
             if (MediaIsLoaded)
            {
                MediaPlayer.Play();
            }
            else
            {
                Loading.IsVisible = true;
                StartASAP = true;
            }

            Play.IsVisible = false;
        }

        private void MediaPlayer_Buffering(object sender, MediaPlayerBufferingEventArgs e)
        {
            Debug.WriteLine(">>> Video Buffering: " + e.Cache);
        }
        
    }
}
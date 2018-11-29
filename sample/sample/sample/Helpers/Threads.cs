using Microsoft.AppCenter.Crashes;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sample.Helpers
{
    public static class Threads
    {
        #region Methods

        public static Task RunAndContinuationInContext(Action action, Action<Task> continuationAction)
        {
            return Task.Run(() =>
            {
                action();
            })
                .ContinueWith((t) =>
                {
                    if (t.Exception != null)
                    {
                        Debug.WriteLine(t.Exception);
                    }
                    else
                    {
                        continuationAction(t);
                    }
                },
                    CancellationToken.None,
                    TaskContinuationOptions.AttachedToParent,
                    TaskScheduler.FromCurrentSynchronizationContext());
        }
        public static Task RunInContext(Action action)
        {
            return Task.Run(() =>
            {
                action();
            });
        }

        //public static void RunAndContinuationInContext(Func<Task> p1, Action<Task<List<RankListDTO>>> p2)
        //{
        //    throw new NotImplementedException();
        //}

        public static Task RunAndContinuationInContext(Func<Task> action, Action<Task> continuationAction)
        {
            return Task.Run(() =>
            {
                return action();
            })
                .ContinueWith((t) =>
                {
                    if (t.Exception != null)
                    {
                        Debug.WriteLine(t.Exception);
                    }
                    else
                    {
                        try
                        {
                            continuationAction(t);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                            Crashes.TrackError(ex);
                        }
                    }
                },
                    CancellationToken.None,
                    TaskContinuationOptions.AttachedToParent,
                    TaskScheduler.FromCurrentSynchronizationContext());
        }
        public static Task RunAndContinuationInContext<TResult>(Func<Task<TResult>> action, Action<Task<TResult>> continuationAction)
        {
            return Task.Run(async () =>
            {
                return await action();
            })
                .ContinueWith((t) =>
                {
                    if (t.Exception != null)
                    {
                        Debug.WriteLine(t.Exception);
                    }
                    else
                    {
                        try
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                continuationAction(t);
                            });
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                            Crashes.TrackError(ex);
                        }
                    }
                },
                    CancellationToken.None,
                    TaskContinuationOptions.AttachedToParent,
                    TaskScheduler.FromCurrentSynchronizationContext());
        }

        //public static void Forget(this Task task)
        //{
        //    task.ContinueWith(t =>
        //    {
        //        CommonData.Instance.ExceptionService.DisplayException(t.Exception);
        //    }
        //    , TaskContinuationOptions.OnlyOnFaulted);
        //}

        public static Task RunAsyncSafe(Action action, Action continuation = null)
        {
            return Task.Run(() =>
            {
                action();
            })
            .ContinueWith((t) =>
            {
                continuation?.Invoke();

                if (t.Exception != null)
                {
                    Debug.WriteLine(t.Exception);
                }
            },
                CancellationToken.None,
                TaskContinuationOptions.AttachedToParent,
                TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion
    }

}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Helpers
{
    /// <summary>
    /// Source:
    ///     https://github.com/jamesmontemagno/FrenchPressTimer/blob/master/SimpleTimerPortable/Timer.cs
    /// </summary>
    public delegate void TimerCallback(object state);

    public sealed class Timer : CancellationTokenSource, IDisposable
    {
        #region Public Const

        public const int RUN_ONCE = 0;

        #endregion

        public Timer(TimerCallback callback, int period, int dueTime = 0, object state = null)
        {
            Task.Delay(dueTime, Token).ContinueWith(async (t, s) =>
            {
                var tuple = (Tuple<TimerCallback, object>)s;

                do
                {
                    if (IsCancellationRequested)
                    {
                        break;
                    }

#pragma warning disable CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
                    Task.Run(() => tuple.Item1(tuple.Item2));
#pragma warning restore CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
                    await Task.Delay(period);
                } while (true && period != RUN_ONCE);

            }, Tuple.Create(callback, state), CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnRanToCompletion,
                TaskScheduler.Default);
        }

        public new void Dispose() { base.Cancel(); }
    }
}

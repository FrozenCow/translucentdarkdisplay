using System;
using System.Collections.Generic;
using System.Timers;

namespace Growl.Displays.Wpf
{
    /// <summary>
    /// Provides the ability to define multiple timeout-actions, which will be invoked after the specified timeout-duration.
    /// </summary>
    public class MultiTimeout : IDisposable
    {
        private struct Timeout
        {
            public DateTime ElapseTime;
            public Action ElapseAction;
            public object Identifier;
        }

        private object _locker = new object();
        private readonly LinkedList<Timeout> _timeouts = new LinkedList<Timeout>();
        private readonly Timer _timer;

        public MultiTimeout()
        {
            _timer = new Timer();
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            var invokingActions = new List<Action>();
            lock (_locker)
            {
                _timer.Stop();
                var now = DateTime.Now;
                while (_timeouts.First != null && _timeouts.First.Value.ElapseTime <= now)
                {
                    Timeout timeout = _timeouts.First.Value;
                    invokingActions.Add(timeout.ElapseAction);
                    _timeouts.RemoveFirst();
                }
            }
            foreach (var action in invokingActions)
            {
                action();
            }

            ResetTimer();
        }

        public void AddTimeout(TimeSpan dueTime, Action action, object identifier)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            if (identifier == null)
                throw new ArgumentNullException("identifier");
            AddTimeout(new Timeout
                           {
                               ElapseTime = DateTime.Now.Add(dueTime), ElapseAction = action, Identifier = identifier
                           });
        }

        private void AddTimeout(Timeout timeout)
        {
            LinkedListNode<Timeout> currentNode;
            lock (_locker)
            {
                for (currentNode = _timeouts.First; currentNode != null; currentNode = currentNode.Next)
                {
                    if (timeout.ElapseTime > currentNode.Value.ElapseTime)
                        continue;
                    _timeouts.AddBefore(currentNode, timeout);
                    break;
                }
                if (currentNode == null)
                    _timeouts.AddLast(timeout);
                ResetTimer();
            }
        }

        public void RemoveTimeout(object identifier)
        {
            if (identifier == null)
                throw new ArgumentNullException("identifier");
            lock (_timeouts)
            {
                LinkedListNode<Timeout> currentNode;
                for (currentNode = _timeouts.First; currentNode != null; currentNode = currentNode.Next)
                {
                    if (currentNode.Value.Identifier != identifier)
                        continue;
                    _timeouts.Remove(currentNode);
                    break;
                }
            }
        }

        private void ResetTimer()
        {
            lock (_locker)
            {
                _timer.Stop();
                if (_timeouts.First == null)
                    return;
                _timer.Interval = Math.Max(1, (_timeouts.First.Value.ElapseTime - DateTime.Now).TotalSeconds * 1000);
                _timer.Start();
            }
        }

        public void Dispose()
        {
            lock (_locker)
            {
                _timeouts.Clear();
                _timer.Stop();
                _timer.Dispose();
            }
        }
    }
}
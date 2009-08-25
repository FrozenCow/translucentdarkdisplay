using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Growl.Displays.TranslucentDark
{
    /// <summary>
    /// Emulates a given ObservableCollection in reverse order.
    /// </summary>
    public class ReversedObservableCollection<T> : ObservableCollection<T>
    {
        private ObservableCollection<T> _parent;

        public ReversedObservableCollection(ObservableCollection<T> parent)
        {
            _parent = parent;
            _parent.CollectionChanged += ParentCollectionChanged;
            for (int i = parent.Count - 1; i >= 0; i--)
            {
                Add(parent[i]);
            }
        }

        private void ParentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    int addindex = e.NewStartingIndex;
                    foreach (T item in e.NewItems)
                        Insert(Count - addindex, item);
                    break;
                case NotifyCollectionChangedAction.Move:
                    MoveItem(Count - e.OldStartingIndex, Count - e.NewStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (T item in e.OldItems)
                        Remove(item);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    throw new NotSupportedException();
                case NotifyCollectionChangedAction.Reset:
                    Clear();
                    break;
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Task.Core
{
    /// <summary>
    /// http://stackoverflow.com/questions/1427471/observablecollection-not-noticing-when-item-in-it-changes-even-with-inotifyprop
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BusinessCollectionBase<T> : ObservableCollection<T>
        where T : BusinessBase
    {
        /// <summary>
        /// Occurs when a property is changed within an item.
        /// </summary>
        public event EventHandler<ItemPropertyChangedEventArgs> ItemPropertyChanged;

        public BusinessCollectionBase() : base()
        { }

        public BusinessCollectionBase(List<T> list) : base(list)
        {
            ObserveAll();
        }

        public BusinessCollectionBase(IEnumerable<T> enumerable) : base(enumerable)
        {
            ObserveAll();
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove ||
                e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (T item in e.OldItems)
                    item.PropertyChanged -= ChildPropertyChanged;
            }

            if (e.Action == NotifyCollectionChangedAction.Add ||
                e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (T item in e.NewItems)
                    item.PropertyChanged += ChildPropertyChanged;
            }

            base.OnCollectionChanged(e);
        }

        protected void OnItemPropertyChanged(ItemPropertyChangedEventArgs e)
        {
            ItemPropertyChanged?.Invoke(this, e);
        }

        protected void OnItemPropertyChanged(int index, PropertyChangedEventArgs e)
        {
            OnItemPropertyChanged(new ItemPropertyChangedEventArgs(index, e));
        }

        protected override void ClearItems()
        {
            foreach (T item in Items)
                item.PropertyChanged -= ChildPropertyChanged;

            base.ClearItems();
        }

        private void ObserveAll()
        {
            foreach (T item in Items)
                item.PropertyChanged += ChildPropertyChanged;
        }

        private void ChildPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            T typedSender = (T)sender;
            int i = Items.IndexOf(typedSender);

            if (i < 0)
                throw new ArgumentException("Received property notification from item not in collection");

            OnItemPropertyChanged(i, e);
        }
    }

    /// <summary>
    /// Provides data for the <see cref="BusinessCollectionBase{T}.ItemPropertyChanged"/> event.
    /// </summary>
    public class ItemPropertyChangedEventArgs : PropertyChangedEventArgs
    {
        /// <summary>
        /// Gets the index in the collection for which the property change has occurred.
        /// </summary>
        /// <value>
        /// Index in parent collection.
        /// </value>
        public int CollectionIndex { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemPropertyChangedEventArgs"/> class.
        /// </summary>
        /// <param name="index">The index in the collection of changed item.</param>
        /// <param name="name">The name of the property that changed.</param>
        public ItemPropertyChangedEventArgs(int index, string name) : base(name)
        {
            CollectionIndex = index;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemPropertyChangedEventArgs"/> class.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="args">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        public ItemPropertyChangedEventArgs(int index, PropertyChangedEventArgs args) : this(index, args.PropertyName)
        { }
    }
}

﻿
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Task.Core
{
    public class BusinessBase : INotifyPropertyChanged
    {
        private bool _isDirty;

        public delegate void DirtyStateChangedEventHandler(object sender);
        public event DirtyStateChangedEventHandler DirtyStateChanged;

        public event PropertyChangedEventHandler PropertyChanged;
        public RulesCollection Rules { get; set; }

        public BusinessBase()
        {
            MarkNew();
            Rules = new RulesCollection();
        }

        public bool IsNew { get; private set; }
        public bool IsDeleted { get; private set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                //if(_isDirty == value) return;
                _isDirty = value;
                OnDirtyStateChanged();
            }
        }

        protected void MarkNew()
        {
            IsNew = true;
            MarkDirty();
        }

        protected void MarkDirty()
        {
            IsDirty = true;
        }

        public void MarkOld()
        {
            IsNew = false;
            IsDirty = false;
        }

        public void MarkDeleted()
        {
            IsDeleted = true;
            MarkDirty();
        }
        

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnDirtyStateChanged()
        {
            DirtyStateChanged?.Invoke(this);
        }
    }
}

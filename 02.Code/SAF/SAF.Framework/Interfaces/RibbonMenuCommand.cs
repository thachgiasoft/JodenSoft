﻿using DevExpress.XtraBars;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SAF.Framework
{
    public interface IRibbonMenuCommand
    {
        PopupControl DropDownControl { get; }
        string Caption { get; }
        bool BeginGroup { get; }
        BarShortcut ItemShortcut { get; }
        Image LargeGlyph { get; }
        Image Glyph { get; }
        void Execute(object parameter);
        bool CanExecute(object parameter);
    }

    public sealed class RibbonMenuCommandCollection : IEnumerable<IRibbonMenuCommand>
    {
        private List<IRibbonMenuCommand> commands = new List<IRibbonMenuCommand>();

        public void Add(IRibbonMenuCommand cmd)
        {
            this.commands.Add(cmd);
        }

        public bool Remove(IRibbonMenuCommand cmd)
        {
            return this.commands.Remove(cmd);
        }

        public int Count
        {
            get { return commands.Count; }
        }

        public void Clear()
        {
            this.commands.Clear();
        }

        public IEnumerator<IRibbonMenuCommand> GetEnumerator()
        {
            return commands.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class RibbonMenuCommand : IRibbonMenuCommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public virtual string Caption { get; set; }
        public virtual bool BeginGroup { get; set; }
        public virtual PopupControl DropDownControl { get; set; }
        public virtual Image LargeGlyph { get; set; }
        public virtual Image Glyph { get; set; }
        public BarShortcut ItemShortcut { get; set; }

        public RibbonMenuCommand(string caption, Action<object> execute, Predicate<object> canExecute)
        {
            this.Caption = caption;
            _execute = execute;
            _canExecute = canExecute;

        }

        public RibbonMenuCommand(string caption, Action<object> execute)
            : this(caption, execute, null)
        {
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }
    }
}

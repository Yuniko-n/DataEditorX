﻿using System;
using System.Collections.Generic;

namespace DataEditorX.Core
{
    public delegate void StatusBool(bool val);
    public interface ICommand : ICloneable
    {
        bool Excute(params object[] args);
    }
    public interface IBackableCommand : ICommand
    {
        void Undo();
    }
    public interface ICommandManager
    {
        void ExcuteCommand(ICommand command, params object[] args);
        void Undo();
        void ReverseUndo();//反撤销

        event StatusBool UndoStateChanged;
    }
    public class CommandManager : ICommandManager
    {
        private readonly Stack<ICommand> undoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> reverseStack = new Stack<ICommand>();

        public event StatusBool UndoStateChanged;

        public CommandManager()
        {
            UndoStateChanged += new StatusBool(this.CommandManager_UndoStateChanged);
            UndoStateChanged += new StatusBool(this.CommandManager_ReverseUndoStateChanged);
        }

        private void CommandManager_UndoStateChanged(bool val)
        {

        }

        private void CommandManager_ReverseUndoStateChanged(bool val)
        {

        }

        #region ICommandManager 成员
        public void ExcuteCommand(ICommand command, params object[] args)
        {
            if (!command.Excute(args))
            {
                return;
            }

            this.reverseStack.Clear();

            if (command is IBackableCommand)
            {
                this.undoStack.Push((ICommand)command.Clone());
            }
            else
            {
                this.undoStack.Clear();
            }

            UndoStateChanged(this.undoStack.Count > 0);
        }

        public void Undo()
        {
            IBackableCommand command = (IBackableCommand)this.undoStack.Pop();
            if (command == null)
            {
                return;
            }

            command.Undo();
            this.reverseStack.Push((ICommand)command.Clone());

            UndoStateChanged(this.undoStack.Count > 0);
            //UndoStateChanged(reverseStack.Count > 0);
        }

        public void ReverseUndo()
        {
            IBackableCommand command = (IBackableCommand)this.reverseStack.Pop();
            if (command == null)
            {
                return;
            }

            command.Excute();
            this.undoStack.Push((ICommand)command.Clone());

            UndoStateChanged(this.undoStack.Count > 0);
        }
        #endregion
    }
}

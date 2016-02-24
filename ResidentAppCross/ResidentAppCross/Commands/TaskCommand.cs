﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using ResidentAppCross.ViewModels;

namespace ResidentAppCross.Commands
{
    public class TaskCommand : MvxCommandBase, IMvxCommand, ICommand, ITaskCommandContext
    {

        private readonly Func<bool> _canExecute;
        private readonly Func<ITaskCommandContext, Task> _execute;
        private readonly ViewModelBase _owner;

        public TaskCommand(ViewModelBase owner, Func<ITaskCommandContext, Task> execute) : this(owner, execute, (Func<bool>) null)
        {
        }

        public TaskCommand(ViewModelBase owner, Func<ITaskCommandContext, Task> execute, Func<bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
            this._owner = owner;
        }

        public bool CanExecute(object parameter)
        {
            if (this._canExecute != null)
                return this._canExecute();
            return true;
        }

        public bool CanExecute()
        {
            return this.CanExecute((object)null);
        }

        public void Execute(object parameter)
        {
            if (!this.CanExecute(parameter))
                return;


            Task.Run(async () =>
            {
                ProcessStart();
                try
                {
                    await this._execute(this);
                    ProcessComplete();
                }
                catch (Exception ex)
                {
                    ProcessFail(ex);
                }

            });
        }

        private void ProcessFail(Exception exception)
        {
            _owner.FailTaskWithPrompt(exception.Message,ExceptionHandler);
        }

        private void ProcessStart()
        {
            _owner.StartTask(StartMessage);
        }

        private void ProcessComplete()
        {
            if (!string.IsNullOrEmpty(CompleteMessage))
            {
                _owner.CompleteTaskWithPrompt(CompleteMessage,CompleteHandler);
            }
            else
            {
                _owner.CompleteTask();
            }
        }

        public void Execute()
        {
            this.Execute((object)null);
        }

        private Action CompleteHandler { get; set; }
        private Action<Exception> ExceptionHandler { get; set; }
        private string CompleteMessage { get; set; }
        private string StartMessage { get; set; } = "Please, Wait...";

        public TaskCommand OnStart(string message)
        {
            StartMessage = message;
            return this;
        }

        public TaskCommand OnComplete(string message, Action completeHandler = null)
        {
            CompleteHandler = completeHandler;
            CompleteMessage = message;
            return this;
        }

        public TaskCommand OnFail(Action<Exception> exceptionHandler = null)
        {
            ExceptionHandler = exceptionHandler;
            return this;
        }

        public void UpdateTask(string message, float progress = -1)
        {
            throw new NotImplementedException();
        }

        public void FailTask(string reason)
        {
            throw new Exception(reason);
        }
    }

    public interface ITaskCommandContext
    {
        void UpdateTask(string message, float progress = -1);
        void FailTask(string reason);
    }
}

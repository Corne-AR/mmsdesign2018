using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReportManager.MVVM
{
    /// <summary>
    /// Creates a parameterless WPF ICommand object
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class DelegateCommand : ICommand
    {
        private Action execute;
        private Func<bool> canExecute;

        private event EventHandler CanExecuteChangedInternal;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        public DelegateCommand(Action execute)
           : this(execute, () => true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">if set to <c>true</c> [can execute].</param>
        /// <exception cref="System.ArgumentNullException">execute</exception>
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedInternal += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedInternal -= value;
            }
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            try
            {
                return this.canExecute.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not get 'CanExecute' Method.\r\nParameter: {parameter}", ex);
            }
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            this.execute();
        }
        /// <summary>
        /// Called when [can execute changed].
        /// </summary>
        public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedInternal;
            if (handler != null)
            {
                //DispatcherHelper.BeginInvokeOnUIThread(() => handler.Invoke(this, EventArgs.Empty));
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        public void Destroy()
        {
            this.canExecute = null;
            this.execute = null;
        }

        /// <summary>
        /// Creates new ICommand with an execute.
        /// </summary>
        /// <param name="Execute">The execute method.</param>
        /// <returns></returns>
        public static DelegateCommand Create(Action Execute)
            => Create(Execute, () => true);

        /// <summary>
        /// Creates new ICommand with specified execute and can-execute.
        /// </summary>
        /// <param name="Execute">The execute method.</param>
        /// <param name="CanExecute">if set to <c>true</c> [can execute].</param>
        /// <returns></returns>
        public static DelegateCommand Create(Action Execute, Func<bool> CanExecute)
            => new DelegateCommand(Execute, CanExecute);
    }

    /// <summary>
    /// Creates a parameter based WPF ICommand object
    /// </summary>
    /// <typeparam name="T">type of parameter object</typeparam>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class DelegateCommand<T> : ICommand
    {
        private Action<T> execute;
        private Predicate<T> canExecute;

        private event EventHandler CanExecuteChangedInternal;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand{T}"/> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        public DelegateCommand(Action<T> execute)
           : this(execute, (T) => true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand{T}"/> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">The can execute.</param>
        /// <exception cref="System.ArgumentNullException">
        /// execute
        /// or
        /// canExecute
        /// </exception>
        public DelegateCommand(Action<T> execute, Predicate<T> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute ?? throw new ArgumentNullException("canExecute");
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedInternal += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedInternal -= value;
            }
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            try
            {
                if (typeof(T) == typeof(object)) return this.canExecute != null && canExecute((T)parameter);
                else return this.canExecute != null && this.canExecute((T)Convert.ChangeType(parameter, typeof(T))); // this.canExecute((T)parameter);
            }
            catch (InvalidCastException ex)
            {
                var t = typeof(T);
                var pt = parameter.GetType();

                throw new InvalidCastException($"Could not get 'CanExecute' Method.\nParameter: {parameter}\nParameter Type: {pt.FullName}\nExpected Type: {t.FullName}", ex);
            }
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (typeof(T) == typeof(object)) execute((T)parameter);
            else execute((T)Convert.ChangeType(parameter, typeof(T)));
        }

        /// <summary>
        /// Called when [can execute changed].
        /// </summary>
        public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedInternal;
            if (handler != null)
            {
                //DispatcherHelper.BeginInvokeOnUIThread(() => handler.Invoke(this, EventArgs.Empty));
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        public void Destroy()
        {
            this.canExecute = _ => false;
            this.execute = _ => { return; };
        }

        /// <summary>
        /// Creates new ICommand with specified execute.
        /// </summary>
        /// <param name="Execute">The execute.</param>
        /// <returns></returns>
        public static DelegateCommand<T> Create(Action<T> Execute)
            => Create(Execute, (T) => true);

        /// <summary>
        /// Creates new ICommand with specified execute and can-execute.
        /// </summary>
        /// <param name="Execute">The execute.</param>
        /// <param name="CanExecute">The can execute.</param>
        /// <returns></returns>
        public static DelegateCommand<T> Create(Action<T> Execute, Predicate<T> CanExecute)
            => new DelegateCommand<T>(Execute, CanExecute);
    }
}

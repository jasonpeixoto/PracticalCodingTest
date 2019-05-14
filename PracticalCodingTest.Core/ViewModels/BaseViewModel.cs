//--------------------------------------------------------------------------------------------------------
// Project: PracticalCodingTest
// Author: Jason Peixoto
// Version: v1.0
// Copyright: IOTEcoSystem
// May not use this code without granted permission from Jason Peixoto
//--------------------------------------------------------------------------------------------------------
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PracticalCodingTest.ViewModel
{
    /// <summary>
    /// Base view model.
    /// </summary>
    public abstract class BaseViewModel<TParameter> : BaseViewModel
    {
        protected BaseViewModel() : base()
        {
        }

        public override void Init()
        {
            Init(default(TParameter));
        }

        public abstract Task Init(TParameter parameter);
    }

    /// <summary>
    /// Base view model.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// Init this instance.
        /// </summary>
        /// ------------------------------------------------------------------------------------------
        public virtual void Init()
        {
        }

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// Init the specified parameter.
        /// </summary>
        /// <returns>The init.</returns>
        /// <param name="parameter">Parameter.</param>
        /// ------------------------------------------------------------------------------------------
        public virtual void Init(dynamic parameter)
        {
        }


        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="T:INLShac.ViewModels.BaseViewModel"/> class.
        /// </summary>
        /// ------------------------------------------------------------------------------------------
        public BaseViewModel() => InitlizeModel();

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// Initlizes the model.
        /// </summary>
        /// ------------------------------------------------------------------------------------------
        public abstract void InitlizeModel();

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// Ons the property changed.
        /// </summary>
        /// <param name="propertyValue">Property value.</param>
        /// <param name="propertyName">Property name.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// ------------------------------------------------------------------------------------------
        protected virtual void OnPropertyChanged<T>(T propertyValue, [CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null && propertyName != System.String.Empty)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// The title.
        /// </summary>
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { OnPropertyChanged(_Title = value); }
        }
    }
}


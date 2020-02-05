using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace pe2020.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

		#region GET/SET
		string title;

		public string Title
		{
			get { return title; }
			set
			{
				SetProperty(ref title, value);
			}
		}

		#endregion

		#region NotifyPropertyChanged

		protected bool SetProperty<T>(ref T backingValue, T value, [CallerMemberName] string propertyName = "")
		{
			if(EqualityComparer<T>.Default.Equals(backingValue, value))
				return false;

			backingValue = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			return true;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}
}

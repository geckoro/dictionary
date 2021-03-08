using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
	public class Word : INotifyPropertyChanged
	{
		private string imagePath;
		private string category;
		private string description;
		private string name;

		[JsonInclude]
		public string Name
		{
			get => name;
			set
			{
				name = value;
				OnPropertyChanged();
			}
		}

		[JsonInclude]
		public string Description
		{
			get => description;
			set
			{
				description = value;
				OnPropertyChanged();
			}
		}

		[JsonInclude]
		public string Category
		{
			get => category;
			set
			{
				category = value;
				OnPropertyChanged();
			}
		}

		[JsonInclude]
		public string ImagePath
		{
			get => imagePath;
			set
			{
				imagePath = value;
				OnPropertyChanged();
			}
		}

		public Word(string name, string description, string category, string imagePath = @"D:\FACULT 2020-2021\MVP\Dictionary\Dictionary\Resources\noimage.png")
		{
			Name = name;
			Description = description;
			Category = category;
			ImagePath = imagePath;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

		public override string ToString() 
		{
			return Name;
		}

		private System.Collections.IEnumerable words;

        public System.Collections.IEnumerable Words { get => words; set => SetProperty(ref words, value); }
    }
}

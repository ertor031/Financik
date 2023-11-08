using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Financik.ViewModels
{
    public class FinanceViewModel : INotifyPropertyChanged
    {
        private string title;
        private string price;
        private bool isAddButtonEnabled;

        private bool isCategorySelected;
        private bool isIncomeSourceSelected;

        private DateTime selectedDateFrom;
        private DateTime selectedDateTo;
        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged();
                    UpdateAddButton();
                }
            }
        }

        public string Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged();
                    UpdateAddButton();
                }
            }
        }

        public DateTime SelectedDateFrom
        {
            get { return selectedDateFrom; }
            set
            {
                if(selectedDateFrom != value)
                {
                    selectedDateFrom = value;
                    OnPropertyChanged();
                    UpdateAddButton();
                }
            }
        }

        public DateTime SelectedDateTo
        {
            get { return selectedDateTo; }
            set
            {
                if( selectedDateTo != value)
                {
                    selectedDateTo = value;
                    OnPropertyChanged();
                    UpdateAddButton();
                }
            }
        }

        public bool IsAddButtonEnabled
        {
            get { return isAddButtonEnabled; }
            set
            {
                if (isAddButtonEnabled != value)
                {
                    isAddButtonEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsCategorySelected
        {
            get { return isCategorySelected; }
            set
            {
                if(isCategorySelected != value)
                {
                    isCategorySelected = value;
                    OnPropertyChanged();
                    UpdateAddButton();
                }
            }
        }

        public bool IsIncomeSourceSelected
        {
            get { return isIncomeSourceSelected; }
            set
            {
                if(isIncomeSourceSelected != value)
                {
                    isIncomeSourceSelected = value;
                    OnPropertyChanged();
                    UpdateAddButton();
                }
            }
        }

        public FinanceViewModel()
        {
            UpdateAddButton();
            SelectedDateFrom = new DateTime(2023, 1, 1);
            SelectedDateTo = new DateTime(2023, 1, 2);
        }

        public void UpdateAddButton()
        {
            IsAddButtonEnabled = !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Price)
                && (IsCategorySelected || IsIncomeSourceSelected)
                && SelectedDateFrom!=default && SelectedDateTo!=default
                && SelectedDateFrom<SelectedDateTo;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

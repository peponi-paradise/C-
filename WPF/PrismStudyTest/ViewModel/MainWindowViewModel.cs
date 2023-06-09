﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismStudy.Services;

namespace PrismStudy.Services
{
    public interface ICustomerStore
    {
        List<string> GetAll();
    }

    public class DbCustomerStore : ICustomerStore
    {
        public List<string> GetAll() => new() { "A", "B", "C" };
    }
}

namespace ViewModel.ViewModels
{
    public interface IViewModel
    {
    }

    public class MainWindowViewModel : BindableBase, IViewModel
    {
        private ICustomerStore _customerStore = null;

        public MainWindowViewModel(ICustomerStore customerStore)
        {
            _customerStore = customerStore;
        }

        public ObservableCollection<string> Customers { get; private set; } =
            new ObservableCollection<string>();

        private string _selectedCustomer = null;

        public string SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (SetProperty<string>(ref _selectedCustomer, value))
                {
                    Debug.WriteLine(_selectedCustomer ?? "no customer selected");
                }
            }
        }

        private DelegateCommand _commandLoad = null;

        public DelegateCommand CommandLoad =>
            _commandLoad ?? (_commandLoad = new DelegateCommand(CommandLoadExecute));

        private void CommandLoadExecute()
        {
            Customers.Clear();
            List<string> list = _customerStore.GetAll();
            foreach (string item in list)
                Customers.Add(item);
        }
    }
}
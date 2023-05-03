using System;
using System.Collections.Generic;
using System.ComponentModel;
using WhatsOn.Models;
using WhatsOn.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatsOn.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}
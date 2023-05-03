using System;
using System.Collections.Generic;
using WhatsOn.ViewModels;
using WhatsOn.Views;
using Xamarin.Forms;

namespace WhatsOn
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}

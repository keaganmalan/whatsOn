using System.ComponentModel;
using WhatsOn.ViewModels;
using Xamarin.Forms;

namespace WhatsOn.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
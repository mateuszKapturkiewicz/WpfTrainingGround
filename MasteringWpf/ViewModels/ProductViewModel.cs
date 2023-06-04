using MasteringWpf.DataModels;

namespace MasteringWpf.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private Product product = new Product();

        public Product Product
        {
            get { return product; }
            set { if (product != value) { product = value; NotifyPropertyChanged(); } }
        }
    }
}

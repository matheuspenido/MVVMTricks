namespace DemoApp.ViewModels
{
    using System.Collections.ObjectModel;
    using Microsoft.Practices.Prism.Commands;

    public class SingleBrandViewModel : BaseViewModel
    {
        private DelegateCommand<string> addProduct;
        private DelegateCommand<ProductViewModel> deleteProduct;
        private ObservableCollection<ProductViewModel> products;
        private string header;

        public SingleBrandViewModel()
        {
        }

        public string Header
        {
            get
            {
                return this.header;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.header = value;
                    NotifyPropertyChanged("Header");
                }
            }
        }

        public ObservableCollection<ProductViewModel> Products
        {
            get
            {
                return this.products ?? 
                    (this.products = new ObservableCollection<ProductViewModel>());
            }

            set
            {
                if (value != null)
                {
                    this.products = value;
                    NotifyPropertyChanged("Products");
                }
            }
        }

        public DelegateCommand<ProductViewModel> DeleteProduct
        {
            get
            {
                return this.deleteProduct ?? (this.deleteProduct = new DelegateCommand<ProductViewModel>(
                                                                       this.ExecuteDeleteProduct,
                                                                       (arg) => true));
            }
        }

        public DelegateCommand<string> AddProduct
        {
            get
            {
                return this.addProduct ?? (this.addProduct = new DelegateCommand<string>(
                                                                  this.ExecuteAddProduct,
                                                                  (arg) => true));
            }
        }

        private void ExecuteAddProduct(string obj)
        {
            if (!string.IsNullOrEmpty(obj))
            {
                this.Products.Add(new ProductViewModel()
                                      {
                                          ProductName = obj
                                      });
            }
        }

        private void ExecuteDeleteProduct(ProductViewModel obj)
        {
            if (this.Products.Contains(obj))
            {
                this.Products.Remove(obj);
            }
        }
    }
}

namespace DemoApp.ViewModels
{
    using System.Collections.ObjectModel;
    using Microsoft.Practices.Prism.Commands;

    public class BrandsViewModel : BaseViewModel
    {
        private DelegateCommand<string> addBrand;
        private DelegateCommand<SingleBrandViewModel> deleteBrand;
        private ObservableCollection<SingleBrandViewModel> brands;
        
        public ObservableCollection<SingleBrandViewModel> Brands
        {
            get
            {
                return this.brands ?? (this.brands = new ObservableCollection<SingleBrandViewModel>());
            }

            set
            {
                if (value != null)
                {
                    this.brands = value;
                    NotifyPropertyChanged("Brands");
                }
            }
        }

        public DelegateCommand<SingleBrandViewModel> DeleteBrand
        {
            get
            {
                return this.deleteBrand ?? (this.deleteBrand = new DelegateCommand<SingleBrandViewModel>(
                                                                                 this.ExecuteDeleteBrand,
                                                                                 (arg) => true));
            }
        }

        public DelegateCommand<string> AddBrand
        {
            get
            {
                return this.addBrand ?? (this.addBrand = new DelegateCommand<string>(
                                                             this.ExecuteAddBrand,
                                                             (arg) => true));
            }
        }

        private void ExecuteAddBrand(string obj)
        {
            if (!string.IsNullOrEmpty(obj))
            {
                this.Brands.Add(new SingleBrandViewModel()
                                    {
                                        Header = obj
                                    });
            }
        }

        private void ExecuteDeleteBrand(SingleBrandViewModel obj)
        {
            if (this.Brands.Contains(obj))
            {
                this.Brands.Remove(obj);
            }
        }
    }
}

namespace DemoApp.Views
{
    using System.Windows;
    using System.Windows.Controls;
    using DemoApp.ViewModels;

    /// <summary>
    /// Interaction logic for BrandView.xaml
    /// </summary>
    public partial class BrandsView : UserControl
    {
        public BrandsView()
        {
            InitializeComponent();
            this.FindAndApplyResources();
            this.DataContext = new BrandsViewModel();
        }

        private void FindAndApplyResources()
        {
            var singleBrandKey = new DataTemplateKey(typeof(SingleBrandViewModel));
            var productKey = new DataTemplateKey(typeof(ProductViewModel));
            var singleBrandTemplate = this.TryFindResource(singleBrandKey);
            var productTemplate = this.TryFindResource(productKey);
            if (singleBrandTemplate != null && productTemplate != null)
            {
                this.tab.AddResource(singleBrandKey, singleBrandTemplate);
                this.tab.AddResource(productKey, productTemplate);
            }
        }
    }
}

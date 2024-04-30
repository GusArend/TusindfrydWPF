
using System.Windows;


namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for CreateFlowerSortDialog.xaml
    /// </summary>
    public partial class CreateFlowerSortDialog : Window
    {
        Flowersort flowersort;

        public CreateFlowerSortDialog()
        {
            InitializeComponent();
            flowersort = new Flowersort();
        }

        private void SetFlowerSortProperties()
        {
            if (tbName.Text != "" && tbImagePath.Text != "" && tbProdTime.Text != "" && tbHalfLifeTime.Text != "" && tbSize.Text != "")
            {
                flowersort.Name = tbName.Text.Trim();
                flowersort.PicturePath = tbImagePath.Text.Trim();
                flowersort.ProductionTime = ParseInt(tbProdTime.Text.Trim());
                flowersort.HalfLifeTime = ParseInt(tbHalfLifeTime.Text.Trim());
                flowersort.Size = ParseInt(tbSize.Text.Trim());
            }
            else
            {
                this.DialogResult = false;
                this.Close();
            }

        }

        private int ParseInt(string text)
        {
            int result;
            if (!int.TryParse(text, out result))
            {
                result = 0;
            }
            return result;
        }

        public new Flowersort ShowDialog()
        {
            btnOK.IsEnabled = false;
            base.ShowDialog();
            return flowersort;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            SetFlowerSortProperties();
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void tb_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            EnableOkBtn();
        }

        private void EnableOkBtn()
        {
            if (tbName.Text != "" && tbImagePath.Text != "" && tbProdTime.Text != "" && tbHalfLifeTime.Text != "" && tbSize.Text != "")
            {
                btnOK.IsEnabled = true;
            }
            else
            {
                btnOK.IsEnabled = false;
            }
        }
    }

}

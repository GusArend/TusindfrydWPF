using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Flowersort> flowersorts;
        

        public MainWindow()
        {
            InitializeComponent();
            flowersorts = new List<Flowersort>();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateFlowerSortDialog createFlowerSortDialog = new CreateFlowerSortDialog();
            try
            {
                Flowersort flowersort = createFlowerSortDialog.ShowDialog();
                if (flowersort != null)
                {
                    if (new string(flowersort.Name).Trim() != "" && new string(flowersort.PicturePath).Trim() != "" && new string(flowersort.ProductionTime.ToString()).Trim()
                        != "" && new string(flowersort.HalfLifeTime.ToString()).Trim() != "" && new string(flowersort.Size.ToString()).Trim() != "")
                    {
                        flowersorts.Add(flowersort);
                        UpdateFlowersortList();
                        ShowStatusMessage("Flowersort added successfully.", "green");
                    } else
                    {
                        ShowStatusMessage("Cancelled.", "blue");
                    }
                    
                    
                }
                else
                {
                    ShowStatusMessage("Failed to add flowersort.", "red");
                }
            } catch (Exception ex)
            {
                ShowStatusMessage(ex.Message, "red");
            }
        }

        private void UpdateFlowersortList()
        {
            tblockFlowersorts.Text = string.Join(Environment.NewLine, flowersorts.Select(fs => fs.Name));
        }

        private void ShowStatusMessage(string message, string color)
        {
            switch (color.ToLower())
            {
                case "red":
                    statusLabel.Foreground = Brushes.Red;
                    break;
                case "green":
                    statusLabel.Foreground = Brushes.Green;
                    break;
                case "blue":
                    statusLabel.Foreground = Brushes.Blue;
                    break;
                default:
                    statusLabel.Foreground = Brushes.Black;
                    break;
            }
            statusLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            statusLabel.Content = message;
        }
    }

}
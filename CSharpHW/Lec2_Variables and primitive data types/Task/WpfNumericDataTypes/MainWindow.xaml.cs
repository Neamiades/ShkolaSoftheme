using System.Windows;
using System.Windows.Controls;

namespace WpfNumericDataTypes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const string Info = "Maximal value of {0} type: {1}\n" + 
                                    "Minimal value of {0} type: {2}\n" + 
                                    "Default value of {0} type: {3}";

        public MainWindow() => InitializeComponent();

        private void TypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChoosenType.SelectedItem is ListBoxItem selectedType)
            {
                Value.Document.Blocks.Clear();
                switch (selectedType.Content.ToString())
                {
                    case "int":
                        Value.AppendText(
                            string.Format(Info, "int",
                            int.MaxValue, int.MinValue, default(int)));
                        break;
                    case "long":
                        Value.AppendText(
                            string.Format(Info, "long",
                            long.MaxValue, long.MinValue, default(long)));
                        break;
                    case "float":
                        Value.AppendText(
                            string.Format(Info, "float",
                            float.MaxValue, float.MinValue, default(float)));
                        break;
                    case "double":
                        Value.AppendText(
                            string.Format(Info, "double",
                            double.MaxValue, double.MinValue, default(double)));
                        break;
                    case "decimal":
                        Value.AppendText(
                            string.Format(Info, "decimal",
                            decimal.MaxValue, decimal.MinValue, default(decimal)));
                        break;
                    case "string":
                        Value.AppendText(
                            string.Format(Info, "string",
                            "2 GB, or about 1 billion characters", 0, "empty string \"\""));
                        break;
                    case "char":
                        Value.AppendText(
                            string.Format(Info, "char",
                            (int)char.MaxValue, (int)char.MinValue, (int)default(char)));
                        break;
                    case "bool":
                        Value.AppendText(
                            string.Format(Info, "bool",
                            true, false, default(bool)));
                        break;
                }
            }
        }
        private void QuitClick(object sender, RoutedEventArgs e) => Close();
    }


}

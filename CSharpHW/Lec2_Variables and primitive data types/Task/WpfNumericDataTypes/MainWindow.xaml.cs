using System.Windows;
using System.Windows.Controls;

namespace WpfNumericDataTypes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void TypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChoosenType.SelectedItem is ListBoxItem selectedType)
            {
                Value.Document.Blocks.Clear();
                switch (selectedType.Content.ToString())
                {
                    case "int":
                        Value.AppendText($"Maximal value of int type: {int.MaxValue}\n" +
                                         $"Minimal value of int type: {int.MinValue}\n" +
                                         $"Default value of int type: {default(int)}");
                        break;
                    case "long":
                        Value.AppendText($"Maximal value of long type: {long.MaxValue}\n" +
                                         $"Minimal value of long type: {long.MinValue}\n" +
                                         $"Default value of long type: {default(long)}");
                        break;
                    case "float":
                        Value.AppendText($"Maximal value of float type: {float.MaxValue}\n" +
                                         $"Minimal value of float type: {float.MinValue}\n" +
                                         $"Default value of float type: {default(float)}");
                        break;
                    case "double":
                        Value.AppendText($"Maximal value of double type: {double.MaxValue}\n" +
                                         $"Minimal value of double type: {double.MinValue}\n" +
                                         $"Default value of double type: {default(double)}");
                        break;
                    case "decimal":
                        Value.AppendText($"Maximal value of decimal type: {decimal.MaxValue}\n" +
                                         $"Minimal value of decimal type: {decimal.MinValue}\n" +
                                         $"Default value of decimal type: {default(decimal)}");
                        break;
                    case "string":
                        Value.AppendText("Maximal value of string type:\n" +
                                         "\t1. Under the link https://msdn.microsoft.com/en-us/library/sx08afx2.aspx\n" +
                                         "\t2. Or quick answer - 2 GB, or about 1 billion characters.\n" +
                                         "Minimal value of string type: 0\n" +
                                         "Default value of string type: empty string \"\"");
                        break;
                    case "char":
                        Value.AppendText($"Maximal value of char type: {(int) char.MaxValue}\n" +
                                         $"Minimal value of char type: {(int) char.MinValue}\n" +
                                         $"Default value of char type: {(int) default(char)}");
                        break;
                    case "bool":
                        Value.AppendText($"Maximal value of int type: {true}\n" +
                                         $"Minimal value of int type: {false}\n" +
                                         $"Default value of int type: {default(bool)}");
                        break;
                }
            }
        }
        private void QuitClick(object sender, RoutedEventArgs e) => Close();
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
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

namespace PersonalQ
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            theWord.Loaded += new RoutedEventHandler(this.theWord_Loaded);
        }

        private void theWord_Loaded(object sender, RoutedEventArgs e)
        {
            this.theWord.ApplyTemplate();
            TextBox textBox = this.theWord.Template.FindName("PART_EditableTextBox", this.theWord) as TextBox;
            textBox.SelectionLength = 0;

            if (textBox != null)
            {
                textBox.TextChanged += delegate                    //HAHAHAHAH
                {
                    this.theWord.IsDropDownOpen = true;
                    this.theWord.SelectedIndex = -1;
                    this.theWord.Items.Filter += symbol =>
                    {
                        if (symbol.ToString().ToUpper().Contains(textBox.Text.ToUpper()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    };
                    textBox.SelectionLength = 0;
                    textBox.CaretIndex = textBox.Text.Length;
                };
            }
        }
    }
}

using Blocks_Programming.Blocks;
using Blocks_Programming.Blocks_Fabriks;
using Blocks_Programming.BlocksFabriks.CommandBlockFabrik;
using Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.CompareFabrik;
using Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.NumberFabrik;
using Blocks_Programming.BlocksFabriks.ReturnBlockFabrik.TextFabrik;
using Blocks_Programming.Bloks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Blocks_Programming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Start start = null;
        public MainWindow()
        {
            InitializeComponent();
            List<BaseBlockFabrik> BlocksFabriksList = new List<BaseBlockFabrik>() {
            new IfBlockFabrik(),
            new WhileBlockFabrik(),
            new RepeatBlockFabrik(),
            new PrintBlockFabrik(),
            new SetTextVariableFabrik(),
            new SetNumberVariableFabrik(),
            new CompareBlockFabrik(),
            new CompareTextBlockFabrik(),
            new NumberFabrik(),
            new NumberVarBlockFabrik(),
            new TextToNumberBlockFabrik(),
            new ArifmeticFabrik(),
            new TextBlockFabrik(),
            new GetTextFromKeyboardFabrik(),
            new TextVarBlockFabrik(),
            new NumberToTextBlockFabrik()
        };
            foreach (var block in BlocksFabriksList)
                blocks.Children.Add(block);
            start = new Start(Main, buttStart);
            BaseBlock.SetConsole(console);
            OnPropertyChanged();
            buttStart.SetValues(console, start);
            buttGetCode.SetValues(start);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        void DeleteBlock(object sender, DragEventArgs e)
        {

            var delBlock = e.Data.GetData(DataFormats.Serializable) as BaseBlock;
            if (delBlock != null) delBlock.Delete();
            Trash.Source = new BitmapImage(new Uri("Resources/delete.png", UriKind.Relative));
        }
        void LeaveBlock(object sender, DragEventArgs e)
        {
            Trash.Source = new BitmapImage(new Uri("Resources/delete.png", UriKind.Relative));
        }

        void EnterBlock(object sender, DragEventArgs e)
        {
            Trash.Source = new BitmapImage(new Uri("Resources/delete_open.png", UriKind.Relative));
        }
        
    }
}

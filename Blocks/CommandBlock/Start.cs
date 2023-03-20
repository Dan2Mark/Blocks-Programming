using Blocks_Programming.Blocks.CommandBlock;
using Blocks_Programming.Blocks_Fabriks;
using Blocks_Programming.BlocksFabriks.CommandBlockFabrik;
using Blocks_Programming.Bloks;
using Blocks_Programming.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Blocks_Programming.Blocks
{
    class Start : BaseCommandBlock
    {
        public Start(FrameworkElement container, StartButton startButton) : base(container)
        {
            index = 0;
            Background = new SolidColorBrush(Colors.LimeGreen);
            elements.Children.Add(new TextBlock { Text = "Start", FontWeight = FontWeights.Bold, Foreground = new SolidColorBrush(Colors.White), HorizontalAlignment = HorizontalAlignment.Center });
            nextBlock = new Finish(container, startButton, 1);
        }
        protected override void Command()
        {
            console.IsOpen(true);
        }
        public override string GetC_SharpCode(int c, int i = 0)
        {
            string stringVars = "";
            if (VariablesStorage.TextVariables.Count > 2)
            {
                foreach (var Var in VariablesStorage.TextVariables.Keys)
                    stringVars += $"\t\t\t{Var} = \"\",\n";
                stringVars = "\t\tstatic string" + (stringVars.Remove(stringVars.Length - 2) + ";\n").Remove(0, stringVars.IndexOf("Видалити = \"\"") + 14);
            }
            string numVars = "";
            if (VariablesStorage.NumberVariables.Count > 2)
            {
                foreach (var Var in VariablesStorage.NumberVariables.Keys)
                    numVars += $"\t\t\t{Var} = 0,\n";
                numVars = "\t\tstatic double\n" + (numVars.Remove(numVars.Length - 2) + ";\n").Remove(0, numVars.IndexOf("Видалити = 0") + 14);
            }
            string childrensCode = "";
            BaseCommandBlock nb = nextBlock;
            while (nb != null)
            {
                childrensCode += nb.GetC_SharpCode(c, 3) + "\n";
                nb = nb.nextBlock;
            }
            return $"using System;\n\nnamespace TEST_C_SHARP\n{{\n\tclass Program\n\t{{\n{stringVars}{numVars}\n\t\tstatic void Main(string[] args)\n\t\t{{{childrensCode}\n\t\t}}\n\t}}\n}}".Replace("\n\n","\n");
        }
    }
}

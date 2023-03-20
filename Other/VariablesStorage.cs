using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Blocks_Programming.Other
{
    public static class VariablesStorage
    {
        /// <summary>
        /// Список текстових змінних
        /// </summary>
        static public Dictionary<string, string> TextVariables { get; private set; }
        /// <summary>
        /// Список числових змінних
        /// </summary>
        static public Dictionary<string, double> NumberVariables { get; private set; }
        static VariablesStorage()
        {
            NumberVariables = new Dictionary<string, double>() { { "Додати", -1f }, { "Видалити", -1f } };
            TextVariables = new Dictionary<string, string>() { { "Додати", "" }, { "Видалити", "" } };
        }

        /// <returns>
        /// Повертає новий ComboBox для звертання до текстових змінних
        /// </returns>
        static public ComboBox getTextComboBox ()
        {
            var cbox = new ComboBox { };
            cbox.SelectionChanged += changedText;
            cbox.MouseEnter += TextUpdate; 
            return cbox;
        }

        /// <returns>
        /// Повертає новий ComboBox для звертання до числових змінних
        /// </returns>
        static public ComboBox getNumberComboBox()
        {
            var cbox = new ComboBox { };
            cbox.SelectionChanged += changedNum;
            cbox.MouseEnter += NumUpdate;
            return cbox;
        }

        static void TextUpdate(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            if (cbx != null)
            {
                Update(cbx, true);
            }

        }

        static void NumUpdate(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            if (cbx != null)
            {
                Update(cbx, false);
            }

        }
        private static bool detectedFlag = true;
        static void Update(ComboBox cbx, bool TN, int index = -1)
        {
            int indx;
            if (index == -1)
                indx = cbx.SelectedIndex;
            else if (index == 0 || index == 1)
                indx = -1;
            else
                indx = index;
            cbx.Items.Clear();
            if (TN)
                foreach (string str in TextVariables.Keys)
                    cbx.Items.Add(str);
            else
                foreach (string str in NumberVariables.Keys)
                    cbx.Items.Add(str);
            detectedFlag = false;
            cbx.SelectedIndex = indx;
            detectedFlag = true;
        }
        static void changedText (object sender, EventArgs e)
        {
            if (detectedFlag)
            {
                var cbx = (ComboBox)sender;
                int indx = cbx.SelectedIndex;
                if (indx == 0)
                {
                    string name = getNameTextVariable(TextVariables.Values.Count() - 2);
                    TextVariables.Add(name, "");
                    Update(cbx, true, TextVariables.Count - 1);
                }
                else if (indx == 1)
                {
                    TextVariables.Remove(getNameTextVariable(TextVariables.Values.Count() - 3));
                    Update(cbx, true, TextVariables.Count - 1);
                }
            }
        }
        static void changedNum(object sender, EventArgs e)
        {
            if (detectedFlag)
            {
                var cbx = (ComboBox)sender;
                int indx = cbx.SelectedIndex;
                if (indx == 0)
                {
                    string name = getNameNumVariable(NumberVariables.Values.Count() - 2);
                    NumberVariables.Add(name, 0);
                    Update(cbx, false, NumberVariables.Count - 1);
                }
                else if (indx == 1)
                {
                    NumberVariables.Remove(getNameNumVariable(NumberVariables.Values.Count() - 3));
                    Update(cbx, false, NumberVariables.Count - 1);
                }
            }
        }
        public static string getNameTextVariable (int i)
        {
            string name = "";
            int c = i / 26;
            name += (char)('a' + i%26);
            if (c > 0)
                name += (c - 1).ToString();
            name += "_text";
            return name;
        }
        public static string getNameNumVariable(int i)
        {
            string name = "";
            int c = i / 26;
            name += (char)('a' + i % 26);
            if (c > 0)
                name += (c - 1).ToString();
            name += "_num";
            return name;
        }
    }

}

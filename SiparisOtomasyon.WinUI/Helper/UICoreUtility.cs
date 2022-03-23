using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.WinUI.Helper
{
    using Core.Utility;
    using System.Windows.Forms;

    public static class UICoreUtility
    {
        
        public static void SuccessMessage(string Message)
        {
            System.Windows.Forms.MessageBox.Show(Message,CoreHelper.AppNameVersion,System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
        }

        public static void ErrorMessage(string Message)
        {
            System.Windows.Forms.MessageBox.Show(Message, CoreHelper.AppNameVersion, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        public static DialogResult DialogMessage(string message)
        {
            return MessageBox.Show(message,CoreHelper.AppNameVersion,MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
        }

        /// <summary>
        /// Data gridview için column mappingte kullanılacak
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dataPropertyName">Datasource içindeki data index</param>
        /// <param name="HeaderTextt">Header kısmında gözükecek ad</param>
        /// <returns>DataGridViewTextBoxColumn</returns>
        public static DataGridViewTextBoxColumn generateDataGridTextBoxColumn(string name, string dataPropertyName, string HeaderTextt)
        {
            return new DataGridViewTextBoxColumn()
            {
                Name = name,
                DataPropertyName = dataPropertyName,
                HeaderText = HeaderTextt
            };
        }

        /// <summary>
        /// Form üzerindeki kontrollerin sıfırlanması işlemi
        /// </summary>
        /// <param name="controls"></param>
        public static void FormClear(Control controls=null)
        {
            foreach (var item in controls.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Clear();
                }
                else if (item is MaskedTextBox)
                {
                    (item as MaskedTextBox).Clear();
                }
                else if (item is Panel)
                {
                    FormClear(item as Panel);
                }
                else if (item is NumericUpDown)
                {
                    (item as NumericUpDown).Value = 0;
                }
                else if (item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = -1;
                }
                else if (item is CheckBox)
                {
                    ((CheckBox)item).Checked = false;
                }
                else if (item is GroupBox)
                {
                    FormClear(item as GroupBox);
                }
                else if (item is DateTimePicker)
                {
                    (item as DateTimePicker).Value = DateTime.Now;
                }

                //switch (item)
                //{
                //    case MaskedTextBox mt:
                //    case TextBox t:
                //        break;
                //}
            }
        }
    }
}

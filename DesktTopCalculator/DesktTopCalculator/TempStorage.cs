using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DesktTopCalculator
{
    internal class TempStorage
    {
        //KeepBoxの文字列の取得
        public string SelectResult(ListBox buttonkeep)
        {
            string selectedItem = buttonkeep.SelectedItem.ToString();

            // ＝のインデックスを検索
            int indexOfEquals = selectedItem.IndexOf("=");

            // ＝以降の文字列を取得
            string resultString = selectedItem.Substring(indexOfEquals + 1);

            return resultString;
        }
    }
}

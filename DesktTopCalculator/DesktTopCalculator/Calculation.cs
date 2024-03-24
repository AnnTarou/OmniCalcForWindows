using Dangl.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesktTopCalculator
{
    // 計算用のクラス
    public class Calculation
    {
        // 計算用の文字列を格納する
        public string? formula = "";
        // 結果を格納する文字列
        public string? resultnumber = "";

        // 計算用に文字列を変換させ、不適切な入力に対しエラーを出す
        public void Evaluate(string txt)
        {
            string str = txt.Replace(",", "");

            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '×':
                        formula += "*";
                        break;
                    case '÷':
                        formula += "/";
                        break;
                    default:
                        formula += str[i];
                        break;
                }
            }
            // 前括弧と後括弧の数が違う場合はエラー
            if (!(IsBalanced(formula)))
            {
                MessageBox.Show("The number of parentheses() doesn't match", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        // 前括弧と後括弧の数が同じか調べる
        public static bool IsBalanced(string f)
        {
            int openingCount = Regex.Matches(f, @"\(").Count;
            int closingCount = Regex.Matches(f, @"\)").Count;
            return openingCount == closingCount;
        }

        // 計算メソッド
        // https://docs.dangl-it.com/Projects/Dangl.Calculator/1.2.0/index.html
        public void Calculate()
        {
            try
            {
                var result = Calculator.Calculate(formula);
                resultnumber = result.Result.ToString();
            }
            catch
            {
                MessageBox.Show("Cannot be calculated", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}

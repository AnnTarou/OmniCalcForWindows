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

        // 計算用に文字列を変換
        public string Evaluate(string txt)
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
            return formula;
        }
        public bool CheckFormula(string formula)
        {
            // 演算子等が重ねて入力されている場合
            if(Regex.IsMatch(formula, @"[+\-\*\/\%\.]{2,20}"))
            {
                MessageBox.Show("formula is incorrect", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;               
            }
            // 演算子から文字列が始まる場合
            if (Regex.IsMatch(formula, @"^[\*\/\.\%\)]"))
            {
                MessageBox.Show("formula is incorrect", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            // 数字の中にピリオドが複数ある場合
            if (Regex.IsMatch(formula, @"\d*\.\d+\."))
            {
                MessageBox.Show("Check the number of periods", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            // 前括弧の直後に演算子やピリオド、後括弧がある場合
            if (Regex.IsMatch(formula, @"\((?=[+\-\*\/\.\)])"))
            {
                MessageBox.Show("formula is incorrect", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            // 後括弧の直後に数字またはピリオドがある場合
            if (Regex.IsMatch(formula, @"\)(?=[\d\%\.])"))
            {
                MessageBox.Show("formula is incorrect", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            // 括弧の数が均等でなかったら
            if(IsBalanced(formula) == false)
            {
                MessageBox.Show("formula is incorrect", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        // 前括弧と後括弧の数が同じか調べる
         static bool IsBalanced(string formula)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in formula)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    // 閉じ括弧が現れたが、対応する開き括弧がスタックにない場合
                    if (stack.Count == 0 )
                    { 
                        return false;
                    }
                    stack.Pop();
                }
            }
            // 最終的にスタックが空であれば、すべての開き括弧が閉じられている
           if(stack.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
         }
         // 計算メソッド
         public void Calculate()
        {
            var result = Calculator.Calculate(formula);
            resultnumber = result.Result.ToString();

        }
    }
}

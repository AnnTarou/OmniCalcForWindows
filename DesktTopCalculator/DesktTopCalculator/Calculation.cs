using Dangl.Calculator;
using System.Text.RegularExpressions;

namespace DesktTopCalculator
{
    // 計算用のクラス
    public class Calculation
    {
        // 計算用の文字列を格納する
        public string? formula = "";

        // 結果を格納する文字列
        public string resultnumber = "";

        // 計算用に文字列を変換
        public string? Evaluate(string txt)
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

        // 不正な計算式が入力されていないかチェックする
        public bool CheckFormula(string? formula)
        {
            // 計算式が空のとき
            if (formula == null)
            {
                return false;
            }
            else
            {
                // 数字の中にピリオドが複数あるとき
                if (Regex.IsMatch(formula, @"\d*\.\d+\."))
                {
                    // エラーメッセージを出し結果を返す
                    MessageBox.Show("Check the number of periods", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                // 括弧の数が均等でなかったら
                else if (IsBalanced(formula) == false)
                {
                    // エラーメッセージを出し結果を返す
                    MessageBox.Show("formula is incorrect", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

         // 前括弧と後括弧の数が同じか調べる
        static bool IsBalanced(string formula)
        {
                Stack<char> stack = new Stack<char>();

                foreach (char c in formula)
                {
                    // 前括弧が現れたらPush
                    if (c == '(')
                    {
                        stack.Push(c);
                    }
                    // 後括弧が現れたとき前括弧をPop
                    else if (c == ')')
                    {
                        // 閉じ括弧が現れたが、対応する開き括弧がスタックにない
                        if (stack.Count == 0)
                        {
                            return false;
                        }

                        stack.Pop();
                    }
                }
                // 最終的にスタックが空であれば、すべての括弧が閉じられている
                if (stack.Count == 0)
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
            // 文字列より計算
            var result = Calculator.Calculate(formula);

            // 結果を文字列に変換
            resultnumber = result.Result.ToString();
        }
    }
}

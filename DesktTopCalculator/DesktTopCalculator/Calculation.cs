using System.Text;
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
            // 可変長文字列を扱うためのStringBuilderクラスのインスタンス生成
            StringBuilder formulaBuilder = new StringBuilder();

            // 文字列の中のカンマを削除 
            string str = txt.Replace(",", "");

            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '×':
                        formulaBuilder.Append("*");
                        break;
                    case '÷':
                        formulaBuilder.Append("/");
                        break;
                    default:
                        formulaBuilder.Append(str[i]);
                        break;
                }
            }

            // 計算式をformulaへ格納
            formula = formulaBuilder.ToString();

            // 前括弧の直前が数字にマッチしたら*を挿入
            formula = Regex.Replace(formula, @"(\d)\(", "$1*(");

            // 文字列の先頭が＋の時は削除
            if (formula.StartsWith("+"))
            {
                formula = formula.Remove(0, 1);
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
                    MessageBox.Show("Check the number of periods", "Error:E-04",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formula = "";
                    return false;
                }
                // 数式の中に％があるとき
                else if (Regex.IsMatch(formula, @"\%"))
                {
                    // エラーメッセージを出し結果を返す
                    MessageBox.Show("Formula is invalid", "Error:E-05",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formula = "";
                    return false;
                }
                // マイナス,. の直後にマイナスがあるとき
                else if (Regex.IsMatch(formula, @"[\-\.](?=\-)"))
                {
                    // エラーメッセージを出し結果を返す
                    MessageBox.Show("Formula is invalid", "Error:E-06",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formula = "";
                    return false;
                }
                // 演算子,ピリオドに演算子のいづれかが重なるとき（マイナス以外）
                else if (Regex.IsMatch(formula, @"[\+\-\*\/\.](?=[\+\*\/])"))
                {
                    // エラーメッセージを出し結果を返す
                    MessageBox.Show("Formula is invalid", "Error:E-07",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formula = "";
                    return false;
                }
                // 前括弧の直後が*,/,.のとき
                else if (Regex.IsMatch(formula, @"\((?=[\*\/\.])"))
                {
                    // エラーメッセージを出し結果を返す
                    MessageBox.Show("Formula is invalid", "Error:E-08",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formula = "";
                    return false;
                }
                // 前括弧の直前が.のとき
                else if (Regex.IsMatch(formula, @"(?<=[\.])\("))
                {
                    // エラーメッセージを出し結果を返す
                    MessageBox.Show("Formula is invalid", "Error:E-09",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formula = "";
                    return false;
                }
                // 後括弧の直前が演算子,.,前括弧のとき
                else if (Regex.IsMatch(formula, @"(?<=[\+\-\*\/\.\(])\)"))
                {
                    // エラーメッセージを出し結果を返す
                    MessageBox.Show("Formula is invalid","Error:E-10",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formula = "";
                    return false;

                }
                // 先頭が×,÷,.,後括弧のとき
                else if (Regex.IsMatch(formula, @"^[\*\/\.\)]"))
                {
                    // エラーメッセージを出し結果を返す
                    MessageBox.Show("Formula is invalid", "Error:E-11",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formula = "";
                    return false;

                }
                // 括弧の数が均等でなかったら
                else if (IsBalanced(formula) == false)
                {
                    // エラーメッセージを出し結果を返す
                    MessageBox.Show("Unequal number of brackets", "Error:E-12",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formula = "";
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        // 前括弧と後括弧の数が同じか調べる
        public bool IsBalanced(string formula)
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
        public bool TryCalculate(string formula, out string resultnumber)
        {
            // 計算用文字列を逆ポーランド記法に変換
            List<string> rpn = ToRPN(formula);

            // 逆ポーランド記法が計算できないとき
            if (TryEvaluateRPN(rpn, out decimal rpnresult) == false)
            {
                // 0の除算を検出した場合
                if (rpnresult == 0)
                {
                    // エラーのメッセージボックス表示
                    MessageBox.Show("Division by 0 is not possible.", "Error:E-13",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formula = "";
                    resultnumber = "";
                    return false;
                }
                // 数値の変換に失敗した場合
                else if (rpnresult == -1)
                {
                    // エラーのメッセージボックス表示
                    MessageBox.Show("Formula is invalid", "Error:E-14",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formula = "";
                    resultnumber = "";
                    return false;

                }
                // 計算結果がdecimalの最大値を超える場合
                else if (rpnresult == -2)
                {
                    // エラーのメッセージボックス表示
                    MessageBox.Show("The result is too large", "Error:E-15",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formula = "";
                    resultnumber = "";
                    return false;
                }
                // 入力値がdecimal型に変換できない場合
                else if (rpnresult == -3)
                {
                    // エラーのメッセージボックス表示
                    MessageBox.Show("Input value is too large", "Error:E-16",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formula = "";
                    resultnumber = "";
                    return false;
                }
                else
                {
                    // エラーのメッセージボックス表示
                    MessageBox.Show("you get a critical hit", "Error:E-17",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formula = "";
                    resultnumber = "";
                    return false;
                }
            }
            else
            {
                resultnumber = rpnresult.ToString();
                formula = "";
                return true;
            }
        }

        // 文字列を逆ポーランド記法へ変換
        public List<string> ToRPN(string formula)
        {
            // 一時保管のスタックを作成
            Stack<string> stack = new Stack<string>();

            // 計算用のリストを作成
            List<string> output = new List<string>();

            // 計算式の分割
            // 「-で文字列が始まる」または「前括弧の直後に＋or-がある」または「演算子の後に-がある」数値、その他の場合は数値、演算子、括弧を分割
            var matches = Regex.Matches(formula, @"(^[\-]\d+\.?\d*)|((?<=\()[\+\-]\d+\.?\d*)|((?<=[\+\*\/])-\d+\.?\d*)|(\d+\.?\d*|\+|-|\*|/|\(|\))");
            List<string> tokens = matches.Cast<Match>().Select(m => m.Value).ToList();

            foreach (string token in tokens)
            {
                switch (token)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        // スタックが空でなく、スタックの先頭の演算子の方が優先順位が高いとき
                        while (stack.Count > 0 && Precedence(stack.Peek()) >= Precedence(token))
                        {
                            // スタックの先頭の演算子をリストへ出力
                            output.Add(stack.Pop());
                        }
                        stack.Push(token);
                        break;
                    case "(":
                        stack.Push(token);
                        break;
                    case ")":
                        // スタックの先頭が前括弧になるまでリストへ出力
                        while (stack.Peek() != "(")
                        {
                            output.Add(stack.Pop());
                        }
                        // 前括弧を破棄してbreak
                        stack.Pop();
                        break;
                    default:
                        output.Add(token);
                        break;
                }
            }

            // スタックが空になるまで演算子をリストへ出力
            while (stack.Count > 0)
            {
                output.Add(stack.Pop());
            }

            return output;
        }

        // 演算子の優先順位を返す
        static int Precedence(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                default:
                    return 0;
            }
        }

        // 逆ポーランド記法を計算して結果を返す
        public bool TryEvaluateRPN(List<string> output, out decimal result)
        {
            // 計算用のスタックを作成
            Stack<decimal> stack = new Stack<decimal>();

            // Popした値を格納する変数    
            decimal val1, val2;

            // 計算結果を格納する変数
            decimal ariresult;

            foreach (var token in output)
            {
                switch (token)
                {
                    case "+":
                        val2 = stack.Pop();
                        val1 = stack.Pop();
                        try
                        {
                            ariresult = val1 + val2;
                        }
                        // 計算結果がdecimalの最大値を超える場合falseを返す
                        catch (OverflowException e)
                        {
                            result = -2;
                            return false;
                        }
                        stack.Push(ariresult);
                        break;
                    case "-":
                        val2 = stack.Pop();
                        val1 = stack.Pop();
                        try
                        {
                            ariresult = val1 - val2;
                        }
                        // 計算結果がdecimalの最大値を超える場合falseを返す
                        catch (OverflowException e)
                        {
                            result = -2;
                            return false;
                        }
                        stack.Push(ariresult);
                        break;
                    case "*":
                        val2 = stack.Pop();
                        val1 = stack.Pop();
                        try
                        {
                            ariresult = val1 * val2;
                        }
                        // 計算結果がdecimalの最大値を超える場合falseを返す
                        catch(OverflowException e)
                        {
                            result = -2;
                            return false;
                        }
                        stack.Push(ariresult);
                        break;
                    case "/":
                        val2 = stack.Pop();
                        val1 = stack.Pop();
                        // 0での除算を検出した場合falseを返す
                        if (val2 == 0)
                        {
                            result = 0;
                            return false;
                        }
                        try
                        {
                            stack.Push(val1 / val2);

                        }
                        // 計算結果がdecimalの最大値を超える場合falseを返す
                        catch (OverflowException e)
                        {
                            result = -2;
                            return false;
                        }
                        break;
                    default:
                        try
                        {
                            stack.Push(decimal.Parse(token));
                        }
                        // decimalへの変換に失敗した場合falseを返す
                        catch (FormatException e)
                        {
                            result = -1;
                            return false;

                        }
                        // 数値がdecimalの最大値を超える場合falseを返す
                        catch (OverflowException e)
                        {
                            result = -3;
                            return false;
                        }
                        break;
                }
            }

            result = stack.Pop();

            // スタックが空でない場合falseを返す
            if (stack.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}


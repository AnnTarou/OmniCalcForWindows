using Antlr4.Runtime;
using System.Linq.Expressions;
using Dangl.Calculator;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;

namespace DesktTopCalculator
{
    public partial class Form1 : Form
    {
        //計算式を表示するテキストボックスの名前はDisplay
        //Keepした計算式を入れるリストボックスの名前はKeepBox

        //数字の入力は初めてか？
        //trueのとき"%, ),演算子"の入力不可、ピリオドは"0."とする
        //falseのときすべての入力可
        public bool firstflag = true;

        //数字の入力可否操作のため
        //このフラグがfalseのときは数字入力不可
        public bool canflag = true;

        //クリックされた値を格納するための文字列
        public string input = "";

        //inputされた数式を評価して格納するためのList
        List<string> expression;

        //計算メソッドクラスのオブジェクト
        Calc cl;
        public Form1()
        {
            InitializeComponent();
            cl = new Calc();
        }

        //------ここから各ボタンのイベントハンドラ-----------------

        //[0]を押したとき
        private void button0_Click(object sender, EventArgs e)
        {
            AddNumber("0");
            UpdateDisplay(input);           
        }
        //[1]を押したとき
        private void button1_Click(object sender, EventArgs e)
        {
            AddNumber("1");
            UpdateDisplay(input);
        }
        //[2]を押したとき
        private void button2_Click(object sender, EventArgs e)
        {
            AddNumber("2");
            UpdateDisplay(input);
        }
        //[3]を押したとき
        private void button3_Click(object sender, EventArgs e)
        {
            AddNumber("3");
            UpdateDisplay(input);
        }
        //[4]を押したとき
        private void button4_Click(object sender, EventArgs e)
        {
            AddNumber("4");
            UpdateDisplay(input);
        }
        //[5]を押したとき
        private void button5_Click(object sender, EventArgs e)
        {
            AddNumber("5");
            UpdateDisplay(input);
        }
        //[6]を押したとき
        private void button6_Click(object sender, EventArgs e)
        {
            AddNumber("6");
            UpdateDisplay(input);
        }
        //[7]を押したとき
        private void button7_Click(object sender, EventArgs e)
        {
            AddNumber("7");
            UpdateDisplay(input);
        }
        //[8]を押したとき
        private void button8_Click(object sender, EventArgs e)
        {
            AddNumber("8");
            UpdateDisplay(input);
        }
        //[9]を押したとき
        private void button9_Click(object sender, EventArgs e)
        {
            AddNumber("9");
            UpdateDisplay(input);
        }
        //[00]を押したとき
        private void button00_Click(object sender, EventArgs e)
        {
            AddNumber("00");
            UpdateDisplay(input);
        }
        //[.]を押したとき
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            AddPeriod(".");
            UpdateDisplay(input);
        }
        //[+]を押したとき
        private void buttonpuls_Click(object sender, EventArgs e)
        {
            AddOperator("+");
            UpdateDisplay(input);
        }
        //[-]を押したとき
        private void buttonminus_Click(object sender, EventArgs e)
        {
            AddOperator("-");
            UpdateDisplay(input);
        }
        //[×]を押したとき
        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            AddOperator("×");
            UpdateDisplay(input);
        }
        //[÷]を押したとき
        private void buttondivision_Click(object sender, EventArgs e)
        {
            AddOperator("÷");
            UpdateDisplay(input);
        }
        //[前括弧]を押したとき
        private void buttonfrontbracket_Click(object sender, EventArgs e)
        {
            AddFrontBracket("(");
            UpdateDisplay(input);
        }
        //[後括弧]を押したとき
        private void buttonbackbracket_Click(object sender, EventArgs e)
        {
            AddBackBracket(")");
            UpdateDisplay(input);
        }
        //[％]を押したとき
        private void buttonpercent_Click(object sender, EventArgs e)
        {
            AddPercent("%");
            UpdateDisplay(input);

        }
        //[＝]を押したとき
        private void buttonequal_Click(object sender, EventArgs e)
        {
            //計算のために文字列を新たに取得するメソッド
            cl.Evaluate(expression);
            //計算メソッド
            cl.Calculate();

            AddEqual("=", cl.resultnumber);
            UpdateDisplay(input);
        }
        //[delete]を押したとき
        private void buttonchardelete_Click(object sender, EventArgs e)
        {
            //Listに要素がある時、末尾を削除
            if (expression.Count > 0)
            {
                expression.RemoveAt(expression.Count - 1);
                Display.Text = string.Join("", expression);
            }
            //Listが空の時の処理
            else if (expression.Count == 0)
            {
                return;
            }
        }
        //[C]を押したとき
        private void buttonTextClear_Click(object sender, EventArgs e)
        {
            input = "";
            Display.Text = "";
            firstflag = true;
            canflag = true;
        }
        //[AC]を押したとき
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            input = "";
            Display.Text = "";
            //※Keepするために使用していた配列も削除する予定！！
            KeepBox.Text = "";
            firstflag = true;
            canflag = true;
        }
        // 数字を文字列inputへ追加し、Displayへ表示させるメソッド
        //※数値評価の時に0が先頭の場合を考慮する予定なのでここでは0の処理はせずに表示
        //※すなわち0123のような表記を許容する
        //※またピリオドの数も表記の時点では言及せず計算の時点でエラーメッセージを出す


        //数字を文字列inputへ追加
        public void AddNumber(string number)
        {
            if(canflag == false)
            {
                return;
            }
            else
            {
                input += number;
            }
            if (firstflag == true)
            {
                firstflag = false;
            }
            canflag = true;
        }

        // 演算子を文字列inputへ追加
        public void AddOperator(string ope)
        {
            //入力はじめまたは演算子が直前にある時
            if (firstflag == true)
            {
                return;
            }
            input += ope;
            firstflag = true;
            canflag = true;
        }

        //ピリオドを文字列inputへ追加
        public void AddPeriod(string period)
        {
            //コンマが先頭で押された場合
            if (firstflag == true)
            {
                input += "0.";
            }
            //直前にカンマがある場合
            else if (input[input.Length - 1] == '.')
            {
                return;
            }
            else
            {
                input += period;
            }
            firstflag = true;
            canflag = true;
        }
        //前括弧を文字列inputへ追加
        public void AddFrontBracket(string fb)
        {
            //直前にピリオドがある時
            if (input[input.Length - 1] == '.')
            {
                return;
            }
            //直前に")"または"%"がある時
            else if (canflag == false)
            {
                return;
            }
            //初めての入力でないとき
            else if (firstflag == false)
            {
                return;
            }
            else
            {
                input += fb;
            }
        }
        //後括弧を文字列inputへ追加
        public void AddBackBracket(string bb)
        {
            //数字のあとのみ入力可
            if (firstflag == false)
            {
                input += bb;
                //直後に数字を入力させない
                canflag = false;
            }
            else
            {
                return;
            }
        }
        //パーセントを文字列inputへ追加
        public void AddPercent(string p)
        {
            //入力はじめまたは演算子orピリオドが直前にある時
            if (firstflag == true)
            {
                return;
            }
            //直前に%がある時
            //canflag==falseにしていないのは後括弧の直後を許容するため
            else if (input[input.Length - 1] == '%')
            {
                return;
            }
            else
            {
                input += p;
                //直後に数字を入力させない
                canflag = false;
            }
        }
        //イコール以降を文字列inputへ追加
        public void AddEqual(string eql, string res)
        {
            input += (eql + res);
            //直後に数字を入力させない
            canflag = false;
        }

        //文字列inputを評価し数式としてListへ追加する
        public void UpdateDisplay(string inp)
        {
            //正規表現　\D+　数字以外の文字が1回以上続く部分で切り分けて格納。
            expression = Regex.Split(inp, @"(\D+)").ToList();

            for (int i = 0; i < expression.Count; i++)
            {
                //数字の時
                if (IsNumeric(expression[i]))
                {
                    decimal number = Convert.ToDecimal(expression[i]);
                    expression[i] = number.ToString("N0");
                }
                //ピリオドの数が不適切な時
                else if (ContainsMultiplePeriods(expression[i]))
                {
                    MessageBox.Show("(.)Incorrect number of periods", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }                
                //パーセントかつ直前が数字だった時
                else if (expression[i] == "%" && IsNumeric(expression[i - 1]))
                {
                    decimal number = Convert.ToDecimal(expression[i - 1]);
                    decimal answer = number * 0.01m;
                    expression[i - 1] = answer.ToString("#,##0.##########");
                    // % を削除する
                    expression.RemoveAt(i);
                    //inputの％を削除する
                    input = input.TrimEnd('%');
                    //inputに計算後の数値を入れなおす
                    input = string.Concat(expression.Select(item => item.Replace(",", "")));
                    // インデックスを戻す
                    i--;
                }
            }
            //Listの要素を文字列へ再度代入
            Display.Text = string.Concat(expression);            
        }

        //文字列が数値かを問う
        public static bool IsNumeric(string inp)
        {
           return decimal.TryParse(inp, out _);
        }
        //文字列の中にピリオドが2個以上含まれるかを問う
        public static bool ContainsMultiplePeriods(string inp)
        {
            // 数字の中にピリオドが2個以上含まれる正規表現パターン
            string pattern = @"\d+\.\d+\.\d+";

            // パターンにマッチするかどうかを確認
            return Regex.IsMatch(inp, pattern);
        }
    }

    //計算用のクラス
    public class Calc
    {
        //計算用の文字列を格納する
        public string? formula = "";
        //結果を格納する文字列
        public string? resultnumber = "";

    //計算用に文字列を変換させ、不適切な入力に対しエラーを出す
        public void Evaluate(List<string> list)
        {
           //計算用の文字列の作成
            foreach (var item in list)
            {
                switch (item)
                {
                    case "×":
                        formula += "*";                       
                        break;
                    case "÷":
                        formula += "/";
                        break;
                    default:
                        formula += item;
                        break;
                }
            }
            //前括弧と後括弧の数が違う場合はエラー
            if (!(IsBalanced(formula)))
            {
                MessageBox.Show("The number of parentheses() doesn't match", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }
        }
    //前括弧と後括弧の数が同じか調べる
        public static bool IsBalanced(string f)
    {
        int openingCount = Regex.Matches(f, @"\(").Count;
        int closingCount = Regex.Matches(f, @"\)").Count;
        return openingCount == closingCount;
    }

    //計算メソッド
    //https://docs.dangl-it.com/Projects/Dangl.Calculator/1.2.0/index.html
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

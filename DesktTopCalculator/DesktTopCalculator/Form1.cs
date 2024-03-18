using Antlr4.Runtime;
using System.Linq.Expressions;
using Dangl.Calculator;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesktTopCalculator
{
    public partial class Form1 : Form
    {
        //計算式を表示するテキストボックスの名前はDisplay
        //Keepした計算式を入れるリストボックスの名前はKeepBox

        //計算が終了したか？計算結果がでた時のみtrueになる
        public bool endflag = false;

        //inputされた数式を評価して格納するためのList
        List<string> expression;

        //計算メソッドクラスのオブジェクト
        Calc cl;

        //保存系メソッドクラスのオブジェクト
        KeepDate kd;

        public Form1()
        {
            InitializeComponent();
            cl = new Calc();
            kd = new KeepDate();
        }

        //------ここから各ボタンのイベントハンドラ-----------------

        //[0]を押したとき
        private void button0_Click(object sender, EventArgs e)
        {
            AddNumber("0");
            UpdateDisplay(Display.Text);           
        }
        //[1]を押したとき
        private void button1_Click(object sender, EventArgs e)
        {
            AddNumber("1");
            UpdateDisplay(Display.Text);
        }
        //[2]を押したとき
        private void button2_Click(object sender, EventArgs e)
        {
            AddNumber("2");
            UpdateDisplay(Display.Text);
        }
        //[3]を押したとき
        private void button3_Click(object sender, EventArgs e)
        {
            AddNumber("3");
            UpdateDisplay(Display.Text);
        }
        //[4]を押したとき
        private void button4_Click(object sender, EventArgs e)
        {
            AddNumber("4");
            UpdateDisplay(Display.Text);
        }
        //[5]を押したとき
        private void button5_Click(object sender, EventArgs e)
        {
            AddNumber("5");
            UpdateDisplay(Display.Text);
        }
        //[6]を押したとき
        private void button6_Click(object sender, EventArgs e)
        {
            AddNumber("6");
            UpdateDisplay(Display.Text);
        }
        //[7]を押したとき
        private void button7_Click(object sender, EventArgs e)
        {
            AddNumber("7");
            UpdateDisplay(Display.Text);
        }
        //[8]を押したとき
        private void button8_Click(object sender, EventArgs e)
        {
            AddNumber("8");
            UpdateDisplay(Display.Text);
        }
        //[9]を押したとき
        private void button9_Click(object sender, EventArgs e)
        {
            AddNumber("9");
            UpdateDisplay(Display.Text);
        }
        //[00]を押したとき
        private void button00_Click(object sender, EventArgs e)
        {
            AddNumber("00");
            UpdateDisplay(Display.Text);
        }
        //[.]を押したとき
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            // テキストボックスのカーソル位置を取得
            int cursorIndex = Display.SelectionStart;
            //演算子または前括弧が直前にあるまたは入力はじめの時
            if (Display.Text[cursorIndex - 1] == '+'
                || Display.Text[cursorIndex - 1] == '-'
                || Display.Text[cursorIndex - 1] == '×'
                || Display.Text[cursorIndex - 1] == '÷'
                || Display.Text[cursorIndex - 1] == '('
                || Display.Text.Length == 0)
            {
                AddPeriod("0.");
            }
            else
            {
                AddPeriod(".");
            }
            UpdateDisplay(Display.Text);
        }
        //[+]を押したとき
        private void buttonpuls_Click(object sender, EventArgs e)
        {
            AddOperator("+");
            UpdateDisplay(Display.Text);
        }
        //[-]を押したとき
        private void buttonminus_Click(object sender, EventArgs e)
        {
            AddOperator("-");
            UpdateDisplay(Display.Text);
        }
        //[×]を押したとき
        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            AddOperator("×");
            UpdateDisplay(Display.Text);
        }
        //[÷]を押したとき
        private void buttondivision_Click(object sender, EventArgs e)
        {
            AddOperator("÷");
            UpdateDisplay(Display.Text);
        }
        //[前括弧]を押したとき
        private void buttonfrontbracket_Click(object sender, EventArgs e)
        {
            AddFrontBracket("(");
            UpdateDisplay(Display.Text);
        }
        //[後括弧]を押したとき
        private void buttonbackbracket_Click(object sender, EventArgs e)
        {
            AddBackBracket(")");
            UpdateDisplay(Display.Text);
        }
        //[％]を押したとき
        private void buttonpercent_Click(object sender, EventArgs e)
        {
            AddPercent("%");
            UpdateDisplay(Display.Text);

        }
        //[＝]を押したとき
        private void buttonequal_Click(object sender, EventArgs e)
        {
            //計算のために文字列を新たに取得するメソッド
            cl.Evaluate(expression);
            //計算メソッド
            cl.Calculate();

            AddEqual("=", cl.resultnumber);
            UpdateDisplay(Display.Text);

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
            Display.Text = "";
        }
        //[AC]を押したとき
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            Display.Text = "";
            //※Keepするために使用していた配列も削除する予定！！
        }
        // 数字を文字列inputへ追加し、Displayへ表示させるメソッド
        //※数値評価の時に0が先頭の場合を考慮する予定なのでここでは0の処理はせずに表示
        //※すなわち0123のような表記を許容する
        //※またピリオドの数も表記の時点では言及せず計算の時点でエラーメッセージを出す


     //数字をDisplayへ追加
        public void AddNumber(string number)
        {
           // テキストボックスのカーソル位置を取得
           int cursorIndex = Display.SelectionStart;

            //直前が%か後括弧だった場合
            if (Display.Text[cursorIndex - 1] == '%' || Display.Text[cursorIndex - 1] == ')')
            {
                return;
            }
            // カーソルが末尾にある場合はテキストを末尾に追加
            else if (cursorIndex == Display.Text.Length)
            {
                Display.Text += number;
            }
            //Displayにカーソルがないとき末尾に追加
            else if (cursorIndex == -1)
            {
                Display.Text += number;
            }
            //それ以外の時はカーソルの後ろに追加
            else
            {
                Display.Text = Display.Text.Insert(cursorIndex, number);
            }
        }

     // 演算子を文字列inputへ追加
        public void AddOperator(string ope)
        {
            // テキストボックスのカーソル位置を取得
            int cursorIndex = Display.SelectionStart;

            //演算子または前括弧が直前にある時
            if (Display.Text[cursorIndex - 1] == '+'
                || Display.Text[cursorIndex - 1] == '-'
                || Display.Text[cursorIndex - 1] == '×'
                || Display.Text[cursorIndex - 1] == '÷'
                || Display.Text[cursorIndex - 1] == '(')
            {
                return;
            }
            //初めての入力の時
            else if(Display.Text.Length == 0)
            {
                return;
            }
            // カーソルが末尾にある場合はテキストを末尾に追加
            else if (cursorIndex == Display.Text.Length)
            {
                Display.Text += ope;
            }
            //Displayにカーソルがないとき末尾に追加
            else if (cursorIndex == -1)
            {
                Display.Text += ope;
            }
            //それ以外の時はカーソルの後ろに追加
            else
            {
                Display.Text = Display.Text.Insert(cursorIndex, ope);
            }
        }
    //ピリオドをDisplayへ追加
        public void AddPeriod(string period)
        {
            // テキストボックスのカーソル位置を取得
            int cursorIndex = Display.SelectionStart;

            //直前にカンマがある場合
            if (Display.Text[cursorIndex - 1] == '.' || Display.Text[cursorIndex - 1] == ')')
            {
                return;
            }
            // カーソルが末尾にある場合はテキストを末尾に追加
            else if (cursorIndex == Display.Text.Length)
            {
                Display.Text += period;
            }
            //Displayにカーソルがないとき末尾に追加
            else if (cursorIndex == -1)
            {
                Display.Text += period;
            }
            //それ以外の時はカーソルの後ろに追加
            else
            {
                Display.Text = Display.Text.Insert(cursorIndex, period);
            }
        }
     //前括弧をDisplayへ追加

        public void AddFrontBracket(string fb)
        {
            // テキストボックスのカーソル位置を取得
            int cursorIndex = Display.SelectionStart;

            //後括弧が直前にある時
            if ( Display.Text[cursorIndex - 1] == ')')
            {
                return;
            }
            // カーソルが末尾にある場合はテキストを末尾に追加
            else if (cursorIndex == Display.Text.Length)
            {
                Display.Text +=fb;
            }
            //Displayにカーソルがないとき末尾に追加
            else if (cursorIndex == -1)
            {
                Display.Text += fb;
            }
            //それ以外の時はカーソルの後ろに追加
            else
            {
                Display.Text = Display.Text.Insert(cursorIndex, fb);
            }
        }
        //後括弧を文字列Displayへ追加
        public void AddBackBracket(string bb)
        {
            // テキストボックスのカーソル位置を取得
            int cursorIndex = Display.SelectionStart;

            //数字のあとのみ入力可
            if (Char.IsDigit(Display.Text[cursorIndex - 1]))
            {
                 // カーソルが末尾にある場合はテキストを末尾に追加
                if (cursorIndex == Display.Text.Length)
                {
                    Display.Text += bb;
                }
                //Displayにカーソルがないとき末尾に追加
                else if (cursorIndex == -1)
                {
                    Display.Text += bb;
                }
                //それ以外の時はカーソルの後ろに追加
                else
                {
                    Display.Text = Display.Text.Insert(cursorIndex, bb);
                }
            }
            else
            {
                return;
            }
        
        }
     //パーセントを文字列Displayへ追加
        public void AddPercent(string p)
        {
            // テキストボックスのカーソル位置を取得
            int cursorIndex = Display.SelectionStart;

            //演算子または前括弧またはピリオドが直前にあるまたは入力はじめの時
            if (Display.Text[cursorIndex - 1] == '+'
                || Display.Text[cursorIndex - 1] == '-'
                || Display.Text[cursorIndex - 1] == '×'
                || Display.Text[cursorIndex - 1] == '÷'
                || Display.Text[cursorIndex - 1] == '('
                || Display.Text[cursorIndex - 1] == '.'
                || Display.Text[cursorIndex - 1] == '%'
                || Display.Text.Length == 0)
            {
                return;
            }
            // カーソルが末尾にある場合はテキストを末尾に追加
            else if (cursorIndex == Display.Text.Length)
            {
                Display.Text += p;
            }
            //Displayにカーソルがないとき末尾に追加
            else if (cursorIndex == -1)
            {
                Display.Text += p;
            }
            //それ以外の時はカーソルの後ろに追加
            else
            {
                Display.Text = Display.Text.Insert(cursorIndex, p);
            }
        }
        //イコール以降を文字列inputへ追加
        public void AddEqual(string eql, string res)
        {
            Display.Text += (eql + res);

        }

        //文字列inputを評価し数式としてListへ追加する
        public void UpdateDisplay(string txt)
        {
            //Displayのテキストを数値評価用に加工するために","を取り除いた形で文字列へ代入
            string input = txt.Replace(",", "");

            //正規表現　\D+　数字以外の文字が1回以上続く部分で切り分けて格納。
            expression = Regex.Split(txt, @"(\D+)").ToList();

            for (int i = 0; i < expression.Count; i++)
            {
                //数字の時
                if (IsNumeric(expression[i]))
                {
                    decimal number = Convert.ToDecimal(expression[i]);
                    expression[i] = number.ToString("N10");
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
    public class KeepDate
    {

    }














}

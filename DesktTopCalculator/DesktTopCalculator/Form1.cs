using Antlr4.Runtime;
using System.Linq.Expressions;
using Dangl.Calculator;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;

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


        // カーソルの位置を追跡するための変数
        public int cursorPosition = 0;

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
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("0");
            UpdateDisplay(Display.Text);
        }
        //[1]を押したとき
        private void button1_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("1");
            UpdateDisplay(Display.Text);
        }
        //[2]を押したとき
        private void button2_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("2");
            UpdateDisplay(Display.Text);
        }
        //[3]を押したとき
        private void button3_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("3");
            UpdateDisplay(Display.Text);
        }
        //[4]を押したとき
        private void button4_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("4");
            UpdateDisplay(Display.Text);
        }
        //[5]を押したとき
        private void button5_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("5");
            UpdateDisplay(Display.Text);
        }
        //[6]を押したとき
        private void button6_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("6");
            UpdateDisplay(Display.Text);
        }
        //[7]を押したとき
        private void button7_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("7");
            UpdateDisplay(Display.Text);
        }
        //[8]を押したとき
        private void button8_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("8");
            UpdateDisplay(Display.Text);
        }
        //[9]を押したとき
        private void button9_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("9");
            UpdateDisplay(Display.Text);
        }
        //[00]を押したとき
        private void button00_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
                return;
            }
            AddDisplay("00");
            UpdateDisplay(Display.Text);
        }
        //[.]を押したとき
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay(".");
            UpdateDisplay(Display.Text);
        }
        //[+]を押したとき
        private void buttonpuls_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            AddDisplay("+");
            UpdateDisplay(Display.Text);
        }
        //[-]を押したとき
        private void buttonminus_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            AddDisplay("-");
            UpdateDisplay(Display.Text);
        }
        //[×]を押したとき
        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            AddDisplay("×");
            UpdateDisplay(Display.Text);
        }
        //[÷]を押したとき
        private void buttondivision_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            AddDisplay("÷");
            UpdateDisplay(Display.Text);
        }
        //[前括弧]を押したとき
        private void buttonfrontbracket_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            AddDisplay("(");
            UpdateDisplay(Display.Text);
        }
        //[後括弧]を押したとき
        private void buttonbackbracket_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
                return;
            }
            AddDisplay(")");
            UpdateDisplay(Display.Text);
        }
        //[％]を押したとき
        private void buttonpercent_Click(object sender, EventArgs e)
        {

            if (endflag)
            {
                SelectResult();
                return;
            }
            AddDisplay("%");
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
            //Keep,AC,Cしかボタンを押せないようにする
            endflag = true;
        }
        //Displayがクリックされた時
        private void Display_Click(object sender, EventArgs e)
        {
            //カーソル位置を取得
            cursorPosition = Display.SelectionStart;
        }
        //Displayにキーダウンがあった時
        private void Display_KeyDown(object sender, KeyEventArgs e)
        {
            //カーソル位置を取得
            cursorPosition = Display.SelectionStart;
            //右矢印キーが押されたとき
            if (e.KeyCode == Keys.Right)
            {
                // カーソルがテキストボックスの末尾にない場合は、カーソルを右にずらす
                if (Display.SelectionStart < Display.Text.Length)
                {
                    Display.SelectionStart++;
                    Display.SelectionLength = 0;
                }
            }
        }
        //[delete]を押したとき
        private void buttonchardelete_Click(object sender, EventArgs e)
        {
            //カーソルがなく文字列がある場合末尾より削除
            if (cursorPosition == 0 && Display.Text.Length > 0)
            {
                Display.Text = Display.Text.Remove(Display.Text.Length - 1);
                UpdateDisplay(Display.Text);
            }
            // カーソルがある場合はカーソルの左側の文字を削除
            else if (cursorPosition > 0)
            {
                Display.Text = Display.Text.Remove(cursorPosition - 1, 1);
                UpdateDisplay(Display.Text);
            }
            //文字列がない場合
            else if ((cursorPosition <= 0) && (Display.Text.Length == 0))
            {
                return;
            }
        }
        //[C]を押したとき
        private void buttonTextClear_Click(object sender, EventArgs e)
        {
            ClearMethod();
        }
        //[AC]を押したとき
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            //※Keepするために使用していた配列も削除する予定！！
            ClearMethod();
        }
        //初期値に戻すメソッド
        public void ClearMethod()
        {
            //カーソルを非表示にする
            Cursor.Hide();

            // Displayのクリア
            Display.Clear();

            //Listのクリア
            expression.Clear();

            // イベントハンドラを削除
            Display.KeyDown -= Display_KeyDown;
            Display.Click -= Display_Click;

            //フィールド初期化            
            endflag = false;
            cursorPosition = 0;
        }

        // 数字を文字列inputへ追加し、Displayへ表示させるメソッド
        //※数値評価の時に0が先頭の場合を考慮する予定なのでここでは0の処理はせずに表示
        //※すなわち0123のような表記を許容する
        //※またピリオドの数も表記の時点では言及せず計算の時点でエラーメッセージを出す

        //数字をDisplayへ追加
        public void AddDisplay(string buttonText)
        {
            Display.Text = Display.Text.Insert(cursorPosition, buttonText);
            // カーソル位置を挿入した後の位置に移動
            cursorPosition += buttonText.Length;
            // テキストボックスのフォーカスを設定し、カーソルを表示
            Display.Focus();
            Display.SelectionStart = cursorPosition;
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
        //計算結果から＝以降の文字列を取得しDisplayへ追加する
        public void SelectResult()
        {
            // ＝のインデックスを取得
            int index = Display.Text.IndexOf("=");

            // ＝が見つかった場合、その位置以降の部分文字列を取得
            if (index != -1)
            {
                // ＝の位置以降の部分文字列を取得
                string selectresult = Display.Text.Substring(index + 1);
                //リセット
                ClearMethod();
                //数値としてDisplayへ追加
                AddDisplay(selectresult);
            }
        }

        private void buttonKeep_Click(object sender, EventArgs e)
        {
            if(endflag == true)
            {
                KeepBox.Items.Add(Display.Text);
            }
            else
            {
                return;
            }
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

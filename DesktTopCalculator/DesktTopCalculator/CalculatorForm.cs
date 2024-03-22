using Antlr4.Runtime;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;

namespace DesktTopCalculator
{
    public partial class CalculatorForm : Form
    {
        //計算式を表示するテキストボックスの名前はDisplay
        //Keepした計算式を入れるリストボックスの名前はKeepBox

        //計算が終了したか？計算結果がでた時のみtrueになる
        public bool endflag = false;

        // カーソルの位置を追跡するための変数
        public int cursorposition = 0;

        //計算メソッドクラスのオブジェクト
        Calculation cl;

        //保存系メソッドクラスのオブジェクト
        TempStorage ts;

        public CalculatorForm()
        {
            InitializeComponent();
            cl = new Calculation();
            ts = new TempStorage();
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
            //計算結果が出た後にイコールが押された場合
            if (endflag)
            {
                return;
            }
            else
            {
                //計算のために文字列を新たに取得するメソッド
                cl.Evaluate(Display.Text);
                //計算メソッド
                cl.Calculate();

                AddEqual("=", cl.resultnumber);
                UpdateDisplay(Display.Text);
                //Keep,AC,Cしかボタンを押せないようにする
                endflag = true;
            }
        }
        //Displayがクリックされた時
        private void Display_Click(object sender, EventArgs e)
        {
            //カーソル位置を取得
            cursorposition = Display.SelectionStart;
        }
        //Displayにキーダウンがあった時
        private void Display_KeyDown(object sender, KeyEventArgs e)
        {
            //カーソル位置を取得
            cursorposition = Display.SelectionStart;
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
            //カーソル位置を取得
            cursorposition = Display.SelectionStart;

            //計算結果が出た後は何もしない
            if (endflag)
            {
                return;
            }
            //カーソル位置が0で文字列がある場合
            else if (cursorposition == 0 && Display.Text.Length > 0)
            {
                return;
            }
            //文字列がない場合
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // カーソルがある場合
            else if (cursorposition > 0)
            {
                //カーソルの左側一文字削除
                Display.Text = Display.Text.Remove(cursorposition - 1, 1);
                //Displayへ表示
                UpdateDisplay(Display.Text);
                //カーソルの位置を再度取得
                cursorposition -= 1;
                // テキストボックスのフォーカスを設定し、カーソルを表示
                Display.Focus();
            }
        }
        //[C]を押したとき
        private void buttonTextClear_Click(object sender, EventArgs e)
        {
            //Displayとフィールドの初期化
            ClearMethod();
        }
        //[AC]を押したとき
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            //Displayとフィールドの初期化
            ClearMethod();
            //KeepBoxの初期化
            KeepBox.Items.Clear();
        }
        //Keepボタンをクリックしたとき
        private void buttonKeep_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                KeepBox.Items.Add(Display.Text);
            }
            else
            {
                return;
            }
        }
        //Keepボタンをダブルクリックした時⇒Displayへ追加
        private void KeepBox_DoubleClick(object sender, EventArgs e)
        {
            if (KeepBox.SelectedItem == null)
            {
                return;
            }
            else if (Display.Text.Contains("="))
            {
                //Displayとフィールドの初期化
                ClearMethod();

                // DisplayにKeepの回答部分のみ追加
                AddDisplay(ts.SelectResult(KeepBox));
                UpdateDisplay(Display.Text);
            }
            else
            {
                // DisplayにKeepの回答部分のみ追加
                AddDisplay(ts.SelectResult(KeepBox));
                UpdateDisplay(Display.Text);
            }
        }
        //KeepBoxの削除ボタンが押されたとき
        private void このリストの削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KeepBox.SelectedItem != null)
            {
                KeepBox.Items.Remove(KeepBox.SelectedItem);
            }

        }
        //初期値に戻すメソッド
        public void ClearMethod()
        {
            // Displayのクリア
            Display.Clear();

            //フィールド初期化            
            endflag = false;
            cursorposition = 0;
            cl.formula = "";
        }
        //ボタンのテキストをDisplayへ追加
        public void AddDisplay(string buttonText)
        {
            //カーソルの位置を取得
            cursorposition = Display.SelectionStart;
            //カーソル位置の直後にボタンテキストを追加
            Display.Text = Display.Text.Insert(cursorposition, buttonText);
            // カーソル位置を挿入したテキストの後ろへ移動
            cursorposition += buttonText.Length;
            // テキストボックスのフォーカスを設定し、カーソルを表示
            Display.Focus();           
        }

        //イコール以降を文字列inputへ追加
        public void AddEqual(string eql, string res)
        {
            Display.Text += (eql + res);

        }
        //文字列を適切な形に変換してDisplayへ表示
        public void UpdateDisplay(string txt)
        {
            //Displayのテキストを数値評価用に加工するために","を取り除いた形で文字列へ代入
            string input = txt.Replace(",", "");

            //正規表現　\D+　数字以外の文字が1回以上続く部分で切り分けて格納。
            List<string> expression = Regex.Split(txt, @"(\D+)").ToList();

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
    }
}

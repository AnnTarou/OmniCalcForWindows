using Antlr4.Runtime;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlTypes;

namespace DesktTopCalculator
{
    public partial class CalculatorForm : Form
    {
        // 計算式を表示するテキストボックスの名前はDisplay
        // Keepした計算式を入れるリストボックスの名前はKeepBox

        // 計算が終了したか？計算結果がでた時のみtrueになる
        public bool endflag = false;

        // カーソルの位置を追跡するための変数
        public int cursorposition = 0;

        // 計算メソッドクラスのオブジェクト
        Calculation cl;

        // 保存系メソッドクラスのオブジェクト
        TempStorage ts;

        public CalculatorForm()
        {
            InitializeComponent();
            cl = new Calculation();
            ts = new TempStorage();
            ts.PushInitialValue();
        }

        //------ここから各ボタンのイベントハンドラ-----------------

        // [0]を押したとき
        private void button0_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            else if (Display.Text.Length > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }
            AddDisplay("0");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);

        }
        // [1]を押したとき
        private void button1_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            else if (Display.Text.Length > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }
            AddDisplay("1");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [2]を押したとき
        private void button2_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            else if (Display.Text.Length > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }
            AddDisplay("2");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [3]を押したとき
        private void button3_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            else if (Display.Text.Length > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }
            AddDisplay("3");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [4]を押したとき
        private void button4_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            else if (Display.Text.Length > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }
            AddDisplay("4");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [5]を押したとき
        private void button5_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            else if (Display.Text.Length > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }
            AddDisplay("5");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [6]を押したとき
        private void button6_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            else if (Display.Text.Length > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }
            AddDisplay("6");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [7]を押したとき
        private void button7_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            else if (Display.Text.Length > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }
            AddDisplay("7");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [8]を押したとき
        private void button8_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            else if (Display.Text.Length > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }
            AddDisplay("8");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [9]を押したとき
        private void button9_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            else if (Display.Text.Length > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }
            AddDisplay("9");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [00]を押したとき
        private void button00_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
                return;
            }
            else if ((Display.Text.Length == 0)|| (Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\(\)\%]")))
            {
                return;
            }
            else
            {
                AddDisplay("00");
                UpdateDisplay(Display.Text);
                ts.TempStack(Display.Text, cursorposition);
            }
        }
        // [.]を押したとき
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
                AddDisplay(".");
                UpdateDisplay(Display.Text);
                ts.TempStack(Display.Text, cursorposition);
            }
            else if ((Display.Text.Length == 0) || (Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\(]")))
            {
                AddDisplay("0.");
                UpdateDisplay(Display.Text);
                ts.TempStack(Display.Text, cursorposition);
            }
            else if (Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\.\%\)]"))
            {
                return;
            }
            else
            {
                AddDisplay(".");
                UpdateDisplay(Display.Text);
                ts.TempStack(Display.Text, cursorposition);
            }
        }
        // [+]を押したとき
        private void buttonpuls_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            else if (Display.Text.Length == 0)
            {
                return;
            }
            else if (Regex.IsMatch(Display.Text[cursorposition-1].ToString() , @"[\+\-\u00D7\u00F7\(\.\%]"))
            {
                return;
            }
            AddDisplay("+");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [-]を押したとき
        private void buttonminus_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            else if (Display.Text.Length > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\(\.\%]"))
            {
                return;
            }
            AddDisplay("-");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [×]を押したとき
        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            else if (Display.Text.Length == 0)
            {
                return;
            }
            else if (Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\(\.\%]"))
            {
                return;
            }
            AddDisplay("×");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        
        }
        // [÷]を押したとき
        private void buttondivision_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            else if (Display.Text.Length == 0)
            {
                return;
            }
            else if (Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\(\.\%]"))
            {
                return;
            }
            AddDisplay("÷");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [前括弧]を押したとき
        private void buttonfrontbracket_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            else if (Display.Text.Length > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\.\%]"))
            {
                return;
            }
            AddDisplay("(");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [後括弧]を押したとき
        private void buttonbackbracket_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
                return;
            }
            else if (Display.Text.Length == 0)
            {
                return;
            }
            else if (Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"\D"))
            {
                return;
            }
            else
            {
                AddDisplay(")");
                UpdateDisplay(Display.Text);
                ts.TempStack(Display.Text, cursorposition);
            }
        }
        // [％]を押したとき
        private void buttonpercent_Click(object sender, EventArgs e)
        {

            if (endflag)
            {
                SelectResult();
            }
            else if(Display.Text.Length == 0) 
            {
                return;            
            }
            else if (Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"\D"))
            {
                return;
            }
            AddDisplay("%");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [＝]を押したとき
        private void buttonequal_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後にイコールが押された場合
            if (endflag)
            {
                return;
            }
            else
            {
                // 数式評価でエラーがなければ
                if (cl.CheckFormula(cl.Evaluate(Display.Text)))
                {
                    // 計算メソッド
                    cl.Calculate();

                    if (cl.resultnumber == "NaN" || cl.resultnumber == "∞" || string.IsNullOrEmpty(cl.resultnumber))
                    {
                        MessageBox.Show("Can't calculate", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        AddEqual("=", cl.resultnumber);
                        UpdateDisplay(Display.Text);
                        // Keep,AC,Cしかボタンを押せないようにする
                        endflag = true;
                    }
                }
                else
                {
                    return;
                }
            }
        }
        // Displayがクリックされた時
        private void Display_Click(object sender, EventArgs e)
        {
            // カーソル位置を取得
            cursorposition = Display.SelectionStart;
        }
        // Displayにキーダウンがあった時
        private void Display_KeyDown(object sender, KeyEventArgs e)
        {
            // 右矢印キーが押されたとき
            if (e.KeyCode == Keys.Right)
            {
                // カーソルがテキストボックスの末尾にない場合は、カーソルを右にずらす
                if (Display.SelectionStart < Display.Text.Length)
                {
                    cursorposition++;
                }
            }
            // 左矢印キーが押されたとき
            else if (e.KeyCode == Keys.Left)
            {
                // カーソルがテキストボックスの先頭にない場合は、カーソルを左にずらす
                if (Display.SelectionStart != 0)
                {
                    cursorposition--;
                }
            }
        }
        // [delete]を押したとき
        private void buttonchardelete_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後は何もしない
            if (endflag)
            {
                return;
            }
            // カーソル位置が0で文字列がある場合
            else if (cursorposition == 0 && Display.Text.Length > 0)
            {
                return;
            }
            // 文字列がない場合
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // カーソルがある場合
            else if (cursorposition > 0)
            {
                // カーソルの左側一文字削除
                Display.Text = Display.Text.Remove(cursorposition - 1, 1);
                // カーソルの位置を再度取得
                cursorposition -= 1;
                // Displayへ表示
                UpdateDisplay(Display.Text);
                ts.TempStack(Display.Text, cursorposition);
            }
        }
        // [return]を押したとき
        private void buttonreturn_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後は何もしない
            if (endflag)
            {
                return;
            }
            // スタックが実質空の時
            else if (ts.storageStack.Count==1 || ts.storageStackIndex.Count == 1)
            {
                return;
            }
            // スタックに要素がある場合はそれぞれの値を取り出して代入
            else
            {
                Display.Text = ts.PopDisplayText();
                cursorposition = ts.PopCursoulPosition();
                // 元に戻した後のDisplay.Textとカーソル位置をスタックへ積む
                ts.TempStack(Display.Text, cursorposition);
            }
            
        }
        // [C]を押したとき
        private void buttonTextClear_Click(object sender, EventArgs e)
        {
            // Displayとフィールドの初期化
            ClearMethod();
        }
        // [AC]を押したとき
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            // Displayとフィールドの初期化
            ClearMethod();
            // KeepBoxの初期化
            KeepBox.Items.Clear();
        }
        // Keepボタンをクリックしたとき
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
        // Keepボタンをダブルクリックした時⇒Displayへ追加
        private void KeepBox_DoubleClick(object sender, EventArgs e)
        {
            if (KeepBox.SelectedItem == null)
            {
                return;
            }
            else if (Display.Text.Contains("="))
            {
                // Displayとフィールドの初期化
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
        // KeepBoxの削除ボタンが押されたとき
        private void このリストの削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KeepBox.SelectedItem != null)
            {
                KeepBox.Items.Remove(KeepBox.SelectedItem);
            }
            else
            {
                return;
            }

        }
        // 初期値に戻すメソッド
        public void ClearMethod()
        {
            // Displayのクリア
            Display.Clear();

            // フィールド初期化            
            endflag = false;
            cursorposition = 0;
            cl.formula = "";

            //スタックのクリア
            ts.ClearStack();
            // スタックの初期化
            ts.PushInitialValue();
        }
        // ボタンのテキストをDisplayへ追加
        public void AddDisplay(string buttonText)
        {
            // カーソル位置の直後にボタンテキストを追加
            Display.Text = Display.Text.Insert(cursorposition, buttonText);

           // カーソル位置を挿入したテキストの後ろへ移動
                cursorposition += buttonText.Length;
        }

        // イコール以降を文字列inputへ追加
        public void AddEqual(string eql, string res)
        {
            Display.Text += (eql + res);

        }
        // 文字列を適切な形に変換してDisplayへ表示
        public void UpdateDisplay(string txt)
        {
            // 現在のカーソル位置より後ろの文字列数を取得
            int aftercursolstr = Display.Text.Substring(cursorposition).Length;

            // Displayのテキストを数値評価用に加工するために","を取り除いた形で文字列へ代入
            string input = txt.Replace(",", "");

            // 正規表現 数字が1回以上続く部分で切り分けて格納。
            List<string> expression = Regex.Split(input, @"([^\d\.]+)").ToList();

                for (int i = 0; i < expression.Count; i++)
                {
                    // 数字の時
                    if (IsNumeric(expression[i]))
                    {
                        // 文字列にピリオドが含まれていたら
                        if (expression[i].Contains('.'))
                        {
                            // 文字列の中で一番めのピリオドの位置を確認
                            int index = expression[i].IndexOf('.');
                            // ピリオドの前の文字列を取得
                            string beforepiriod = expression[i].Substring(0, index);
                            // ピリオドの前の文字列を三桁区切りへ変換したものとピリオド以降を足して文字列を作成
                            expression[i] = Regex.Replace(beforepiriod, @"(\d{1,3})(?=(\d{3})+(?!\d))", "$1,")+ expression[i].Substring(index);
                        }
                        else
                        {
                            expression[i] = Regex.Replace(expression[i], @"(\d{1,3})(?=(\d{3})+(?!\d))", "$1,");
                        }
                    }
                    // パーセントかつ直前が数字だった時
                    else if (expression[i] == "%" && IsNumeric(expression[i - 1]))
                    {
                        decimal number = Convert.ToDecimal(expression[i - 1]);
                        decimal answer = number * 0.01m;
                        expression[i - 1] = answer.ToString("#,##0.############");
                        expression.RemoveAt(i);
                        // 計算後の文字列の長さから計算前の文字列の長さを引いた数分カーソル位置を移動
                        cursorposition += (expression[i - 1].Length -cursorposition);
                    }
                }

            // Listの要素を文字列へ再度代入
            Display.Text = string.Concat(expression);
            // 変換前のカーソルの後の文字列が変換後の文字列と変わっていた場合
            if(aftercursolstr != Display.Text.Substring(cursorposition).Length)
            {
                cursorposition += (Display.Text.Substring(cursorposition).Length - aftercursolstr);
            }
        }

        // 文字列が数値かを問う
        public static bool IsNumeric(string inp)
        {
            return decimal.TryParse(inp, out _);
        }

        // 計算結果から＝以降の文字列を取得しDisplayへ追加する
        public void SelectResult()
        {
            // ＝のインデックスを取得
            int index = Display.Text.IndexOf("=");

            // ＝が見つかった場合、その位置以降の部分文字列を取得
            if (index != -1)
            {
                // ＝の位置以降の部分文字列を取得
                string selectresult = Display.Text.Substring(index + 1);
                // リセット
                ClearMethod();
                // 数値としてDisplayへ追加
                AddDisplay(selectresult);
            }
        }
    }
}

using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace DesktTopCalculator
{
    public partial class CalculatorForm : Form
    {
        // 計算結果がでた時のみtrueになる
        public bool endflag = false;

        // カーソルの位置を追跡するための変数
        public int cursorposition = 0;

        // 計算メソッドクラスのオブジェクト
        Calculation cl;

        // 保存系メソッドクラスのオブジェクト
        TempStorage ts;

        // フォームのコンストラクター
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
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 初期化
                ClearMethod();
            }
            // カーソル位置の前の文字が後括弧もしくは%のとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("0");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);

        }

        // [1]を押したとき
        private void button1_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 初期化
                ClearMethod();
            }
            // カーソル位置の前の文字が後括弧もしくは%のとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("1");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);
        }

        // [2]を押したとき
        private void button2_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 初期化
                ClearMethod();
            }
            // カーソル位置の前の文字が後括弧もしくは%のとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }


            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("2");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);
        }

        // [3]を押したとき
        private void button3_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 初期化
                ClearMethod();
            }
            // カーソル位置の前の文字が後括弧もしくは%のとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("3");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);
        }

        // [4]を押したとき
        private void button4_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 初期化
                ClearMethod();
            }
            // カーソル位置の前の文字が後括弧もしくは%のとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("4");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);
        }

        // [5]を押したとき
        private void button5_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 初期化
                ClearMethod();
            }
            // カーソル位置の前の文字が後括弧もしくは%のとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("5");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);
        }

        // [6]を押したとき
        private void button6_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 初期化
                ClearMethod();
            }
            // カーソル位置の前の文字が後括弧もしくは%のとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("6");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);
        }

        // [7]を押したとき
        private void button7_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 初期化
                ClearMethod();
            }
            // カーソル位置の前の文字が後括弧もしくは%のとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("7");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);
        }

        // [8]を押したとき
        private void button8_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 初期化
                ClearMethod();
            }
            // カーソル位置の前の文字が後括弧もしくは%のとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("8");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);
        }

        // [9]を押したとき
        private void button9_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 初期化
                ClearMethod();
            }
            // カーソル位置の前の文字が後括弧もしくは%のとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("9");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);
        }

        // [00]を押したとき
        private void button00_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 初期化
                ClearMethod();
                return;
            }
            // 入力はじめのとき
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // カーソル位置の前の文字が(+,-,×,÷,括弧,%)いずれかのとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\(\)\%]"))
            {
                return;
            }
            else
            {
                // 各処理をしてDisplayにテキストとして表示
                AddDisplay("00");
                UpdateDisplay(Display.Text);

                // StackへDisplayのテキストとカーソル位置をPush
                ts.TempStack(Display.Text, cursorposition);
            }
        }

        // [.]を押したとき
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 初期化
                ClearMethod();

                // 各処理をしてDisplayにテキストとして表示
                AddDisplay("0.");
                UpdateDisplay(Display.Text);

                // StackへDisplayのテキストとカーソル位置をPush
                ts.TempStack(Display.Text, cursorposition);

            }
            // 入力はじめのとき
            else if (Display.Text.Length == 0)
            {
                // 各処理をしてDisplayにテキストとして表示
                AddDisplay("0.");
                UpdateDisplay(Display.Text);

                // StackへDisplayのテキストとカーソル位置をPush
                ts.TempStack(Display.Text, cursorposition);
            }
            // カーソル位置の前の文字が(+,-,×,÷,前括弧)いずれかのとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\(]"))
            {
                // 各処理をしてDisplayにテキストとして表示
                AddDisplay("0.");
                UpdateDisplay(Display.Text);

                // StackへDisplayのテキストとカーソル位置をPush
                ts.TempStack(Display.Text, cursorposition);
            }
            // カーソル位置の前の文字が(.,%,後括弧)いずれかのとき
            else if (cursorposition > 0　&& Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\.\%\)]"))
            {
                return;
            }
            else
            {
                // 各処理をしてDisplayにテキストとして表示
                AddDisplay(".");
                UpdateDisplay(Display.Text);

                // StackへDisplayのテキストとカーソル位置をPush
                ts.TempStack(Display.Text, cursorposition);
                
            }
        }

        // [+]を押したとき
        private void buttonpuls_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 計算結果の数字部分のみを切りだしDisplayへ表示
                SelectResult();
            }
            // 入力はじめのとき
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // カーソル位置の前の文字が(+,-,×,÷.,%)いずれかのとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\.\%]"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("+");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);
        }

        // [-]を押したとき
        private void buttonminus_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 計算結果の数字部分のみを切りだしDisplayへ表示
                SelectResult();
            }
            // カーソル位置の前の文字が(+,-,×,÷,.,%)いずれかのとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\.\%]"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("-");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);
        }

        // [×]を押したとき
        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 計算結果の数字部分のみを切りだしDisplayへ表示
                SelectResult();
            }
            // 入力はじめのとき
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // カーソル位置の前の文字が(+,-,×,÷,前括弧,.,%)いずれかのとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\(\.\%]"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("×");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);
        }

        // [÷]を押したとき
        private void buttondivision_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 計算結果の数字部分のみを切りだしDisplayへ表示
                SelectResult();
            }
            // 入力はじめのとき
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // カーソル位置の前の文字が(+,-,×,÷,前括弧,.,%)いずれかのとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\(\.\%]"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("÷");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);

        }

        // [前括弧]を押したとき
        private void buttonfrontbracket_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 初期化
                ClearMethod();
            }
            // カーソル位置の前の文字が(後括弧,.,%)いずれかのとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\.\%]"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("(");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);
        }

        // [後括弧]を押したとき
        private void buttonbackbracket_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 計算結果の数字部分のみを切りだしDisplayへ表示
                SelectResult();
                return;
            }
            // 入力はじめのとき
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // カーソル位置の前の文字が数字以外のとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"\D"))
            {
                return;
            }
            else
            {
                // 各処理をしてDisplayにテキストとして表示
                AddDisplay(")");
                UpdateDisplay(Display.Text);

                // StackへDisplayのテキストとカーソル位置をPush
                ts.TempStack(Display.Text, cursorposition);
            }
        }

        // [％]を押したとき
        private void buttonpercent_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                // 計算結果の数字部分のみを切りだしDisplayへ表示
                SelectResult();
            }
            // 入力はじめのとき
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // カーソル位置の前の文字が数字以外のとき
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"\D"))
            {
                return;
            }

            // 各処理をしてDisplayにテキストとして表示
            AddDisplay("%");
            UpdateDisplay(Display.Text);

            // StackへDisplayのテキストとカーソル位置をPush
            ts.TempStack(Display.Text, cursorposition);
        }

        // [＝]を押したとき
        private void buttonequal_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                return;
            }
            // Displayの文字が2文字以下のとき
            else if (Display.Text.Length <= 2)
            {
                return;
            }
            // 文字列があり、Displayの最後の文字が(+,-,×,÷,前括弧,.,%)のとき
            else if (!string.IsNullOrEmpty(Display.Text) && Regex.IsMatch(Display.Text[Display.Text.Length - 1].ToString(), @"[\+\-\u00D7\u00F7\(\.\%]"))
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

                    // 計算不能、計算結果∞、結果空文字のとき
                    if (cl.resultnumber == "NaN" || cl.resultnumber == "∞" || string.IsNullOrEmpty(cl.resultnumber))
                    {
                        // エラーのメッセージボックス表示
                        MessageBox.Show("Can't calculate", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        // イコール以下を処理してDisplayへ表示
                        AddEqual("=", cl.resultnumber);
                        UpdateDisplay(Display.Text);

                        // 計算が終了したフラグを立てる
                        endflag = true;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        // [Display]を押したとき
        private void Display_Click(object sender, EventArgs e)
        {
            // カーソル位置を取得
            cursorposition = Display.SelectionStart;
        }

        // [Display]にキーダウンがあった時
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
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                return;
            }
            // カーソル位置が0のとき
            else if (cursorposition == 0)
            {
                return;
            }
            // 文字列がないとき
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // カーソルがある場合
            else if (cursorposition > 0)
            {
                // カーソルの直前の文字がカンマのとき
                if (Display.Text[cursorposition -1] == ',')
                {
                    // カーソルの左側二文字削除
                    Display.Text = Display.Text.Remove(cursorposition - 2, 2);

                    // カーソルの位置を2つずらす
                    cursorposition -= 2;

                    // Displayへ表示
                    UpdateDisplay(Display.Text);

                    // StackへDisplayのテキストとカーソル位置をPush
                    ts.TempStack(Display.Text, cursorposition);

                }
                else
                {
                    // カーソルの左側一文字削除
                    Display.Text = Display.Text.Remove(cursorposition - 1, 1);

                    // カーソルの位置を1つずらす
                    cursorposition--;

                    // Displayへ表示
                    UpdateDisplay(Display.Text);

                    // StackへDisplayのテキストとカーソル位置をPush
                    ts.TempStack(Display.Text, cursorposition);

                }               
            }
        }

        // [return]を押したとき
        private void buttonreturn_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                return;
            }
            // スタックが実質空のとき
            else if (ts.storageStack.Count == 1 || ts.storageStackIndex.Count == 1)
            {
                return;
            }
            // スタックに要素があるとき
            else
            {
                // スタックの2番目のDisplayテキストとカーソル位置を代入
                Display.Text = ts.PopDisplayText();
                cursorposition = ts.PopCursoulPosition();

                // 元に戻した後のDisplay.Textとカーソル位置をスタックへ積む
                ts.TempStack(Display.Text, cursorposition);
            }
        }

        // [C]を押したとき
        private void buttonTextClear_Click(object sender, EventArgs e)
        {
            // Displayとメンバー変数の初期化
            ClearMethod();
        }

        // [AC]を押したとき
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            // Displayとメンバー変数の初期化
            ClearMethod();

            // KeepBoxの初期化
            KeepBox.Items.Clear();
        }

        // [Keep]を押したとき
        private void buttonKeep_Click(object sender, EventArgs e)
        {
            // 計算結果が出た後に押されたとき
            if (endflag)
            {
                KeepBox.Items.Add(Display.Text);
            }
            else
            {
                return;
            }
        }

        // [KeepBox]をダブルクリックしたとき
        private void KeepBox_DoubleClick(object sender, EventArgs e)
        {
            // KeepBoxが空のとき
            if (KeepBox.SelectedItem == null)
            {
                return;
            }
            // 計算結果が出た後に押されたとき
            else if (endflag)
            {
                // Displayとフィールドの初期化
                ClearMethod();

                // DisplayにKeepの回答部分のみ追加
                AddDisplay(ts.SelectResult(KeepBox));
                UpdateDisplay(Display.Text);
            }
            // 計算式入力途中の時
            else
            {
                // カーソル位置の前の文字が後括弧もしくは%もしくはピリオドのとき
                if (Display.Text.Length > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%\.]"))
                {
                    return;
                }
                // DisplayにKeepの回答部分のみ追加
                else
                {
                    // KeepBoxの回答部分をDisplayへ追加
                    AddDisplay(ts.SelectResult(KeepBox));
                    UpdateDisplay(Display.Text);
                }
            }
        }

        // KeepBoxの削除ボタンが押されたとき
        private void このリストの削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // KeepBoxがnullでないとき
            if (KeepBox.SelectedItem != null)
            {
                // KeepBoxのアイテムを削除
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

            // メンバー変数の初期化            
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

            // 数字が1回以上続く部分で切り分けてリストに格納。
            List<string> expression = Regex.Split(input, @"([^\d\.]+)").ToList();

            for (int i = 0; i < expression.Count; i++)
            {
                // 数字の時
                if (Regex.IsMatch(expression[i], @"\d"))
                {
                    // 文字列にピリオドが含まれていたら
                    if (expression[i].Contains('.'))
                    {
                        // 文字列の中で一番目のピリオドの位置を確認
                        int index = expression[i].IndexOf('.');

                        // ピリオドの前の文字列を取得
                        string beforepiriod = expression[i].Substring(0, index);

                        // ピリオドの前の文字列を三桁区切りへ変換したものとピリオド以降を足して文字列を作成
                        expression[i] = Regex.Replace(beforepiriod, @"(\d{1,3})(?=(\d{3})+(?!\d))", "$1,") + expression[i].Substring(index);
                    }
                    else
                    {
                        expression[i] = Regex.Replace(expression[i], @"(\d{1,3})(?=(\d{3})+(?!\d))", "$1,");
                    }
                }
                // パーセントかつ直前が数字だった時
                else if (expression[i] == "%" && Regex.IsMatch(expression[i - 1], @"\d"))
                {
                    try
                    {
                        // %の前の数字をdecimal型に変換
                        decimal number = decimal.Parse(expression[i - 1]);

                        // 変換した数字に0.01をかける
                        decimal answer = number * 0.01m;

                        // 計算結果を文字列に変換して代入
                        expression[i - 1] = answer.ToString("#,##0.################");

                        // %のインデックスを削除
                        expression.RemoveAt(i);

                        // 計算後の文字列の長さから計算前の文字列の長さを引いた数分カーソル位置を移動
                        cursorposition += (expression[i - 1].Length - cursorposition);
                    }
                    // 数字の中に少数点が複数含まれるとき
                    catch (FormatException)
                    {
                        // エラーのメッセージボックス表示
                        MessageBox.Show("Number is invalid", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // %のインデックスを削除
                        expression.RemoveAt(i);

                        // カーソル位置を元に戻す
                        cursorposition--;

                        break;
                    }
                    // Decimal型の桁数を超えているとき
                    catch (OverflowException)
                    {
                        // エラーのメッセージボックス表示
                        MessageBox.Show("Number of digits is out of range", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // %のインデックスを削除
                        expression.RemoveAt(i);

                        // カーソル位置を元に戻す
                        cursorposition--;

                        break;
                    }
                    // その他のエラーが発生したとき
                    catch (Exception)
                    {
                        // エラーのメッセージボックス表示
                        MessageBox.Show("Cannot be calculated", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // %のインデックスを削除
                        expression.RemoveAt(i);

                        // カーソル位置を元に戻す
                        cursorposition--;

                        break;
                    }
                }
            }

            // Listの要素を文字列へ再度代入
            Display.Text = string.Concat(expression);

            // Displayのテキストの長さがカーソル位置より短い時
            if (Display.Text.Length < cursorposition)
            {
                // カーソル位置を文字列の最後尾へ移動
                cursorposition -= cursorposition - Display.Text.Length;
            }

            // 変換後にカーソルの位置の後ろの文字数が増えていたとき
            if (aftercursolstr < Display.Text.Substring(cursorposition).Length)
            {
                // 増えた文字数分カーソル位置を移動
                cursorposition += (Display.Text.Substring(cursorposition).Length - aftercursolstr);
            }
            // 変換後にカーソルの位置の後ろの文字数が減っていたとき
            else if (aftercursolstr > Display.Text.Substring(cursorposition).Length)
            {
                // 減った文字数分カーソル位置を移動
                cursorposition += (Display.Text.Substring(cursorposition).Length - aftercursolstr);
            }

            // SelectionStartに現在のカーソル位置を代入
            Display.SelectionStart = cursorposition;

            // カーソル位置にフォーカスを持ってくるメソッド
            Display.ScrollToCaret();
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

                // 初期化
                ClearMethod();

                // 数値としてDisplayへ追加
                AddDisplay(selectresult);
            }
        }
    }
}

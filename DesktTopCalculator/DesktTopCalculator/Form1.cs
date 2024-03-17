using Antlr4.Runtime;
using System.Linq.Expressions;
using Dangl.Calculator;

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

        //文字列の値を評価し格納するList
        List<string> expression;

        //計算メソッドクラスのオブジェクト
        Calc cl;
        public Form1()
        {
            InitializeComponent();
            expression = new List<string>();
            cl = new Calc();
        }

        //------ここから各ボタンのイベントハンドラ-----------------

        //[0]を押したとき
        private void button0_Click(object sender, EventArgs e)
        {
            AddNumber("0");
        }
        //[1]を押したとき
        private void button1_Click(object sender, EventArgs e)
        {
            AddNumber("1");
        }
        //[2]を押したとき
        private void button2_Click(object sender, EventArgs e)
        {
            AddNumber("2");
        }
        //[3]を押したとき
        private void button3_Click(object sender, EventArgs e)
        {
            AddNumber("3");
        }
        //[4]を押したとき
        private void button4_Click(object sender, EventArgs e)
        {
            AddNumber("4");
        }
        //[5]を押したとき
        private void button5_Click(object sender, EventArgs e)
        {
            AddNumber("5");
        }
        //[6]を押したとき
        private void button6_Click(object sender, EventArgs e)
        {
            AddNumber("6");
        }
        //[7]を押したとき
        private void button7_Click(object sender, EventArgs e)
        {
            AddNumber("7");
        }
        //[8]を押したとき
        private void button8_Click(object sender, EventArgs e)
        {
            AddNumber("8");
        }
        //[9]を押したとき
        private void button9_Click(object sender, EventArgs e)
        {
            AddNumber("9");
        }
        //[00]を押したとき
        private void button00_Click(object sender, EventArgs e)
        {
            AddNumber("00");
        }
        //[.]を押したとき
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            AddPeriod(".");
        }
        //[+]を押したとき
        private void buttonpuls_Click(object sender, EventArgs e)
        {
            AddOperator("+");
        }
        //[-]を押したとき
        private void buttonminus_Click(object sender, EventArgs e)
        {
            AddOperator("-");
        }
        //[×]を押したとき
        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            AddOperator("×");
        }
        //[÷]を押したとき
        private void buttondivision_Click(object sender, EventArgs e)
        {
            AddOperator("÷");
        }
        //[前括弧]を押したとき
        private void buttonfrontbracket_Click(object sender, EventArgs e)
        {
            AddFrontBracket("(");
        }
        //[後括弧]を押したとき
        private void buttonbackbracket_Click(object sender, EventArgs e)
        {
            AddBackBracket(")");
        }
        //[％]を押したとき
        private void buttonpercent_Click(object sender, EventArgs e)
        {
            AddPercent("%");
            
        }
        //[＝]を押したとき
        private void buttonequal_Click(object sender, EventArgs e)
        {
            //計算のために文字列を新たに取得するメソッド
            cl.Evaluate(expression);
            //計算メソッド
            cl.Calculate();
            AddElse("=");
            expression.Add(cl.resultnumber);
            UpdateDisplay();
            //直後に数字を入力させない
            canflag = false;
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
            expression.Clear();
            Display.Text = "";
        }
        //[AC]を押したとき
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            expression.Clear();
            Display.Text = "";
            //※Keepするために使用していた配列も削除する予定！！
            KeepBox.Text = "";

        }
        // 数字を文字列inputへ追加し、Displayへ表示させるメソッド
        //※数値評価の時に0が先頭の場合を考慮する予定なのでここでは0の処理はせずに表示
        //※すなわち0123のような表記を許容する
        //※またピリオドの数も表記の時点では言及せず計算の時点でエラーメッセージを出す


        //数字を文字列inputへ追加
        public void AddNumber(string number)
        {
            //文字列へ数値追加
            input += number;
            //数字が初めての入力だった場合
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
            //canflag==0にしていないのは後括弧の直後を許容するため
            else if (input[input.Length-1] == '%')
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

    //文字列inputを評価し数式としてListへ追加する
        public void UpdateDisplay()
        {
                
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            string format = string.Join("", expression);
                double result;
                if (double.TryParse(format, out result))
                {
                    Display.Text = result.ToString("#,###");
                }
                else
                {
                    // 表示できる形式の数値でない場合、そのまま表示
                    Display.Text = format;
                }
        }
    }
    public class Calc
    {
        //計算用の文字列を格納する
        public string? formula = "";
        //結果を格納する文字列
        public string? resultnumber = "";

        //入力された数値の評価と計算の前準備
        //計算用として string型formulaへ値を代入
        public void Evaluate(List<string> list)
        {
            foreach (string f in list)
            {
                switch (f)
                {
                    case "×":
                        formula += "*";
                        break;
                    case "÷":
                        formula += "/";
                        break;
                    default:
                        formula += f;
                        break;
                }
            }
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
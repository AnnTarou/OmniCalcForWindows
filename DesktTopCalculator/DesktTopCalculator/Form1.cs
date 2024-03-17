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
            cl= new Calc();
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
            //コンマが先頭で押された場合
            if (firstflag == true)
            {
                AddNumber("0");
                AddNumber(".");
            }
            //直前にカンマがある場合
            else if (expression.Last().Last().ToString() == ".")
            {
                return;
            }
            else
            {
                AddNumber(".");
            }
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
            if (expression.Count == 0)
            {
                expression.Add("(");
                UpdateDisplay();
            }
            //直前に")"がある時
            else if ((expression.Count > 0) && (expression.Last().Last().ToString() == ")"))
            {
                return;
            }
            //直前にカンマがある時
            else if ((expression.Count > 0) && (expression.Last().Last().ToString() == "."))
            {
                return;
            }
            else
            {
                expression.Add("(");
                UpdateDisplay();
            }
        }
        //[後括弧]を押したとき
        private void buttonbackbracket_Click(object sender, EventArgs e)
        {
            AddElse(")");
        }
        //[％]を押したとき
        private void buttonpercent_Click(object sender, EventArgs e)
        {
            //初めての入力の時＆演算子の直後
            if (firstflag == true)
            {
                return;
            }
            //直前にカンマがある時
            else if (expression.Last().Last().ToString() == ".")
            {
                return;
            }
            //直前に%がある時
            else if (expression.Last().Last().ToString() == "%")
            {
                return;
            }
            else
            {
                expression.Add("%");
                UpdateDisplay();
                //直後に数字を入力させない
                canflag = false;
            }
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


    //数字の追加メソッド
    public void AddNumber(string number)
        {
           ;
            UpdateDisplay();
            //数字が初めての入力だった場合
            if (firstflag == true)
            {
                firstflag = false;
            }
            canflag = true;
        }
        // 演算子をListへ追加し、Displayへ表示させるメソッド
        public void AddOperator(string ope)
        {
            //入力はじめまたは演算子が直前にある時
            if (firstflag == true)
            {
                return;
            }
            expression.Add(ope);
            UpdateDisplay();
            firstflag = true;
            canflag = true;
        }
        //")"と"="ボタンをListへ追加するメソッド
        public void AddElse(string button)
        {
            //初めての入力の時＆演算子の直後
            if (firstflag == true)
            {
                return;
            }
            //直前にカンマがある時
            else if (expression.Last().Last().ToString() == ".")
            {
                return;
            }
            //直前にカンマがある時
            else if (expression.Last().Last().ToString() == "(")
            {
                return;
            }
            else
            {
                expression.Add(button);
                UpdateDisplay();
                //フラグの初期化
                canflag = true;
            }
        }

        //表示画面の数字に3桁区切りを入れるメソッド
        //※↓↓↓このメソッドは不十分の為改良必要。。。
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
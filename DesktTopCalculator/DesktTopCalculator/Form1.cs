using Antlr4.Runtime;
using System.Linq.Expressions;
using Dangl.Calculator;

namespace DesktTopCalculator
{
    public partial class Form1 : Form
    {
        //�v�Z����\������e�L�X�g�{�b�N�X�̖��O��Display
        //Keep�����v�Z��������e�L�X�g�{�b�N�X�̖��O��KeepBox

        //�����̓��͂͏��߂Ă��H
        public static bool firstflag = true;

        //�����̓��͉ۑ���̂���
        public static bool canflag = true;

        //�N���b�N���ꂽ�l���i�[����List
        public static List<string> expression = new List<string>();

        Calc cl = new Calc();
        public Form1()
        {
            InitializeComponent();
        }

        //------��������e�{�^���̃C�x���g�n���h��--------------------
        private void button0_Click(object sender, EventArgs e)
        {
            AddNumber("0");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddNumber("1");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddNumber("2");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            AddNumber("3");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            AddNumber("4");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            AddNumber("5");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            AddNumber("6");
        }
        private void button7_Click(object sender, EventArgs e)
        {
            AddNumber("7");
        }
        private void button8_Click(object sender, EventArgs e)
        {
            AddNumber("8");
        }
        private void button9_Click(object sender, EventArgs e)
        {
            AddNumber("9");
        }
        private void button00_Click(object sender, EventArgs e)
        {
            AddNumber("00");
        }
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            //�R���}���擪�ŉ����ꂽ�ꍇ
            if (firstflag == true)
            {
                AddNumber("0");
                AddNumber(".");
            }
            //���O�ɃJ���}������ꍇ
            else if (expression.Last().Last().ToString() == ".")
            {
                return;
            }
            else
            {
                AddNumber(".");
            }
        }
        private void buttonpuls_Click(object sender, EventArgs e)
        {
            AddOperator("+");
        }
        private void buttonminus_Click(object sender, EventArgs e)
        {
            AddOperator("-");
        }
        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            AddOperator("�~");
        }
        private void buttondivision_Click(object sender, EventArgs e)
        {
            AddOperator("��");
        }
        private void buttonfrontbracket_Click(object sender, EventArgs e)
        {
            if (expression.Count == 0)
            {
                expression.Add("(");
                UpdateDisplay();
            }
            //���O��")"�����鎞
            else if ((expression.Count > 0) && (expression.Last().Last().ToString() == ")"))
            {
                return;
            }
            //���O�ɃJ���}�����鎞
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
        private void buttonbackbracket_Click(object sender, EventArgs e)
        {
            AddElse(")");
        }
        private void buttonpercent_Click(object sender, EventArgs e)
        {
            //���߂Ă̓��͂̎������Z�q�̒���
            if (firstflag == true)
            {
                return;
            }
            //���O�ɃJ���}�����鎞
            else if (expression.Last().Last().ToString() == ".")
            {
                return;
            }
            //���O��%�����鎞
            else if (expression.Last().Last().ToString() == "%")
            {
                return;
            }
            else
            {
                expression.Add("%");
                UpdateDisplay();
                //����ɐ�������͂����Ȃ�
                canflag = false;
            }
        }
        private void buttonequal_Click(object sender, EventArgs e)
        {
            //�v�Z�̂��߂ɕ������V���Ɏ擾���郁�\�b�h
            cl.Evaluate(expression);
            //�v�Z���\�b�h
            cl.Calculate();
            AddElse("=");
            expression.Add(cl.resultnumber);
            UpdateDisplay();
            //����ɐ�������͂����Ȃ�
            canflag = false;
        }
        private void buttonchardelete_Click(object sender, EventArgs e)
        {
            //List�ɗv�f�����鎞�A�������폜
            if (expression.Count > 0)
            {
                expression.RemoveAt(expression.Count - 1);
                Display.Text = string.Join("", expression);
            }
            //List����̎��̏���
            else if (expression.Count == 0)
            {
                return;
            }
        }
        private void buttonTextClear_Click(object sender, EventArgs e)
        {
            expression.Clear();
            Display.Text = "";
        }
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            expression.Clear();
            Display.Text = "";
            //��Keep���邽�߂Ɏg�p���Ă����z����폜����\��I�I
            KeepBox.Text = "";

        }       
    // ������List�֒ǉ����ADisplay�֕\�������郁�\�b�h
    //�����l�]���̎���0���擪�̏ꍇ���l������\��Ȃ̂ł����ł�0�̏����͂����ɕ\��
    //�����Ȃ킿0123�̂悤�ȕ\�L�����e����
    //���܂��J���}�̐����\�L�̎��_�ł͌��y�����v�Z�̎��_�ŃG���[���b�Z�[�W���o���\��

    public void AddNumber(string number)
        {
            expression.Add(number);
            UpdateDisplay();
            //���������߂Ă̓��͂������ꍇ
            if (firstflag == true)
            {
                firstflag = false;
            }
            canflag = true;
        }
        // ���Z�q��List�֒ǉ����ADisplay�֕\�������郁�\�b�h
        public void AddOperator(string ope)
        {
            //���͂͂��߂܂��͉��Z�q�����O�ɂ��鎞
            if (firstflag == true)
            {
                return;
            }
            expression.Add(ope);
            UpdateDisplay();
            firstflag = true;
            canflag = true;
        }
        //")"��"="�{�^����List�֒ǉ����郁�\�b�h
        public void AddElse(string button)
        {
            //���߂Ă̓��͂̎������Z�q�̒���
            if (firstflag == true)
            {
                return;
            }
            //���O�ɃJ���}�����鎞
            else if (expression.Last().Last().ToString() == ".")
            {
                return;
            }
            //���O�ɃJ���}�����鎞
            else if (expression.Last().Last().ToString() == "(")
            {
                return;
            }
            else
            {
                expression.Add(button);
                UpdateDisplay();
                //�t���O�̏�����
                canflag = true;
            }
        }

        //�\����ʂ̐�����3����؂�����郁�\�b�h
        //�����������̃��\�b�h�͕s�\���̈׉��ǕK�v�B�B�B
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
                // �\���ł���`���̐��l�łȂ��ꍇ�A���̂܂ܕ\��
                Display.Text = format;
            }
        }
    }
    public class Calc
    {
        //�v�Z�p�̕�������i�[����
        public string? formula = "";
        //���ʂ��i�[���镶����
        public string? resultnumber = "";

        //���͂��ꂽ���l�̕]���ƌv�Z�̑O����
        //�v�Z�p�Ƃ��� string�^formula�֒l����
        public void Evaluate(List<string> list)
        {
            foreach (string f in list)
            {
                switch (f)
                {
                    case "�~":
                        formula += "*";
                        break;
                    case "��":
                        formula += "/";
                        break;
                    default:
                        formula += f;
                        break;
                }
            }
        }
        //�v�Z���\�b�h
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
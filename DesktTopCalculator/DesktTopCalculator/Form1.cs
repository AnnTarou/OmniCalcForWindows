using Antlr4.Runtime;
using System.Linq.Expressions;
using Dangl.Calculator;

namespace DesktTopCalculator
{
    public partial class Form1 : Form
    {
        //�v�Z����\������e�L�X�g�{�b�N�X�̖��O��Display
        //Keep�����v�Z�������郊�X�g�{�b�N�X�̖��O��KeepBox

        //�����̓��͂͏��߂Ă��H
        //true�̂Ƃ�"%, ),���Z�q"�̓��͕s�A�s���I�h��"0."�Ƃ���
        //false�̂Ƃ����ׂĂ̓��͉�
        public bool firstflag = true;

        //�����̓��͉ۑ���̂���
        //���̃t���O��false�̂Ƃ��͐������͕s��
        public bool canflag = true;

        //�N���b�N���ꂽ�l���i�[���邽�߂̕�����
        public string input = "";

        //������̒l��]�����i�[����List
        List<string> expression;

        //�v�Z���\�b�h�N���X�̃I�u�W�F�N�g
        Calc cl;
        public Form1()
        {
            InitializeComponent();
            expression = new List<string>();
            cl= new Calc();
        }

        //------��������e�{�^���̃C�x���g�n���h��-----------------

        //[0]���������Ƃ�
        private void button0_Click(object sender, EventArgs e)
        {
            AddNumber("0");
        }
        //[1]���������Ƃ�
        private void button1_Click(object sender, EventArgs e)
        {
            AddNumber("1");
        }
        //[2]���������Ƃ�
        private void button2_Click(object sender, EventArgs e)
        {
            AddNumber("2");
        }
        //[3]���������Ƃ�
        private void button3_Click(object sender, EventArgs e)
        {
            AddNumber("3");
        }
        //[4]���������Ƃ�
        private void button4_Click(object sender, EventArgs e)
        {
            AddNumber("4");
        }
        //[5]���������Ƃ�
        private void button5_Click(object sender, EventArgs e)
        {
            AddNumber("5");
        }
        //[6]���������Ƃ�
        private void button6_Click(object sender, EventArgs e)
        {
            AddNumber("6");
        }
        //[7]���������Ƃ�
        private void button7_Click(object sender, EventArgs e)
        {
            AddNumber("7");
        }
        //[8]���������Ƃ�
        private void button8_Click(object sender, EventArgs e)
        {
            AddNumber("8");
        }
        //[9]���������Ƃ�
        private void button9_Click(object sender, EventArgs e)
        {
            AddNumber("9");
        }
        //[00]���������Ƃ�
        private void button00_Click(object sender, EventArgs e)
        {
            AddNumber("00");
        }
        //[.]���������Ƃ�
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
        //[+]���������Ƃ�
        private void buttonpuls_Click(object sender, EventArgs e)
        {
            AddOperator("+");
        }
        //[-]���������Ƃ�
        private void buttonminus_Click(object sender, EventArgs e)
        {
            AddOperator("-");
        }
        //[�~]���������Ƃ�
        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            AddOperator("�~");
        }
        //[��]���������Ƃ�
        private void buttondivision_Click(object sender, EventArgs e)
        {
            AddOperator("��");
        }
        //[�O����]���������Ƃ�
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
        //[�㊇��]���������Ƃ�
        private void buttonbackbracket_Click(object sender, EventArgs e)
        {
            AddElse(")");
        }
        //[��]���������Ƃ�
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
        //[��]���������Ƃ�
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
        //[delete]���������Ƃ�
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
        //[C]���������Ƃ�
        private void buttonTextClear_Click(object sender, EventArgs e)
        {
            expression.Clear();
            Display.Text = "";
        }
        //[AC]���������Ƃ�
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            expression.Clear();
            Display.Text = "";
            //��Keep���邽�߂Ɏg�p���Ă����z����폜����\��I�I
            KeepBox.Text = "";

        }       
    // �����𕶎���input�֒ǉ����ADisplay�֕\�������郁�\�b�h
    //�����l�]���̎���0���擪�̏ꍇ���l������\��Ȃ̂ł����ł�0�̏����͂����ɕ\��
    //�����Ȃ킿0123�̂悤�ȕ\�L�����e����
    //���܂��s���I�h�̐����\�L�̎��_�ł͌��y�����v�Z�̎��_�ŃG���[���b�Z�[�W���o��


    //�����̒ǉ����\�b�h
    public void AddNumber(string number)
        {
           ;
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
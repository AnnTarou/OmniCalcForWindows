using Antlr4.Runtime;
using System.Linq.Expressions;
using Dangl.Calculator;
using System.Text.RegularExpressions;

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

        //input���ꂽ������]�����Ċi�[���邽�߂�List
        List<string> expression;

        //�]����Display�֕\�����邽�߂̕�����
        public string output;

        //�v�Z���\�b�h�N���X�̃I�u�W�F�N�g
        Calc cl;
        public Form1()
        {
            InitializeComponent();
            cl = new Calc();
        }

        //------��������e�{�^���̃C�x���g�n���h��-----------------

        //[0]���������Ƃ�
        private void button0_Click(object sender, EventArgs e)
        {
            AddNumber("0");
            Display.Text = output;
        }
        //[1]���������Ƃ�
        private void button1_Click(object sender, EventArgs e)
        {
            AddNumber("1");
            Display.Text = output;
        }
        //[2]���������Ƃ�
        private void button2_Click(object sender, EventArgs e)
        {
            AddNumber("2");
            Display.Text = output;
        }
        //[3]���������Ƃ�
        private void button3_Click(object sender, EventArgs e)
        {
            AddNumber("3");
            Display.Text = output;
        }
        //[4]���������Ƃ�
        private void button4_Click(object sender, EventArgs e)
        {
            AddNumber("4");
            Display.Text = output;
        }
        //[5]���������Ƃ�
        private void button5_Click(object sender, EventArgs e)
        {
            AddNumber("5");
            Display.Text = output;
        }
        //[6]���������Ƃ�
        private void button6_Click(object sender, EventArgs e)
        {
            AddNumber("6");
            Display.Text = output;
        }
        //[7]���������Ƃ�
        private void button7_Click(object sender, EventArgs e)
        {
            AddNumber("7");
            Display.Text = output;
        }
        //[8]���������Ƃ�
        private void button8_Click(object sender, EventArgs e)
        {
            AddNumber("8");
            Display.Text = output;
        }
        //[9]���������Ƃ�
        private void button9_Click(object sender, EventArgs e)
        {
            AddNumber("9");
            Display.Text = output;
        }
        //[00]���������Ƃ�
        private void button00_Click(object sender, EventArgs e)
        {
            AddNumber("00");
            Display.Text = output;
        }
        //[.]���������Ƃ�
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            AddPeriod(".");
            Display.Text = output;
        }
        //[+]���������Ƃ�
        private void buttonpuls_Click(object sender, EventArgs e)
        {
            AddOperator("+");
            Display.Text = output;
        }
        //[-]���������Ƃ�
        private void buttonminus_Click(object sender, EventArgs e)
        {
            AddOperator("-");
            Display.Text = output;
        }
        //[�~]���������Ƃ�
        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            AddOperator("�~");
            Display.Text = output;
        }
        //[��]���������Ƃ�
        private void buttondivision_Click(object sender, EventArgs e)
        {
            AddOperator("��");
            Display.Text = output;
        }
        //[�O����]���������Ƃ�
        private void buttonfrontbracket_Click(object sender, EventArgs e)
        {
            AddFrontBracket("(");
            Display.Text = output;
        }
        //[�㊇��]���������Ƃ�
        private void buttonbackbracket_Click(object sender, EventArgs e)
        {
            AddBackBracket(")");
            Display.Text = output;
        }
        //[��]���������Ƃ�
        private void buttonpercent_Click(object sender, EventArgs e)
        {
            AddPercent("%");
            Display.Text = output;

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
            input = "";
            output = "";
            Display.Text = "";
            firstflag = true;
            canflag = true;
        }
        //[AC]���������Ƃ�
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            input = "";
            output = "";
            Display.Text = "";
            //��Keep���邽�߂Ɏg�p���Ă����z����폜����\��I�I
            KeepBox.Text = "";
            firstflag = true;
            canflag = true;
        }
        // �����𕶎���input�֒ǉ����ADisplay�֕\�������郁�\�b�h
        //�����l�]���̎���0���擪�̏ꍇ���l������\��Ȃ̂ł����ł�0�̏����͂����ɕ\��
        //�����Ȃ킿0123�̂悤�ȕ\�L�����e����
        //���܂��s���I�h�̐����\�L�̎��_�ł͌��y�����v�Z�̎��_�ŃG���[���b�Z�[�W���o��


        //�����𕶎���input�֒ǉ�
        public void AddNumber(string number)
        {
            //������֐��l�ǉ�
            input += number;
            //���������߂Ă̓��͂������ꍇ
            if (firstflag == true)
            {
                firstflag = false;
            }
            canflag = true;
        }

        // ���Z�q�𕶎���input�֒ǉ�
        public void AddOperator(string ope)
        {
            //���͂͂��߂܂��͉��Z�q�����O�ɂ��鎞
            if (firstflag == true)
            {
                return;
            }
            input += ope;
            firstflag = true;
            canflag = true;
        }

        //�s���I�h�𕶎���input�֒ǉ�
        public void AddPeriod(string period)
        {
            //�R���}���擪�ŉ����ꂽ�ꍇ
            if (firstflag == true)
            {
                input += "0.";
            }
            //���O�ɃJ���}������ꍇ
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
        //�O���ʂ𕶎���input�֒ǉ�
        public void AddFrontBracket(string fb)
        {
            //���O�Ƀs���I�h�����鎞
            if (input[input.Length - 1] == '.')
            {
                return;
            }
            //���O��")"�܂���"%"�����鎞
            else if (canflag == false)
            {
                return;
            }
            //���߂Ă̓��͂łȂ��Ƃ�
            else if (firstflag == false)
            {
                return;
            }
            else
            {
                input += fb;
            }
        }
        //�㊇�ʂ𕶎���input�֒ǉ�
        public void AddBackBracket(string bb)
        {
            //�����̂��Ƃ̂ݓ��͉�
            if (firstflag == false)
            {
                input += bb;
                //����ɐ�������͂����Ȃ�
                canflag = false;
            }
            else
            {
                return;
            }
        }
        //�p�[�Z���g�𕶎���input�֒ǉ�
        public void AddPercent(string p)
        {
            //���͂͂��߂܂��͉��Z�qor�s���I�h�����O�ɂ��鎞
            if (firstflag == true)
            {
                return;
            }
            //���O��%�����鎞
            //canflag==0�ɂ��Ă��Ȃ��̂͌㊇�ʂ̒�������e���邽��
            else if (input[input.Length - 1] == '%')
            {
                return;
            }
            else
            {
                input += p;
                //����ɐ�������͂����Ȃ�
                canflag = false;
            }
        }

        //������input��]���������Ƃ���List�֒ǉ�����
        public void UpdateDisplay(string input)
        {
            //���K�\���@\D+�@�����ȊO�̕�����1��ȏ㑱�������Ő؂蕪���Ċi�[�B
            expression = Regex.Split(input, @"(\D+)").ToList();

            for (int i = 0; i < expression.Count; i++)
            {
                //�����̎�
                if (IsNumeric(expression[i]))
                {
                    decimal number = Convert.ToDecimal(expression[i]);
                    expression[i] = number.ToString("#,##0");
                }
                //�p�[�Z���g�����O��������������
                else if (expression[i] == "%" && IsNumeric(expression[i - 1]))
                {
                    decimal number = Convert.ToDecimal(expression[i - 1]);
                    decimal answer = Math.Round(number * 0.01m, 10);
                    expression[i - 1] = answer.ToString("#,##0");
                    // % ���폜����
                    expression.RemoveAt(i);
                    // �C���f�b�N�X��߂�
                    i--;
                }
            }
            //List�̗v�f�𕶎���֑��
            output = string.Concat(expression);
        }
        //���l��������decimal�^�̐��l��Ԃ�
        public static bool IsNumeric(string input)
        {
            return decimal.TryParse(input, out _);
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
            foreach (var item in list)
            {
                switch (item)
                {
                    case "�~":
                        formula += "*";
                        break;
                    case "��":
                        formula += "/";
                        break;
                    default:
                        formula += item;
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

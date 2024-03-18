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
        //�v�Z����\������e�L�X�g�{�b�N�X�̖��O��Display
        //Keep�����v�Z�������郊�X�g�{�b�N�X�̖��O��KeepBox

        //�v�Z���I���������H�v�Z���ʂ��ł����̂�true�ɂȂ�
        public bool endflag = false;

        //input���ꂽ������]�����Ċi�[���邽�߂�List
        List<string> expression;

        //�v�Z���\�b�h�N���X�̃I�u�W�F�N�g
        Calc cl;

        //�ۑ��n���\�b�h�N���X�̃I�u�W�F�N�g
        KeepDate kd;

        public Form1()
        {
            InitializeComponent();
            cl = new Calc();
            kd = new KeepDate();
        }

        //------��������e�{�^���̃C�x���g�n���h��-----------------

        //[0]���������Ƃ�
        private void button0_Click(object sender, EventArgs e)
        {
            AddNumber("0");
            UpdateDisplay(Display.Text);           
        }
        //[1]���������Ƃ�
        private void button1_Click(object sender, EventArgs e)
        {
            AddNumber("1");
            UpdateDisplay(Display.Text);
        }
        //[2]���������Ƃ�
        private void button2_Click(object sender, EventArgs e)
        {
            AddNumber("2");
            UpdateDisplay(Display.Text);
        }
        //[3]���������Ƃ�
        private void button3_Click(object sender, EventArgs e)
        {
            AddNumber("3");
            UpdateDisplay(Display.Text);
        }
        //[4]���������Ƃ�
        private void button4_Click(object sender, EventArgs e)
        {
            AddNumber("4");
            UpdateDisplay(Display.Text);
        }
        //[5]���������Ƃ�
        private void button5_Click(object sender, EventArgs e)
        {
            AddNumber("5");
            UpdateDisplay(Display.Text);
        }
        //[6]���������Ƃ�
        private void button6_Click(object sender, EventArgs e)
        {
            AddNumber("6");
            UpdateDisplay(Display.Text);
        }
        //[7]���������Ƃ�
        private void button7_Click(object sender, EventArgs e)
        {
            AddNumber("7");
            UpdateDisplay(Display.Text);
        }
        //[8]���������Ƃ�
        private void button8_Click(object sender, EventArgs e)
        {
            AddNumber("8");
            UpdateDisplay(Display.Text);
        }
        //[9]���������Ƃ�
        private void button9_Click(object sender, EventArgs e)
        {
            AddNumber("9");
            UpdateDisplay(Display.Text);
        }
        //[00]���������Ƃ�
        private void button00_Click(object sender, EventArgs e)
        {
            AddNumber("00");
            UpdateDisplay(Display.Text);
        }
        //[.]���������Ƃ�
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            // �e�L�X�g�{�b�N�X�̃J�[�\���ʒu���擾
            int cursorIndex = Display.SelectionStart;
            //���Z�q�܂��͑O���ʂ����O�ɂ���܂��͓��͂͂��߂̎�
            if (Display.Text[cursorIndex - 1] == '+'
                || Display.Text[cursorIndex - 1] == '-'
                || Display.Text[cursorIndex - 1] == '�~'
                || Display.Text[cursorIndex - 1] == '��'
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
        //[+]���������Ƃ�
        private void buttonpuls_Click(object sender, EventArgs e)
        {
            AddOperator("+");
            UpdateDisplay(Display.Text);
        }
        //[-]���������Ƃ�
        private void buttonminus_Click(object sender, EventArgs e)
        {
            AddOperator("-");
            UpdateDisplay(Display.Text);
        }
        //[�~]���������Ƃ�
        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            AddOperator("�~");
            UpdateDisplay(Display.Text);
        }
        //[��]���������Ƃ�
        private void buttondivision_Click(object sender, EventArgs e)
        {
            AddOperator("��");
            UpdateDisplay(Display.Text);
        }
        //[�O����]���������Ƃ�
        private void buttonfrontbracket_Click(object sender, EventArgs e)
        {
            AddFrontBracket("(");
            UpdateDisplay(Display.Text);
        }
        //[�㊇��]���������Ƃ�
        private void buttonbackbracket_Click(object sender, EventArgs e)
        {
            AddBackBracket(")");
            UpdateDisplay(Display.Text);
        }
        //[��]���������Ƃ�
        private void buttonpercent_Click(object sender, EventArgs e)
        {
            AddPercent("%");
            UpdateDisplay(Display.Text);

        }
        //[��]���������Ƃ�
        private void buttonequal_Click(object sender, EventArgs e)
        {
            //�v�Z�̂��߂ɕ������V���Ɏ擾���郁�\�b�h
            cl.Evaluate(expression);
            //�v�Z���\�b�h
            cl.Calculate();

            AddEqual("=", cl.resultnumber);
            UpdateDisplay(Display.Text);

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
            Display.Text = "";
        }
        //[AC]���������Ƃ�
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            Display.Text = "";
            //��Keep���邽�߂Ɏg�p���Ă����z����폜����\��I�I
        }
        // �����𕶎���input�֒ǉ����ADisplay�֕\�������郁�\�b�h
        //�����l�]���̎���0���擪�̏ꍇ���l������\��Ȃ̂ł����ł�0�̏����͂����ɕ\��
        //�����Ȃ킿0123�̂悤�ȕ\�L�����e����
        //���܂��s���I�h�̐����\�L�̎��_�ł͌��y�����v�Z�̎��_�ŃG���[���b�Z�[�W���o��


     //������Display�֒ǉ�
        public void AddNumber(string number)
        {
           // �e�L�X�g�{�b�N�X�̃J�[�\���ʒu���擾
           int cursorIndex = Display.SelectionStart;

            //���O��%���㊇�ʂ������ꍇ
            if (Display.Text[cursorIndex - 1] == '%' || Display.Text[cursorIndex - 1] == ')')
            {
                return;
            }
            // �J�[�\���������ɂ���ꍇ�̓e�L�X�g�𖖔��ɒǉ�
            else if (cursorIndex == Display.Text.Length)
            {
                Display.Text += number;
            }
            //Display�ɃJ�[�\�����Ȃ��Ƃ������ɒǉ�
            else if (cursorIndex == -1)
            {
                Display.Text += number;
            }
            //����ȊO�̎��̓J�[�\���̌��ɒǉ�
            else
            {
                Display.Text = Display.Text.Insert(cursorIndex, number);
            }
        }

     // ���Z�q�𕶎���input�֒ǉ�
        public void AddOperator(string ope)
        {
            // �e�L�X�g�{�b�N�X�̃J�[�\���ʒu���擾
            int cursorIndex = Display.SelectionStart;

            //���Z�q�܂��͑O���ʂ����O�ɂ��鎞
            if (Display.Text[cursorIndex - 1] == '+'
                || Display.Text[cursorIndex - 1] == '-'
                || Display.Text[cursorIndex - 1] == '�~'
                || Display.Text[cursorIndex - 1] == '��'
                || Display.Text[cursorIndex - 1] == '(')
            {
                return;
            }
            //���߂Ă̓��͂̎�
            else if(Display.Text.Length == 0)
            {
                return;
            }
            // �J�[�\���������ɂ���ꍇ�̓e�L�X�g�𖖔��ɒǉ�
            else if (cursorIndex == Display.Text.Length)
            {
                Display.Text += ope;
            }
            //Display�ɃJ�[�\�����Ȃ��Ƃ������ɒǉ�
            else if (cursorIndex == -1)
            {
                Display.Text += ope;
            }
            //����ȊO�̎��̓J�[�\���̌��ɒǉ�
            else
            {
                Display.Text = Display.Text.Insert(cursorIndex, ope);
            }
        }
    //�s���I�h��Display�֒ǉ�
        public void AddPeriod(string period)
        {
            // �e�L�X�g�{�b�N�X�̃J�[�\���ʒu���擾
            int cursorIndex = Display.SelectionStart;

            //���O�ɃJ���}������ꍇ
            if (Display.Text[cursorIndex - 1] == '.' || Display.Text[cursorIndex - 1] == ')')
            {
                return;
            }
            // �J�[�\���������ɂ���ꍇ�̓e�L�X�g�𖖔��ɒǉ�
            else if (cursorIndex == Display.Text.Length)
            {
                Display.Text += period;
            }
            //Display�ɃJ�[�\�����Ȃ��Ƃ������ɒǉ�
            else if (cursorIndex == -1)
            {
                Display.Text += period;
            }
            //����ȊO�̎��̓J�[�\���̌��ɒǉ�
            else
            {
                Display.Text = Display.Text.Insert(cursorIndex, period);
            }
        }
     //�O���ʂ�Display�֒ǉ�

        public void AddFrontBracket(string fb)
        {
            // �e�L�X�g�{�b�N�X�̃J�[�\���ʒu���擾
            int cursorIndex = Display.SelectionStart;

            //�㊇�ʂ����O�ɂ��鎞
            if ( Display.Text[cursorIndex - 1] == ')')
            {
                return;
            }
            // �J�[�\���������ɂ���ꍇ�̓e�L�X�g�𖖔��ɒǉ�
            else if (cursorIndex == Display.Text.Length)
            {
                Display.Text +=fb;
            }
            //Display�ɃJ�[�\�����Ȃ��Ƃ������ɒǉ�
            else if (cursorIndex == -1)
            {
                Display.Text += fb;
            }
            //����ȊO�̎��̓J�[�\���̌��ɒǉ�
            else
            {
                Display.Text = Display.Text.Insert(cursorIndex, fb);
            }
        }
        //�㊇�ʂ𕶎���Display�֒ǉ�
        public void AddBackBracket(string bb)
        {
            // �e�L�X�g�{�b�N�X�̃J�[�\���ʒu���擾
            int cursorIndex = Display.SelectionStart;

            //�����̂��Ƃ̂ݓ��͉�
            if (Char.IsDigit(Display.Text[cursorIndex - 1]))
            {
                 // �J�[�\���������ɂ���ꍇ�̓e�L�X�g�𖖔��ɒǉ�
                if (cursorIndex == Display.Text.Length)
                {
                    Display.Text += bb;
                }
                //Display�ɃJ�[�\�����Ȃ��Ƃ������ɒǉ�
                else if (cursorIndex == -1)
                {
                    Display.Text += bb;
                }
                //����ȊO�̎��̓J�[�\���̌��ɒǉ�
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
     //�p�[�Z���g�𕶎���Display�֒ǉ�
        public void AddPercent(string p)
        {
            // �e�L�X�g�{�b�N�X�̃J�[�\���ʒu���擾
            int cursorIndex = Display.SelectionStart;

            //���Z�q�܂��͑O���ʂ܂��̓s���I�h�����O�ɂ���܂��͓��͂͂��߂̎�
            if (Display.Text[cursorIndex - 1] == '+'
                || Display.Text[cursorIndex - 1] == '-'
                || Display.Text[cursorIndex - 1] == '�~'
                || Display.Text[cursorIndex - 1] == '��'
                || Display.Text[cursorIndex - 1] == '('
                || Display.Text[cursorIndex - 1] == '.'
                || Display.Text[cursorIndex - 1] == '%'
                || Display.Text.Length == 0)
            {
                return;
            }
            // �J�[�\���������ɂ���ꍇ�̓e�L�X�g�𖖔��ɒǉ�
            else if (cursorIndex == Display.Text.Length)
            {
                Display.Text += p;
            }
            //Display�ɃJ�[�\�����Ȃ��Ƃ������ɒǉ�
            else if (cursorIndex == -1)
            {
                Display.Text += p;
            }
            //����ȊO�̎��̓J�[�\���̌��ɒǉ�
            else
            {
                Display.Text = Display.Text.Insert(cursorIndex, p);
            }
        }
        //�C�R�[���ȍ~�𕶎���input�֒ǉ�
        public void AddEqual(string eql, string res)
        {
            Display.Text += (eql + res);

        }

        //������input��]���������Ƃ���List�֒ǉ�����
        public void UpdateDisplay(string txt)
        {
            //Display�̃e�L�X�g�𐔒l�]���p�ɉ��H���邽�߂�","����菜�����`�ŕ�����֑��
            string input = txt.Replace(",", "");

            //���K�\���@\D+�@�����ȊO�̕�����1��ȏ㑱�������Ő؂蕪���Ċi�[�B
            expression = Regex.Split(txt, @"(\D+)").ToList();

            for (int i = 0; i < expression.Count; i++)
            {
                //�����̎�
                if (IsNumeric(expression[i]))
                {
                    decimal number = Convert.ToDecimal(expression[i]);
                    expression[i] = number.ToString("N10");
                }
                //�s���I�h�̐����s�K�؂Ȏ�
                else if (ContainsMultiplePeriods(expression[i]))
                {
                    MessageBox.Show("(.)Incorrect number of periods", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }                
                //�p�[�Z���g�����O��������������
                else if (expression[i] == "%" && IsNumeric(expression[i - 1]))
                {
                    decimal number = Convert.ToDecimal(expression[i - 1]);
                    decimal answer = number * 0.01m;
                    expression[i - 1] = answer.ToString("#,##0.##########");
                    // % ���폜����
                    expression.RemoveAt(i);
                    i--;
                }
            }
            //List�̗v�f�𕶎���֍ēx���
            Display.Text = string.Concat(expression);            
        }

        //�����񂪐��l����₤
        public static bool IsNumeric(string inp)
        {
           return decimal.TryParse(inp, out _);
        }
        //������̒��Ƀs���I�h��2�ȏ�܂܂�邩��₤
        public static bool ContainsMultiplePeriods(string inp)
        {
            // �����̒��Ƀs���I�h��2�ȏ�܂܂�鐳�K�\���p�^�[��
            string pattern = @"\d+\.\d+\.\d+";

            // �p�^�[���Ƀ}�b�`���邩�ǂ������m�F
            return Regex.IsMatch(inp, pattern);
        }
    }

    //�v�Z�p�̃N���X
    public class Calc
    {
        //�v�Z�p�̕�������i�[����
        public string? formula = "";
        //���ʂ��i�[���镶����
        public string? resultnumber = "";

    //�v�Z�p�ɕ������ϊ������A�s�K�؂ȓ��͂ɑ΂��G���[���o��
        public void Evaluate(List<string> list)
        {
           //�v�Z�p�̕�����̍쐬
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
            //�O���ʂƌ㊇�ʂ̐����Ⴄ�ꍇ�̓G���[
            if (!(IsBalanced(formula)))
            {
                MessageBox.Show("The number of parentheses() doesn't match", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }
        }
    //�O���ʂƌ㊇�ʂ̐������������ׂ�
        public static bool IsBalanced(string f)
    {
        int openingCount = Regex.Matches(f, @"\(").Count;
        int closingCount = Regex.Matches(f, @"\)").Count;
        return openingCount == closingCount;
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
    public class KeepDate
    {

    }














}

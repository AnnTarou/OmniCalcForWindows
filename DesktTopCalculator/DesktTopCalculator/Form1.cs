using Antlr4.Runtime;
using System.Linq.Expressions;
using Dangl.Calculator;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;

namespace DesktTopCalculator
{
    public partial class Form1 : Form
    {
        //�v�Z����\������e�L�X�g�{�b�N�X�̖��O��Display
        //Keep�����v�Z�������郊�X�g�{�b�N�X�̖��O��KeepBox

        //�v�Z���I���������H�v�Z���ʂ��ł����̂�true�ɂȂ�
        public bool endflag = false;

        // �J�[�\���̈ʒu��ǐՂ��邽�߂̕ϐ�
        public int cursorPosition = 0;

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
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("0");
            UpdateDisplay(Display.Text);
        }
        //[1]���������Ƃ�
        private void button1_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("1");
            UpdateDisplay(Display.Text);
        }
        //[2]���������Ƃ�
        private void button2_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("2");
            UpdateDisplay(Display.Text);
        }
        //[3]���������Ƃ�
        private void button3_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("3");
            UpdateDisplay(Display.Text);
        }
        //[4]���������Ƃ�
        private void button4_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("4");
            UpdateDisplay(Display.Text);
        }
        //[5]���������Ƃ�
        private void button5_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("5");
            UpdateDisplay(Display.Text);
        }
        //[6]���������Ƃ�
        private void button6_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("6");
            UpdateDisplay(Display.Text);
        }
        //[7]���������Ƃ�
        private void button7_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("7");
            UpdateDisplay(Display.Text);
        }
        //[8]���������Ƃ�
        private void button8_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("8");
            UpdateDisplay(Display.Text);
        }
        //[9]���������Ƃ�
        private void button9_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("9");
            UpdateDisplay(Display.Text);
        }
        //[00]���������Ƃ�
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
        //[.]���������Ƃ�
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay(".");
            UpdateDisplay(Display.Text);
        }
        //[+]���������Ƃ�
        private void buttonpuls_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            AddDisplay("+");
            UpdateDisplay(Display.Text);
        }
        //[-]���������Ƃ�
        private void buttonminus_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            AddDisplay("-");
            UpdateDisplay(Display.Text);
        }
        //[�~]���������Ƃ�
        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            AddDisplay("�~");
            UpdateDisplay(Display.Text);
        }
        //[��]���������Ƃ�
        private void buttondivision_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            AddDisplay("��");
            UpdateDisplay(Display.Text);
        }
        //[�O����]���������Ƃ�
        private void buttonfrontbracket_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            AddDisplay("(");
            UpdateDisplay(Display.Text);
        }
        //[�㊇��]���������Ƃ�
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
        //[��]���������Ƃ�
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
        //[��]���������Ƃ�
        private void buttonequal_Click(object sender, EventArgs e)
        {
            //�v�Z�̂��߂ɕ������V���Ɏ擾���郁�\�b�h
            cl.Evaluate(Display.Text);
            //�v�Z���\�b�h
            cl.Calculate();

            AddEqual("=", cl.resultnumber);
            UpdateDisplay(Display.Text);
            //Keep,AC,C�����{�^���������Ȃ��悤�ɂ���
            endflag = true;
        }
        //Display���N���b�N���ꂽ��
        private void Display_Click(object sender, EventArgs e)
        {
            //�J�[�\���ʒu���擾
            cursorPosition = Display.SelectionStart;
        }
        //Display�ɃL�[�_�E������������
        private void Display_KeyDown(object sender, KeyEventArgs e)
        {
            //�J�[�\���ʒu���擾
            cursorPosition = Display.SelectionStart;
            //�E���L�[�������ꂽ�Ƃ�
            if (e.KeyCode == Keys.Right)
            {
                // �J�[�\�����e�L�X�g�{�b�N�X�̖����ɂȂ��ꍇ�́A�J�[�\�����E�ɂ��炷
                if (Display.SelectionStart < Display.Text.Length)
                {
                    Display.SelectionStart++;
                    Display.SelectionLength = 0;
                }
            }
        }
        //[delete]���������Ƃ�
        private void buttonchardelete_Click(object sender, EventArgs e)
        {
            //�J�[�\�����Ȃ������񂪂���ꍇ�������폜
            if (cursorPosition == 0 && Display.Text.Length > 0)
            {
                Display.Text = Display.Text.Remove(Display.Text.Length - 1);
                UpdateDisplay(Display.Text);
            }
            // �J�[�\��������ꍇ�̓J�[�\���̍����̕������폜
            else if (cursorPosition > 0)
            {
                Display.Text = Display.Text.Remove(cursorPosition - 1, 1);
                UpdateDisplay(Display.Text);
            }
            //�����񂪂Ȃ��ꍇ
            else if ((cursorPosition <= 0) && (Display.Text.Length == 0))
            {
                return;
            }
        }
        //[C]���������Ƃ�
        private void buttonTextClear_Click(object sender, EventArgs e)
        {
            //Display�ƃt�B�[���h�̏�����
            ClearMethod();
        }
        //[AC]���������Ƃ�
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            //Display�ƃt�B�[���h�̏�����
            ClearMethod();
            //KeepBox�̏�����
            KeepBox.Items.Clear();
        }
        //Keep�{�^�����N���b�N�����Ƃ�
        private void buttonKeep_Click(object sender, EventArgs e)
        {
            if (endflag == true)
            {
                KeepBox.Items.Add(Display.Text);
            }
            else
            {
                return;
            }
        }
        //Keep�{�^�����_�u���N���b�N��������Display�֒ǉ�
        private void KeepBox_DoubleClick(object sender, EventArgs e)
        {
            if (KeepBox.SelectedItem == null)
            {
                return;
            }
            else if (Display.Text.Contains("="))
            {
                string selectedItem = KeepBox.SelectedItem.ToString();

                // ���̃C���f�b�N�X������
                int indexOfEquals = selectedItem.IndexOf("=");

                // ���ȍ~�̕�������擾
                string resultString = selectedItem.Substring(indexOfEquals + 1);

                //�e�L�X�g�{�b�N�X�̂ƃt�B�[���h�̏�����
                ClearMethod();

                // �e�L�X�g�{�b�N�X�ɕ\��
                AddDisplay(resultString);
                UpdateDisplay(Display.Text);
            }
            else
            {
                string selectedItem = KeepBox.SelectedItem.ToString();

                // ���̃C���f�b�N�X������
                int indexOfEquals = selectedItem.IndexOf("=");

                // ���ȍ~�̕�������擾
                string resultString = selectedItem.Substring(indexOfEquals + 1);

                // �e�L�X�g�{�b�N�X�ɕ\��
                AddDisplay(resultString);
                UpdateDisplay(Display.Text);
            }
        }
        //�����l�ɖ߂����\�b�h
        public void ClearMethod()
        {
            //�J�[�\�����\���ɂ���
            Cursor.Hide();

            // Display�̃N���A
            Display.Clear();

            //�t�B�[���h������            
            endflag = false;
            cursorPosition = 0;
        }

        //--------�������烁�\�b�h--------
        //������Display�֒ǉ�
        public void AddDisplay(string buttonText)
        {
            Display.Text = Display.Text.Insert(cursorPosition, buttonText);
            // �J�[�\���ʒu��}��������̈ʒu�Ɉړ�
            cursorPosition += buttonText.Length;
            // �e�L�X�g�{�b�N�X�̃t�H�[�J�X��ݒ肵�A�J�[�\����\��
            Display.Focus();
            Display.SelectionStart = cursorPosition;
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
            List<string>expression = Regex.Split(txt, @"(\D+)").ToList();

            for (int i = 0; i < expression.Count; i++)
            {
                //�����̎�
                if (IsNumeric(expression[i]))
                {
                    decimal number = Convert.ToDecimal(expression[i]);
                    expression[i] = number.ToString("N0");
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
        //�v�Z���ʂ��灁�ȍ~�̕�������擾��Display�֒ǉ�����
        public void SelectResult()
        {
            // ���̃C���f�b�N�X���擾
            int index = Display.Text.IndexOf("=");

            // �������������ꍇ�A���̈ʒu�ȍ~�̕�����������擾
            if (index != -1)
            {
                // ���̈ʒu�ȍ~�̕�����������擾
                string selectresult = Display.Text.Substring(index + 1);
                //���Z�b�g
                ClearMethod();
                //���l�Ƃ���Display�֒ǉ�
                AddDisplay(selectresult);
            }
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
        public void Evaluate(string txt)
        {
            string str = txt.Replace(",", "");

            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '�~':
                        formula += "*";                       
                        break;
                    case '��':
                        formula += "/";
                        break;
                    default:
                        formula += str[i];
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
    //�ۑ��n�̃N���X

    public class KeepDate
    {

    }
}

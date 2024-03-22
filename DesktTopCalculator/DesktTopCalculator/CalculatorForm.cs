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
        //�v�Z����\������e�L�X�g�{�b�N�X�̖��O��Display
        //Keep�����v�Z�������郊�X�g�{�b�N�X�̖��O��KeepBox

        //�v�Z���I���������H�v�Z���ʂ��ł����̂�true�ɂȂ�
        public bool endflag = false;

        // �J�[�\���̈ʒu��ǐՂ��邽�߂̕ϐ�
        public int cursorposition = 0;

        //�v�Z���\�b�h�N���X�̃I�u�W�F�N�g
        Calculation cl;

        //�ۑ��n���\�b�h�N���X�̃I�u�W�F�N�g
        TempStorage ts;

        public CalculatorForm()
        {
            InitializeComponent();
            cl = new Calculation();
            ts = new TempStorage();
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
            //�v�Z���ʂ��o����ɃC�R�[���������ꂽ�ꍇ
            if (endflag)
            {
                return;
            }
            else
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
        }
        //Display���N���b�N���ꂽ��
        private void Display_Click(object sender, EventArgs e)
        {
            //�J�[�\���ʒu���擾
            cursorposition = Display.SelectionStart;
        }
        //Display�ɃL�[�_�E������������
        private void Display_KeyDown(object sender, KeyEventArgs e)
        {
            //�J�[�\���ʒu���擾
            cursorposition = Display.SelectionStart;
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
            //�J�[�\���ʒu���擾
            cursorposition = Display.SelectionStart;

            //�v�Z���ʂ��o����͉������Ȃ�
            if (endflag)
            {
                return;
            }
            //�J�[�\���ʒu��0�ŕ����񂪂���ꍇ
            else if (cursorposition == 0 && Display.Text.Length > 0)
            {
                return;
            }
            //�����񂪂Ȃ��ꍇ
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // �J�[�\��������ꍇ
            else if (cursorposition > 0)
            {
                //�J�[�\���̍����ꕶ���폜
                Display.Text = Display.Text.Remove(cursorposition - 1, 1);
                //Display�֕\��
                UpdateDisplay(Display.Text);
                //�J�[�\���̈ʒu���ēx�擾
                cursorposition -= 1;
                // �e�L�X�g�{�b�N�X�̃t�H�[�J�X��ݒ肵�A�J�[�\����\��
                Display.Focus();
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
            if (endflag)
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
                //Display�ƃt�B�[���h�̏�����
                ClearMethod();

                // Display��Keep�̉񓚕����̂ݒǉ�
                AddDisplay(ts.SelectResult(KeepBox));
                UpdateDisplay(Display.Text);
            }
            else
            {
                // Display��Keep�̉񓚕����̂ݒǉ�
                AddDisplay(ts.SelectResult(KeepBox));
                UpdateDisplay(Display.Text);
            }
        }
        //KeepBox�̍폜�{�^���������ꂽ�Ƃ�
        private void ���̃��X�g�̍폜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KeepBox.SelectedItem != null)
            {
                KeepBox.Items.Remove(KeepBox.SelectedItem);
            }

        }
        //�����l�ɖ߂����\�b�h
        public void ClearMethod()
        {
            // Display�̃N���A
            Display.Clear();

            //�t�B�[���h������            
            endflag = false;
            cursorposition = 0;
            cl.formula = "";
        }
        //�{�^���̃e�L�X�g��Display�֒ǉ�
        public void AddDisplay(string buttonText)
        {
            //�J�[�\���̈ʒu���擾
            cursorposition = Display.SelectionStart;
            //�J�[�\���ʒu�̒���Ƀ{�^���e�L�X�g��ǉ�
            Display.Text = Display.Text.Insert(cursorposition, buttonText);
            // �J�[�\���ʒu��}�������e�L�X�g�̌��ֈړ�
            cursorposition += buttonText.Length;
            // �e�L�X�g�{�b�N�X�̃t�H�[�J�X��ݒ肵�A�J�[�\����\��
            Display.Focus();           
        }

        //�C�R�[���ȍ~�𕶎���input�֒ǉ�
        public void AddEqual(string eql, string res)
        {
            Display.Text += (eql + res);

        }
        //�������K�؂Ȍ`�ɕϊ�����Display�֕\��
        public void UpdateDisplay(string txt)
        {
            //Display�̃e�L�X�g�𐔒l�]���p�ɉ��H���邽�߂�","����菜�����`�ŕ�����֑��
            string input = txt.Replace(",", "");

            //���K�\���@\D+�@�����ȊO�̕�����1��ȏ㑱�������Ő؂蕪���Ċi�[�B
            List<string> expression = Regex.Split(txt, @"(\D+)").ToList();

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
}

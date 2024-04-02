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
        // �v�Z����\������e�L�X�g�{�b�N�X�̖��O��Display
        // Keep�����v�Z�������郊�X�g�{�b�N�X�̖��O��KeepBox

        // �v�Z���I���������H�v�Z���ʂ��ł����̂�true�ɂȂ�
        public bool endflag = false;

        // �J�[�\���̈ʒu��ǐՂ��邽�߂̕ϐ�
        public int cursorposition = 0;

        // �v�Z���\�b�h�N���X�̃I�u�W�F�N�g
        Calculation cl;

        // �ۑ��n���\�b�h�N���X�̃I�u�W�F�N�g
        TempStorage ts;

        public CalculatorForm()
        {
            InitializeComponent();
            cl = new Calculation();
            ts = new TempStorage();
            ts.PushInitialValue();
        }

        //------��������e�{�^���̃C�x���g�n���h��-----------------

        // [0]���������Ƃ�
        private void button0_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("0");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);

        }
        // [1]���������Ƃ�
        private void button1_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("1");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [2]���������Ƃ�
        private void button2_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("2");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [3]���������Ƃ�
        private void button3_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("3");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [4]���������Ƃ�
        private void button4_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("4");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [5]���������Ƃ�
        private void button5_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("5");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [6]���������Ƃ�
        private void button6_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("6");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [7]���������Ƃ�
        private void button7_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("7");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [8]���������Ƃ�
        private void button8_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("8");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [9]���������Ƃ�
        private void button9_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            AddDisplay("9");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [00]���������Ƃ�
        private void button00_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
                return;
            }
            else if(Display.Text.Length == 0)
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
        // [.]���������Ƃ�
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                ClearMethod();
            }
            else if (Display.Text.Length == 0)
            {
                AddDisplay("0.");
                UpdateDisplay(Display.Text);
                ts.TempStack(Display.Text, cursorposition);
            }
            else
            {
                AddDisplay(".");
                UpdateDisplay(Display.Text);
                ts.TempStack(Display.Text, cursorposition);
            }
        }
        // [+]���������Ƃ�
        private void buttonpuls_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            else if(Display.Text.Length == 0)
            {
                return;
            }
            AddDisplay("+");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [-]���������Ƃ�
        private void buttonminus_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            else if (Display.Text.Length == 0)
            {
                return;
            }
            AddDisplay("-");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [�~]���������Ƃ�
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
            AddDisplay("�~");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        
        }
        // [��]���������Ƃ�
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
            else
            AddDisplay("��");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [�O����]���������Ƃ�
        private void buttonfrontbracket_Click(object sender, EventArgs e)
        {
            if (endflag)
            {
                SelectResult();
            }
            AddDisplay("(");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [�㊇��]���������Ƃ�
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
            else
            {
                AddDisplay(")");
                UpdateDisplay(Display.Text);
                ts.TempStack(Display.Text, cursorposition);
            }
        }
        // [��]���������Ƃ�
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
            AddDisplay("%");
            UpdateDisplay(Display.Text);
            ts.TempStack(Display.Text, cursorposition);
        }
        // [��]���������Ƃ�
        private void buttonequal_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɃC�R�[���������ꂽ�ꍇ
            if (endflag)
            {
                return;
            }
            else
            {
                // �����]���ŃG���[���Ȃ����
                if (cl.CheckFormula(cl.Evaluate(Display.Text)))
                {
                    // �v�Z���\�b�h
                    cl.Calculate();

                    if (cl.resultnumber == "NaN" || cl.resultnumber == "��" || string.IsNullOrEmpty(cl.resultnumber))
                    {
                        MessageBox.Show("Can't calculate", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        AddEqual("=", cl.resultnumber);
                        UpdateDisplay(Display.Text);
                        // Keep,AC,C�����{�^���������Ȃ��悤�ɂ���
                        endflag = true;
                    }
                }
                else
                {
                    return;
                }
            }
        }
        // Display���N���b�N���ꂽ��
        private void Display_Click(object sender, EventArgs e)
        {
            // �J�[�\���ʒu���擾
            cursorposition = Display.SelectionStart;
        }
        // Display�ɃL�[�_�E������������
        private void Display_KeyDown(object sender, KeyEventArgs e)
        {
            // �E���L�[�������ꂽ�Ƃ�
            if (e.KeyCode == Keys.Right)
            {
                // �J�[�\�����e�L�X�g�{�b�N�X�̖����ɂȂ��ꍇ�́A�J�[�\�����E�ɂ��炷
                if (Display.SelectionStart < Display.Text.Length)
                {
                    cursorposition++;
                }
            }
            // �����L�[�������ꂽ�Ƃ�
            else if (e.KeyCode == Keys.Left)
            {
                // �J�[�\�����e�L�X�g�{�b�N�X�̐擪�ɂȂ��ꍇ�́A�J�[�\�������ɂ��炷
                if (Display.SelectionStart != 0)
                {
                    cursorposition--;
                }
            }
        }
        // [delete]���������Ƃ�
        private void buttonchardelete_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����͉������Ȃ�
            if (endflag)
            {
                return;
            }
            // �J�[�\���ʒu��0�ŕ����񂪂���ꍇ
            else if (cursorposition == 0 && Display.Text.Length > 0)
            {
                return;
            }
            // �����񂪂Ȃ��ꍇ
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // �J�[�\��������ꍇ
            else if (cursorposition > 0)
            {
                // �J�[�\���̍����ꕶ���폜
                Display.Text = Display.Text.Remove(cursorposition - 1, 1);
                // Display�֕\��
                UpdateDisplay(Display.Text);
                // �J�[�\���̈ʒu���ēx�擾
                cursorposition -= 1;
                ts.TempStack(Display.Text, cursorposition);
            }
        }
        // [return]���������Ƃ�
        private void buttonreturn_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����͉������Ȃ�
            if (endflag)
            {
                return;
            }
            // �X�^�b�N��������̎�
            else if (ts.storageStack.Count==1 || ts.storageStackIndex.Count == 1)
            {
                return;
            }
            // �X�^�b�N�ɗv�f������ꍇ�͂��ꂼ��̒l�����o���đ��
            else
            {
                Display.Text = ts.PopDisplayText();
                cursorposition = ts.PopCursoulPosition();
                // ���ɖ߂������Display.Text�ƃJ�[�\���ʒu���X�^�b�N�֐ς�
                ts.TempStack(Display.Text, cursorposition);
            }
            
        }
        // [C]���������Ƃ�
        private void buttonTextClear_Click(object sender, EventArgs e)
        {
            // Display�ƃt�B�[���h�̏�����
            ClearMethod();
        }
        // [AC]���������Ƃ�
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            // Display�ƃt�B�[���h�̏�����
            ClearMethod();
            // KeepBox�̏�����
            KeepBox.Items.Clear();
        }
        // Keep�{�^�����N���b�N�����Ƃ�
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
        // Keep�{�^�����_�u���N���b�N��������Display�֒ǉ�
        private void KeepBox_DoubleClick(object sender, EventArgs e)
        {
            if (KeepBox.SelectedItem == null)
            {
                return;
            }
            else if (Display.Text.Contains("="))
            {
                // Display�ƃt�B�[���h�̏�����
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
        // KeepBox�̍폜�{�^���������ꂽ�Ƃ�
        private void ���̃��X�g�̍폜ToolStripMenuItem_Click(object sender, EventArgs e)
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
        // �����l�ɖ߂����\�b�h
        public void ClearMethod()
        {
            // Display�̃N���A
            Display.Clear();

            // �t�B�[���h������            
            endflag = false;
            cursorposition = 0;
            cl.formula = "";

            //�X�^�b�N�̃N���A
            ts.ClearStack();
            // �X�^�b�N�̏�����
            ts.PushInitialValue();
        }
        // �{�^���̃e�L�X�g��Display�֒ǉ�
        public void AddDisplay(string buttonText)
        {
            // Display.Text���X�V�����O�̒l���ꎞ�ۑ�
            string tmpDisplayText = Display.Text;

            // �J�[�\���ʒu�̒���Ƀ{�^���e�L�X�g��ǉ�
            Display.Text = Display.Text.Insert(cursorposition, buttonText);

            // �{�^���e�L�X�g�ǉ��O��Display.Text��00�`09�ȊO�̏ꍇ
            if (!(tmpDisplayText == "0" && buttonText != "00"))
            {
                // �J�[�\���ʒu��}�������e�L�X�g�̌��ֈړ�
                cursorposition += buttonText.Length;

                // ��L�̏������{�^���e�L�X�g�ǉ��O��Display.Text���󕶎����{�^���e�L�X�g��"00"�̏ꍇ
                if (tmpDisplayText == "" && buttonText == "00")
                {
                    // �J�[�\���ʒu����O�ɖ߂�
                    cursorposition--;
                }
            }
        }

        // �C�R�[���ȍ~�𕶎���input�֒ǉ�
        public void AddEqual(string eql, string res)
        {
            Display.Text += (eql + res);

        }
        // �������K�؂Ȍ`�ɕϊ�����Display�֕\��
        public void UpdateDisplay(string txt)
        {
            // ���݂̃J�[�\���ʒu�����̕����񐔂��擾
            int aftercursolstr = Display.Text.Substring(cursorposition).Length;

            // Display�̃e�L�X�g�𐔒l�]���p�ɉ��H���邽�߂�","����菜�����`�ŕ�����֑��
            string input = txt.Replace(",", "");

            // ���K�\���@\D+�@�����ȊO�̕�����1��ȏ㑱�������Ő؂蕪���Ċi�[�B
            List<string> expression = Regex.Split(input, @"([^0-9\.]+)").ToList();

            // expression����łȂ��ꍇ�́A�Ō�̗v�f���擾���A��̏ꍇ�͋󕶎����������
            string endExpression = expression.Count > 0 ? expression[expression.Count - 1] : "";

            // endExpression��null�łȂ��A���Ō�̕������s���I�h�łȂ��ꍇ�ɏ��������s����
            // �܂��́AendExpression����̏ꍇ�����������s����
            if (!string.IsNullOrEmpty(endExpression) && endExpression[endExpression.Length - 1] != '.' || string.IsNullOrEmpty(endExpression))
            {
                for (int i = 0; i < expression.Count; i++)
                {
                    // �󕶎��̏ꍇ�u���[�N
                    if (string.IsNullOrEmpty(expression[i]))
                    {
                        break;
                    }

                    // �����̎�
                    if (IsNumeric(expression[i]))
                    {
                        decimal number = Convert.ToDecimal(expression[i]);
                        expression[i] = number.ToString("#,##0.############");                        
                    }
                    // �p�[�Z���g�����O��������������
                    else if (expression[i] == "%" && IsNumeric(expression[i - 1]))
                    {
                        decimal number = Convert.ToDecimal(expression[i - 1]);
                        decimal answer = number * 0.01m;
                        expression[i - 1] = answer.ToString("#,##0.############");
                        expression.RemoveAt(i);
                        // �v�Z��̕�����̒�������v�Z�O�̕�����̒����������������J�[�\���ʒu���ړ�
                        cursorposition += (expression[i - 1].Length -cursorposition);
                    }
                }
            }
            // List�̗v�f�𕶎���֍ēx���
            Display.Text = string.Concat(expression);
            // �ϊ��O�̃J�[�\���̌�̕����񂪕ԊҌ�̕�����ƕς���Ă����ꍇ
            if(aftercursolstr != Display.Text.Substring(cursorposition).Length)
            {
                cursorposition += (Display.Text.Substring(cursorposition).Length - aftercursolstr);
            }
        }

        // �����񂪐��l����₤
        public static bool IsNumeric(string inp)
        {
            return decimal.TryParse(inp, out _);
        }

        // �v�Z���ʂ��灁�ȍ~�̕�������擾��Display�֒ǉ�����
        public void SelectResult()
        {
            // ���̃C���f�b�N�X���擾
            int index = Display.Text.IndexOf("=");

            // �������������ꍇ�A���̈ʒu�ȍ~�̕�����������擾
            if (index != -1)
            {
                // ���̈ʒu�ȍ~�̕�����������擾
                string selectresult = Display.Text.Substring(index + 1);
                // ���Z�b�g
                ClearMethod();
                // ���l�Ƃ���Display�֒ǉ�
                AddDisplay(selectresult);
            }
        }
    }
}

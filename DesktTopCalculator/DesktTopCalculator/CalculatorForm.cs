using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace DesktTopCalculator
{
    public partial class CalculatorForm : Form
    {
        // �v�Z���ʂ��ł����̂�true�ɂȂ�
        public bool endflag = false;

        // �J�[�\���̈ʒu��ǐՂ��邽�߂̕ϐ�
        public int cursorposition = 0;

        // �v�Z���\�b�h�N���X�̃I�u�W�F�N�g
        Calculation cl;

        // �ۑ��n���\�b�h�N���X�̃I�u�W�F�N�g
        TempStorage ts;

        // �t�H�[���̃R���X�g���N�^�[
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
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // ������
                ClearMethod();
            }
            // �J�[�\���ʒu�̑O�̕������㊇�ʂ�������%�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("0");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);

        }

        // [1]���������Ƃ�
        private void button1_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // ������
                ClearMethod();
            }
            // �J�[�\���ʒu�̑O�̕������㊇�ʂ�������%�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("1");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);
        }

        // [2]���������Ƃ�
        private void button2_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // ������
                ClearMethod();
            }
            // �J�[�\���ʒu�̑O�̕������㊇�ʂ�������%�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }


            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("2");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);
        }

        // [3]���������Ƃ�
        private void button3_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // ������
                ClearMethod();
            }
            // �J�[�\���ʒu�̑O�̕������㊇�ʂ�������%�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("3");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);
        }

        // [4]���������Ƃ�
        private void button4_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // ������
                ClearMethod();
            }
            // �J�[�\���ʒu�̑O�̕������㊇�ʂ�������%�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("4");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);
        }

        // [5]���������Ƃ�
        private void button5_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // ������
                ClearMethod();
            }
            // �J�[�\���ʒu�̑O�̕������㊇�ʂ�������%�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("5");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);
        }

        // [6]���������Ƃ�
        private void button6_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // ������
                ClearMethod();
            }
            // �J�[�\���ʒu�̑O�̕������㊇�ʂ�������%�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("6");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);
        }

        // [7]���������Ƃ�
        private void button7_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // ������
                ClearMethod();
            }
            // �J�[�\���ʒu�̑O�̕������㊇�ʂ�������%�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("7");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);
        }

        // [8]���������Ƃ�
        private void button8_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // ������
                ClearMethod();
            }
            // �J�[�\���ʒu�̑O�̕������㊇�ʂ�������%�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("8");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);
        }

        // [9]���������Ƃ�
        private void button9_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // ������
                ClearMethod();
            }
            // �J�[�\���ʒu�̑O�̕������㊇�ʂ�������%�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%]"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("9");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);
        }

        // [00]���������Ƃ�
        private void button00_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // ������
                ClearMethod();
                return;
            }
            // ���͂͂��߂̂Ƃ�
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // �J�[�\���ʒu�̑O�̕�����(+,-,�~,��,����,%)�����ꂩ�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\(\)\%]"))
            {
                return;
            }
            else
            {
                // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
                AddDisplay("00");
                UpdateDisplay(Display.Text);

                // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
                ts.TempStack(Display.Text, cursorposition);
            }
        }

        // [.]���������Ƃ�
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // ������
                ClearMethod();

                // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
                AddDisplay("0.");
                UpdateDisplay(Display.Text);

                // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
                ts.TempStack(Display.Text, cursorposition);

            }
            // ���͂͂��߂̂Ƃ�
            else if (Display.Text.Length == 0)
            {
                // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
                AddDisplay("0.");
                UpdateDisplay(Display.Text);

                // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
                ts.TempStack(Display.Text, cursorposition);
            }
            // �J�[�\���ʒu�̑O�̕�����(+,-,�~,��,�O����)�����ꂩ�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\(]"))
            {
                // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
                AddDisplay("0.");
                UpdateDisplay(Display.Text);

                // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
                ts.TempStack(Display.Text, cursorposition);
            }
            // �J�[�\���ʒu�̑O�̕�����(.,%,�㊇��)�����ꂩ�̂Ƃ�
            else if (cursorposition > 0�@&& Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\.\%\)]"))
            {
                return;
            }
            else
            {
                // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
                AddDisplay(".");
                UpdateDisplay(Display.Text);

                // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
                ts.TempStack(Display.Text, cursorposition);
                
            }
        }

        // [+]���������Ƃ�
        private void buttonpuls_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // �v�Z���ʂ̐��������݂̂�؂肾��Display�֕\��
                SelectResult();
            }
            // ���͂͂��߂̂Ƃ�
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // �J�[�\���ʒu�̑O�̕�����(+,-,�~,��.,%)�����ꂩ�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\.\%]"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("+");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);
        }

        // [-]���������Ƃ�
        private void buttonminus_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // �v�Z���ʂ̐��������݂̂�؂肾��Display�֕\��
                SelectResult();
            }
            // �J�[�\���ʒu�̑O�̕�����(+,-,�~,��,.,%)�����ꂩ�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\.\%]"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("-");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);
        }

        // [�~]���������Ƃ�
        private void buttonmultiply_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // �v�Z���ʂ̐��������݂̂�؂肾��Display�֕\��
                SelectResult();
            }
            // ���͂͂��߂̂Ƃ�
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // �J�[�\���ʒu�̑O�̕�����(+,-,�~,��,�O����,.,%)�����ꂩ�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\(\.\%]"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("�~");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);
        }

        // [��]���������Ƃ�
        private void buttondivision_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // �v�Z���ʂ̐��������݂̂�؂肾��Display�֕\��
                SelectResult();
            }
            // ���͂͂��߂̂Ƃ�
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // �J�[�\���ʒu�̑O�̕�����(+,-,�~,��,�O����,.,%)�����ꂩ�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\+\-\u00D7\u00F7\(\.\%]"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("��");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);

        }

        // [�O����]���������Ƃ�
        private void buttonfrontbracket_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // ������
                ClearMethod();
            }
            // �J�[�\���ʒu�̑O�̕�����(�㊇��,.,%)�����ꂩ�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\.\%]"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("(");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);
        }

        // [�㊇��]���������Ƃ�
        private void buttonbackbracket_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // �v�Z���ʂ̐��������݂̂�؂肾��Display�֕\��
                SelectResult();
                return;
            }
            // ���͂͂��߂̂Ƃ�
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // �J�[�\���ʒu�̑O�̕����������ȊO�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"\D"))
            {
                return;
            }
            else
            {
                // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
                AddDisplay(")");
                UpdateDisplay(Display.Text);

                // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
                ts.TempStack(Display.Text, cursorposition);
            }
        }

        // [��]���������Ƃ�
        private void buttonpercent_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                // �v�Z���ʂ̐��������݂̂�؂肾��Display�֕\��
                SelectResult();
            }
            // ���͂͂��߂̂Ƃ�
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // �J�[�\���ʒu�̑O�̕����������ȊO�̂Ƃ�
            else if (cursorposition > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"\D"))
            {
                return;
            }

            // �e����������Display�Ƀe�L�X�g�Ƃ��ĕ\��
            AddDisplay("%");
            UpdateDisplay(Display.Text);

            // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
            ts.TempStack(Display.Text, cursorposition);
        }

        // [��]���������Ƃ�
        private void buttonequal_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                return;
            }
            // Display�̕�����2�����ȉ��̂Ƃ�
            else if (Display.Text.Length <= 2)
            {
                return;
            }
            // �����񂪂���ADisplay�̍Ō�̕�����(+,-,�~,��,�O����,.,%)�̂Ƃ�
            else if (!string.IsNullOrEmpty(Display.Text) && Regex.IsMatch(Display.Text[Display.Text.Length - 1].ToString(), @"[\+\-\u00D7\u00F7\(\.\%]"))
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

                    // �v�Z�s�\�A�v�Z���ʁ��A���ʋ󕶎��̂Ƃ�
                    if (cl.resultnumber == "NaN" || cl.resultnumber == "��" || string.IsNullOrEmpty(cl.resultnumber))
                    {
                        // �G���[�̃��b�Z�[�W�{�b�N�X�\��
                        MessageBox.Show("Can't calculate", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        // �C�R�[���ȉ�����������Display�֕\��
                        AddEqual("=", cl.resultnumber);
                        UpdateDisplay(Display.Text);

                        // �v�Z���I�������t���O�𗧂Ă�
                        endflag = true;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        // [Display]���������Ƃ�
        private void Display_Click(object sender, EventArgs e)
        {
            // �J�[�\���ʒu���擾
            cursorposition = Display.SelectionStart;
        }

        // [Display]�ɃL�[�_�E������������
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
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                return;
            }
            // �J�[�\���ʒu��0�̂Ƃ�
            else if (cursorposition == 0)
            {
                return;
            }
            // �����񂪂Ȃ��Ƃ�
            else if (Display.Text.Length == 0)
            {
                return;
            }
            // �J�[�\��������ꍇ
            else if (cursorposition > 0)
            {
                // �J�[�\���̒��O�̕������J���}�̂Ƃ�
                if (Display.Text[cursorposition -1] == ',')
                {
                    // �J�[�\���̍����񕶎��폜
                    Display.Text = Display.Text.Remove(cursorposition - 2, 2);

                    // �J�[�\���̈ʒu��2���炷
                    cursorposition -= 2;

                    // Display�֕\��
                    UpdateDisplay(Display.Text);

                    // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
                    ts.TempStack(Display.Text, cursorposition);

                }
                else
                {
                    // �J�[�\���̍����ꕶ���폜
                    Display.Text = Display.Text.Remove(cursorposition - 1, 1);

                    // �J�[�\���̈ʒu��1���炷
                    cursorposition--;

                    // Display�֕\��
                    UpdateDisplay(Display.Text);

                    // Stack��Display�̃e�L�X�g�ƃJ�[�\���ʒu��Push
                    ts.TempStack(Display.Text, cursorposition);

                }               
            }
        }

        // [return]���������Ƃ�
        private void buttonreturn_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                return;
            }
            // �X�^�b�N��������̂Ƃ�
            else if (ts.storageStack.Count == 1 || ts.storageStackIndex.Count == 1)
            {
                return;
            }
            // �X�^�b�N�ɗv�f������Ƃ�
            else
            {
                // �X�^�b�N��2�Ԗڂ�Display�e�L�X�g�ƃJ�[�\���ʒu����
                Display.Text = ts.PopDisplayText();
                cursorposition = ts.PopCursoulPosition();

                // ���ɖ߂������Display.Text�ƃJ�[�\���ʒu���X�^�b�N�֐ς�
                ts.TempStack(Display.Text, cursorposition);
            }
        }

        // [C]���������Ƃ�
        private void buttonTextClear_Click(object sender, EventArgs e)
        {
            // Display�ƃ����o�[�ϐ��̏�����
            ClearMethod();
        }

        // [AC]���������Ƃ�
        private void buttonAllClear_Click(object sender, EventArgs e)
        {
            // Display�ƃ����o�[�ϐ��̏�����
            ClearMethod();

            // KeepBox�̏�����
            KeepBox.Items.Clear();
        }

        // [Keep]���������Ƃ�
        private void buttonKeep_Click(object sender, EventArgs e)
        {
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            if (endflag)
            {
                KeepBox.Items.Add(Display.Text);
            }
            else
            {
                return;
            }
        }

        // [KeepBox]���_�u���N���b�N�����Ƃ�
        private void KeepBox_DoubleClick(object sender, EventArgs e)
        {
            // KeepBox����̂Ƃ�
            if (KeepBox.SelectedItem == null)
            {
                return;
            }
            // �v�Z���ʂ��o����ɉ����ꂽ�Ƃ�
            else if (endflag)
            {
                // Display�ƃt�B�[���h�̏�����
                ClearMethod();

                // Display��Keep�̉񓚕����̂ݒǉ�
                AddDisplay(ts.SelectResult(KeepBox));
                UpdateDisplay(Display.Text);
            }
            // �v�Z�����͓r���̎�
            else
            {
                // �J�[�\���ʒu�̑O�̕������㊇�ʂ�������%�������̓s���I�h�̂Ƃ�
                if (Display.Text.Length > 0 && Regex.IsMatch(Display.Text[cursorposition - 1].ToString(), @"[\)\%\.]"))
                {
                    return;
                }
                // Display��Keep�̉񓚕����̂ݒǉ�
                else
                {
                    // KeepBox�̉񓚕�����Display�֒ǉ�
                    AddDisplay(ts.SelectResult(KeepBox));
                    UpdateDisplay(Display.Text);
                }
            }
        }

        // KeepBox�̍폜�{�^���������ꂽ�Ƃ�
        private void ���̃��X�g�̍폜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // KeepBox��null�łȂ��Ƃ�
            if (KeepBox.SelectedItem != null)
            {
                // KeepBox�̃A�C�e�����폜
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

            // �����o�[�ϐ��̏�����            
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
            // �J�[�\���ʒu�̒���Ƀ{�^���e�L�X�g��ǉ�
            Display.Text = Display.Text.Insert(cursorposition, buttonText);

            // �J�[�\���ʒu��}�������e�L�X�g�̌��ֈړ�
            cursorposition += buttonText.Length;
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

            // ������1��ȏ㑱�������Ő؂蕪���ă��X�g�Ɋi�[�B
            List<string> expression = Regex.Split(input, @"([^\d\.]+)").ToList();

            for (int i = 0; i < expression.Count; i++)
            {
                // �����̎�
                if (Regex.IsMatch(expression[i], @"\d"))
                {
                    // ������Ƀs���I�h���܂܂�Ă�����
                    if (expression[i].Contains('.'))
                    {
                        // ������̒��ň�Ԗڂ̃s���I�h�̈ʒu���m�F
                        int index = expression[i].IndexOf('.');

                        // �s���I�h�̑O�̕�������擾
                        string beforepiriod = expression[i].Substring(0, index);

                        // �s���I�h�̑O�̕�������O����؂�֕ϊ��������̂ƃs���I�h�ȍ~�𑫂��ĕ�������쐬
                        expression[i] = Regex.Replace(beforepiriod, @"(\d{1,3})(?=(\d{3})+(?!\d))", "$1,") + expression[i].Substring(index);
                    }
                    else
                    {
                        expression[i] = Regex.Replace(expression[i], @"(\d{1,3})(?=(\d{3})+(?!\d))", "$1,");
                    }
                }
                // �p�[�Z���g�����O��������������
                else if (expression[i] == "%" && Regex.IsMatch(expression[i - 1], @"\d"))
                {
                    try
                    {
                        // %�̑O�̐�����decimal�^�ɕϊ�
                        decimal number = decimal.Parse(expression[i - 1]);

                        // �ϊ�����������0.01��������
                        decimal answer = number * 0.01m;

                        // �v�Z���ʂ𕶎���ɕϊ����đ��
                        expression[i - 1] = answer.ToString("#,##0.################");

                        // %�̃C���f�b�N�X���폜
                        expression.RemoveAt(i);

                        // �v�Z��̕�����̒�������v�Z�O�̕�����̒����������������J�[�\���ʒu���ړ�
                        cursorposition += (expression[i - 1].Length - cursorposition);
                    }
                    // �����̒��ɏ����_�������܂܂��Ƃ�
                    catch (FormatException)
                    {
                        // �G���[�̃��b�Z�[�W�{�b�N�X�\��
                        MessageBox.Show("Number is invalid", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // %�̃C���f�b�N�X���폜
                        expression.RemoveAt(i);

                        // �J�[�\���ʒu�����ɖ߂�
                        cursorposition--;

                        break;
                    }
                    // Decimal�^�̌����𒴂��Ă���Ƃ�
                    catch (OverflowException)
                    {
                        // �G���[�̃��b�Z�[�W�{�b�N�X�\��
                        MessageBox.Show("Number of digits is out of range", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // %�̃C���f�b�N�X���폜
                        expression.RemoveAt(i);

                        // �J�[�\���ʒu�����ɖ߂�
                        cursorposition--;

                        break;
                    }
                    // ���̑��̃G���[�����������Ƃ�
                    catch (Exception)
                    {
                        // �G���[�̃��b�Z�[�W�{�b�N�X�\��
                        MessageBox.Show("Cannot be calculated", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // %�̃C���f�b�N�X���폜
                        expression.RemoveAt(i);

                        // �J�[�\���ʒu�����ɖ߂�
                        cursorposition--;

                        break;
                    }
                }
            }

            // List�̗v�f�𕶎���֍ēx���
            Display.Text = string.Concat(expression);

            // Display�̃e�L�X�g�̒������J�[�\���ʒu���Z����
            if (Display.Text.Length < cursorposition)
            {
                // �J�[�\���ʒu�𕶎���̍Ō���ֈړ�
                cursorposition -= cursorposition - Display.Text.Length;
            }

            // �ϊ���ɃJ�[�\���̈ʒu�̌��̕������������Ă����Ƃ�
            if (aftercursolstr < Display.Text.Substring(cursorposition).Length)
            {
                // ���������������J�[�\���ʒu���ړ�
                cursorposition += (Display.Text.Substring(cursorposition).Length - aftercursolstr);
            }
            // �ϊ���ɃJ�[�\���̈ʒu�̌��̕������������Ă����Ƃ�
            else if (aftercursolstr > Display.Text.Substring(cursorposition).Length)
            {
                // ���������������J�[�\���ʒu���ړ�
                cursorposition += (Display.Text.Substring(cursorposition).Length - aftercursolstr);
            }

            // SelectionStart�Ɍ��݂̃J�[�\���ʒu����
            Display.SelectionStart = cursorposition;

            // �J�[�\���ʒu�Ƀt�H�[�J�X�������Ă��郁�\�b�h
            Display.ScrollToCaret();
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

                // ������
                ClearMethod();

                // ���l�Ƃ���Display�֒ǉ�
                AddDisplay(selectresult);
            }
        }
    }
}

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
        private bool firstflag = true;

        //�����̓��͉ۑ���̂���
        private bool canflag = true;

        //�N���b�N���ꂽ�l���i�[����List
        List<string> expression = new List<string>();

        //�v�Z�p�̕�������i�[����
        string? formula = "";


        //Keep�{�^���������ꂽ�Ƃ���List�̓��e���ꎞ�I�ɕۊǂ���IEnumerable
        //��{�ǂݎ���p�Ń������̐ߖ񂪊��҂���邽�ߍ̗p
        IEnumerable<string> keepresult;


        public Form1()
        {
            InitializeComponent();
        }


        //------��������e�{�^���̃C�x���g�n���h��-----------------------

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
            if (firstflag == true)//�R���}���擪�ŉ����ꂽ�ꍇ
            {
                AddNumber("0");
                AddNumber(".");
            }
            else if (expression.Last().Last().ToString() == ".")//���O�ɃJ���}������ꍇ
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
            else if ((expression.Count > 0) && (expression.Last().Last().ToString() == ")"))//���O��")"�����鎞
            {
                return;
            }
            else if ((expression.Count > 0) && (expression.Last().Last().ToString() == "."))//���O�ɃJ���}�����鎞
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
            ElseButton(")");            
        }
        private void buttonpercent_Click(object sender, EventArgs e)
        {
            if (firstflag == true)//���߂Ă̓��͂̎������Z�q�̒���
            {
                return;
            }
            else if (expression.Last().Last().ToString() == ".")//���O�ɃJ���}�����鎞
            {
                return;
            }
            else if (expression.Last().Last().ToString() == "%")//���O��%�����鎞
            {
                return;
            }
            else
            {
                expression.Add("%");
                UpdateDisplay();
                canflag = false;//����ɐ�������͂����Ȃ�
            }
        }
        private void buttonequal_Click(object sender, EventArgs e)
        {
            Evaluation();//�v�Z�̂��߂ɕ������V���Ɏ擾���郁�\�b�h

            Calculate();//�v�Z���\�b�h

            canflag = false;//����ɐ�������͂����Ȃ�

        }

        private void buttonchardelete_Click(object sender, EventArgs e)
        {
            if (expression.Count > 0)//List�ɗv�f�����鎞�A�������폜
            {
                expression.RemoveAt(expression.Count - 1);
                Display.Text = string.Join("", expression);
            }
            else if (expression.Count == 0)//List��̎��̗�O����
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
        //--------------��������e���\�b�h----------------------------

        // ������List�֒ǉ����ADisplay�֕\�������郁�\�b�h

        //�����l�]���̎���0���擪�̏ꍇ���l������\��Ȃ̂ł����ł�0�̏����͂����ɕ\��
        //�����Ȃ킿0123�̂悤�ȕ\�L�����e����
        //���܂��J���}�̐����\�L�̎��_�ł͌��y�����v�Z�̎��_�ŃG���[���b�Z�[�W���o���\��

        private void AddNumber(string number)
        {
            expression.Add(number);
            UpdateDisplay();
            if (firstflag == true)//���������߂Ă̓��͂������ꍇ
            {
                firstflag = false;
            }
            canflag = true;
        }

        // ���Z�q��List�֒ǉ����ADisplay�֕\�������郁�\�b�h

        private void AddOperator(string ope)
        {
            if (firstflag == true) //���͂͂��߂܂��͉��Z�q�����O�ɂ��鎞
            {
                return;
            }
            expression.Add(ope);
            UpdateDisplay();
            firstflag = true;
            canflag = true;
        }

        //")"��"="�{�^����List�֒ǉ����郁�\�b�h
        private void ElseButton(string button)
        {
            if (firstflag == true)//���߂Ă̓��͂̎������Z�q�̒���
            {
                return;
            }
            else if (expression.Last().Last().ToString() == ".")//���O�ɃJ���}�����鎞
            {
                return;
            }
            else if (expression.Last().Last().ToString() == "(")//���O�ɃJ���}�����鎞
            {
                return;
            }
            else
            {
                expression.Add(button);
                UpdateDisplay();
                canflag = true;//�t���O�̏�����
            }
        }
        
        //�\����ʂ̐�����3����؂�����郁�\�b�h
        //�����������̃��\�b�h�͕s�\���̈׉��ǕK�v�B�B�B
        private void UpdateDisplay()
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

        //���͂��ꂽ���l�̕]���ƌv�Z�̑O����
        //�v�Z�p�Ƃ��� string�^formula�֒l����

        private void Evaluation()
        {
            foreach (string f in expression)
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
                    ElseButton("=");
                    expression.Add(result.Result.ToString());
                    UpdateDisplay();
            }
            catch 
            {
                MessageBox.Show("Cannot be calculated", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         
        }

    }
}
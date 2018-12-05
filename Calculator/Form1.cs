using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public static string str = "";   //字符的存取与叠加
        bool isEqual=true;   //判断上一次是否点击了等号
        string memory="";   //ms保存的数据
        bool m_ = false;   //判断是否进行存储数据加减法
        /// <summary>
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
            //Form1_Load(this,);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void equal_Click(object sender, EventArgs e)  //点击等于
        {
            if (isEqual == true)
            {
                textBox1.Text = "0";
                return;
            }
            isEqual = true;
            str = textBox1.Text;
            String str1 = new Calculate().calculating(str);
            if (m_&&str1!=null&&!str.Equals("错误"))     //读入计算后的存储数据
            {
                memory = new string(str1.ToCharArray());
                m_ = false;
            }
            if (str.Equals("错误"))
            {
                error.Visible = true;
                str = "";
            }
            else str = str1;
            textBox1.Text = str;
        }
        private void zero_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '0';
            textBox1.Text = str;
        }

        private void dot_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '.';
            textBox1.Text = str;
        }

        private void three_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '3';
            textBox1.Text = str;
        }

        private void tow_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '2';
            textBox1.Text = str;
        }

        private void one_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '1';
            textBox1.Text = str;
        }

        private void four_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '4';
            textBox1.Text = str;
        }

        private void five_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '5';
            textBox1.Text = str;
        }

        private void six_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '6';
            textBox1.Text = str;
        }

        private void seven_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '7';
            textBox1.Text = str;
        }

        private void eight_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '8';
            textBox1.Text = str;
        }

        private void nine_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '9';
            textBox1.Text = str;
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '+';
            textBox1.Text = str;
        }

        private void sub_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '-';
            textBox1.Text = str;
        }

        private void multi_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '*';
            textBox1.Text = str;
        }

        private void division_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '/';
            textBox1.Text = str;
        }

        private void lefBracket_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '(';
            textBox1.Text = str;
        }

        private void rigBracket_Click(object sender, EventArgs e)//点击右括号
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += ')';
            textBox1.Text = str;
        }

        private void twicePower_Click(object sender, EventArgs e)//点击2次方
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += "^2";
            textBox1.Text = str;
        }

        private void threethPower_Click(object sender, EventArgs e)//点击3次方
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += "^3";
            textBox1.Text = str;
        }

        private void nthPower_Click(object sender, EventArgs e)//点击n次方
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '^';
            textBox1.Text = str;
        }

        private void radical_Click(object sender, EventArgs e)  //点击2次方根
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '√';
            textBox1.Text = str;
        }

        private void factorial_Click(object sender, EventArgs e)  //点击阶乘
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '!';
            textBox1.Text = str;
        }

        private void delete_Click(object sender, EventArgs e)   //点击删除键
        {
            if (error.Visible) error.Visible = false;
            if (textBox1.Text == "") return;
            if (isEqual) textBox1.Text = "";
            else
            {
                char[] str1 = textBox1.Text.ToCharArray();
                str = "";
                for (int i = 0; i < str1.Length - 1; i++) str += str1[i];
                textBox1.Text = str;
            }
            isEqual = false;
        }

        private void ms_Click(object sender, EventArgs e)
        {
            if (error.Visible) error.Visible = false;
            if (textBox1.Text == "" || textBox1.Text == null || textBox1.Text == "0") return;
            m.Visible = true;     //M标识可见
            memory = new string(textBox1.Text.ToCharArray());   //保存数据
            isEqual = true;
        }

        private void mr_Click(object sender, EventArgs e)    //读取存储数据
        {
            if (error.Visible) error.Visible = false;      //若error可见，则设置为不可见
            if (!m.Visible) return;     //若M不可见，则不执行
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            textBox1.Text += memory ;
        }

        private void mc_Click(object sender, EventArgs e)   //清除存储数据
        {
            if (error.Visible) error.Visible = false;     //若error可见，则设置为不可见
            if (!m.Visible) return;    //若M不可见，则不执行
            m.Visible = false;
            m.Visible = false;  //M标识消失
            memory = "";
        }

        private void mEqual_Click(object sender, EventArgs e)   //存储数据M加法
        {
            if (error.Visible) error.Visible = false;     //若error可见，则设置为不可见
            if (m.Visible)
            {
                m_ = true;
                str = "";
                str += memory + '+';
                isEqual = false;
                textBox1.Text = str;
            }
        }

        private void mSub_Click(object sender, EventArgs e)  //存储数据减法
        {
            if (error.Visible) error.Visible = false;     //若error可见，则设置为不可见
            if (m.Visible)
            {
                m_ = true;
                str = "";
                str += memory + '-';
                isEqual = false;
                textBox1.Text = str;
            }
        }

        private void mod_Click(object sender, EventArgs e)  //点击求模运算
        {
            if (error.Visible) error.Visible = false;
            if (isEqual)
            {
                textBox1.Text = "";
                isEqual = false;
            }
            str = textBox1.Text;
            str += '%';
            textBox1.Text = str;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Calculator
{
    class Calculate
    {
        /*加载加法运算动态链接库*/
        [DllImport(@"./Release/AddDLL.dll", EntryPoint = "add", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern double add(double a, double b);
        /*加载减法运算动态链接库*/
        [DllImport(@"./Release/SubDLL.dll", EntryPoint = "sub", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern double sub(double a, double b);
        /*加载乘法运算动态链接库*/
        [DllImport(@"./Release/MulitDLL.dll", EntryPoint = "mulit", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern double mulit(double a, double b);
        /*加载除法运算动态链接库*/
        [DllImport(@"./Release/DivDLL.dll", EntryPoint = "div", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern double div(double a, double b);

        Stack<double> s = new Stack<double>();
        void PushOperand(double op)
        {
            s.Push(op);
        }
        public string calculating(string str1)  //计算输入式
        {
            double newop=0;
            List<String> str2;
            str2=infixToPostfix(str1.ToCharArray());    //获取中缀表达式
            foreach(String str3 in str2)
            {
                if (str3.Length == 1)
                {
                    switch (str3.ToCharArray()[0])
                    {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                        case '^':
                            DoOperator(str3.ToCharArray()[0]);
                            break;
                        default:
                            PushOperand((double)(str3.ToCharArray()[0] - '0'));
                            break;
                    }
                }
                else
                {
                    char[] operand1 = str3.ToCharArray();
                    double sum = 0;
                    int n = 0;
                    bool dot = false;
                    for (int i=0; i<operand1.Length&&(operand1[i] >= '0' && operand1[i] <= '9' || operand1[i] == '.'); i++)
                    {
                        if (operand1[i] == '.') //判断是否有小数点
                        {
                            dot = true;
                            continue;
                        }
                        if (!dot) sum = sum * 10 + (operand1[i] - '0');   //算整数
                        else    //加上小数
                        {
                            sum = sum + (operand1[i] - '0') * Math.Pow(10, -++n);
                        }
                        Console.WriteLine(sum);
                    }
                    Console.WriteLine();
                    PushOperand(sum);
                }
            }
            if (Form1.str.Equals("错误")) return null;
            if (s.Top(ref newop)) return newop.ToString();
            return null;
        }
        bool GetOperands(ref double op1,ref double op2)
        {
            if(!s.Top(ref op1))
            {
                return false;
            }
            s.Pop();
            if(!s.Top(ref op2))
            {
                return false;
            }
            s.Pop();
            return true;
        }
        void DoOperator(char oper)
        {
            bool result;
            double oper1=0, oper2=0;
            result = GetOperands(ref oper1, ref oper2);
            if (result)
                switch (oper)
                {
                    case '+': s.Push(add(oper1 , oper2)); break;
                    case '-': s.Push(sub(oper2 , oper1)); break;
                    case '*': s.Push(mulit(oper2 , oper1)); break;
                    case '/':
                        if (oper1 == 0)
                        {
                            s.Clear();
                        }
                        else s.Push(div(oper2 , oper1)); break;
                    case '^': s.Push(Math.Pow(oper2, oper1)); break;
                }
            else s.Clear();
        }
        private List<String> infixToPostfix(char[] operand)   //中缀表达式转换为后缀表达式
        {
            List<String> str1=new List<string>();    //因数及运算符存储
            Stack<char> s=new Stack<char>();
            char y='\0'; s.Push('#');    //#号作为结束的标志
            for(int i = 0; i < operand.Length; i++)
            {
                if (operand[i] >= '0' && operand[i] <= '9')
                {
                    double sum = 0,//运算符边的数字
                           sum1=0;  //运算符边的数字
                    int n = 0;
                    bool dot = false;   //判断是否有小数点
                    bool mod = false;  //判断是否有模运算
                    for (;i<operand.Length&&(operand[i] >= '0' && operand[i] <= '9'||operand[i]=='.'||operand[i]=='!'||operand[i]=='%'); i++)
                    {
                        if (operand[i] == '.')//判断是否有小数点
                        {
                            dot = true;
                            continue;
                        }
                        if (operand[i] == '!')   //计算阶乘
                        {
                            if (!dot) sum = factorial(sum);   //判断，小数没有阶乘
                            else Form1.str = "错误";
                            continue;
                        }
                        if (operand[i] == '%')   //判断是否有模运算
                        {
                            mod = true ;
                            sum1 = sum;
                            sum = 0;
                            continue;
                        }
                        if (!dot) sum = sum * 10 + (operand[i] - '0');   //算整数
                        else    //加上小数
                        {
                            sum = sum + (operand[i] - '0') * Math.Pow(10, -++n);
                        }
                        if (mod)
                        {
                            if ((i + 1) < operand.Length && (operand[i + 1] >= '0' && operand[i + 1] <= '9' || operand[i + 1] == '.' || operand[i + 1] == '!' || operand[i + 1] == '%')) ;
                            else if (sum >= 1) sum = (int)sum1 % (int)sum;
                            else Form1.str = "错误";
                        }
                    }
                    i--;      //把多增加的i减回来
                    str1.Add(sum.ToString());
                }
                else if(operand[i]== '√')     //求根号
                {
                    double sum = 0;
                    int n = 0;
                    bool dot = false;
                    for (i++; i < operand.Length && (operand[i] >= '0' && operand[i] <= '9' || operand[i] == '.' || operand[i] == '!'); i++)
                    {
                        if (operand[i] == '.')//判断是否有小数点
                        {
                            dot = true;
                            continue;
                        }
                        if (operand[i] == '!')   //计算阶乘
                        {
                            if (!dot) sum = factorial(sum);   //判断，小数没有阶乘
                            else Form1.str = "错误";
                            continue;
                        }
                        if (!dot) sum = sum * 10 + (operand[i] - '0');   //算整数
                        else    //加上小数
                        {
                            sum = sum + (operand[i] - '0') * Math.Pow(10, -++n);
                        }
                    }
                    sum = Math.Sqrt(sum);    //求根号
                    i--;      //把多增加的i减回来
                    str1.Add(sum.ToString());
                }
                else if (operand[i] == ')')
                    for (s.Top(ref y), s.Pop(); y != '('; s.Top(ref y), s.Pop()) str1.Add(y.ToString());
                else
                {
                    for (s.Top(ref y), s.Pop(); icp(operand[i]) <= isp(y); s.Top(ref y), s.Pop()) str1.Add(y.ToString());
                    s.Push(y);
                    s.Push(operand[i]);
                }
            }
            while (!s.IsEmpty())
            {
                s.Top(ref y);
                s.Pop();
                if (y != '#') str1.Add(y.ToString());
            }
            return str1;
        }
        private double factorial(double sum)    //求整数sum的阶乘
        {
            if (sum == 0) return 1;
            int n = (int)sum;
            sum = 1;
            if (n < 13) for (int i = 1; i <= n; i++) sum = sum * i;
            else Form1.str = "错误";
            return sum;
        }
        private int icp(char c)
        {
            switch (c)
            {
                case '#': return 0;
                case '(': return 7;
                case '^': return 6;
                case '*': return 4;
                case '/': return 4;
                case '+': return 2;
                case '-': return 2;
                case ')': return 1;
                default: return -1;
            }
        }
        private int isp(char c)
        {
            switch (c)
            {
                case '#': return 0;
                case '(': return 1;
                case '^': return 6;
                case '*': return 5;
                case '/': return 5;
                case '+': return 3;
                case '-': return 3;
                case ')': return 7;
                default: return -1;
            }
        }
    }
}

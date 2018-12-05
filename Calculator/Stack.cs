using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Stack<T>
    {
        private int top=-1;   //栈顶指针
        private int maxTop=50;  //最大栈顶指针,默认为50
        T[] s=new T[50];    //存储顺序栈的数组
        public bool IsEmpty()   
        {
            return top == -1;
        }
        public bool IsFull()
        {
            return top == maxTop;
        }
        public bool Top(ref T x)   //返回栈顶的值
        {
            if (IsEmpty())
            {
                Form1.str="错误";
                return false;
            }
            x = s[top];
            return true;
        }
        public bool Push(T x)    //进栈
        {
            if (IsFull())
            {
                Form1.str = "错误";
                return false;
            }
            s[++top] = x;
            return true;
        }
        public bool Pop()    //出栈
        {
            if (IsEmpty())
            {
                Form1.str = "错误";
                return false;
            }
            top--;
            return true;
        }
        public void Clear()
        {
            top = -1;
        }
    }
}

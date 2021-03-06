using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C_SHARP_STUDY
{
    public partial class Form1 : Form
    {
        //用户看到的是V(WINFORM,ASPX...)
        //这里是控制类C(IF...ELSE....)
        public Form1()
        {
            InitializeComponent();
        }
        //实体类声明M
        private PARA p = new PARA();
        //业务类声明
        private Logic l = new Logic();

        private void button1_Click(object sender, EventArgs e)
        {
            //实体类赋值
            p.ID = 11123;
            //处理登录(比如1.清空工作环境2.临时表登录3.xxxx4.xxxxN.清空工作环境)
            //按照业务的逻辑顺序登录处理列表，这样主调度函数就可以循环处理了
            Logic.MyTestDelgate[] list = new Logic.MyTestDelgate[] {
                  l.functionM1
                , l.functionM2
                , l.functionM3 
            };
            //主函数调度
            this.testDg(list);
        }
        //主函数,执行顺序及其流程控制(事务等)，根据具体业务组织，
        //处理列表中放入哪些函数，开发者自己是清楚滴
        private int testDg(Logic.MyTestDelgate[] M)
        {
            try
            {
                for (int i = 0; i < M.Length; i++)
                {
                    //处理逐次进行
                    this.listBox1.Items.Add(M[i](p));
                }
                return 0;
            }
            catch 
            {
                return 1;
            }
        }
    }
}
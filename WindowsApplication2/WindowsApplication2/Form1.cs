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
        //实体类声明M(INPUT)
        private PARA p = new PARA();
        //实体类声明(OUTPUT)
        //private XXX YYY = new XXX();
        //业务类声明
        private Logic l = new Logic();

        private void button1_Click(object sender, EventArgs e)
        {


            //验证通过后，实体类赋值，为后续的业务logic提供参数
            p.ID = 11123;

            //赋值前，各种检查
            //比如
            //1.为空不为空的必要性
            //2.入力类型
            //3.范围合理
            //等等
            //做一个验证Logic，把前期的验证全部放进去

            //处理登录(比如1.清空工作环境2.临时表登录3.xxxx4.xxxxN.清空工作环境)
            //按照业务的逻辑顺序登录处理列表，这样主调度函数就可以循环处理了
            //参数应该都是实体类，以统一functionM1,2,3的入口
            //TODO:M1 成功/失败 M2的启动与否等等 
            Logic.MyTestDelgate[] list = new Logic.MyTestDelgate[] {
                  l.functionM1
                , l.functionM2
                , l.functionM3 
            };
            //主函数调度
            //TODO Method(list，YYY)
            this.testDg(list);

            //YYY调度处理结果和状态确认，通知用户
        }
        //主函数,执行顺序及其流程控制(事务等)，根据具体业务组织，
        //处理列表中放入哪些函数，开发者自己是清楚滴
        private int testDg(Logic.MyTestDelgate[] M)
        {
            try
            {
                for (int i = 0; i < M.Length; i++)
                {
                    //各个处理依次进行
                    //处理结果添加到ListBox中
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
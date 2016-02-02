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
        //下面的考虑还不够，业务整体考虑后，
        //要提取父类，抽象类，接口
        //还要实现代码的可复用共同化
        public Form1()
        {
            InitializeComponent();
        }
        //实体类声明M(INPUT)
        private PARA p = new PARA();
        //实体类声明(OUTPUT)
        //input和output可以统合到一块管理
        //内部属性要合理设定
        private OUTPUT o = new OUTPUT();
        //业务类声明
        private Logic l = new Logic();

        private void button1_Click(object sender, EventArgs e)
        {


            //实体类赋值，为后续的业务logic提供参数
            p.ID = 11123;

            //各种检查，比如
            //1.为空不为空的必要性
            //2.入力类型
            //3.范围合理
            //等等
            //做一个验证Logic，把前期的验证全部放进去

            //处理登录(比如1.清空工作环境2.临时表登录3.xxxx4.xxxxN.清空工作环境)
            //按照业务的逻辑顺序登录处理列表，这样主调度函数就可以循环处理了
            //参数应该都是实体类，以统一functionM1,2,3的入口
            //TODO:M1 成功/失败 M2的启动与否等等 
            //Q:在这个地方控制各个函数的执行是否合适
            //这个地方只调用一个整体的函数名，具体分几步啥的都在logic类中爱咋滴咋滴
            Logic.MyTestDelgate[] list = new Logic.MyTestDelgate[] {
                  l.functionM1
                , l.functionM2
                , l.functionM3 
            };
            //主函数调度
            this.testDg(list);

            //根据YYY来调度处理结果和状态确认，通知用户
            this.end();
        }

        //我的一个设想，把所有的和用户交互（弹消息框，抽出去，信号控制可行不？）
        private void end()
        {
            this.listBox1.Items.Add(o.Result1);
            this.listBox1.Items.Add(o.Result2);
            this.listBox1.Items.Add(o.Result3);
            MessageBox.Show(o.Message.ToString());
        }
        //主函数,执行顺序及其流程控制(事务等)，根据具体业务组织，
        //处理列表中放入哪些函数，开发者自己是清楚滴
        private int testDg(Logic.MyTestDelgate[] M)
        {
            try
            {
                //for (int i = 0; i < M.Length; i++)
                //{
                //    //各个处理依次进行
                //    //处理结果添加到ListBox中
                //    this.listBox1.Items.Add(M[i](p));
                //}
                //return 0;

                //step结果，信息
                //整体状态
                //可以用集合类型来存储，规避这样的列举
                o.Result1 = M[0](p).ToString();
                o.Result2 = M[1](p).ToString();
                o.Result3 = M[2](p).ToString();
                o.Status = 0;
                o.Message = "this operation is success!";

                return o.Status;

            }
            catch 
            {
                return 1;
            }
        }
    }
}
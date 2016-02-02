using System;
using System.Collections.Generic;
using System.Text;

namespace C_SHARP_STUDY
{
    class PARA
    {
        //实体类这部分可以分成两种类型
        //1.页面传递给业务的处理参数
        //2.业务处理完毕返回给页面的显示数据
        private int _id;
        public int ID
        {
            get { return _id;}
            set { _id = value; }
        }
    }
}

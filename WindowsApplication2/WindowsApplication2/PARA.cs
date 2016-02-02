using System;
using System.Collections.Generic;
using System.Text;

namespace C_SHARP_STUDY
{
    public class OUTPUT
    {
        //实体类这部分可以分成两种类型
        //1.页面传递给业务的处理参数
        //2.业务处理完毕返回给页面的显示数据

        public int Status
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }
        public string Result1
        {
            get;
            set;
        }
        public string Result2
        {
            get;
            set;
        }
        public string Result3
        {
            get;
            set;
        }
        
    }
}

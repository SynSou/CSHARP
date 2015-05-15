using System;
using System.Collections.Generic;
using System.Text;

namespace C_SHARP_STUDY
{
    class Logic
    {
        //一般业务处理都会操作数据库，数据库的操作抽象成一个操作类（static），供这里调用
        //
        //
        //
        //
        //
        //委托定义(考虑到分层，参数应该都是实体类，以统一参数入口，方便实现委托；这些业务处理单独划分成业务层独立出去)
        public delegate int MyTestDelgate(PARA i);
        //委托的实现1
        public int functionM1(PARA i)
        {
            //可能有数据库的操作
            return i.ID;
        }
        //委托的实现2
        public int functionM2(PARA i)
        {
            //可能有数据库的操作
            return i.ID*2;
        }
        //委托的实现3
        public int functionM3(PARA i)
        {
            //可能有数据库的操作
            return i.ID * 3;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace example_reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //メソッド名前
            string methodName = "Cry";
            //string methodName = "Cry2";
            //string methodName = "Cry3";
            //メソッド処理結果
            object result = null;
            //外部dll
            //Assembly assembly = Assembly.LoadFile("xxxxxxxxx.dll");
            //命名空間.クラス名
            //这个地方可以根据不同的对象，switch分支取相应的业务类
            Type type = Type.GetType("example_reflection.Class2");
            if (type != null)
            {
                //インスタンス建て
                object classInstance = Activator.CreateInstance(type, null);
                //メソッド取得
                MethodInfo methodInfo = type.GetMethod(methodName);
                if (methodInfo != null)
                {   
                    //メソッド引数情報取得
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    if (parameters.Length == 0)
                    {
                        //引数が無い場合、コールする
                        result = methodInfo.Invoke(classInstance, null);
                    }
                    else
                    {
                        //引数がある場合、引数を建て入れてコールする
                        string p1 = "dog";
                        List<string> p2 = new List<string>();
                        p2.AddRange(new string[] { "わん", "わん", "わん" });
                        object[] parametersArray = new object[] { p1,p2 };           
                        result = methodInfo.Invoke(classInstance, parametersArray);
                    }
                }
            }
            if (result == null)
            {
                Console.WriteLine("リータン値がないです");
            }
            else
            {
                Console.WriteLine(result.ToString());
            }
            Console.ReadLine();
        }
    }
}

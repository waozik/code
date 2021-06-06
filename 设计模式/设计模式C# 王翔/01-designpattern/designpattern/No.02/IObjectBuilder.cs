using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.No._02
{   /// <summary>
    /// 根据类型的名称生成类型实例
    /// </summary>
    interface IObjectBuilder
    {   /// <summary>
        /// 创建类型实例
        /// </summary>
        /// <typeparam name="T">返回的类型</typeparam>
        /// <param name="args">构造参数</param>
        /// <returns>指定类型T的实例</returns>
        T BuildUp<T>(object[] args);
        /// <summary>
        /// 创建类型实例
        /// </summary>
        /// <remarks>该方法仅适用于有无参构造函数的类型</remarks>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T BuildUp<T>() where T : new();
        /// <summary>
        /// 按照目标返回的类型，加工指定类型名称对应的类型实例。
        /// 目标类型可以为接口，抽象类等抽象类型，typeName一本为实体类的名称
        /// </summary>
        /// <typeparam name="T">目标返回的类型</typeparam>
        /// <param name="typeName">类型的名称</param>
        /// <returns>按照目标返回的类型加工好的一个实例</returns>
        T BuildUp<T>(string typeName);
        /// <summary>
        /// 按照目标类型，通过调用指定的名称类型的构造函数，生成目标类型的实例。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        T BuildUp<T>(string typeName, object[] args);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.No._02
{
    /// <summary>
    /// 一个轻便的IObjectBuilder实现
    /// </summary>
    public class TypeCreator : IObjectBuilder

    {
        public T BuildUp<T>() where T : new()
        {
            return Activator.CreateInstance<T>();
        }

        public T BuildUp<T>(string typeName)
        {
            return (T)Activator.CreateInstance(Type.GetType(typeName));
        }

        public T BuildUp<T> (object[] args)
        {
            object result = Activator.CreateInstance(typeof(T), args);
            return (T)result;
        }

        public T BuildUp<T>(string typeName,object[] args)
        {
            object result = Activator.CreateInstance(Type.GetType(typeName),args);
            return (T)result;

        }
    }
}

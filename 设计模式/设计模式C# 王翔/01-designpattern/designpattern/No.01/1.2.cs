using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPattern.No._01
{
    /// <summary>
    /// 1.2.2 简洁的异步通知机制--委托
    /// </summary>
    public class AsyncInvoker
    {
        private IList<string> output = new List<string>();
        public AsyncInvoker()
        {
            Timer slowTimer = new Timer(OnTimerInterval, "slow", 250, 250);
            Timer fastTimer = new Timer(new TimerCallback(OnTimerInterval), "fast", 200, 200);
            output.Add("method");
        }
        private void OnTimerInterval(object state)
        {
            output.Add(state as string);
        }
        public IList<string> Output { get { return output; } }
    }

    /// <summary>
    /// 1.2.3考验你的算法抽象能力--泛型
    /// </summary>
    public static class  RawGenericFactory
    {
        public static T Create<T>(string typeName)
        {
            return (T)Activator.CreateInstance(Type.GetType(typeName));
        }
    }
    /// <summary>
    /// 1.2.4用作标签的方式扩展对象特性--属性
    /// </summary>
    public interface IAttributedBuilder
    {

    }
}

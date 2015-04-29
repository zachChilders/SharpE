using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpe.Support
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CircularQueue<T> : List<T>
    {
        private int currentIndex = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Enqueue(T data)
        {
            this.Add(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            return this[currentIndex++];
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            currentIndex = 0;
        }


    }
}

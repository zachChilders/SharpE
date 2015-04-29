using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpe.Support
{
    public class CircularStack<T>:List<T>
    {
        private int currentIndex;

        /// <summary>
        /// 
        /// </summary>
        public CircularStack()
        {
            currentIndex = this.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Push(T data)
        {
            this.Add(data);
            currentIndex = this.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T data = default(T);
            if (currentIndex > 0)
            {
                data = this[currentIndex-1];
                currentIndex--;
            }
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            currentIndex = this.Count;
        }
    }
}

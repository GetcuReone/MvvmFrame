using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// Аn object storing a link to the finished frame
    /// </summary>
    public class Given
    {
        internal Queue<Func<ValueTask>> FuncsQueue { get; set; }
        /// <summary>
        /// Frame
        /// </summary>
        public Frame Frame { get; internal set; }
        /// <summary>
        /// Discription
        /// </summary>
        public string Discription { get; set; }

        /// <summary>
        /// Block 'and given'
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="andGivenBlock"></param>
        /// <returns></returns>
        public virtual AndGiven And(string discription, Func<Frame, ValueTask> andGivenBlock)
        {
            bool givenBlockComplited = false;
            var andGiven = new AndGiven
            {
                Frame = Frame,
                FuncsQueue = FuncsQueue,
                Discription = discription,
                PreviousGiven = this,
            };

            Console.WriteLine($"And given '{andGiven.Discription}' init time: {DateTime.Now}");

            FuncsQueue.Enqueue(async () =>
            {
                Console.WriteLine($"And given '{andGiven.Discription}' run time: {DateTime.Now}");

                await andGivenBlock(andGiven.Frame);
                givenBlockComplited = true;

                Console.WriteLine($"And given '{andGiven.Discription}' finish time: {DateTime.Now}");
            });

            while (!givenBlockComplited)
                Thread.Sleep(100);

            Console.WriteLine($"And given '{andGiven.Discription}' end time: {DateTime.Now}\n");
            return andGiven;
        }

        /// <summary>
        /// Block when
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="whenBlock"></param>
        /// <returns></returns>
        public virtual When When(string discription, Func<ValueTask> whenBlock)
        {
            bool whenBlockComplited = false;
            var when = new When
            {
                FuncsQueue = FuncsQueue,
                Discription = discription,
                Given = this,
            };

            Console.WriteLine($"When '{when.Discription}' init time: {DateTime.Now}");

            FuncsQueue.Enqueue(async () =>
            {
                Console.WriteLine($"When '{when.Discription}' run time: {DateTime.Now}");

                await whenBlock();
                whenBlockComplited = true;

                Console.WriteLine($"When '{when.Discription}' finish time: {DateTime.Now}");
            });

            while (!whenBlockComplited)
                Thread.Sleep(100);

            Console.WriteLine($"When '{when.Discription}' end time: {DateTime.Now}\n");
            return when;
        }
    }

    /// <summary>
    /// Аn object storing a link to the finished frame and the result of the block Given
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class Given<TResult> : Given
    {
        /// <summary>
        /// block result given
        /// </summary>
        public TResult Result { get; internal set; }
    }
}

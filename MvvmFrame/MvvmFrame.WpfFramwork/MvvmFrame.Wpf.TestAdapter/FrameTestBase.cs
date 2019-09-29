using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Interfaces;
using MvvmFrame.Wpf.TestAdapter.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter
{
    /// <summary>
    /// base class for testing pages written on the MvvmFrame.Wpf
    /// </summary>
    [TestClass]
    public abstract class FrameTestBase
    {
        private readonly Queue<Func<ValueTask>> _funcsQueue = new Queue<Func<ValueTask>>();
        private bool _needWindowClose;
        private bool _windowClosed;
        private TestWindow _window;

        /// <summary>
        /// Init method
        /// </summary>
        [TestInitialize]
        public virtual void Initialize()
        {
            Task.Run(() =>
            {
                _windowClosed = false;
                _needWindowClose = false;
                _window = new TestWindow();
                _window.Closed += (semder, e) => _windowClosed = true;
                _window.Loaded += async (sender, e) =>
                {
                    while (!_windowClosed)
                    {
                        if (_funcsQueue.Count > 0)
                            await _funcsQueue.Dequeue().Invoke();
                        else if (_needWindowClose)
                            _window.Close();
                        else
                            await Task.Delay(100);
                    }
                };
                _window.Show();
            });
        }

        /// <summary>
        /// Cleanup
        /// </summary>
        [TestCleanup]
        public virtual void Cleanup()
        {
            _needWindowClose = true;
            while (!_windowClosed)
                Thread.Sleep(100);
        }

        /// <summary>
        /// Block given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        protected virtual Given Given(string discription, Func<Frame, ValueTask> givenBlock)
        {
            bool givenBlockComplited = false;
            var given = new Given
            {
                Frame = _window.mainFrame,
                FuncsQueue = _funcsQueue,
                Discription = discription,
            };

            Console.WriteLine($"Given '{given.Discription}' init time: {DateTime.Now}");

            _funcsQueue.Enqueue(async () => 
            {
                Console.WriteLine($"Given '{given.Discription}' run time: {DateTime.Now}");

                await givenBlock(given.Frame);
                givenBlockComplited = true;

                Console.WriteLine($"Given '{given.Discription}' finish time: {DateTime.Now}");
            });

            while (!givenBlockComplited)
                Thread.Sleep(100);

            Console.WriteLine($"Given '{given.Discription}' end time: {DateTime.Now}\n");
            return given;
        }
    }
}

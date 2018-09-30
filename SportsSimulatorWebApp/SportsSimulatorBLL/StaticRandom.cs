using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace SportsSimulatorWebApp.SportsSimulatorBLL
{
    public static class StaticRandom
    {
        /// <summary>
        /// Class is to replace random.Next() as it is called in a tight loop which gives the same randoms based off the time.
        /// </summary>
        private static int seed;

        private static ThreadLocal<Random> threadLocal = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        static StaticRandom()
        {
            seed = Environment.TickCount;
        }

        public static Random Instance { get { return threadLocal.Value; } }
    }
}
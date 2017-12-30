using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paperboy.Extensions
{
   public static class DataExtensions
    {
        public static Task ToTaskRun(this Task me)
        {
            return Task.Run(async () => { await me; });
        }
    }
}

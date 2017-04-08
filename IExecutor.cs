using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVController
{
    interface IExecutor : IDisposable
    {
        void Prepare(string device);

        void Execute(string format, params object[] args);
    }
}

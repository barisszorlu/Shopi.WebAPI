using System;
using System.Collections.Generic;
using System.Text;

namespace Shopi.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit(bool state = true);
    }
}

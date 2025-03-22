using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Assignment.Core.Common
{
    public interface IDBContext
    {
        DbConnection Connection { get; }
        public bool TestConnection();
    }
}

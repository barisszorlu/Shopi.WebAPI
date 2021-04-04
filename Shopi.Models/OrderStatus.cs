using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Shopi.Models
{
    public enum OrderStatus
    {
        Created = 10,
        InProgress = 20,
        Failed = 30,
        Completed = 40,
        Canceled = 50,
        Returned = 60
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.ApplicationCore.ServiceInterface
{
    public interface ICurrentUserService
    {
        int Id { get;}
        string FullName { get; }
        string Email { get; }
        bool IsAuthenticated { get; }
    }
}

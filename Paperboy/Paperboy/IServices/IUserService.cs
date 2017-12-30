using Paperboy.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paperboy.IServices
{
    public interface IUserService
    {
        UserInformation GetUserInformation();
    }
}

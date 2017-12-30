using Paperboy.IServices;
using Paperboy.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paperboy.Services
{
    public class UserService : IUserService
    {
        public UserInformation GetUserInformation()
        {
            var user = new UserInformation
            {
                DisplayName = "Edgar Gonzalez",
                BioContent = "I am a Mobile Developer",
                ProfileImageUrl = "https://wintellectnow.blob.core.windows.net/public/Scott_Peterson.jpg"
            };
            return user;
        }
    }
}

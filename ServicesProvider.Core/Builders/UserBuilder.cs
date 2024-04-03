using ServicesProvider.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Builders
{
    public class UserBuilder
    {
        private string _email;
        private string _userName;

        public UserBuilder WithEmail(string Email)
        {
            _email = Email;
            return this;
       
        }

        public AppUser Build()
        {
            return new AppUser
            {
                Email = _email,
                UserName = _userName
            };
        } 
        
       
    }
}

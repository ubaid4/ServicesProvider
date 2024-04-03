using ServicesProvider.Core.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Builders
{
    public class ClaimBuilder
    {
        //this class is used to build a claim object, which is used to assign permissions to roles
        //this class implements the builder pattern, which is a creational design pattern that lets you construct complex objects step by step.
        private string _type;
        private ActionDTO actions=new ActionDTO();

      

        public ClaimBuilder(string moduleName)
        {
            _type= moduleName;
        }
        public ClaimBuilder CanAdd()
        {
            actions.Add = true;
            return this;
        }
        public ClaimBuilder CanEdit()
        {
            actions.Edit = true;
            return this;
        }
        public ClaimBuilder CanDelete()
        {
            actions.Delete = true;
            return this;
        }
        public ClaimBuilder CanView()
        {
            actions.View = true;
            return this;
        }

        public Claim Build()
        {
            return new Claim(_type,JsonSerializer.Serialize(actions));
        }
    }
}

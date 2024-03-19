using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using ServicesProvider.UI.Authorization.Requirements;

namespace ServicesProvider.UI.Authorization.PolicyMaker
{
    public class AppPolicyProvider: DefaultAuthorizationPolicyProvider
    {
        public AppPolicyProvider(IOptions<AuthorizationOptions> option) : base(option)
        {

        }
        public override async Task<AuthorizationPolicy> GetPolicyAsync(string PolicyName)
        {
            var policyParams = PolicyName.Split('-');

            return new AuthorizationPolicyBuilder().AddRequirements(new AuthorizationRequirement(policyParams[0], policyParams[1])).Build();
        }
    }
}

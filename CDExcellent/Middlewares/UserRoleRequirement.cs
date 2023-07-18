using Microsoft.AspNetCore.Authorization;

namespace CDExcellent.Middlewares
{
    public class UserRoleRequirement : IAuthorizationRequirement
    {
        public string Permission { get; set; }
        public UserRoleRequirement(string permission)
        {
            Permission = permission;
        }
    }
}

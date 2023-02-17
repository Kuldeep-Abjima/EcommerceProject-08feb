using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace EcommerceProject
{
    public static class ClaimPrincipleExtension
    {
        public static string getUserById(this ClaimsPrincipal users)
        {
            return users.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}

using IdentityServer4.Models;
using IdentityServer4.Validation;
using CentralDeErros.Models;
using System.Linq;
using System.Threading.Tasks;
 
namespace CentralDeErros.Services
{
    public class ValidadorSenhaService : IResourceOwnerPasswordValidator
    {
        private readonly CentralErrosContext _context;

        // utilizar o mesmo banco atual

        public ValidadorSenhaService(CentralErrosContext context)
        {
            _context = context;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            // acessar cliente na base
            var user = _context.Users.FirstOrDefault(x => x.Login == context.UserName);

            // verificar a senha
            if (user != null && user.Password.TrimEnd() == context.Password)
            {
                // retornar objeto tipo GrantValidationResult com sub, auth e claims
                context.Result = new GrantValidationResult(
                    subject: user.Id.ToString(),
                    authenticationMethod: "custom", 
                    claims: UserProfileService.GetUserClaims(user)
                );
                return Task.CompletedTask;
            } 
            else 
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant, "Usuário ou senha inválidos");

                return Task.FromResult(context.Result);
            }
        }
     
    }
}
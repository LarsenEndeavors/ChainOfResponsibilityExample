using System.Security.Authentication;

namespace ChainOfResponsibilityExample.Objects
{
    public class ClassValidationChain : IValidationChain
    {
        public IValidationChain NextValidation { get; set; }
        public void Validate(PlayerCharacter character)
        {
            if (string.IsNullOrWhiteSpace(character.Class))
            {
                throw new AuthenticationException("Class not found!");
            }
        }
    }
}
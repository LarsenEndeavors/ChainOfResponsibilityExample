using System.Security.Authentication;

namespace ChainOfResponsibilityExample.Objects
{
    public class LevelValidationChain : IValidationChain
    {
        public IValidationChain NextValidation { get; set; }
        public void Validate(PlayerCharacter character)
        {
            if (character.Level <= 0)
            {
                throw new AuthenticationException("Level not found!");
            }
        }
    }
}
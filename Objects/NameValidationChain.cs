using System;
using System.Security.Authentication;

namespace ChainOfResponsibilityExample.Objects
{
    public class NameValidationChain : IValidationChain
    {
        public IValidationChain NextValidation { get; set; }
        public void Validate(PlayerCharacter character)
        {
            if (string.IsNullOrWhiteSpace(character.Name))
            {
                throw new AuthenticationException("Name not found!");
            }
        }
    }
}
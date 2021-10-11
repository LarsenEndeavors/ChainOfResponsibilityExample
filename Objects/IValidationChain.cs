using System;

namespace ChainOfResponsibilityExample.Objects
{
    public interface IValidationChain
    {
        public IValidationChain NextValidation { get; set; }

        public void Then(IValidationChain validationChain)
        {
            NextValidation = validationChain;
        } 

        public void Validate(PlayerCharacter character);

        public void Next(PlayerCharacter character)
        {
            Validate(character);
            if (NextValidation != null)
            {
                NextValidation.Next(character);
            }
            else
            {
                Console.WriteLine("Validation Complete!");
            }
        }
    }
}
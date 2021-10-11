using System;
using System.Security.Authentication;
using ChainOfResponsibilityExample.Objects;

namespace ChainOfResponsibilityExample
{
    internal static class ChainOfResponsibilityExample
    {
        
        /*
         * The majority of this code is mocked or directly taken from the Christopher Okhravi YouTube series in
         * an effort to teach myself and get familiar with these patterns.  None of this is meant to be
         * original content, and if you see this and wonder why it's in my repo, mostly it's for me, but
         * I'm happy that you're here and here's proof that I have at least heard of this particular
         * pattern!
         *
         * Author: Nicholas Larsen
         * Date: 2021/10/11
         */
        
        private static void Main()
        {
            // The Chain of Responsibility pattern allows for things like chained validation
            // This allows for the program to break early and often.
            
            IValidationChain nameValidator = new NameValidationChain();
            IValidationChain levelValidator = new LevelValidationChain();
            IValidationChain classValidator = new ClassValidationChain();

            nameValidator.NextValidation = levelValidator;
            levelValidator.NextValidation = classValidator;

            var character = new PlayerCharacter { Name = "Nick", Class = "Tailor" };

            try
            {
                nameValidator.Next(character);
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine(e.Message);
            }

            character.Level = 10;
            
            try
            {
                nameValidator.Validate(character);
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
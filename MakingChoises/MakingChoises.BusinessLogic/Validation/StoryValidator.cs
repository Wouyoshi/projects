using MakingChoises.Model;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingChoises.BusinessLogic.Validation
{
    public class StoryValidator : Validator<Story>
    {
        protected override void DoValidate(Story objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            throw new NotImplementedException();
        }

        protected override string DefaultMessageTemplate
        {
            get { return "Validation failed."; }
        }
    }
}

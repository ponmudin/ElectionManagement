using ElectionManagement.API.Models;
using FluentValidation;

namespace ElectionManagement.API.ModelValidator
{
    public class CandidateValidator : AbstractValidator<Candidate>
    {
        public CandidateValidator()
        {
            RuleFor(x => x.CandidateName).NotEmpty();
        }
    }
}

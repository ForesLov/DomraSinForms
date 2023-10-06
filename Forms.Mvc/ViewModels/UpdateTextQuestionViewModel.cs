using DomraSinForms.Application.Features.Questions.Commands.UpdateTextQuestion;
using DomraSinForms.Domain.Models.Forms.Questions.Types;

namespace Forms.Mvc.ViewModels;

#nullable disable

public class UpdateTextQuestionViewModel
{
    public TextQuestion Question { get; set; }
    public UpdateTextQuestionCommand Command { get; set; }

    public static explicit operator UpdateTextQuestionViewModel(TextQuestion question)
    {
        return new UpdateTextQuestionViewModel { Question = question };
    }

    public static implicit operator UpdateTextQuestionCommand(UpdateTextQuestionViewModel viewModel)
    {
        return viewModel.Command;
    }
}

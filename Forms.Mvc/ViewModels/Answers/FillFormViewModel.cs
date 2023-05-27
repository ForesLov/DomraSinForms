using System.Collections.Immutable;
using DomraSinForms.Application.Answers.Queries.GetList;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;

namespace Forms.Mvc.ViewModels.Answers;

public class FillFormViewModel
{
    private readonly FormAnswersDto? _dto;

    public FillFormViewModel() { }
    public FillFormViewModel(FormAnswersDto command)
    {
        _dto = command;
        Answers = new AnswerFactory().GetAnswers(command.Answers)?.OrderBy(a => a.Index)?.ToArray() ?? Array.Empty<IAnswerViewModel>();
    }
    public FillFormViewModel(FormAnswers command)
    {
        Answers = new AnswerFactory().GetAnswers(command.Answers)?.OrderBy(a => a.Index)?.ToArray() ?? Array.Empty<IAnswerViewModel>();
    }

    public FillFormViewModel(FormAnswersDto command, Form form) : this(command)
    {
        Form = form;
    }
    public string FormId => _dto?.FormId ?? "";
    public IAnswerViewModel[] Answers { get; set; } = Array.Empty<IAnswerViewModel>();
    public bool RequiredQuestionsAnswered => Answers?.Where(a => a.IsRequired && string.IsNullOrWhiteSpace(a.Value)).Count() == 0;

    public Form? Form { get; }
}

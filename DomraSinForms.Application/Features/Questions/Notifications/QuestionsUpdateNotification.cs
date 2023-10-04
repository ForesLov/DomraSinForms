using MediatR;

namespace DomraSinForms.Application.Features.Questions.Notifications;
public class QuestionsUpdateNotification : INotification
{
    public string FormId { get; set; } = string.Empty;
}

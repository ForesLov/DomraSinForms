using MediatR;

namespace DomraSinForms.Application.Questions.Notifications;
public class QuestionsUpdateNotification : INotification
{
    public string FormId { get; set; } = string.Empty;
}

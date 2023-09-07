using MediatR;

namespace DomraSinForms.Application.Forms.Notifications.Update;
public class UpdateFormNotification : INotification
{
    public string FormId { get; set; } = string.Empty;
}

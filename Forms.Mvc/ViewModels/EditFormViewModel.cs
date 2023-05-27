using DomraSinForms.Application.Forms.Commands.Update;
using DomraSinForms.Domain.Models;

namespace Forms.Mvc.ViewModels;

#nullable disable

public class EditFormViewModel
{
    public Form Form { get; set; }
    public UpdateFormCommand UpdateFormCommand => new UpdateFormCommand { Id = Form.Id, Description = Form.Description, Title = Form.Title, UserId = Form.CreatorId };
}

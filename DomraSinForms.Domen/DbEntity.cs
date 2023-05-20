using System.ComponentModel.DataAnnotations;

namespace DomraSinForms.Domain;

public class DbEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
}

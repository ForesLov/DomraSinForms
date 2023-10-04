using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models.Answers;

namespace DomraSinForms.Domain.Models.Versions;
public class FormVersion : DbEntity
{
    public int Index { get; set; } = 1;
    public string FormId { get; set; } = string.Empty;
    public Form Form { get; set; }
    public DateTime CreationDate { get; set; }
    //public ICollection<FormAnswers> FormAnswers { get; set; }
}

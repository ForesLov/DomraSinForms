using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Domain.Models.Versions;
public class FormVersion : DbEntity
{
    public int Index { get; set; } = 1;
    public string FormId { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
}

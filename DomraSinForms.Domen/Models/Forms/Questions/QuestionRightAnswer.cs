using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Domain.Models.Forms.Questions;
public class QuestionRightAnswer
{
    [Key] public string QuestionId { get; set; }
    public string RightAnswer { get; set; }
    public int Score { get; set; }
}

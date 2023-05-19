using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DomraSinForms.Domain.Identity;
public class User : IdentityUser
{
    public string? NickName { get; set; }
}

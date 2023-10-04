using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Domain.Models.Versions;
using DomraSinForms.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Domain.Interfaces.Repositories;
public interface IDatabaseContext
{
    DbSet<T> Set<T>() where T : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

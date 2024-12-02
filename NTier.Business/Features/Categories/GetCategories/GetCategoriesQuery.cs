using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NTier.Entities.Models;

// <>   {}

namespace NTier.Business.Features.Categories.GetCategories
{
    public sealed record GetCategoriesQuery : IRequest<List<Category>>
    {
 
    }
}

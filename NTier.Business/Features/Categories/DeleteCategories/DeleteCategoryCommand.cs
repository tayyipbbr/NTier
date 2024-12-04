using MediatR;


// <>   {}  @

namespace NTier.Business.Features.Categories.DeleteCategories
{
    public sealed record DeleteCategoryCommand(Guid Id) : IRequest
    {
    }
}



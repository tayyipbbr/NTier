using MediatR;

// <>   {}
namespace NTier.Business.Features.Categories.CreateCategory
{
    public sealed record CreateCategoryCommand(string Name) : IRequest; // user-webapi-business-command'a istek-irequest+assembly-handler-run-response
}

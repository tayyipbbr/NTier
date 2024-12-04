using MediatR;

// <>   {}
namespace NTier.Business.Features.Categories.CreateCategory
{
    public sealed record CreateCategoryCommand(
        string Name) : IRequest<Unit>; 
                                                                 // user-webapi-business-command'a istek-irequest+assembly-handler-run-response
}                                                                // unit void tipi bir dönüş değeridir. void dönemediği için mediatR içerisinde bbu kullanılır. (tip alanlar valid sorgusuna dahil olur -perfor için- bu sebeple tip vermeliyiz)

using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTier.Business.Features.Categories.CreateCategory;
using NTier.Business.Features.Categories.DeleteCategories;
using NTier.Business.Features.Categories.GetCategories;
using NTier.Business.Features.Categories.UpdateCategory;
using NTier.WebApi.Abstracts;

// []  <>   {}

namespace NTier.WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }


        // bir istek atacağız.
        [HttpPost] // MediatR ile %95 post işlemi yapılıyor.                                                                                                     // api end-points
        public async Task<IActionResult> Add(CreateCategoryCommand request, CancellationToken cancellationToken)     // request atmak istediğim şey bir Category create işlemi, bu command IRequest yapıda olduğu için bu yapı createcategory oluşturur.
        {                                                                                                            // cancellationToken nesnesi bazı yerlerde hazır?
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {                                                                                                           
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllQ(GetCategoriesQuery request, CancellationToken cancellationToken)           // liste döner.
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}


/*
 * mediator send üzerinden request aldığı için assembly sayesinde işleme başlar.
 * request CreateCategoryCommand tipinde olduğu için oray erişir ilk olarak.
 * Eriştiği yer IRequest kalıtımında olduğu için Handler'ine gider.
 * Handler işleminden önce -varsa- validator devreye girer ve gerekli kontrolleri atar.
 * Daha sonra ilgili handler çalışır ve response döndürür. Task içerisinde tip olrak ActionResult verdiğimiz için requesti çevirir.
 */
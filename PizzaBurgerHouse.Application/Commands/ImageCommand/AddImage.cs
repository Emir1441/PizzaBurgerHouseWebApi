using MediatR;
using Microsoft.AspNetCore.Http;
using PizzaBurgerHouse.Application.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBurgerHouse.Application.Commands.ImageCommand
{

    public class AddImage : IRequest<int>
    {

        public IFormFile UploadedFile { get; set; }

        public AddImage(IFormFile uploadedFile)
        {
            UploadedFile = uploadedFile;
        }

    }

    public class AddImageCommandHandler : IRequestHandler<AddImage, int>
    {

        private readonly IProductRepository productRepo;

        public AddImageCommandHandler(IProductRepository _productRepo)
        {
            productRepo = _productRepo;
        }

        public async Task<int> Handle(AddImage request, CancellationToken cancellationToken)
        {
            return await productRepo.AddImageAsync(request.UploadedFile);
        }
    }
}

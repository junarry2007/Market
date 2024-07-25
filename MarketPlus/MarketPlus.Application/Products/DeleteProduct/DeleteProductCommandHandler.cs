using MarketPlus.Application.Abstractions.Clock;
using MarketPlus.Application.Abstractions.Messaging;
using MarketPlus.Domain.Abstractions;
using MarketPlus.Domain.Products;

namespace MarketPlus.Application.Products.DeleteProduct
{
    internal sealed class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;
        public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.id, cancellationToken);

            if (product is null)
            {
                return Result.Failure<Guid>(ProductError.NotFound);
            }

            product.DeleteProduct(_dateTimeProvider.currentTime);

            _productRepository.Delete(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}

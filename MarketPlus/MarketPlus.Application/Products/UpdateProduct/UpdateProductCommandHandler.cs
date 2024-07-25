using MarketPlus.Application.Abstractions.Clock;
using MarketPlus.Application.Abstractions.Messaging;
using MarketPlus.Domain.Abstractions;
using MarketPlus.Domain.Products;

namespace MarketPlus.Application.Products.UpdateProduct
{
    internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            if (product is null)
            {
                return Result.Failure<Guid>(ProductError.NotFound);
            }

            product.UpdateProduct(request.Name,request.Description,request.Status,request.Stock, new Price(request.amount, Currency.FromCode(request.currency)), _dateTimeProvider.currentTime);

            _productRepository.Update(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}

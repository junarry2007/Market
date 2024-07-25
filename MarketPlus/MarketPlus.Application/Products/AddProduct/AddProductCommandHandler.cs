using MarketPlus.Application.Abstractions.Clock;
using MarketPlus.Application.Abstractions.Messaging;
using MarketPlus.Domain.Abstractions;
using MarketPlus.Domain.Products;

namespace MarketPlus.Application.Products.AddProduct
{
    internal sealed class AddProductCommandHandler : ICommandHandler<AddProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public AddProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.CreateProduct(request.Name,request.Description,request.Status,request.Stock, new Price(request.amount,Currency.FromCode(request.currency)), _dateTimeProvider.currentTime);

            _productRepository.Add(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}

namespace MarketPlus.Domain.Products
{
    public interface IProductRepository
    {
        /// <summary>
        /// Get all records
        /// </summary>
        /// <returns>Entity object</returns>
        Task<IReadOnlyList<Product?>> GetAll(CancellationToken cancellationToken = default);

        /// <summary>
        /// Search record by id
        /// </summary>
        /// <param name="id">Id search</param>
        /// <returns>Record</returns>
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Save record
        /// </summary>
        /// <param name="product">Entity to create</param>
        //// <returns>Entity created</returns>
        //Task<Product> Save(Product product);
        void Add(Product product);

        /// <summary>
        /// Update record
        /// </summary>
        /// <param name="id">Id update</param>
        /// <param name="product">Entity to update</param>
        /// <returns>Entity updated</returns>
        void Update(Product product);

        /// <summary>
        /// Delete record
        /// </summary>
        /// <param name="id">Id to delete</param>
        /// <returns>Id deleted; 0 not found</returns>
        void Delete(Product product);

    }
}

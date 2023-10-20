using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Comment;
using ShopManagement.Domain.CommentAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly ShopContext _shopContext;

        public CommentRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var qury = _shopContext.comments.Include(x => x.Product)
                .Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    Email = x.Email,
                    IsCanceled = x.IsCanceled,
                    IsConfirmed = x.IsConfirmed,
                    Message = x.Message,
                    Name = x.Name,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    CommentDate = x.CreationDate.ToFarsi()
                });

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                qury=qury.Where(x=>x.Name.Contains(searchModel.Name));
            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                qury = qury.Where(x => x.Email.Contains(searchModel.Email));
            return qury.OrderByDescending(x=>x.Id).ToList();
        }
    }
}

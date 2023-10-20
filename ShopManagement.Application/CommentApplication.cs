using _0_Framework.Application;
using ShopManagement.Application.Contracts.Comment;
using ShopManagement.Domain.CommentAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _repository;

        public CommentApplication(ICommentRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Add(AddComment command)
        {
            var opertion=new OperationResult();
            var comment = new Comment(command.Name, command.Email, command.Message, command.ProductId);
            _repository.Create(comment);
            _repository.SaveChanges();
            return opertion.Succedded();
        }

        public OperationResult Cancel(long id)
        {
            var opertion = new OperationResult();
            var comment=_repository.Get(id);

            if (comment == null)
                return opertion.Failed(ApplicationMessages.DuplicatedRecord);

            comment.Cancel();
            _repository.SaveChanges();
            return opertion.Succedded();
        }

        public OperationResult Confirm(long id)
        {
            var opertion = new OperationResult();
            var comment = _repository.Get(id);


            if(comment == null)
                return opertion.Failed(ApplicationMessages.DuplicatedRecord);

            comment.Confirm();
            _repository.SaveChanges();
            return opertion.Succedded();
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            return _repository.Search(searchModel); 
        }
    }
}

using KZ.Entity.Models.Data;
using System.Collections.Generic;

namespace KZ.Business.Abstract
{
    public interface ICommentService
    {
        void Add(Comment comment);

        void Update(Comment comment);

        void Delete(Comment comment);

        Comment GetById(int id);

        List<Comment> GetList();

        List<Comment> GetList_UI();

        List<Comment> GetList_Home();
    }
}

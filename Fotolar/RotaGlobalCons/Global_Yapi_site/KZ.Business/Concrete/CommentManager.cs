using KZ.Business.Abstract;
using System.Collections.Generic;
using KZ.Entity.Models.Data;
using KZ.DataAccess.Abstract;

namespace KZ.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private ICommentDal _commentDal;
        public CommentManager(ICommentDal CommentDal)
        {
            _commentDal = CommentDal;
        }

        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public void Delete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public Comment GetById(int id)
        {
            return _commentDal.Get(x => x.Id == id);
        }

        public List<Comment> GetList()
        {
            return _commentDal.GetList();
        }

        public List<Comment> GetList_Home()
        {
            return _commentDal.GetList(x => x.IsHome && x.IsView);
        }

        public List<Comment> GetList_UI()
        {
            return _commentDal.GetList(x => x.IsView);
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }
    }
}

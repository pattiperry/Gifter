using Gifter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        List<Post> GetAllWithComments();
        List<Post> Search(string criterion, bool sortDescending);
        List<Post> Hottest(DateTime since, bool sortDescending);

        Post GetById(int id);
        Post GetPostByIdWithComments(int id);
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
    }
}

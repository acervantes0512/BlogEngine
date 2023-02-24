using Application.DTOs;
using Application.Implementations;
using Domain.Entities;
using Persistence.UnitOfWork;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task addPost(PostDto post)
        {

            Post newPost = new Post
            {
                Tittle = post.Tittle,
                Content = post.Content,
                CreationDate = post.CreationDate,
                UserAuthor = await getUserById(post.UserId),
                StatusPost = await getStatusPostId(3) // TODO: Eliminar quemado
            };

            await _unitOfWork.GetRepository<Post>().AddAsync(newPost);
            _unitOfWork.SaveChanges();
        }

        private async Task<User> getUserById(int id)
        {
            return await _unitOfWork.GetRepository<User>().GetByIdAsync(id);
        }

        private async Task<StatusPost> getStatusPostId(int id)
        {
            return await _unitOfWork.GetRepository<StatusPost>().GetByIdAsync(id);
        }
    }
}

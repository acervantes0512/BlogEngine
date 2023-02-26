using Application.DTOs;
using Application.Implementations;
using Domain.Entities;
using Persistence.Repository;
using Persistence.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _postRepository;

        public PostService(IUnitOfWork unitOfWork, IPostRepository postRepository)
        {
            this._unitOfWork = unitOfWork;
            this._postRepository = postRepository;
        } 

        public async Task<IEnumerable<Post>> getPostsByUserId(int userId)
        {
            return await _unitOfWork.PostRepository.GetByUserIdAsync(userId);            
        }

        public async Task<IEnumerable<Post>> getPostsEditedByUserId(int userId)
        {
            return await _unitOfWork.PostRepository.GetEditedByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Post>> GetPostsByStatus(int statudId)
        {
            return await _unitOfWork.PostRepository.GetPostsByStatus(statudId);
        }



    }
}

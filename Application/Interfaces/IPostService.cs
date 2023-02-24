using Application.DTOs;
using System.Threading.Tasks;

namespace Application.Implementations
{
    public interface IPostService
    {
        Task addPost(PostDto post);
    }
}
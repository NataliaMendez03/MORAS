using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Repositories;
using System.Net;

namespace Sistema_de_Gestion_Moras.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetAll();
        Task<Post> GetPost(int idPost);
        Task<Post> CreatePost(string namePost);
        Task<Post> UpdatePost(int idPost, string? namePost = null);
        Task<Post> DeletePost(int idPost);
    }
    public class PostService : IPostService
    {
        public readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<Post> CreatePost(string namePost)
        {
            return await _postRepository.CreatePost(namePost);
        }

        public async Task<Post> DeletePost(int idPost)
        {
            // comprobar si existe
            Post PostToDelete = await _postRepository.GetPost(idPost);
            if (PostToDelete == null)
            {
                throw new Exception($"This Post with the Id {idPost} don´t exist. ");
            }
            PostToDelete.StateDelete = true;
            PostToDelete.CreatedDate = DateTime.Now;
            return await _postRepository.DeletePost(PostToDelete);
        }

        public async Task<List<Post>> GetAll()
        {
            return await _postRepository.GetAll();
        }

        public async Task<Post> GetPost(int idPost)
        {
            return await _postRepository.GetPost(idPost);
        }

        public async Task<Post> UpdatePost(int idPost, string? namePost = null)
        {
            Post newPost = await _postRepository.GetPost(idPost);
            if (newPost != null)
            {
                if (namePost != null)
                {
                    newPost.NamePost = (string)namePost;
                }
                return await _postRepository.UpdatePost(newPost);
            }
            throw new NotImplementedException();
        }
    }
}
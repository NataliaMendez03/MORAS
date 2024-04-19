using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Context;
using Sistema_de_Gestion_Moras.Models;
using System.Net;

namespace Sistema_de_Gestion_Moras.Repositories
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAll();
        Task<Post> GetPost(int idPost);
        Task<Post> CreatePost(string namePost);
        Task<Post> UpdatePost(Post post);
        Task<Post> DeletePost(Post post);
    }
    public class PostRepository : IPostRepository
    {
        private readonly berriesdbContext _db;
        public PostRepository(berriesdbContext db)
        {
            _db = db;
        }

        public async Task<Post> CreatePost(string namePost)
        {
            Post newPost = new Post
            {
                NamePost = namePost,
                StateDelete = false,
                CreatedDate = null
            };

            await _db.Post.AddAsync(newPost);
            _db.SaveChanges();

            return newPost;
        }

        public async Task<Post> DeletePost(Post post)
        {
            _db.Post.Attach(post); //Llamamos la actualizacion
            _db.Entry(post).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return post;
        }

        public async Task<List<Post>> GetAll()
        {
            return await _db.Post.ToListAsync();
        }

        public async Task<Post> GetPost(int idPost)
        {
            return await _db.Post.FirstOrDefaultAsync(u => u.IdPost == idPost);
        }

        public async Task<Post> UpdatePost(Post post)
        {
            Post PostUpdate = await _db.Post.FindAsync(post.IdPost);
            if (PostUpdate != null)
            {
                //?? ConsultUpdate.IdConsult = idConsult;
                PostUpdate.NamePost = post.NamePost;


                await _db.SaveChangesAsync();
            }

            return PostUpdate;
        }
    }
}
using System;

namespace blogger.api.Models
{
    public class Article
    {
        public Article(int id, string title, string content, DateTime createdAt, DateTime updatedAt)
        {
            if(string.IsNullOrEmpty(title)){
                throw new ArgumentException("Invalid title");
            }

            if(string.IsNullOrEmpty(content)){
                throw new ArgumentException("Invalid Content");
            }
            
            Id = id;
            Title = title;
            Content = content;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
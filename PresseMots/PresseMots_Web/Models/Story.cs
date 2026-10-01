using PresseMots.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresseMots.Models
{
    public class Story : IWordCountable
    {
        public Story()
        {
            Likes = new List<Like>();
            Shares = new List<Share>();
            Comments = new List<Comment>();
            StoryTags = new List<StoryTag>(); // Initialisation de la table de correspondance
        }

        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? LastEditTime { get; set; }
        public DateTime? PublishTime { get; set; }
        public bool Draft { get; set; }

        public virtual User Owner { get; set; }
        public int OwnerId { get; set; }

        public virtual IList<Like> Likes { get; set; }
        public virtual IList<Share> Shares { get; set; }
        public virtual IList<Comment> Comments { get; set; }

        // Nouvelle propriété de navigation pour la relation Plusieurs-à-Plusieurs
        public virtual IList<StoryTag> StoryTags { get; set; }
    }
}


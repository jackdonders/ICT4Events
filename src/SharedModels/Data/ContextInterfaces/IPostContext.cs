﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Models;

namespace SharedModels.Data.ContextInterfaces
{
    public interface IPostContext : IRepositoryContext<Post>
    {
        Reply Insert(Reply entity);
        List<Post> GetAllByEvent(Event ev);
        List<Reply> GetRepliesByPost(Post post);

        List<int> GetAllLikes(Post post);
        bool AddLikeToPost(Post post, Guest guest);
        bool RemoveLikeFromPost(Post post, Guest guest);
        bool AddLikeToPost(Post post, User admin);
        bool RemoveLikeFromPost(Post post, User admin);

        List<Post> GetPostsByTag(string tag);
        List<string> GetTagsByPost(Post post);
        bool AddTagToPost(Post post, string tag);
        bool AddTagToEvent(Event ev, string tag);
        bool RemoveTagFromPost(Post post, string tag);
    }
}

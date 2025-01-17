﻿using System;
using System.Collections.Generic;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Data.OracleContexts;
using SharedModels.Models;

namespace SharedModels.Logic
{
    public class PostLogic
    {
        private readonly IPostContext _context;
        private readonly IReportContext _reportContext;

        public PostLogic()
        {
            _context = new PostOracleContext();
            _reportContext = new ReportOracleContext();
        }

        public PostLogic(IPostContext context)
        {
            _context = context;
        }

        public Post InsertPost(Post post)
        {
            return _context.Insert(post);
        }

        public Reply InsertPost(Reply reply)
        {
            return _context.Insert(reply);
        }

        public bool UpdatePost(Post post)
        {
            return _context.Update(post);
        }

        public bool DeletePost(Post post)
        {
            return _context.Delete(post);
        }

        public List<Post> GetAllByEvent(Event ev)
        {
            return _context.GetAllByEvent(ev);
        }

        public List<Reply> GetRepliesByPost(Post post)
        {
            return _context.GetRepliesByPost(post);
        }

        public List<int> GetAllLikes(Post post)
        {
            return _context.GetAllLikes(post);
        }

        /// <summary>
        /// Adds a like to the a post
        /// </summary>
        /// <param name="guest">Guest that liked the post</param>
        /// <param name="post">Post that got liked</param>
        /// <returns>true if succesfull</returns>
        public bool Like(Guest guest, Post post)
        {
            return _context.AddLikeToPost(post, guest);
        }

        /// <summary>
        /// Removes a like from a post
        /// </summary>
        /// <param name="guest">Guest that unliked the post</param>
        /// <param name="post">Post that got unliked</param>
        /// <returns>true if succesfull</returns>
        public bool UnLike(Guest guest, Post post)
        {
            return _context.RemoveLikeFromPost(post, guest);
        }

        /// <summary>
        /// Adds a like to the a post
        /// </summary>
        /// <param name="admin">Guest that liked the post</param>
        /// <param name="post">Post that got liked</param>
        /// <returns>true if succesfull</returns>
        public bool Like(User admin, Post post)
        {
            return _context.AddLikeToPost(post, admin);
        }

        /// <summary>
        /// Removes a like from a post
        /// </summary>
        /// <param name="admin">Guest that unliked the post</param>
        /// <param name="post">Post that got unliked</param>
        /// <returns>true if succesfull</returns>
        public bool UnLike(User admin, Post post)
        {
            return _context.RemoveLikeFromPost(post, admin);
        }

        /// <summary>
        /// Adds a report to a post
        /// </summary>
        /// <param name="guest">Guest that reported the post</param>
        /// <param name="post">Post that got reported</param>
        /// <param name="reason">Reason of guest to report the post</param>
        /// <returns>true if Report was successfully entered</returns>
        public bool Report(Guest guest, Post post, string reason)
        {
            var report = new Report(guest.ID, post.ID, reason, DateTime.Now);
            return (_reportContext.Insert(report) != null);
        }

        /// <summary>
        /// Gets all posts that have a given tag
        /// </summary>
        /// <param name="tag">tag to search for</param>
        /// <returns>All posts that contain given tag</returns>
        public List<Post> GetPostsByTag(string tag)
        {
            return _context.GetPostsByTag(tag);
        }

        public bool AddTagToPost(Post post, string tag)
        {
            return _context.AddTagToPost(post, tag);
        }


        public bool AddTagToEvent(Event ev, string tag)
        {
            return _context.AddTagToEvent(ev, tag);
        }
    }
}

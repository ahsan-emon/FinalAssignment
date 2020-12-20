using Final_Assignment.Models;
using Inventory_with_Repository_Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final_Assignment.Controllers
{
    public class PostsController : ApiController
    {
        PostRepository postRep = new PostRepository();
        public IHttpActionResult Get()
        {
            return Ok(postRep.GetAll());
        }

        public IHttpActionResult Get(int id)
        {
            var Post = postRep.Get(id);
            if(Post == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(postRep.Get(id));
        }
        public IHttpActionResult Post(Post post)
        {
            postRep.Insert(post);
            return Created("api/Posts/" + post.PostID, post);
        }
        public IHttpActionResult Put([FromUri]int id,[FromBody]Post post)
        {
            post.PostID = id;
            postRep.Update(post);
            return Ok(post);
        }
    }
}

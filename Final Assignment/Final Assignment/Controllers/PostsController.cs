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
            return Ok(postRep.Get(id));
        }
        public IHttpActionResult Post(Post posts)
        {
            postRep.Insert(posts);
            return Ok();
        }
    }
}

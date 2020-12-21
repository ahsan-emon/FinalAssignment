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
    [RoutePrefix("api/comment")]
    public class CommentsController : ApiController
    {
        DescribeRepository CmntRepo = new DescribeRepository();
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(CmntRepo.GetAll());
        }
        [Route("{id}", Name = "GetCommentById")]

        public IHttpActionResult Get(int id)
        {
            return Ok(CmntRepo.Get(id));
        }
        [Route("")]
        public IHttpActionResult Post(Comment cmt)
        {
            CmntRepo.Insert(cmt);
            string uri = Url.Link("GetCommentById", new { id = cmt.CommentID });
            return Created(uri, cmt);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Comment cmt)
        {
            cmt.CommentID = id;
            CmntRepo.Update(cmt);
            return Ok(cmt);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            CmntRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

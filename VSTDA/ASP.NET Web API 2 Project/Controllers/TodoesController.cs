using ASP.NET_Web_API_2_Project.Infrastructure;
using ASP.NET_Web_API_2_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP.NET_Web_API_2_Project.Controllers
{
    public class TodoesController : ApiController
    {
        private TodoDataContext db = new TodoDataContext();
        //GET: api/todoes
        public IQueryable<Todo> GetAll()
        {
            return db.Todoes;
        }
        // GET api/todoes/1
        public IHttpActionResult GetById(int id)
        {
            Todo c = db.Todoes.Find(id);
            if(c == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(c);
            }
        }
        // POST: api/todoes
        public IHttpActionResult Create(Todo todo)
        {
            // Server side validation
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            Todo copy = db.Todoes.Add(todo);

            db.SaveChanges();

            return Ok(copy);
        }

        // PUT: api/todoes/1
        public IHttpActionResult Update(int id, Todo todo)
        {
            if(db.Todoes.Any(c => c.todoId == id) == false)
            {
                return NotFound();
            }
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            db.Entry(todo).State = EntityState.Modified;

            db.SaveChanges();

            return Ok();
        }
        // DELETE: api/todoes/1
        public IHttpActionResult Delete(int id)
        {
            var todo = db.Todoes.Find(id);

            if (todo == null)
            {
                return NotFound();
            }
            else
            {
                db.Todoes.Remove(todo);

                db.SaveChanges();

                return Ok(todo);
            }

        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();

            base.Dispose(disposing);
        }
    }
}

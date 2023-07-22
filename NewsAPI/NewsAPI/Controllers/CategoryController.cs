using NewsAPI.EF;
using NewsAPI.EF.Models;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsAPI.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpPost]
        [Route("api/Category/create")]
        public HttpResponseMessage Create(Category cat)
        {
            var db = new NewsContext();
            try
            {
                db.Categories.Add(cat);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Category/all")]
        public HttpResponseMessage GelAll()
        {
            var db = new NewsContext();
            var data = db.Categories.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, Convert(data));
        }

        [HttpPost]
        [Route("api/Category/edit")]
        public HttpResponseMessage Update(Category cat)
        {
            var db = new NewsContext();
            var exp = db.Categories.Find(cat.CategoryId);

            try
            {
                exp.CategoryName = cat.CategoryName;
                /*db.Entry(exp).CurrentValues.SetValues(p);*/
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Category/remove")]
        public HttpResponseMessage Post(Category cat)
        {
            var db = new NewsContext();
            var data = db.Categories.Find(cat.CategoryId);
            db.Categories.Remove(data);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Removed" });
        }

        [HttpGet]
        [Route("api/Category/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var db = new NewsContext();
            var data = db.Categories.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, Convert(data));
        }


        CategoryDTO Convert(Category dto)
        {
            if (dto == null) return null;
            var d = new CategoryDTO();
            d = new CategoryDTO
            {
                CategoryId = dto.CategoryId,
                CategoryName = dto.CategoryName,
                Newses = Convert(dto.Newses)
            };
            return d;
        }
        List<CategoryDTO> Convert(List<Category> n)
        {
            if (n == null) return null;
            var list = new List<CategoryDTO>();
            foreach (var item in n)
            {
                list.Add(new CategoryDTO
                {
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName,
                    Newses = Convert(item.Newses)
                });
                
            }
            return list;
        }
        List<NewsDTO> Convert(ICollection<News> n)
        {
            if(n == null) return null;
            List<NewsDTO> list = new List<NewsDTO>();
            foreach (var item in n)
            {
                list.Add(new NewsDTO
                {
                    NewsId = item.NewsId,
                    NewsName = item.NewsName,
                    NewsDate = item.NewsDate,
                    NewsDescription = item.NewsDescription,
                    CategoryId = item.CategoryId
                });
            }
            return list;
        }
    }   
        
}

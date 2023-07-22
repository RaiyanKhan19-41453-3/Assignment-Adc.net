using NewsAPI.EF.Models;
using NewsAPI.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewsAPI.Models;

namespace NewsAPI.Controllers
{
    public class NewsController : ApiController
    {
        [HttpPost]
        [Route("api/News/create")]
        public HttpResponseMessage Create(News cat)
        {
            var db = new NewsContext();
            try
            {
                db.Newses.Add(cat);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/News/all")]
        public HttpResponseMessage GelAll()
        {
            var db = new NewsContext();
            try
            {
                var data = db.Newses.ToList();

                return Request.CreateResponse(HttpStatusCode.OK, Convert(data));
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/News/edit")]
        public HttpResponseMessage Update(News cat)
        {
            var db = new NewsContext();
            var exp = db.Newses.Find(cat.NewsId);

            try
            {
                exp.NewsName = cat.NewsName;
                exp.NewsDate = cat.NewsDate;
                exp.NewsDescription = cat.NewsDescription;
                exp.CategoryId = cat.CategoryId;
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
        [Route("api/News/remove")]
        public HttpResponseMessage Post(News cat)
        {
            var db = new NewsContext();
            var data = db.Newses.Find(cat.NewsId);
            db.Newses.Remove(data);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Removed" });
        }

        [HttpGet]
        [Route("api/News/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var db = new NewsContext();
            var data = db.Newses.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, Convert(data));
        }


        [HttpGet]
        [Route("api/News/date/{date}")]
        public HttpResponseMessage Get(DateTime date)
        {
            var db = new NewsContext();
            var data = db.Newses.Where(item => item.NewsDate == date).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, Convert(data));
        }

        [HttpGet]
        [Route("api/News/CategoryName/{name}")]
        public HttpResponseMessage Get(string name)
        {
            var db = new NewsContext();
            var data = db.Newses.Where(item => item.Category.CategoryName == name).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, Convert(data));
        }

        [HttpGet]
        [Route("api/News/CategoryDate/{date}/CategoryName/{name}")]
        public HttpResponseMessage Get(DateTime date, string name)
        {
            var db = new NewsContext();
            var data = db.Newses.Where(item => item.Category.CategoryName == name 
                                        && item.NewsDate == date).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, Convert(data));
        }





        NewsDTO Convert(News dto)
        {
            if (dto == null) return null;
            var d = new NewsDTO();
            d = new NewsDTO
            {
                NewsId = dto.NewsId,
                NewsName = dto.NewsName,
                NewsDate = dto.NewsDate,
                NewsDescription = dto.NewsDescription,
                CategoryId = dto.CategoryId
            };
            return d;
        }
        List<NewsDTO> Convert(List<News> n)
        {
            if(n == null || n.Count == 0) return null;
            var list = new List<NewsDTO>();
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

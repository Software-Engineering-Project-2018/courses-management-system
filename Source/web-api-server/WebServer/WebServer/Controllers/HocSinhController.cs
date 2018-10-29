using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebServer.Models;
using WebServer.Repository;

namespace WebServer.Controllers
{
    public class HocSinhController : BaseController
    {
        private HocSinhReposistory hocSinhReposistory = new HocSinhReposistory();

        [Route("rest/hoc-sinh/get-all")]
        [HttpGet]
        public List<HocSinh> GetAll()
        {
            return hocSinhReposistory.GetAll();
        }


        //// GET: api/HocSinh
        //public IQueryable<HocSinh> GetHocSinhs()
        //{
        //    return db.HocSinhs;
        //}

        //// GET: api/HocSinh/5
        //[ResponseType(typeof(HocSinh))]
        //public IHttpActionResult GetHocSinh(long id)
        //{
        //    HocSinh hocSinh = db.HocSinhs.Find(id);
        //    if (hocSinh == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(hocSinh);
        //}

        //// PUT: api/HocSinh/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutHocSinh(long id, HocSinh hocSinh)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != hocSinh.HocSinhId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(hocSinh).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!HocSinhExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/HocSinh
        //[ResponseType(typeof(HocSinh))]
        //public IHttpActionResult PostHocSinh(HocSinh hocSinh)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.HocSinhs.Add(hocSinh);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = hocSinh.HocSinhId }, hocSinh);
        //}

        //// DELETE: api/HocSinh/5
        //[ResponseType(typeof(HocSinh))]
        //public IHttpActionResult DeleteHocSinh(long id)
        //{
        //    HocSinh hocSinh = db.HocSinhs.Find(id);
        //    if (hocSinh == null)
        //    {
        //        return NotFound();
        //    }

        //    db.HocSinhs.Remove(hocSinh);
        //    db.SaveChanges();

        //    return Ok(hocSinh);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool HocSinhExists(long id)
        //{
        //    return db.HocSinhs.Count(e => e.HocSinhId == id) > 0;
        //}
    }
}
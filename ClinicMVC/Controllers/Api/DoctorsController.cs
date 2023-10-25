using ClinicMVC.Models;
using DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DoctorsController : ApiController
    {
        DoctorsData ms = null;
        public DoctorsController()
        {
            ms = new DoctorsData();
        }
        List<DoctorModel> s = new List<DoctorModel>();
        // GET api/<controller>
        [Route("GetAllDoctorDetails")]
        public IEnumerable<DoctorModel> Get()
        {
            List<Doctor> c = ms.GetAllDoctors();
            foreach (var item in c)
            {
                DoctorModel v = new DoctorModel();
                v.UserId = item.UserId;
                v.DoctorId = item.DoctorId;
                v.IsAavailable = item.IsAavailable;
                v.Timings = item.Timings;
                v.SpecializationId = item.SpecializationId;
                //v.Specialization = item.Specialization;
                //v.User = item.User;

                s.Add(v);
            }
            return s;
        }

        // GET api/<controller>/5
        [Route("GetDoctorByID/{id}")]
        public DoctorModel Get(int id)
        {
            DoctorModel r = new DoctorModel();
            Doctor p = new Doctor();
            p = ms.GetDoctorByid(id);

            r.UserId = Convert.ToInt32(p.UserId);
            r.DoctorId = Convert.ToInt32(p.DoctorId);
            r.IsAavailable = Convert.ToBoolean(p.IsAavailable);
            //r.User = p.User;
            //r.Specialization= p.Specialization;
            r.SpecializationId = Convert.ToInt32(p.SpecializationId);
            r.Timings = p.Timings.ToString();

            return r;
        }

        // POST api/<controller>
        [Route("SavingDoctor")]
        public HttpResponseMessage Post([FromBody] DoctorModel value)
        {
            Doctor r = new Doctor();
            r.UserId = value.UserId;
            r.DoctorId = value.DoctorId;
            r.Timings = value.Timings;
            //r.Specialization = value.Specialization;
            r.SpecializationId = value.SpecializationId;
            //r.User = value.User;
            r.IsAavailable = value.IsAavailable;

            bool k = ms.AddDoctor(r);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        // PUT api/<controller>/5
        [Route("UpdateDoctor/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] DoctorModel value)
        {
            Doctor r = new Doctor();
            r.UserId = value.UserId;
            r.DoctorId = value.DoctorId;
            r.Timings = value.Timings;
            //r.Specialization = value.Specialization;
            r.SpecializationId = value.SpecializationId;
            //r.User = value.User;
            r.IsAavailable = value.IsAavailable;

            bool k = ms.UpdateDoctor(id, r);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        // DELETE api/<controller>/5
        [Route("DeleteDoctor/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            bool k = ms.DeleteDoctor(id);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
    }
}

using CodingTestRepository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CodingTest.Models;
using CodingTestRepository;

namespace CodingTest.API.Controllers
{
    public class CodingTestController : ApiController
    {
        private readonly IServices _service;

        public CodingTestController()
        {
            _service = new Repository();
        }


        [HttpGet]
        [ResponseType(typeof(Settled))]
        public IHttpActionResult GetSettledBetHistory()
        {
           List<Settled> entries = _service.GetsettledBetHistory();
            if (entries == null)
            {
                return NotFound();
            }

            return Ok(entries);
        }

        [ResponseType(typeof(UnSettled))]
        public IHttpActionResult GetUnSettledBetHistory()
        {
            List<UnSettled> entries = _service.GetUnsettledBetHistory();
            if (entries == null)
            {
                return NotFound();
            }

            return Ok(entries);
        }
        [HttpGet]
        public IHttpActionResult GetUnusual([FromBody] string Id)
        {
            List<UnSettled> entries = _service.Unusual(Id);
            if (entries == null)
            {
                return NotFound();
            }

            return Ok(entries);
        }
        [HttpGet]
        public IHttpActionResult GetHighlyUnusual([FromUri] string Id)
        {
            List<UnSettled> entries = _service.HighlyUnusual(Id);
            if (entries == null)
            {
                return NotFound();
            }

            return Ok(entries);
        }
        [HttpGet]
        public IHttpActionResult GetHighAmounts([FromUri] string Id)
        {
            List<UnSettled> entries = _service.HighAmounts();
            if (entries == null)
            {
                return NotFound();
            }

            return Ok(entries);
        }
    }

   
}

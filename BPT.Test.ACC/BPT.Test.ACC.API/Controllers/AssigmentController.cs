using BPT.Test.ACC.Core.Entities;
using BPT.Test.ACC.Core.Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPT.Test.ACC.API.Controllers
{
    [Route("api/assigment")]
    [ApiController]
    public class AssigmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssigmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<AssignmentsCls> Get()
        {
            return _unitOfWork.Assigment.GetAll().ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public AssignmentsCls Get(int id)
        {
            return _unitOfWork.Assigment.GetById(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult Post([FromBody] AssignmentsCls value)
        {
            _unitOfWork.Assigment.Insert(value);
            _unitOfWork.Save();

            return Ok();
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AssignmentsCls value)
        {
            var result = _unitOfWork.Assigment.GetById(id);

            if (id != value.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Assigment.Update(value);
            _unitOfWork.Save();
            return Ok();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _unitOfWork.Assigment.GetById(id);
            _unitOfWork.Assigment.Delete(result);
            return Ok();
        }
    }
}

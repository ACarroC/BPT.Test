using BPT.Test.ACC.Core.Entities;
using BPT.Test.ACC.Core.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BPT.Test.ACC.API.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<StudentCls> Get()
        {
            return _unitOfWork.Student.GetAll().ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public StudentCls Get(int id)
        {
            return _unitOfWork.Student.GetById(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult Post([FromBody] StudentCls value)
        {
            _unitOfWork.Student.Insert(value);
            _unitOfWork.Save();

            return Ok();
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] StudentCls value)
        {
            var result = _unitOfWork.Student.GetById(id);

            if(id != value.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Student.Update(value);
            _unitOfWork.Save();
            return Ok();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _unitOfWork.Student.GetById(id);
            _unitOfWork.Student.Delete(result);
            return Ok();
        }
    }
}

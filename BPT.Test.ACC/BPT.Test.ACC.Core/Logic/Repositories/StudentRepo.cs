using BPT.Test.ACC.Core.DAL;
using BPT.Test.ACC.Core.Entities;
using BPT.Test.ACC.Core.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPT.Test.ACC.Core.Logic.Repositories
{
    public class StudentRepo : IStudent
    {
        private readonly SchoolContext _context;

        public StudentRepo(SchoolContext context)
        {
            _context = context;
        }
        public void Delete(StudentCls student)
        {
            _context.Remove(student);

        }

        public List<StudentCls> GetAll()
        {
            return _context.Students.ToList();
        }

        public StudentCls GetById(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(StudentCls student)
        {
            _context.Students.Add(student);

        }

        public void Update(StudentCls student)
        {
            _context.Students.Update(student);

        }
    }
}

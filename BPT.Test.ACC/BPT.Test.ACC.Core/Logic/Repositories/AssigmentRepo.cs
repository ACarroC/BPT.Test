using BPT.Test.ACC.Core.DAL;
using BPT.Test.ACC.Core.Entities;
using BPT.Test.ACC.Core.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPT.Test.ACC.Core.Logic.Repositories
{
    public class AssigmentRepo : IAssigment
    {
        private readonly SchoolContext _context;

        public AssigmentRepo(SchoolContext context)
        {
            _context = context;
        }
        public void Delete(AssignmentsCls assignment)
        {
             _context.Remove(assignment);
            
        }

        public List<AssignmentsCls> GetAll()
        {
            return _context.Assignments.ToList();
        }

        public AssignmentsCls GetById(int id)
        {
            return _context.Assignments.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(AssignmentsCls assignment)
        {
           _context.Assignments.Add(assignment);
            
        }

        public void Update(AssignmentsCls assignment)
        {
            _context.Assignments.Update(assignment);            
        }
    }
}

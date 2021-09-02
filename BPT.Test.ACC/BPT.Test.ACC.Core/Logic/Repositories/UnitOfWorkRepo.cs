using BPT.Test.ACC.Core.DAL;
using BPT.Test.ACC.Core.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BPT.Test.ACC.Core.Logic.Repositories
{
    public class UnitOfWorkRepo : IUnitOfWork
    {
        private readonly SchoolContext _context;
        private IStudent _studentRepo;
        private IAssigment _assigmentRepo;

        public UnitOfWorkRepo(SchoolContext context)
        {
            _context = context;
        }
        public IAssigment Assigment
        {
            get
            {
                return _assigmentRepo = _assigmentRepo ?? new AssigmentRepo(_context);
            }
        }

        public IStudent Student
        {
            get
            {
                return _studentRepo = _studentRepo ?? new StudentRepo(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

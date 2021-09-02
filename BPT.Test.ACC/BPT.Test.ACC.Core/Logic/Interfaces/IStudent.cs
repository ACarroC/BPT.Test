using BPT.Test.ACC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BPT.Test.ACC.Core.Logic.Interfaces
{
    public interface IStudent
    {
        List<StudentCls> GetAll();
        StudentCls GetById(int Id);

        void Insert(StudentCls assignment);

        void Update(StudentCls assignment);

        void Delete(StudentCls assignment);
    }
}

using BPT.Test.ACC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BPT.Test.ACC.Core.Logic.Interfaces
{
    public interface IAssigment
    {
        List<AssignmentsCls> GetAll();
        AssignmentsCls GetById(int id);

        void Insert(AssignmentsCls assignment);

        void Update(AssignmentsCls assignment);

        void Delete(AssignmentsCls assignment);
    }
}

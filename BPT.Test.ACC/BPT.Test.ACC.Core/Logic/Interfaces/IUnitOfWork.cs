using System;
using System.Collections.Generic;
using System.Text;

namespace BPT.Test.ACC.Core.Logic.Interfaces
{
    public interface IUnitOfWork
    {
        IAssigment Assigment {get;}

        IStudent Student { get; }

        void Save();

    }
}

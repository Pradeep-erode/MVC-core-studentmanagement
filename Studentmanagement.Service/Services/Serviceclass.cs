using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Studentmanagement.Core;
using Studentmanagement.Core.IRepository;
using Studentmanagement.Core.IService;
using Studentmanagement.Core.Mystudent_class;

using System;
using System.Collections.Generic;

namespace Studentmanagement.Service
{
    public class Serviceclass : IServices
    {
        IRepository _Repository;


        public Serviceclass(IRepository testRepository)
        {
            _Repository = testRepository;
        }

        public List<Mymodelcs> Dashboard(Mymodelcs detail)
        {
            var listof = _Repository.Dashboard(detail);
            return listof;
        }

        public Mymodelcs Create(Mymodelcs student)
        {
           return _Repository.Create(student);
        }

        public int Check(Mymodelcs student)
        {
            var counter=_Repository.Check(student);
            if (counter > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public Mymodelcs Editing(int studentid)
        {
            return _Repository.Editing(studentid);
        }
        public void Delete(int studentid)
        {
            _Repository.Delete(studentid);
        }

        
    }
}

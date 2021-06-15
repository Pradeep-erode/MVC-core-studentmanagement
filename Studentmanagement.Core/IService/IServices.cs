using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studentmanagement.Core.Mystudent_class;

namespace Studentmanagement.Core.IService
{
    public interface IServices
    {
        public Mymodelcs Create(Mymodelcs student);

        public List<Mymodelcs> Dashboard(Mymodelcs detail);

        public int Check(Mymodelcs student);

        public Mymodelcs Editing(int studentid);

        public void Delete(int studentid);
    }
}

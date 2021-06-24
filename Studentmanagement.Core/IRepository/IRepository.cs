using Studentmanagement.Core.Mystudent_class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentmanagement.Core.IRepository
{
   public interface IRepository
    {
        public Mymodelcs Create(Mymodelcs student);

        public List<Mymodelcs> Dashboard();

        public int Check(Mymodelcs student);

        public Mymodelcs Editing(int studentid);

        public void Delete(int studentid);

        
    }
}

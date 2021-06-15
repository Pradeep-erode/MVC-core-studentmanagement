using Studentmanagement.Core;
using Studentmanagement.Core.IRepository;
using Studentmanagement.Service;
using Studentmanagement.Entities;
using System;
using Studentmanagement.Core.Mystudent_class;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Studentmanagement.Resource.Repository
{
    public class Repository : IRepository
    {
        

        public Mymodelcs Create(Mymodelcs student)
        {
            using (StudentContext entity = new StudentContext())
            {

                var datacheck = entity.Studentmark.Where(m => m.StudentId == student.StudentId).SingleOrDefault();
                if (datacheck != null)
                {
                   
                    datacheck.FirstName = student.firstname;
                    datacheck.LastName = student.secondname;
                    datacheck.StudentDob = student.Studentsdob;
                    datacheck.Age = student.Age;
                    datacheck.FavoriteSubject = student.Favoritesubject;
                    datacheck.InterestedCourse = student.InterestedCourse;
                    datacheck.MathsMark = student.Mathsmark;
                    datacheck.ChemistryMark = student.ChemistryMark;
                    datacheck.CompMark = student.CompMark;
                    datacheck.IsDeleted = false;
                    datacheck.UpdatedTimeStamp = DateTime.Now;
                    datacheck.Username = student.Username;
                    datacheck.Password = student.Password;
                    entity.SaveChanges();
                    return student;
                }
                else 
                {
                    Studentbase create = new Studentbase();
                    create.FirstName = student.firstname;
                    create.LastName = student.secondname;
                    create.StudentDob = student.Studentsdob;
                    create.Age = student.Age;
                    create.FavoriteSubject = student.Favoritesubject;
                    create.InterestedCourse = student.InterestedCourse;
                    create.MathsMark = student.Mathsmark;
                    create.ChemistryMark = student.ChemistryMark;
                    create.CompMark = student.CompMark;
                    create.IsDeleted = false;
                    create.CreatedTimeStamp = DateTime.Now;
                    create.UpdatedTimeStamp = DateTime.Now;
                    create.Username = student.Username;
                    create.Password = student.Password;
                    entity.Studentmark.Add(create);
                    entity.SaveChanges();
                    return student;
                }
                
            }
        }

        //if you need the ability to make permanent changes of any kind to your collection (add & remove),
        //you'll need List<>.
        //If you just need to read, sort and/or filter your collection, IEnumerable<> is sufficient for that purpose.
        public List<Mymodelcs> Dashboard(Mymodelcs detail)
        {
                List<Mymodelcs> lists = new List<Mymodelcs>();
                using (StudentContext entity = new StudentContext())
                {
                    var checking = entity.Studentmark.Where(y => y.Username == detail.Username && y.Password == detail.Password || y.IsDeleted == false).ToList();
                    foreach (var datalist in checking)
                    {
                        Mymodelcs listobj = new Mymodelcs();
                        listobj.StudentId = datalist.StudentId;
                        listobj.firstname = datalist.FirstName;
                        listobj.secondname = datalist.LastName;
                        listobj.Studentsdob = datalist.StudentDob;
                        listobj.Age = datalist.Age;
                        listobj.Favoritesubject = datalist.FavoriteSubject;
                        listobj.InterestedCourse = datalist.InterestedCourse;
                        listobj.Mathsmark = datalist.MathsMark;
                        listobj.ChemistryMark = datalist.ChemistryMark;
                        listobj.CompMark = datalist.CompMark;
                        listobj.Username = datalist.Username;
                        listobj.Password = datalist.Password;
                        lists.Add(listobj);
                    }
                return lists;
                } 
            
        }

        public int Check(Mymodelcs student)
        {
            using (StudentContext entitya = new StudentContext())
            {
                var checking = entitya.Studentmark.Where(model => model.Username == student.Username && model.Password == student.Password).ToList();
                var checkcount=checking.Count();
                if (checkcount > 2)
                { 
                    return 1;
                }
                else
                {  
                    return 0;
                }
            }
        }
        public Mymodelcs Editing(int studentid)
        {
            
            using (StudentContext edit = new StudentContext())
            {  
                var editbase = edit.Studentmark.Where(a => a.StudentId == studentid).SingleOrDefault();
                Mymodelcs student = new Mymodelcs();
                student.StudentId = editbase.StudentId;
                student.firstname = editbase.FirstName;
                student.secondname = editbase.LastName;
                student.Studentsdob = editbase.StudentDob;
                student.Age = editbase.Age;
                student.Favoritesubject = editbase.FavoriteSubject;
                student.InterestedCourse = editbase.InterestedCourse;
                student.Mathsmark = editbase.MathsMark;
                student.ChemistryMark = editbase.ChemistryMark;
                student.CompMark = editbase.CompMark;
                student.Username = editbase.Username;
                student.Password = editbase.Password;        
                return student;
            }
        }

        public void Delete(int studentid)
        {
            using (var baselist = new StudentContext())
            {
                var deletelist = baselist.Studentmark.Where(m => m.StudentId == studentid).SingleOrDefault();
                deletelist.IsDeleted = true;
                baselist.SaveChanges();
            }
        }
    }
}

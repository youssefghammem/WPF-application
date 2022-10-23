using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace TestWPF.Model
{
    public class StudentService
    {

        MVVMDBEntities ObjContext;
        public StudentService()
        {
            ObjContext = new MVVMDBEntities();
        }

        public List<StudentDTO> GetAll()
        {
            List<StudentDTO> objStudentList = new List<StudentDTO>();
            try
            {
                var ObjQuery = from obj in ObjContext.Students
                               select obj;
                foreach (var studentt in ObjQuery)
                {
                    objStudentList.Add(new StudentDTO { Id = studentt.Id, Name = studentt.Name, Age = studentt.Age });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objStudentList;
        }

        public bool Add(StudentDTO newStudent)
        {
            bool IsAdded = false;
           
            if ( newStudent.Age > 35 || newStudent.Age < 18)
                throw new ArgumentException("Invalid age limit for student");

            try
            {
                var objStudent = new Student();
                objStudent.Id = newStudent.Id;
                objStudent.Name = newStudent.Name;
                objStudent.Age = newStudent.Age;

                ObjContext.Students.Add(objStudent);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            return IsAdded;
        }

      

        public bool Delete(int id)
        {
            bool IsDeleted = false;
            try
            {
                var objStudentDeleted = ObjContext.Students.Find(id);
                ObjContext.Students.Remove(objStudentDeleted);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsDeleted = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return IsDeleted;
        }
        public bool Update(StudentDTO studenToUpdate)
        {
            bool IsUpdated = false;

            try
            {
                var objStudent = ObjContext.Students.Find(studenToUpdate.Id);
                objStudent.Name = studenToUpdate.Name;
                objStudent.Age = studenToUpdate.Age;
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsUpdated = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsUpdated;
        }


       
    }
}

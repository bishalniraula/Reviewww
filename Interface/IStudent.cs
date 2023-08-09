using AuthProject.Models;
using System.Security.Permissions;

namespace AuthProject.Interface
{
    public interface IStudent
    {
        public Task<List<Student>> GetAllUser();
       public Task <Student> GetStudentById(int id);
        public Task <bool> InsertUpdate(Student student);
        public Task <bool>DeleteStudent(int? id);
        public Task<Student> ShowStudentById(int? id);
        public Task<Student> Detail(int? id);
    
        
    }
}

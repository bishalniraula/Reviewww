using AuthProject.Data;
using AuthProject.Interface;
using AuthProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace AuthProject.Repositories
{
    public class StudentRepository : IStudent
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

               

        public async Task<List<Student>> GetAllUser()
        {
            return await _context.students.Select(x => new Student()
            {

                Id = x.Id,
                Name = x.Name,
                Address = x.Address


            }).ToListAsync();


        }
        public async Task<Student> GetStudentById(int id)
        {
            var data = await _context.students.Where(x => x.Id == id).FirstOrDefaultAsync();
           
              
                return data;
           
        }
     
      
      

        public async Task<bool> InsertUpdate(Student student)
        {
            try
            {
                if (student.Id > 0)
                {
                    var st = await _context.students.Where(x => x.Id == student.Id).FirstOrDefaultAsync();
                    if (st != null)
                    {
                        st.Id = student.Id;
                        st.Name = student.Name;
                        st.Address = student.Address;

                        _context.Entry(st).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Student data = new Student();
                    data.Id = student.Id;
                    data.Name = student.Name;
                    data.Address = student.Address;
                    var ExistedName = await _context.students.FirstOrDefaultAsync(x => x.Name == data.Name);
                    if (ExistedName == null)
                    {
                        await _context.students.AddAsync(data);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
                catch (Exception ex)
            {
                
                return false;
            }
        }


        public async Task<bool> DeleteStudent(int? id)
        {

            try
            {
                Student data = await _context.students.FindAsync(id);
                _context.students.Remove(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                Exception ex;
                return false;
            }


        }

        public async  Task<Student> ShowStudentById(int? id)
        {
            var data = await _context.students.Where(x => x.Id == id).FirstOrDefaultAsync();


            return data;
        }

        public async Task<Student> Detail(int? id)
        {
            Student data = await _context.students.FindAsync(id);
            return data;

        }

    }
}

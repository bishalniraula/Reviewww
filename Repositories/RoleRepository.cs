using AuthProject.Data;
using AuthProject.Interface;
using AuthProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Construction;
using Microsoft.EntityFrameworkCore;

namespace AuthProject.Repositories
{
    public class RoleRepository : IRole
    {
        public readonly AppDbContext _context;
        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task <List<Role>>GetAllRole()
        {
            return await _context.roles.Select(x => new Role()
            {
                RollName=x.RollName,
                Id=x.Id ,
                Email =x.Email ,


            }).ToListAsync();

            //Another process
            //List<Role> roles = new List<Role>();
            //roles=await _context.roles.ToListAsync();
            //return roles;
           
           

        }
        public async Task<Role> GetRoleById(int?   id)
        {
            return await _context.roles.Where(x => x.Id == id).FirstOrDefaultAsync();

            //Another process

            //            var role = await _context.roles.FindAsync(id);
            //          return role;


            //Another process
            //var v = await _context.roles.Where(x => x.Id==id).Select(x=>new Role()
            //    {

            //        Id = x.Id,
            //        Email = x.Email,
            //        RollName = x.RollName,

            //    }).FirstOrDefaultAsync();
                
            //        return v; 
               
            

        }
        public async Task <bool> insertupdate(Role role)
        {
            try
            {


                if (role.Id > 0)
                {
                    Role update = new Role();
                    update.Id = role.Id;
                    update.RollName = role.RollName;
                    update.Password = role.Password; ;

                    _context.roles.Update(update);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    Role insert = new Role();
                    
                    insert.Id = role.Id;
                    insert.RollName= role.RollName;
                    insert.Email = role.Email;
                    insert.Password = role.Password; 
                    _context.roles.Add(insert);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            
}


    }
}

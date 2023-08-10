using AuthProject.Models;

namespace AuthProject.Interface
{
    public interface IRole
    {
        public Task<List<Role>> GetAllRole();
        public Task<Role> GetRoleById(int? id);
        public Task<bool>insertupdate(Role role);

    }
}

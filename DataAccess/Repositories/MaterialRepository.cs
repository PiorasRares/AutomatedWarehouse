using DataAccess.DataContext;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MaterialRepository
    {
        private readonly Context _context;
        public MaterialRepository(Context context)
        {
            _context= context;
        }
        public List<Material> GetMaterials(int containerId)
        {
            return _context.Materials.Where(material => material.ContainerId == containerId).ToList();
        }
        public List<Material> GetAllMaterials()
        {
            return _context.Materials.GroupBy(material=>material.Name).Select(first=>first.First()).ToList();
        }
    }
}

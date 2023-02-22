using DataAccess.DataContext;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MaterialRepository:BaseRepository
    {
        public MaterialRepository(Context context) : base(context)
        {
        }

        public List<Material> GetMaterials(int containerId)
        {
            return _context.Materials.Where(material => material.ContainerId == containerId).ToList();
        }
    }
}

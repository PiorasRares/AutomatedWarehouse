using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Material
    {
        public int Id { get; set; } 
        public int ContainerId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}

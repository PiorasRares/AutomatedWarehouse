using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class StorageLocation
    {
        public int Id { get; set; }
        public int StorageTypeId { get; set; }
        public string Name { get; set; }
        public int TOFromCount { get; set; }
        public int TOToCount { get; set;}
    }
}

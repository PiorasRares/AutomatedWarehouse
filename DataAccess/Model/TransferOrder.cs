using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class TransferOrder
    {
        public int Id { get; set; }
        public int FromContainerId { get; set; }
        public int ToContainerId { get; set;}
        public string MaterialName { get;set; }
        public int OrderQuantity { get; set; }
    }
}

﻿using DataAccess.DataContext;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ContainerRepository:BaseRepository
    {
        public ContainerRepository(Context context) : base(context)
        {
        }

        public List<Container> GetContainers(int storageLocationId)
        {
            return _context.Containers.Where(container => container.StorageLocationId == storageLocationId).ToList();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.Interfaces
{
    public interface ITable
    {
        
        // TableDTO GetTable(int? id);
        IEnumerable<TableDTO> GetTablesAsync();
        void Dispose();
    }
}

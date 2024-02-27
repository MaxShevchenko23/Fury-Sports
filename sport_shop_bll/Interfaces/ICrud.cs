﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_shop_bll.Interfaces
{
    public interface ICrud<Create, Read, Update>
    {
        Task<IEnumerable<Read>> GetAllAsync();

        Task<Read> GetByIdAsync(int id);

        Task<Create> AddAsync(Create model);

        Task<Update> UpdateAsync(Update model);

        Task DeleteByIdAsync(int modelId);
    }
}

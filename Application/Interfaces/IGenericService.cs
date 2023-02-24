﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task CreateAsync(T entity);
    }
}

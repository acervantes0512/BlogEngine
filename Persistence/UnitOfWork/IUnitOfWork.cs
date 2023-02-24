﻿using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }
        IRepository<T> GetRepository<T>() where T : class;
        void SaveChanges();
    }

}

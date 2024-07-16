using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.Interfaces
{
    public interface IBookStoreRepository<TEntity,out T>
    {
        IList<TEntity> Retrive();

        TEntity GetById(int id);

        public T GetEntityById(int id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}

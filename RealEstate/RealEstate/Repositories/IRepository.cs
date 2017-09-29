using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Repositories
{
    public interface IRepository<T>
    {
        void Add(T item);
        void DeleteData(T item);
        IQueryable<T> GetAll(int pageIndex);
        IQueryable<T> GetAllByID(int ParentID,string columnName,int pageIndex);
        IQueryable<T> SearchData(string name);
        T GetById(int id);
        void Save();
    }
}
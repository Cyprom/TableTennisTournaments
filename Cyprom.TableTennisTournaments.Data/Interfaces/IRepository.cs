using System;
using System.Collections.Generic;
using Cyprom.TableTennisTournaments.Model;

namespace Cyprom.TableTennisTournaments.Data.Interfaces
{
    public interface IRepository<T> where T : Identifiable
    {
        //List<T> ReadAll();
        //T Read(Guid id);
        //void Save(T obj);
        //void Delete(T obj);

        bool Exists(Guid id);
        List<T> SelectAll();
        T Select(Guid id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(Guid id);
    }
}

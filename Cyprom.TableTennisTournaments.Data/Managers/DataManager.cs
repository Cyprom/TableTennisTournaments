using Cyprom.TableTennisTournaments.Data.Repositories;
using Cyprom.TableTennisTournaments.Model;
using System;
using System.Collections.Generic;

namespace Cyprom.TableTennisTournaments.Data.Managers
{
    public static class DataManager
    {
        private static TableRepository _tables = new TableRepository();

        #region Table

        public static bool TableExists(Guid id)
        {
            return _tables.Exists(id);
        }

        public static List<Table> SelectAllTables()
        {
            return _tables.SelectAll();
        }

        public static Table SelectTable(Guid id)
        {
            return _tables.Select(id);
        }

        public static void InsertTable(Table obj)
        {
            _tables.Insert(obj);
        }

        public static void UpdateTable(Table obj)
        {
            _tables.Update(obj);
        }

        public static void DeleteTable(Guid id)
        {
            _tables.Delete(id);
        }

        #endregion
        
    }
}

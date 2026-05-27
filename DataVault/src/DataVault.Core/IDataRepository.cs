using System;
using System.Collections.Generic;

namespace DataVault.Core
{
    /// <summary>
    /// Defines the contract for persistent storage, completely hiding the implementation (JSON, SQLite, Memory).
    /// </summary>
    public interface IDataRepository
    {
        void SaveRecord(VaultRecord record);
        VaultRecord GetRecord(Guid id);
        IEnumerable<VaultRecord> GetAllRecords();
        void DeleteRecord(Guid id);
    }
}

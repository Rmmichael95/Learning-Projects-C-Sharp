using System;
using System.Collections.Generic;
using System.Linq;

namespace DataVault.Core
{
    public class VaultEngine
    {
        private readonly IDataRepository _repository;

        // The engine demands a repository but doesn't care what kind it is (Dependency Injection).
        public VaultEngine(IDataRepository repository)
        {
            _repository = repository;
        }

        public VaultRecord CreateNew(string title, string payload)
        {
            // TODO: Instantiate a new VaultRecord, pass it to _repository.SaveRecord(), and return it.
            VaultRecord record = new() { Title = title, Payload = payload };
            _repository.SaveRecord(record);
            return record;
        }

        public IEnumerable<VaultRecord> SearchByTitle(string searchTerm)
        {
            // TODO: Use LINQ to filter _repository.GetAllRecords() where Title contains the searchTerm.
            return _repository
                .GetAllRecords()
                .Where(record =>
                    record.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                );
        }
    }
}

using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.MongoDb.Repository
{
    public class EmpresaRepository : IEmpresaRepository<Empresa>
    {
        private IMongoDb Db { get; set; }
        public EmpresaRepository(IMongoDb db)
        {
            Db = db;
        }

        public void Save(Empresa entity)
        {
            Db.Save<Empresa>(entity);
        }
    }
}

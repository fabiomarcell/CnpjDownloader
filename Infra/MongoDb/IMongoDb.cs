using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.MongoDb
{
    public interface IMongoDb
    {
        void Save<T>(T entity);
    }
}

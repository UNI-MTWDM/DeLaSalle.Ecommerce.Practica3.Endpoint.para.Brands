
using System.Data.Common;

namespace DeLaSalle.Ecommerce.Api.DataAccess.Interfaces;

public interface IDbContext
{
    DbConnection Connection { get; }
}


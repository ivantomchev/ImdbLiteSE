namespace ImdbLite.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ImdbLite.Data.Common.Repository;
    using ImdbLite.Data.Models;

    public interface IImdbLiteData
    {
        int SaveChanges();
    }
}

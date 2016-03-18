using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistration.Model;

namespace StudentRegistration.Repository
{
    public abstract class BaseRepository
    {
        public BusinessDbContext Db { get; set; }

        protected BaseRepository(BusinessDbContext db)
        {
            this.Db = db;
        }
    }
}

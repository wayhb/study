using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace lec11.models
{
    public class Db : DbContext
    {

        public Db() { }

        public Db(DbContextOptions<Db> options) : base(options) { }

        public virtual DbSet<Gender> genders { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelDev.Comum.Entity
{
    public abstract class CamelDevWebEntityAbstractConfig<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public CamelDevWebEntityAbstractConfig()
        {
            ConfigNameToTable();
            ConfigFields();
            ConfigPrimaryKey();
            ConfigForeignKey();
        }

        protected abstract void ConfigNameToTable();

        protected abstract void ConfigFields();

        protected abstract void ConfigPrimaryKey();

        protected abstract void ConfigForeignKey();
    }
}

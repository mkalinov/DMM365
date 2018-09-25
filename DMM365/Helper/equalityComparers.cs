using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMM365.DataContainers;
using Microsoft.Xrm.Sdk;

namespace DMM365.Helper
{
    public class FieldSchemaEqualityComparers : IEqualityComparer<SchemaField>
    {
        public bool Equals(SchemaField x, SchemaField y)
        {
            return x.name == y.name;
        }

        public int GetHashCode(SchemaField obj)
        {
            return 0;
        }
    }

    public class EntitySchemaEqualityComparer : IEqualityComparer<SchemaEntity>
    {
        public bool Equals(SchemaEntity x, SchemaEntity y)
        {
            return x.name == y.name;
        }

        public int GetHashCode(SchemaEntity obj)
        {
            return 0;
        }
    }

    public class GuidEqualityComparer : IEqualityComparer<Guid>
    {
        public bool Equals(Guid x, Guid y)
        {
            return x == y;
        }

        public int GetHashCode(Guid id)
        {
            return id.GetHashCode();
        }
    }

    public class CrmEntityContainerEqualityComparers : IEqualityComparer<CrmEntityContainer>
    {
        public bool Equals(CrmEntityContainer x, CrmEntityContainer y)
        {
            return x.id == y.id;
        }

        public int GetHashCode(CrmEntityContainer obj)
        {
            return 0;
        }
    }

    public class sdkEntityEqualityComparers : IEqualityComparer<Entity>
    {
        public bool Equals(Entity x, Entity y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Entity obj)
        {
            return 0;
        }
    }

    public class selectedQueryEqualityComparer : IEqualityComparer<selectedQuery>
    {
        public bool Equals(selectedQuery x, selectedQuery y)
        {
            return x.id == y.id;
        }

        public int GetHashCode(selectedQuery id)
        {
            return id.GetHashCode();
        }
    }

}

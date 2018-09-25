using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMM365.DataContainers
{
    [Serializable()]
    public class selectedQuery
    {
        public Guid id { get; set; }
        public bool ExecuteAsListOfLinkedQueries { get; set; }
        public bool CollectAllReferences { get; set; }
        public bool ExcludeFromResults { get; set; }


    }
}

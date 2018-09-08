using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Query;

namespace DMM365.DataContainers
{
    public class queryContainer
    {
        /// <summary>
        /// Relationsheep to upper level
        /// </summary>
        public relationShipType RelationShipType { get; set; }

        public string entityLogicalName { get; set; }

        public bool ExequteAsSeparateLinkedQueries { get; set; }

        public bool CollectAllReferences { get; set; }

        public bool isRoot { get; set; }
        /// <summary>
        /// LogicalName of entity this one is linked to
        /// </summary>
        public string masterEntityLogicalName { get; set; }

        public string masterEntityLookUpName { get; set; }

        public Guid masterEntityLookUpID { get; set; }


        public QueryExpression expression { get; set; }

        public List<queryContainer> linkedExpressions { get; set; }
    }
}

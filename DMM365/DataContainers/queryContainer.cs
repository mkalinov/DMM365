using System;
using System.Collections.Generic;
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

        public string primaryKeyName { get; set; }


        public Guid masterEntityLookUpID { get; set; }

        /// <summary>
        /// logical name, id
        /// </summary>
        public Dictionary<string, Guid> references { get; set; }


        public QueryExpression expression { get; set; }

        public List<queryContainer> linkedExpressions { get; set; }
    }
}

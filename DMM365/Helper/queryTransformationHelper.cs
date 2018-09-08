using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMM365.Helper;
using DMM365.DataContainers;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;

namespace DMM365.Helper
{
    internal static class queryTransformationHelper
    {

        internal static queryContainer transformFetch(CrmServiceClient service, SchemaEntities listOfEntities_DS, string fetch, bool exequteAsSeparateLinkedQueries = false, bool collectAllReferences = false)
        {
            QueryExpression mainQuery = CrmHelper.fetchToQuery(service, fetch);
            queryContainer root = new queryContainer
            {
                isRoot = true,
                expression = mainQuery,
                entityLogicalName = mainQuery.EntityName,
                ExequteAsSeparateLinkedQueries = exequteAsSeparateLinkedQueries,
                CollectAllReferences = collectAllReferences
            };
            //return whole query
            if (!exequteAsSeparateLinkedQueries)
            {
                return root;
            }

            return transformToSeparateQueries(service, listOfEntities_DS, root);
        }

        private static queryContainer transformToSeparateQueries(CrmServiceClient service, SchemaEntities listOfEntities_DS, queryContainer mainQuery)
        {

            QueryExpression exp = mainQuery.expression;
            DataCollection<LinkEntity> linkEntities = exp.LinkEntities;

            //created modified query
            QueryExpression _1stLevel = new QueryExpression(exp.EntityName);
            _1stLevel.ColumnSet = exp.ColumnSet;
            _1stLevel.Criteria = exp.Criteria;
            _1stLevel.NoLock = true;
            _1stLevel.ExtensionData = exp.ExtensionData;

            queryContainer _1stleveQuery = new queryContainer
            {
                expression = _1stLevel,
                entityLogicalName = exp.EntityName,
                linkedExpressions = new List<queryContainer>(),
                ExequteAsSeparateLinkedQueries = mainQuery.ExequteAsSeparateLinkedQueries,
                CollectAllReferences = mainQuery.CollectAllReferences,
                masterEntityLogicalName = mainQuery.masterEntityLogicalName,
                masterEntityLookUpName = mainQuery.masterEntityLookUpName,
                RelationShipType = mainQuery.RelationShipType
            };

            //check  link entities presence
            if (ReferenceEquals(linkEntities, null) || linkEntities.Count == 0) return _1stleveQuery;

            //transform link entities to queries
            List<queryContainer> linkedExpressions = transformLinkEntitiesToQueries(service, listOfEntities_DS, linkEntities, _1stleveQuery);
            if (!ReferenceEquals(linkedExpressions, null) && linkedExpressions.Count > 0) _1stleveQuery.linkedExpressions.AddRange(linkedExpressions);

            return _1stleveQuery;
        }

        private static List<queryContainer> transformLinkEntitiesToQueries(CrmServiceClient service, SchemaEntities listOfEntities_DS, DataCollection<LinkEntity> linkEntities, queryContainer upper)
        {
            List<queryContainer> result = new List<queryContainer>();

            foreach (LinkEntity le in linkEntities)
            {
                queryContainer current = new queryContainer
                {
                    isRoot = false,
                    masterEntityLogicalName = upper.entityLogicalName,
                    entityLogicalName = le.LinkToEntityName,
                    ExequteAsSeparateLinkedQueries = upper.ExequteAsSeparateLinkedQueries,
                    CollectAllReferences = upper.CollectAllReferences
            };

                SchemaField attr = GlobalHelper.getFieldFromSchema(listOfEntities_DS, le.LinkToEntityName, le.LinkToAttributeName);
                if (ReferenceEquals(attr, null)) throw new Exception("Entity '" + le.LinkToEntityName + "' and its attribute '" + le.LinkToEntityName + "' are absent in source schema file");
                string attrType = attr.primaryKey ? "pk" : attr.type;

                //n:1   entity : linkedEntity
                if (attrType == "pk")
                {
                    current.RelationShipType = relationShipType.Lookup;
                    //recurse to first level
                    current.expression = transformLinkToQueryExpression(le);
                    current.masterEntityLogicalName = le.LinkFromEntityName;
                    current.entityLogicalName = le.LinkToEntityName;
                    current.masterEntityLookUpName = le.LinkFromAttributeName;

                    result.Add(transformToSeparateQueries(service, listOfEntities_DS, current));

                }
                //1:n   entity : linkedEntity
                else
                {
                    current.RelationShipType = relationShipType.Child;
                    current.masterEntityLookUpName = attr.name;

                    QueryExpression linkEntityQuiery = new QueryExpression(le.LinkToEntityName);
                    ConditionExpression cond = new ConditionExpression(attr.name, ConditionOperator.Equal, current.masterEntityLookUpID);
                    FilterExpression filter = new FilterExpression(LogicalOperator.And);
                    filter.AddCondition(cond);
                    linkEntityQuiery.ColumnSet = le.Columns;
                    filter.AddFilter(le.LinkCriteria);
                    linkEntityQuiery.Criteria = filter;
                    linkEntityQuiery.NoLock = true;
                    linkEntityQuiery.ExtensionData = le.ExtensionData;

                    current.expression = linkEntityQuiery;
                    if (!ReferenceEquals(le.LinkEntities, null) && le.LinkEntities.Count > 0)
                    {
                        //recurse to itself
                        List<queryContainer> subQueries = transformLinkEntitiesToQueries(service, listOfEntities_DS, le.LinkEntities, current);
                        if (!ReferenceEquals(subQueries, null) && subQueries.Count > 0)
                            current.linkedExpressions = subQueries;
                    }
                    result.Add(current);
                }
            }

            return result;
        }

        private static QueryExpression transformLinkToQueryExpression(LinkEntity le)
        {
            QueryExpression result = new QueryExpression(le.LinkToEntityName);

            result.ColumnSet = le.Columns;
            result.Criteria = le.LinkCriteria;
            result.NoLock = true;
            result.ExtensionData = le.ExtensionData;
            if (!ReferenceEquals(le.LinkEntities, null) && le.LinkEntities.Count > 0)
                result.LinkEntities.AddRange(le.LinkEntities);

            return result;
        }


    }
}

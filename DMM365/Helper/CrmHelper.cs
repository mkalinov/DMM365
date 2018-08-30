using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using DMM365.DataContainers;
using Microsoft.Crm.Sdk.Messages;

namespace DMM365.Helper
{
    internal static class CrmHelper
    {

        internal static List<CrmEntityContainer> getUserQueryListWraped(CrmServiceClient service, int entityTypeCode, int queryType = 0, string customName = "name")
        {
            List<Entity> responce = getUserQueryList(service, entityTypeCode, queryType);         

            return convertEntityToEntityContainer(responce);
        }

        internal static List<CrmEntityContainer> convertEntityToEntityContainer(List<Entity> entities)
        {
            List<CrmEntityContainer> result = new List<CrmEntityContainer>();
            foreach (Entity item in entities)
                result.Add(new CrmEntityContainer(item));

            return result;
        }

        internal static List<Entity> convertEntityContainerToEntity( List<CrmEntityContainer> cont)
        {
            List<Entity> result = new List<Entity>();
            foreach (CrmEntityContainer item in cont)
                result.Add(item.crmEntity);

            return result;
        }




        /// <summary>
        /// Returns  public saved views of calling user (userqueries but savedqueries!) if queryType is default
        /// </summary>
        /// <param name="service"></param>
        /// <param name="entityTypeCode"></param>
        /// <param name="queryType"></param>
        /// <returns></returns>
        internal static List<Entity> getUserQueryList(CrmServiceClient service, int entityTypeCode, int queryType = 0)
        {

            QueryExpression uq = new QueryExpression("userquery");
            uq.ColumnSet = new ColumnSet(true);
            uq.Criteria.AddCondition(new ConditionExpression("returnedtypecode", ConditionOperator.Equal, entityTypeCode));
            uq.Criteria.AddCondition(new ConditionExpression("querytype", ConditionOperator.Equal, 0));

            EntityCollection coll = service.RetrieveMultiple(uq);
            return coll.Entities.ToList<Entity>();
        }

        internal static List<Entity> getUserQueryListByIds(CrmServiceClient service, List<Guid> ids)
        {

            QueryExpression uq = new QueryExpression("userquery");
            uq.ColumnSet = new ColumnSet(true);
            uq.Criteria.AddCondition(new ConditionExpression("userqueryid", ConditionOperator.In, ids.ToArray()));

            EntityCollection coll = service.RetrieveMultiple(uq);
            return coll.Entities.ToList<Entity>();
        }


        /// <summary>
        /// Returns results as xml string
        /// </summary>
        /// <param name="service"></param>
        /// <param name="_userquery"></param>
        /// <returns></returns>
        internal static string executeUserQuery(CrmServiceClient service, EntityReference _userquery)
        {
            ExecuteByIdUserQueryRequest executeUserQuery = new ExecuteByIdUserQueryRequest()
            {
                EntityId = _userquery
            };
            ExecuteByIdUserQueryResponse executeUserQueryResponse =
                       (ExecuteByIdUserQueryResponse)service.Execute(executeUserQuery);

            //<resultset> + <result>result1</result><result>result2</result> + ... + </resultset>
            return executeUserQueryResponse.String;
        }

        internal static List<Entity> executeFetchXml(CrmServiceClient service, string fetchxml)
        {
             return service.RetrieveMultiple(new FetchExpression(fetchxml)).Entities.ToList();
        }

        internal static List<Guid> getIdsFromViewsExecution(CrmServiceClient service, List<CrmEntityContainer> cont)
        {
            List<Guid> result = new List<Guid>() ;
            List<Entity> views = convertEntityContainerToEntity(cont);
            foreach (Entity v in views)
            {
                string fetch = v.GetAttributeValue<string>("fetchxml");
                if (!GlobalHelper.isValidString(fetch)) continue;

                List<Entity> current = executeFetchXml(service, fetch);
                if (!ReferenceEquals(current, null)) result = current.Select(s=>s.Id).ToList();

                //get all lookups IDs from fetched fields. Aliesed values excepted
                List<Guid> fromReferences = getAllReferencesIDs(service, current);
                if(!ReferenceEquals(fromReferences, null) && fromReferences.Count > 0) result.AddRange(fromReferences);

                //get all linked entities
                List<Guid> fromLinked = linkedEntitiesIDs(service, fetch);
                if (!ReferenceEquals(fromLinked, null) && fromLinked.Count > 0) result.AddRange(fromLinked);
            }

            return result.Distinct(new GuidEqualityComparer()).ToList();
        }

        internal static List<Guid> getAllReferencesIDs(CrmServiceClient service, List<Entity> current)
        {
            List<Guid> result = new List<Guid>();

            foreach (Entity en in current)
            {
                foreach (KeyValuePair<string, object> atr in en.Attributes)
                {
                    EntityReference er = atr.Value as EntityReference;
                    if (!ReferenceEquals(er, null)) result.Add(er.Id);
                }
            }

            return result;
        }


        internal static List<Guid> linkedEntitiesIDs(CrmServiceClient service, string fetchxml = "", DataCollection<LinkEntity> _lEntities= null)
        {
            List<Guid> result = new List<Guid>();

            QueryExpression exp = GlobalHelper.isValidString(fetchxml) ? fetchToQuery(service, fetchxml) : null;
            DataCollection<LinkEntity> linkEntities = !ReferenceEquals(exp, null) ? exp.LinkEntities : _lEntities;

            if ( ReferenceEquals(linkEntities, null) || linkEntities.Count == 0) return result;

            foreach (LinkEntity le in linkEntities)
            {
                QueryExpression linkEntityQuiery = new QueryExpression(le.LinkToEntityName);
                linkEntityQuiery.Criteria = le.LinkCriteria;

                List<Entity> nextLevel = service.RetrieveMultiple(linkEntityQuiery).Entities.ToList();
                if (!ReferenceEquals(nextLevel, null) && nextLevel.Count > 0)
                {
                    result.AddRange(nextLevel.Select(s => s.Id).ToList());
                    List<Guid> fromReferences = getAllReferencesIDs(service, nextLevel);
                    if (!ReferenceEquals(fromReferences, null) && fromReferences.Count > 0) result.AddRange(fromReferences);
                }

                //recursive call
                if (ReferenceEquals(le.LinkEntities, null) || le.LinkEntities.Count == 0) continue;
                List<Guid> lastLevel = linkedEntitiesIDs(service, "", le.LinkEntities);
                if (!ReferenceEquals(lastLevel, null) && lastLevel.Count > 0) result.AddRange(lastLevel);
            }

            return result;
        }

        internal static QueryExpression fetchToQuery(CrmServiceClient service, string fetchxml)
        {
            if (!GlobalHelper.isValidString(fetchxml)) return null;
            FetchXmlToQueryExpressionRequest request = new FetchXmlToQueryExpressionRequest { FetchXml = fetchxml};
            return ((FetchXmlToQueryExpressionResponse)service.Execute(request)).Query;
        }
    }

    //QueryType
    /*
     public = 0
     advanced fond = 1
     associated = 2
     quick find = 4
     lookup = 64 
        */
}

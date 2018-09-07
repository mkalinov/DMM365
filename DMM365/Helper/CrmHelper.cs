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

        internal static List<Guid> getIdsFromViewsExecution(CrmServiceClient service, List<CrmEntityContainer> cont, SchemaEntities listOfEntities_DS, bool executeAsSeparateQuieries = true, bool collectAllReferences = true)
        {
            List<Guid> result = new List<Guid>();
            List<Entity> views = convertEntityContainerToEntity(cont);

            foreach (Entity v in views)
            {
                string fetch = v.GetAttributeValue<string>("fetchxml");
                if (!GlobalHelper.isValidString(fetch)) continue;

                #region

                /*
                List<Entity> current = new List<Entity>();

                //execute eaxh part of query as independent fetch.
                //first execution is fetch without linked entities
                //then fetches from linked entities per each entity found by whole fetch - ID is added as condition to linked entity fetch
                //three levels, last two recursively
                if (executeAsSeparateQuieries)
                {

                    QueryExpression exp = fetchToQuery(service, fetch);
                    DataCollection<LinkEntity> linkEntities = exp.LinkEntities;

                    //created modified query
                    QueryExpression _1stLevel = new QueryExpression(exp.EntityName);
                    _1stLevel.ColumnSet = exp.ColumnSet;
                    _1stLevel.Criteria = exp.Criteria;
                    _1stLevel.NoLock = true;

                    current = service.RetrieveMultiple(_1stLevel).Entities.ToList();
                    if (ReferenceEquals(current, null)) continue;
                    //add first level guids
                    result.AddRange(current.Select(s => s.Id).ToList());

                    //get all lookups IDs from first level. Aliesed values excepted
                    if (collectAllReferences)
                    {
                        List<Guid> fromReferences = getAllReferencesIDs(service, current);
                        if (!ReferenceEquals(fromReferences, null) && fromReferences.Count > 0) result.AddRange(fromReferences);
                    }
                    //check  linked entities presence
                    if (ReferenceEquals(linkEntities, null) || linkEntities.Count == 0) continue;

                    //get all linked entities
                    foreach (Entity item in current)
                    {
                        List<Guid> fromLinked = linkedEntitiesIDs(service, item.Id, linkEntities, listOfEntities_DS);
                        if (!ReferenceEquals(fromLinked, null) && fromLinked.Count > 0) result.AddRange(fromLinked);
                    }
                   
                }
                //execute whole fetch
                else
                {
                    current = executeFetchXml(service, fetch);
                    if (!ReferenceEquals(current, null)) result.AddRange(current.Select(s => s.Id).ToList());

                    //get all lookups IDs from first level. Aliesed values excepted
                    if (collectAllReferences)
                    {
                        List<Guid> fromReferences = getAllReferencesIDs(service, current);
                        if (!ReferenceEquals(fromReferences, null) && fromReferences.Count > 0) result.AddRange(fromReferences);
                    }
                }
                */

                #endregion

                result.AddRange(mainEntityIDs(service, fetch, listOfEntities_DS, executeAsSeparateQuieries, collectAllReferences));
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


        internal static List<Guid> mainEntityIDs(CrmServiceClient service, string fetch, SchemaEntities listOfEntities_DS, bool executeAsSeparateQuieries = true, bool collectAllReferences = true)
        {

            List<Guid> result = new List<Guid>();
            List<Entity> current = new List<Entity>();


            //execute eaxh part of query as independent fetch.
            //first execution is fetch without linked entities
            //then fetches from linked entities per each entity found by whole fetch - ID is added as condition to linked entity fetch
            //three levels, last two recursively
            if (executeAsSeparateQuieries)
            {

                QueryExpression exp = fetchToQuery(service, fetch);
                DataCollection<LinkEntity> linkEntities = exp.LinkEntities;

                //created modified query
                QueryExpression _1stLevel = new QueryExpression(exp.EntityName);
                _1stLevel.ColumnSet = exp.ColumnSet;
                _1stLevel.Criteria = exp.Criteria;
                _1stLevel.NoLock = true;

                current = service.RetrieveMultiple(_1stLevel).Entities.ToList();
                if (!ReferenceEquals(current, null))
                    //add first level guids
                    result.AddRange(current.Select(s => s.Id).ToList());

                //get all lookups IDs from first level. Aliesed values excepted
                if (collectAllReferences)
                {
                    List<Guid> fromReferences = getAllReferencesIDs(service, current);
                    if (!ReferenceEquals(fromReferences, null) && fromReferences.Count > 0) result.AddRange(fromReferences);
                }
                //check  linked entities presence
                if (!ReferenceEquals(linkEntities, null) && linkEntities.Count != 0)
                {

                    //get all linked entities
                    foreach (Entity item in current)
                    {
                        List<Guid> fromLinked = linkedEntitiesIDs(service, item.Id, linkEntities, listOfEntities_DS);
                        if (!ReferenceEquals(fromLinked, null) && fromLinked.Count > 0) result.AddRange(fromLinked);
                    }
                }

            }
            //execute whole fetch
            else
            {
                current = executeFetchXml(service, fetch);
                if (!ReferenceEquals(current, null)) result.AddRange(current.Select(s => s.Id).ToList());

                //get all lookups IDs from first level. Aliesed values excepted
                if (collectAllReferences)
                {
                    List<Guid> fromReferences = getAllReferencesIDs(service, current);
                    if (!ReferenceEquals(fromReferences, null) && fromReferences.Count > 0) result.AddRange(fromReferences);
                }
            }

            return result;

        }

        internal static List<Guid> linkedEntitiesIDs(CrmServiceClient service, Guid parentGuid,  DataCollection<LinkEntity> linkEntities, SchemaEntities listOfEntities_DS, bool collectAllReferences = true)
        {

            List<Guid> result = new List<Guid>();

            if ( ReferenceEquals(linkEntities, null) || linkEntities.Count == 0) return result;

            foreach (LinkEntity le in linkEntities)
            {
                //if count is  0  there still may be entities for import in lower level
                //remove all comditions and try by parent guid only
                /*
                 *       <field displayname="Ad" name="adx_adid" type="guid" primaryKey="true" />

                       <field displayname="WebPage" name="adx_webpageid" type="entityreference" lookupType="adx_webpage" customfield="true" />
                        <field displayname="Website" name="adx_websiteid" type="entityreference" lookupType="adx_website" customfield="true" />

                */
                //check if linked  entity is 1:N or N:1 
                SchemaField attr = GlobalHelper.getFieldFromSchema(listOfEntities_DS, le.LinkToEntityName, le.LinkToEntityName);
                if (ReferenceEquals(attr, null)) throw new Exception("Entity '" + le.LinkToEntityName + "' and its attribute '" + le.LinkToEntityName + "' are absent in source schema file");
                string attrType = attr.primaryKey ? "pk" : attr.type;

                //n:1   entity : linkedEntity
                if (attrType == "pk")
                {

                    result.AddRange(mainEntityIDs(service, queryToFetch(service, createQueryFromLinkEntity(le, parentGuid, true  )), listOfEntities_DS, true, true));

                }
                //1:n   entity : linkedEntity
                else
                {

                    QueryExpression linkEntityQuiery = new QueryExpression(le.LinkToEntityName);
                    ConditionExpression cond = new ConditionExpression(le.LinkToAttributeName, ConditionOperator.Equal, parentGuid);
                    FilterExpression filter = new FilterExpression(LogicalOperator.And);
                    filter.AddCondition(cond);
                    linkEntityQuiery.ColumnSet = le.Columns;
                    //all children - must get cause changes might be under entities without chnges
                    List<Entity> nextLevelAllChildren = service.RetrieveMultiple(linkEntityQuiery).Entities.ToList();

                    ////test query
                    //string nextLevelAllChildrenFetch = queryToFetch(service, linkEntityQuiery);

                    //create criteria based on linked entity
                    filter.AddFilter(le.LinkCriteria);
                    linkEntityQuiery.Criteria = filter;

                    //enities that meet criterias
                    List<Entity> nextLevelMeetTheConditions = service.RetrieveMultiple(linkEntityQuiery).Entities.ToList();

                    //entities without changes, to exclude
                    List<Guid> entitiesToExcludeFromResult = nextLevelAllChildren.Except(nextLevelMeetTheConditions, new sdkEntityEqualityComparers()).Select(s => s.Id).ToList();

                    List<Entity> nextLevel = nextLevelAllChildren.Union(nextLevelMeetTheConditions, new sdkEntityEqualityComparers()).ToList();

                    if (!ReferenceEquals(nextLevel, null) && nextLevel.Count > 0)
                    {
                        result.AddRange(nextLevel.Select(s => s.Id).ToList());
                        //collect references from linked entity query result
                        if (collectAllReferences)
                        {
                            List<Guid> fromReferences = getAllReferencesIDs(service, nextLevel);
                            if (!ReferenceEquals(fromReferences, null) && fromReferences.Count > 0) result.AddRange(fromReferences);
                        }

                        if (ReferenceEquals(le.LinkEntities, null) || le.LinkEntities.Count == 0) continue;
                        //recursive call
                        //get all linked entities
                        foreach (Entity item in nextLevel)
                        {
                            //List<Guid> fromLinked = linkedEntitiesIDs(service, item.Id, linkEntities);
                            //if (!ReferenceEquals(fromLinked, null) && fromLinked.Count > 0) result.AddRange(fromLinked);
                        }
                    }

                    //exclude entities entities without changes from result
                    result.Except(entitiesToExcludeFromResult, new GuidEqualityComparer());
                }
            }

           

            return result;
        }

        internal static QueryExpression fetchToQuery(CrmServiceClient service, string fetchxml)
        {
            if (!GlobalHelper.isValidString(fetchxml)) return null;
            FetchXmlToQueryExpressionRequest request = new FetchXmlToQueryExpressionRequest { FetchXml = fetchxml};
            return ((FetchXmlToQueryExpressionResponse)service.Execute(request)).Query;
        }

        internal static string queryToFetch(CrmServiceClient service, QueryBase query)
        {

            QueryExpressionToFetchXmlRequest request = new QueryExpressionToFetchXmlRequest
            { Query = query };
            QueryExpressionToFetchXmlResponse responce = (QueryExpressionToFetchXmlResponse)service.Execute(request);
            return responce.FetchXml;
        }

        /// <summary>
        /// if master id is null and includeMasterId is false - returns only link entity query
        /// if master id is not null and includeMasterId is false - returns query with only masterid condition
        /// if master id is not null and includeMasterId is true - adds masterid condition to link entity query
        /// </summary>
        /// <param name="le"></param>
        /// <param name="masterId"></param>
        /// <param name="includeMasterId"></param>
        /// <returns></returns>
        private static QueryExpression createQueryFromLinkEntity(LinkEntity le, Object masterId = null, bool includeMasterId = false)
        {
            QueryExpression linkEntityQuiery = new QueryExpression(le.LinkToEntityName);
            linkEntityQuiery.ColumnSet = le.Columns;
            FilterExpression filter = new FilterExpression(LogicalOperator.And);



            if (!ReferenceEquals(masterId, null))
            {
                ConditionExpression cond = new ConditionExpression(le.LinkToAttributeName, ConditionOperator.Equal, masterId);
                filter.AddCondition(cond);
                if (!includeMasterId)
                {
                    linkEntityQuiery.Criteria = filter;
                    return linkEntityQuiery;
                }

            }


            //create criteria based on linked entity
            filter.AddFilter(le.LinkCriteria);

            ////test query
            //string nextLevelAllChildrenFetch = queryToFetch(service, linkEntityQuiery);


            linkEntityQuiery.Criteria = filter;

            return linkEntityQuiery;
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

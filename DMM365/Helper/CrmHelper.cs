﻿using System;
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
        #region Common

        internal static IEnumerable<KeyValuePair<object, string>> convertEntityContainerToKVP(List<CrmEntityContainer> list)
        {
            Dictionary<object, string> result = new Dictionary<object, string>();
            result.Add(Guid.Empty, "");

            foreach (CrmEntityContainer item in list)
                result.Add(item.id, item.name);

            return result;
        }

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

        internal static List<Entity> convertEntityContainerToEntity(List<CrmEntityContainer> cont)
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

        internal static List<Entity> getUserQueryListByIds(CrmServiceClient service, List<selectedQuery> ids)
        {
            if (ReferenceEquals(ids, null) || ids.Count == 0) return new List<Entity>();
            QueryExpression uq = new QueryExpression("userquery");
            uq.ColumnSet = new ColumnSet(true);
            uq.Criteria.AddCondition(new ConditionExpression("userqueryid", ConditionOperator.In, ids.Select(s => s.id).ToArray()));

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


        internal static QueryExpression fetchToQuery(CrmServiceClient service, string fetchxml)
        {
            if (!GlobalHelper.isValidString(fetchxml)) return null;
            FetchXmlToQueryExpressionRequest request = new FetchXmlToQueryExpressionRequest { FetchXml = fetchxml };
            return ((FetchXmlToQueryExpressionResponse)service.Execute(request)).Query;
        }

        internal static string queryToFetch(CrmServiceClient service, QueryBase query)
        {

            QueryExpressionToFetchXmlRequest request = new QueryExpressionToFetchXmlRequest
            { Query = query };
            QueryExpressionToFetchXmlResponse responce = (QueryExpressionToFetchXmlResponse)service.Execute(request);
            return responce.FetchXml;
        }

        internal static void deleteEntityByID(CrmServiceClient service, string entityName, List<Guid> ids)
        {
            foreach (Guid item in ids)
            {
                service.Delete(entityName, item);
            }
        }

        #endregion Common


        #region Execute Query


        internal static List<Guid> getIdsFromViewsExecution(CrmServiceClient service, Dictionary<Guid, queryContainer> viewsContainers)
        {
            List<Guid> result = new List<Guid>();
            List<Guid> resultExcluded = new List<Guid>();

            try
            {
                //iterate views
                foreach (Guid v in viewsContainers.Keys)
                {
                    queryContainer current = viewsContainers[v];
                    if (current.ExcludeFromResults)
                    {
                        resultExcluded.AddRange(topLevel(service, current));
                        continue;
                    }
                    result.AddRange(topLevel(service, current));
                }
            }
            catch (Exception ex)
            {
                //TO DO: logging
                throw new Exception(ex.Message);
            }

            var responce = result.Distinct(new GuidEqualityComparer()).ToList();
            //check and remove excluded guids
            responce.RemoveAll(g => resultExcluded.Contains(g, new GuidEqualityComparer()));

            return responce;
        }

        private static List<Guid> topLevel(CrmServiceClient service, queryContainer view)
        {
            List<Guid> result = new List<Guid>();
            List<Entity> currentEntitySet = new List<Entity>();
            //execute current level expression
            currentEntitySet = singleExpression(service, view.expression);
            //result ids
            result.AddRange(currentEntitySet.Select(s => s.Id).ToList());

            //looping entities
            foreach (Entity current in currentEntitySet)
            {
                //get all lookups IDs from first level. Aliesed values excepted
                view.references = getAllReferencesIDs(current);
                //Add to result if flag is set
                if (view.CollectAllReferences)
                {
                    if (!ReferenceEquals(view.references, null) && view.references.Count > 0)
                    {
                        foreach (string k in view.references.Keys)
                        {
                            result.Add(view.references[k]);
                        }
                    }
                }

                //execute linked expressions
                if (!ReferenceEquals(view.linkedExpressions, null) && view.linkedExpressions.Count > 0)
                {
                    foreach (queryContainer le in view.linkedExpressions)
                    {

                        //if link entity is a lookup (M:1) => recursive call
                        if (le.RelationShipType == relationShipType.Lookup)
                        {
                            //if refence not exist then this barnch is empty
                            if (!view.references.Keys.Contains(le.masterEntityLookUpName)) continue;
                            //add condition to keep link between parent and sub
                            ConditionExpression cond = new ConditionExpression(le.primaryKeyName, ConditionOperator.Equal, view.references[le.masterEntityLookUpName]);
                            le.expression.Criteria.AddCondition(cond);
                        }
                        if (le.RelationShipType == relationShipType.Child)
                        {
                            //add condition to keep link between parent and sub
                            ConditionExpression cond = new ConditionExpression(le.masterEntityLookUpName, ConditionOperator.Equal, current.Id);
                            le.expression.Criteria.AddCondition(cond);
                        }


                        //linked entity is a "child", 1:M
                        le.masterEntityLookUpID = current.Id;
                        //recursive call
                        result.AddRange(topLevel(service, le));
                    }

                }
            }

            return result;
        }

        private static List<Entity> singleExpression(CrmServiceClient service, QueryBase view)
        {
            EntityCollection result = new EntityCollection();

            result = service.RetrieveMultiple(view);
            if (ReferenceEquals(result, null)) return new List<Entity>();

            return result.Entities.ToList();
        }

        private static Dictionary<string, Guid> getAllReferencesIDs(Entity current)
        {
            Dictionary<string, Guid> result = new Dictionary<string, Guid>();

            foreach (KeyValuePair<string, object> atr in current.Attributes)
            {
                EntityReference er = atr.Value as EntityReference;
                if (!ReferenceEquals(er, null) && !result.Keys.Contains(er.LogicalName)) result.Add(er.LogicalName, er.Id);
            }

            return result;
        }


        #endregion Execute Query


        #region Annotation

        internal static Entity getLattestAttachmentByEntity(CrmServiceClient service, Guid masterId, string masterLogicalName, bool includeNotes)
        {
            QueryExpression query = new QueryExpression("annotation");
            FilterExpression filter = new FilterExpression(LogicalOperator.And);
            ConditionExpression cond1 = new ConditionExpression("objectid", ConditionOperator.Equal, masterId);
            ConditionExpression cond2 = new ConditionExpression("objecttypecode", ConditionOperator.Equal, masterLogicalName);
            ConditionExpression cond3 = new ConditionExpression("isdocument", ConditionOperator.Equal, "1");
            filter.AddCondition(cond1);
            filter.AddCondition(cond2);
            if (!includeNotes) filter.AddCondition(cond3);

            query.Criteria = filter;
            query.NoLock = true;
            query.ColumnSet = new ColumnSet(true);
            OrderExpression order = new OrderExpression("createdon", OrderType.Descending);
            query.Orders.Add(order);

            EntityCollection result = service.RetrieveMultiple(query);
            if (!ReferenceEquals(result, null) && result.Entities.Count > 0)
                return result.Entities.First();

            return null;
        }

        internal static Guid? cloneAnnotation(CrmServiceClient service, Entity noteSource)
        {
            Entity noteClone = new Entity("annotation");

            if (noteSource.Contains("documentbody"))
                noteClone["documentbody"] = noteSource["documentbody"];
            if (noteSource.Contains("filename"))
                noteClone["filename"] = noteSource["filename"];
            if (noteSource.Contains("isdocument"))
                noteClone["isdocument"] = noteSource["isdocument"];
            if (noteSource.Contains("langid"))
                noteClone["langid"] = noteSource["langid"];
            if (noteSource.Contains("mimetype"))
                noteClone["mimetype"] = noteSource["mimetype"];
            if (noteSource.Contains("notetext"))
                noteClone["notetext"] = noteSource["notetext"];
            if (noteSource.Contains("objectid"))
                noteClone["objectid"] = noteSource["objectid"];
            if (noteSource.Contains("objecttypecode"))
                noteClone["objecttypecode"] = noteSource["objecttypecode"];
            if (noteSource.Contains("stepid"))
                noteClone["stepid"] = noteSource["stepid"];
            if (noteSource.Contains("subject"))
                noteClone["subject"] = noteSource["subject"];

            //for data migration tools only, integer
            //noteClone["importsequencenumber"] = noteSource["importsequencenumber"];

            //for migration only, use for update
            //noteClone["overriddencreatedon"] = noteSource["overriddencreatedon"];

            //leave auto
            //noteClone["ownerid"] = noteSource["ownerid"];
            //noteClone["owneridtype"] = noteSource["owneridtype"];

            return service.Create(noteClone);
        }

        internal static Guid? cloneAnnotationForSpecificID(CrmServiceClient service, Entity noteSource, EntityReference ObjectID)
        {
            Entity noteClone = new Entity("annotation");

            noteClone["objectid"] =  ObjectID;


            if (noteSource.Contains("documentbody"))
                noteClone["documentbody"] = noteSource["documentbody"];
            if (noteSource.Contains("filename"))
                noteClone["filename"] = noteSource["filename"];
            if (noteSource.Contains("isdocument"))
                noteClone["isdocument"] = noteSource["isdocument"];
            if (noteSource.Contains("langid"))
                noteClone["langid"] = noteSource["langid"];
            if (noteSource.Contains("mimetype"))
                noteClone["mimetype"] = noteSource["mimetype"];
            if (noteSource.Contains("notetext"))
                noteClone["notetext"] = noteSource["notetext"];
            if (noteSource.Contains("objecttypecode"))
                noteClone["objecttypecode"] = noteSource["objecttypecode"];
            if (noteSource.Contains("stepid"))
                noteClone["stepid"] = noteSource["stepid"];
            if (noteSource.Contains("subject"))
                noteClone["subject"] = noteSource["subject"];

            return service.Create(noteClone);
        }


        internal static List<CrmEntityContainer> getListOfPortals(CrmServiceClient service)
        {
            QueryExpression query = new QueryExpression("adx_website");
            query.ColumnSet = new ColumnSet(true);

            EntityCollection en = service.RetrieveMultiple(query);

            if (ReferenceEquals(en, null) || ReferenceEquals(en.Entities, null) || en.Entities.Count == 0) return null;

            return convertEntityToEntityContainer(en.Entities.ToList());
        }

        internal static List<CrmEntityContainer> getWebFilesByPortalId(CrmServiceClient service, Guid portalId)
        {

            QueryExpression query = new QueryExpression("adx_webfile");
            FilterExpression filter = new FilterExpression(LogicalOperator.And);
            ConditionExpression cond1 = new ConditionExpression("adx_websiteid", ConditionOperator.Equal, portalId);
            query.ColumnSet = new ColumnSet(new string[] { "adx_name", "adx_partialurl"});
            query.Criteria = filter;
            query.NoLock = true;

            EntityCollection result = service.RetrieveMultiple(query);
            if (!ReferenceEquals(result, null) && result.Entities.Count > 0)
                return convertEntityToEntityContainer(result.Entities.ToList());

            return null;
        }


        #endregion Annotation

    }

    //QueryType
    /*
     public = 0
     advanced f1nd = 1
     associated = 2
     quick find = 4
     lookup = 64 
        */
}

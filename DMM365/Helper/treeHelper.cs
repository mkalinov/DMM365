using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DMM365.DataContainers;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace DMM365.Helper
{
    internal static class treeHelper
    {

        internal static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            TreeNode directoryNode = new TreeNode(directoryInfo.Name);
            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (FileInfo file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(new TreeNode(file.Name));
            return directoryNode;
        }


        internal static TreeNode createEntityNodes(List<DataEntity> entCollection)
        {
            TreeNode entities = new TreeNode();
            int counter = 0;
            foreach (DataEntity ent in entCollection)
            {
                entities.Nodes.Add(new TreeNode(ent.name + "     " + ent.RecordsCollection.Count.ToString()));
                counter += ent.RecordsCollection.Count;
            }
            entities.Text = "Entities  " + entCollection.Count.ToString() + ", records  " + counter.ToString();
            return entities;
        }



        internal static List<TreeNode> fromQuery(CrmServiceClient service, queryContainer container, string fetchXml)
        {
            List<TreeNode> result = new List<TreeNode>();

            result.Add(nodeBasedOnFetch(fetchXml));
            if (!ReferenceEquals(container.linkedExpressions, null) && container.linkedExpressions.Count > 0)
                foreach (queryContainer query in container.linkedExpressions)
                {
                    result.Add(nodeBasedOnFetch(CrmHelper.queryToFetch(service, query.expression)));
                }

            return result;
        }
        

        internal static TreeNode nodeBasedOnFetch(string fetchXml)
        {


                XmlDocument dom = new XmlDocument();

            //System.Windows.Data.x.Xml.Dom
            
                dom.LoadXml(fetchXml);

                TreeNode top = new TreeNode(dom.DocumentElement.Name);

                AddNode(dom.DocumentElement, top);
                return top;
            
        }

        private static void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList nodeList;
            int i;

            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = inTreeNode.Nodes[i];
                    foreach (XmlAttribute item in inXmlNode.Attributes)
                    {
                        tNode.Text += (" " + item.Name + "= " + item.Value + " ");

                    }
                    AddNode(xNode, tNode);
                }
            }
            else
            {
                // Here you need to pull the data from the XmlNode based on the
                // type of node, whether attribute values are required, and so forth.
                inTreeNode.Text = (inXmlNode.OuterXml).Trim();
            }
        }

    }
}

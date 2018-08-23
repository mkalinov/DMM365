using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DMM365.DataContainers;

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
    }
}

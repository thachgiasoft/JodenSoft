using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JNHT_ProdSys.Method
{
    public static class Common
    {
        public static void InitBomTree(woOrder wd, TreeView treeBom)
        {
            var woid = wd.Iden;
            //this.ViewModel.woBomParentEntity.Query("select *  from woBomParent with(nolock) where woid=:woid ", woid);
            int count = DataPortal.ExecuteDataset(ConfigContext.DefaultConnection, "select * from wobomparent with(nolock) where woid=:woid", woid).Tables[0].Rows.Count;

            treeBom.Nodes.Clear();
            if (count > 0)
            {
                createTvNode(wd, treeBom);
            }
        }
        private static void createTvNode(woOrder woorder, TreeView parantTv)
        {
            TreeNode rootNode = new TreeNode();
            rootNode.Text = woorder.CParentId + "      " + woorder.CParentName;
            rootNode.Tag = woorder.CParentId;
            parantTv.Nodes.Add(rootNode);
            createChildNode(rootNode, woorder.Iden);
        }

        private static void createChildNode(TreeNode rootNode, int woid)
        {
            DataTable dt = DataPortal.ExecuteDataset(ConfigContext.DefaultConnection, "select * from wobomparent with(nolock) where BomParentId<> bomchildid and BomParentId=:BomParentId and woid=:woid", rootNode.Tag, woid).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                TreeNode childNode = new TreeNode();
                childNode.Text = item["BomChildId"].ToString() + "      " + item["BomChildDesc"].ToString() + "      " + item["UseQty"].ToString();
                childNode.Tag = item["BomChildId"].ToString();
                rootNode.Nodes.Add(childNode);
                createChildNode(childNode, woid);
            }
        }
    }
}

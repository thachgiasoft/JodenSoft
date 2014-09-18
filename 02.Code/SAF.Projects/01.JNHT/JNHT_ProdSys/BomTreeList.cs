using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.EntityFramework;
using SAF.Framework.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace JNHT_ProdSys
{
    [ToolboxItem(true)]
    public partial class BomTreeList :BaseUserControl
    {

        public BomTreeList()
        {
            InitializeComponent();
            initTreeDataSource();
            

        }
        //接收初始化treelist数据源
        public static string Treebomid = "";
        public static string TreeChildId = "";

        public static EntitySet<bomParent> bomEntity;
        public static bomParent bomprt = null;
       // public static BindingSource bstree;
        //public override void Init()
        //{
        //    base.Init();

        //    //var bomEntity = new EntitySet<bomParent>();
        //    //bomEntity.Query("select Iden,BomParentId,BomChildId,BomChildDesc,num=dbo.Fn_GetTotalUseQty(bomid,BomChildId)  from bomparent");
        //    bsTl.DataSource = bomEntity.DefaultView;   //bstree.DataSource; /
        //    tlBom.ParentFieldName = "BomParentId";
        //    tlBom.KeyFieldName = "BomChildId";
        //    tlBom.Columns[0].Tag = "BomId";

           

        //}

        private void initTreeDataSource()
        {
            //string sql = "select * from bomparent";
            //DataTable dt = DataPortal.ExecuteDataset(ConfigContext.DefaultConnection,sql,null).Tables[0];
            //tlBom.DataSource = dt;
            //tlBom.ParentFieldName = "";

           
            
        }

        private void tlBom_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            //bomprt = sender as  bomParent;
           // Treebomid = tlBom.FocusedNode.ToString();
            //TreeListHitInfo hi = tlBom.CalcHitInfo(e.Node.Id);
            
        }

        
        public  void tlBom_MouseDown(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hi = tlBom.CalcHitInfo(e.Location);
            TreeListNode CurrentNode = hi.Node;
            if (CurrentNode != null)
            {
               // Treebomid = CurrentNode.Tag.ToString();//.GetValue("CategoryID").ToString();
                TreeChildId = CurrentNode.GetValue("BomChildId").ToString();
            }
           
        }




    }
}

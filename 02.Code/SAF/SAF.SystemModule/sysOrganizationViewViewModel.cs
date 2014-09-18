using SAF.Framework.ViewModel;
using SAF.SystemEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;
using SAF.EntityFramework;
using System.Data;

namespace SAF.SystemModule
{
    public class sysOrganizationViewViewModel : SingleViewViewModel<sysOrganization, sysOrganization>
    {
        #region ParentEntitySet

        private EntitySet<sysOrganization> _parentEntitySet = null;

        public virtual EntitySet<sysOrganization> ParentEntitySet
        {
            get
            {
                if (_parentEntitySet == null)
                {
                    _parentEntitySet = new EntitySet<sysOrganization>();
                    _parentEntitySet.PageSize = 0;
                    _parentEntitySet.IsReadOnly = true;
                }
                return _parentEntitySet;
            }
        }

        #endregion

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sysOrganization> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.IsDeleted = false;
            e.CurrentEntity.Code = string.Empty;

            if (e.OriginalEntity != null)
            {
                e.CurrentEntity.ParentId = e.OriginalEntity.Iden;
            }
            else
            {
                e.CurrentEntity.ParentId = -1;
            }
        }

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);

            string sql = @"
SELECT Iden,Name,[ParentId] 
FROM [dbo].[sysOrganization] WITH(NOLOCK)
WHERE [IsDeleted]=0 and {0}
ORDER BY [ParentId]".FormatEx(sCondition);

            this.IndexEntitySet.Query(sql, parameterValues);
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);

            const string sql = @"SELECT * FROM [dbo].[sysOrganization] with(nolock) where Iden=:Iden";

            this.MainEntitySet.Query(sql, key);

            string sqlParent = @"
;WITH tree AS 
(
    SELECT Iden
    FROM [dbo].sysOrganization with(nolock)
    WHERE [Iden]={0}
    UNION ALL
    SELECT b.Iden
    FROM [tree] a 
    JOIN [dbo].sysOrganization b with(nolock)  ON b.[ParentId]=a.[Iden]
)
SELECT Iden,Name,[ParentId]
FROM [dbo].sysOrganization with(nolock)
WHERE [Iden] NOT IN(SELECT [Iden] FROM [tree])
ORDER BY [ParentId], [Code]".FormatEx(key ?? int.MinValue);
            this.ParentEntitySet.Query(sqlParent);
        }

        protected override void OnApplySave()
        {
            base.OnApplySave();

            var es = this.MainEntitySet.GetChanges(DataRowState.Added | DataRowState.Modified);

            if (es.IsEmpty()) return;

            var idens = es.Select(p => p.Iden.ToString()).JoinText(",");

            string sqlUpdateCode = @"
DECLARE @temp TABLE
(
    Id INT IDENTITY(1,1),
    Iden INT
)
DECLARE @result TABLE
(
    Id INT IDENTITY(1,1),
    Iden INT
)

;WITH result AS
(
    SELECT Iden,ParentId ,[Level]=1
    FROM dbo.[sysOrganization] WITH(NOLOCK)
    WHERE Iden IN ({0})
    UNION ALL
    SELECT b.Iden,b.ParentId,iLevel=[Level]+1
    FROM result a
    JOIN dbo.[sysOrganization] b  WITH(NOLOCK) ON b.ParentId=a.Iden
)

INSERT @temp ( Iden)
SELECT Iden
FROM result
ORDER BY [Level],Iden

INSERT @result ([Iden])
SELECT DISTINCT [Iden]
FROM @temp

DECLARE @index INT ,@count INT
SELECT @index=1, @count=COUNT(*)
FROM @result

WHILE @index<=@count
BEGIN
    UPDATE dbo.[sysOrganization]
    SET Code=ISNULL((SELECT TOP 1 Code FROM dbo.[sysOrganization] b WITH(NOLOCK)  WHERE b.Iden=a.ParentId ),'')+ '{{'+CAST(a.Iden AS NVARCHAR)+'}}'
    FROM [sysOrganization] A
    JOIN @result b ON a.Iden=b.Iden

    SET @index=@index+1
END".FormatEx(idens);

            this.ExecuteCache.Execute(sqlUpdateCode);
        }
    }
}

﻿using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JNHT_ProdSys
{
    public class bomParent : Entity<bomParent>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "bomParent";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }
        public string BomId
        {
            get { return base.GetFieldValue<string>(P => P.BomId); }
            set { base.SetFieldValue(P => P.BomId, value); }
        }
        //TODO:添加其他字段
        public string BomParentId
        {
            get { return base.GetFieldValue<string>(P => P.BomParentId); }
            set { base.SetFieldValue(P => P.BomParentId, value); }
        }
        public string BomParentDesc
        {
            get { return base.GetFieldValue<string>(P => P.BomParentDesc); }
            set { base.SetFieldValue(P => P.BomParentDesc, value); }
        }
        public string BomParentStd
        {
            get { return base.GetFieldValue<string>(P => P.BomParentStd); }
            set { base.SetFieldValue(P => P.BomParentStd, value); }
        }
        public string BomParentStyle
        {
            get { return base.GetFieldValue<string>(P => P.BomParentStyle); }
            set { base.SetFieldValue(P => P.BomParentStyle, value); }
        }
        public string BomChildId
        {
            get { return base.GetFieldValue<string>(P => P.BomChildId); }
            set { base.SetFieldValue(P => P.BomChildId, value); }
        }
        public string BomChildDesc
        {
            get { return base.GetFieldValue<string>(P => P.BomChildDesc); }
            set { base.SetFieldValue(P => P.BomChildDesc, value); }
        }
        public string BomChildStd
        {
            get { return base.GetFieldValue<string>(P => P.BomChildStd); }
            set { base.SetFieldValue(P => P.BomChildStd, value); }
        }
        public string BomChildStyle
        {
            get { return base.GetFieldValue<string>(P => P.BomChildStyle); }
            set { base.SetFieldValue(P => P.BomChildStyle, value); }
        }
           
        public decimal UseQty
        {
            get { return base.GetFieldValue<decimal>(P => P.UseQty); }
            set { base.SetFieldValue(P => P.UseQty, value); }
        }
        public string Define1
        {
            get { return base.GetFieldValue<string>(P => P.Define1); }
            set { base.SetFieldValue(P => P.Define1, value); }
        }
       
        public string Define2
        {
            get { return base.GetFieldValue<string>(P => P.Define2); }
            set { base.SetFieldValue(P => P.Define2, value); }
        }
        public string Define3
        {
            get { return base.GetFieldValue<string>(P => P.Define3); }
            set { base.SetFieldValue(P => P.Define3, value); }
        }
        public decimal Define4
        {
            get { return base.GetFieldValue<decimal>(P => P.Define4); }
            set { base.SetFieldValue(P => P.Define4, value); }
        }
        public decimal Define5
        {
            get { return base.GetFieldValue<decimal>(P => P.Define5); }
            set { base.SetFieldValue(P => P.Define5, value); }
        }
        public string Define6
        {
            get { return base.GetFieldValue<string>(P => P.Define6); }
            set { base.SetFieldValue(P => P.Define6, value); }
        }

        public int? CreatedBy
        {
            get { return base.GetFieldValue<int?>(p => p.CreatedBy, null); }
            set { base.SetFieldValue(p => p.CreatedBy, value); }
        }
        public DateTime? CreatedOn
        {
            get { return base.GetFieldValue<DateTime?>(p => p.CreatedOn, null); }
            set { base.SetFieldValue(p => p.CreatedOn, value); }
        }

        public int? ModifiedBy
        {
            get { return base.GetFieldValue<int?>(p => p.ModifiedBy, null); }
            set { base.SetFieldValue(p => p.ModifiedBy, value); }
        }
        public DateTime? ModifiedOn
        {
            get { return base.GetFieldValue<DateTime?>(p => p.ModifiedOn, null); }
            set { base.SetFieldValue(p => p.ModifiedOn, value); }
        }
        public int VersionNumber
        {
            get { return base.GetFieldValue<int>(p => p.VersionNumber, 0); }
        }
    }
}

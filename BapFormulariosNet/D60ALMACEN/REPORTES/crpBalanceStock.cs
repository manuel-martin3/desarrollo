namespace BapFormulariosNet.D60ALMACEN.REPORTES
{
    using System;
    using System.ComponentModel;
    using CrystalDecisions.Shared;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.CrystalReports.Engine;

    public class crpBalanceStock : ReportClass
    {
        public crpBalanceStock()
        {
        }
        public override string ResourceName
        {
            get
            {
                return "crpBalanceStock.rpt";
            }
            set
            {
            }
        }
        public override bool NewGenerator
        {
            get
            {
                return true;
            }
            set
            {
            }
        }
        public override string FullResourceName
        {
            get
            {
                return "BapFormulariosNet.D60ALMACEN.REPORTES.crpBalanceStock.rpt";
            }
            set
            {
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section1
        {
            get
            {
                return ReportDefinition.Sections[0];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section2
        {
            get
            {
                return ReportDefinition.Sections[1];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section GroupHeaderSection1
        {
            get
            {
                return ReportDefinition.Sections[2];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section3
        {
            get
            {
                return ReportDefinition.Sections[3];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section GroupFooterSection1
        {
            get
            {
                return ReportDefinition.Sections[4];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section4
        {
            get
            {
                return ReportDefinition.Sections[5];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section5
        {
            get
            {
                return ReportDefinition.Sections[6];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_mescadena
        {
            get
            {
                return DataDefinition.ParameterFields[0];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_productidini
        {
            get
            {
                return DataDefinition.ParameterFields[1];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_productidfin
        {
            get
            {
                return DataDefinition.ParameterFields[2];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_fechini
        {
            get
            {
                return DataDefinition.ParameterFields[3];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_fechfin
        {
            get
            {
                return DataDefinition.ParameterFields[4];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_ctacte
        {
            get
            {
                return DataDefinition.ParameterFields[5];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_cencosid
        {
            get
            {
                return DataDefinition.ParameterFields[6];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_tipmov
        {
            get
            {
                return DataDefinition.ParameterFields[7];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_tipdoc
        {
            get
            {
                return DataDefinition.ParameterFields[8];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_serdoc
        {
            get
            {
                return DataDefinition.ParameterFields[9];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_numdoc
        {
            get
            {
                return DataDefinition.ParameterFields[10];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_mottrasladoid
        {
            get
            {
                return DataDefinition.ParameterFields[11];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_mottrasladoidint
        {
            get
            {
                return DataDefinition.ParameterFields[12];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_stockmayorcero
        {
            get
            {
                return DataDefinition.ParameterFields[13];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_anio
        {
            get
            {
                return DataDefinition.ParameterFields[14];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_moduloid
        {
            get
            {
                return DataDefinition.ParameterFields[15];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_ruc
        {
            get
            {
                return DataDefinition.ParameterFields[16];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_empresa
        {
            get
            {
                return DataDefinition.ParameterFields[17];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_almacen
        {
            get
            {
                return DataDefinition.ParameterFields[18];
            }
        }
    }
    [System.Drawing.ToolboxBitmapAttribute(typeof(CrystalDecisions.Shared.ExportOptions), "report.bmp")]
    public class CachedcrpBalanceStock : Component, ICachedReport
    {
        public CachedcrpBalanceStock()
        {
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual bool IsCacheable
        {
            get
            {
                return true;
            }
            set
            {
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual bool ShareDBLogonInfo
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual System.TimeSpan CacheTimeOut
        {
            get
            {
                return CachedReportConstants.DEFAULT_TIMEOUT;
            }
            set
            {
            }
        }
        public virtual CrystalDecisions.CrystalReports.Engine.ReportDocument CreateReport()
        {
            var rpt = new crpBalanceStock();
            rpt.Site = Site;
            return rpt;
        }
        public virtual string GetCustomizedCacheKey(RequestContext request)
        {
            var key = (String )null;
            return key;
        }
    }
}

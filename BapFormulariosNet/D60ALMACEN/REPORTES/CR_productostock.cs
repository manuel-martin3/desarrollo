namespace BapFormulariosNet.APT600100.REPORTES
{
    using System;
    using System.ComponentModel;
    using CrystalDecisions.Shared;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.CrystalReports.Engine;

    public class CR_productostock : ReportClass
    {
        public CR_productostock()
        {
        }
        public override string ResourceName
        {
            get
            {
                return "CR_productostock.rpt";
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
                return "BapFormulariosNet.D60ALMACEN.REPORTES.CR_productostock.rpt";
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
        public CrystalDecisions.Shared.IParameterField Parameter_moduloid
        {
            get
            {
                return DataDefinition.ParameterFields[0];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_local
        {
            get
            {
                return DataDefinition.ParameterFields[1];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_lineaid
        {
            get
            {
                return DataDefinition.ParameterFields[2];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_grupoid
        {
            get
            {
                return DataDefinition.ParameterFields[3];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_subgrupoid
        {
            get
            {
                return DataDefinition.ParameterFields[4];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_productid
        {
            get
            {
                return DataDefinition.ParameterFields[5];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_colorid
        {
            get
            {
                return DataDefinition.ParameterFields[6];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_status
        {
            get
            {
                return DataDefinition.ParameterFields[7];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_productname
        {
            get
            {
                return DataDefinition.ParameterFields[8];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_productidold
        {
            get
            {
                return DataDefinition.ParameterFields[9];
            }
        }
    }
    [System.Drawing.ToolboxBitmapAttribute(typeof(CrystalDecisions.Shared.ExportOptions), "report.bmp")]
    public class CachedCR_productostock : Component, ICachedReport
    {
        public CachedCR_productostock()
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
            var rpt = new CR_productostock();
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

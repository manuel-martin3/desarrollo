namespace BapFormulariosNet.D60ALMACEN.REPORTES
{
    using System;
    using System.ComponentModel;
    using CrystalDecisions.Shared;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.CrystalReports.Engine;

    public class CR_inventariado_rollos : ReportClass
    {
        public CR_inventariado_rollos()
        {
        }
        public override string ResourceName
        {
            get
            {
                return "CR_inventariado_rollos.rpt";
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
                return "BapFormulariosNet.D60ALMACEN.REPORTES.CR_inventariado_rollos.rpt";
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
        public CrystalDecisions.CrystalReports.Engine.Section Section3
        {
            get
            {
                return ReportDefinition.Sections[2];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section4
        {
            get
            {
                return ReportDefinition.Sections[3];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section5
        {
            get
            {
                return ReportDefinition.Sections[4];
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
        public CrystalDecisions.Shared.IParameterField Parameter_tipodoc
        {
            get
            {
                return DataDefinition.ParameterFields[2];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_serdoc
        {
            get
            {
                return DataDefinition.ParameterFields[3];
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_numdoc
        {
            get
            {
                return DataDefinition.ParameterFields[4];
            }
        }
    }
    [System.Drawing.ToolboxBitmapAttribute(typeof(CrystalDecisions.Shared.ExportOptions), "report.bmp")]
    public class CachedCR_inventariado_rollos : Component, ICachedReport
    {
        public CachedCR_inventariado_rollos()
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
            var rpt = new CR_inventariado_rollos();
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

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet
{
    public partial class Frm_Reportes : Form
    {
        #region "Fields"
	    private ReportDocument _reporte;
	    private bool _fillTable = true;
	    private System.Data.DataTable _table;
	    private System.Data.DataSet _dataSet;
	    private Dictionary<string, object> _parametros;
		#endregion
	    public bool _VerExportar = true;

	    #region "Constructors"

	    public Frm_Reportes()
	    {
            Load += Frm_Reportes_Load;
		    InitializeComponent();
	    }

	    #endregion

	    #region "Properties"

	    public bool FillTable 
        {
		    get { return this._fillTable; }
		    set { this._fillTable = value; }
	    }

        public Dictionary<string, object> Parametros
        {
            get { return _parametros; }
            set { _parametros = value; }
        }

        //public string Titulo
        //{
        //    get { return this.lblTitulo.Text; }
        //    set { this.lblTitulo.Text = value; }
        //}

        public ReportDocument Reporte
        {
            get { return this._reporte; }
            set { this._reporte = value; }
        }

        public DataTable Table
        {
            get { return this._table; }
            set { this._table = value; }
        }

        public DataSet DataSet
        {
            get { return this._dataSet; }
            set { this._dataSet = value; }
        }

        #endregion

        #region "Methods"

        private void setReporte(DataTable table)
        {
            try
            {
                this._reporte.SetDataSource(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void setReporte(DataSet dataS)
        {
            try
            {
                this._reporte.SetDataSource(dataS);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Método que va a manejar el evento RefreshReport del reporte
        /// </summary>
        private void RefrescaReporte(object sender, EventArgs e)
        {
            AsignarParametros();
        }
        /// <summary>
        /// Metodo que asigna los parámetros al reporte
        /// </summary>
        private void AsignarParametros()
        {
            if (_parametros != null)
            {
                try
                {
                    foreach (string str in _parametros.Keys)
                    {
                        _reporte.SetParameterValue(str, _parametros[str]);
                    }
                }
                catch
                {
                    throw new Exception("Error cargando los parámetros");
                }
            }
        }
        #endregion

        #region "Events"

        private void Frm_Reportes_Load(object sender, EventArgs e)
        {
            this.crvReporte.ShowExportButton = true;
            this.crvReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            //this.Text = this.Text + "-" + this.Titulo;

            if (this._reporte == null)
                return;
            _reporte.RefreshReport += RefrescaReporte;
            
            if (this._table == null & this._fillTable)
                return;
            
            if (this._dataSet == null & !this._fillTable)
                return;

            if (this._fillTable)
                this.setReporte(this._table);
            
            if (!this._fillTable)
                this.setReporte(this._dataSet);

            this._reporte.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
            this._reporte.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";

            //this._reporte.DataDefinition.FormulaFields["empresa"].Text = "'" + VariablesPublicas.EmpresaName + "'";
            //this._reporte.DataDefinition.FormulaFields["ruc"].Text = "'" + "RUC Nº " + VariablesPublicas.EmpresaRuc + "'";
            //this._reporte.DataDefinition.FormulaFields["titulo"].Text = "'" + Titulo.ToUpper() + "'";

            this.crvReporte.ReportSource = this._reporte;
        }

        #endregion
    }
}

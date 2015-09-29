using System.Windows.Forms;
using LayerBusinessLogic;
using LayerBusinessEntities;
using LayerDataAccess;
using bapFunciones;

using System;
using System.Data;
using System.Data.SqlClient;

namespace BapFormulariosNet.D60Tienda
{
    public partial class Frm_AperturaCaja : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = string.Empty;
        private String modulo = string.Empty;
        private String local = string.Empty;
        private Decimal tipoCAmbio = 0;

        private DataTable TablaLiquidacion;
        private DataTable TablaLiquidacion_modal;
        private DataRow row;

        public Frm_AperturaCaja()
        {
            InitializeComponent();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            bloquear(true);
            btn_nuevo.Enabled = false;
            btn_modificar.Enabled = false;
            _CargarDetalle();
        }

        private void Frm_AperturaCaja_Load(object sender, EventArgs e)
        {
            dominio = ((D60Tienda.MainTienda)MdiParent).dominioid;
            modulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
            local = ((D60Tienda.MainTienda)MdiParent).local;

            NameLocal();
            _ArmandoTabla();
            bloquear(false);
            limpiar();
        }
        private void NameLocal()
        {
            var dt = new DataTable();
            var Query = " Select * From tb_sys_local where dominioid = '" + dominio + "' " +
                           " and moduloid = '" + modulo + "' and local = '" + local + "' ";
            dt = QueryLocal(Query).Tables[0];

            if (dt.Rows.Count > 0)
            {
                loc_id.Text = dt.Rows[0]["local"].ToString();
                loc_name.Text = dt.Rows[0]["localname"].ToString();
            }
        }
        private DataSet QueryLocal(String Query)
        {
            var conex = new ConexionDA();
            using (var cnx = new SqlConnection(conex.empConexion(EmpresaID)))
            {
                using (var cmd = new SqlCommand("gspHelpSQL", cnx))
                {
                    var ds = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@sqlquery", SqlDbType.VarChar).Value = Query;
                    try
                    {
                        cnx.Open();
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        private void limpiar()
        {
            monedae.Equals(string.Empty);
            monedan.Equals(string.Empty);
            fecha.EditValue = DateTime.Today;

            get_cajas();
        }

        private void get_cajas()
        {
            try
            {
                var BE = new tb_t1_caja();
                var BL = new tb_t1_cajaBL();

                BE.moduloid = modulo.ToString();
                BE.local = local.ToString();

                gridControl1.DataSource = BL.GetAllCab(VariablesPublicas.EmpresaID, BE).Tables[0];
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bloquear(Boolean var)
        {
            loc_id.Enabled = false;
            loc_name.Enabled = false;
            fecha.Enabled = var;
            monedan.Enabled = var;
            monedae.Enabled = var;
            chkcerrado.Enabled = var;
            btn_aperturar.Enabled = var;
            btn_modificar.Enabled = var;
        }

        private void get_tipocambio(string fecha)
        {
            try
            {
                var BL = new tipocambioBL();
                var dt = new DataTable();

                dt = BL.GetOne(EmpresaID, Convert.ToDateTime(fecha)).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    tipoCAmbio = Convert.ToDecimal(dt.Rows[0]["venta"]);
                }
                else
                {
                    tipoCAmbio = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txttcambio.Text = tipoCAmbio.ToString("###.#0");
        }

        private void fecha_DateTimeChanged(object sender, EventArgs e)
        {
            get_tipocambio(fecha.Text);
            try
            {
                var BE = new tb_t1_caja();
                var BL = new tb_t1_cajaBL();

                BE.moduloid = modulo.ToString();
                BE.local = local.ToString();
                BE.fecha = Convert.ToDateTime(fecha.Text);
                BE.filtro = "1";

                if (TablaLiquidacion != null)
                {
                    TablaLiquidacion.Clear();
                }

                TablaLiquidacion = _CargarDetalle();

                //if (TablaLiquidacion.Rows.Count > 0)
                //{
                //    gridControl1.DataSource = TablaLiquidacion;
                //}
                //else
                //{
                //    gridControl1.DataSource = _CargarDetalle();
                //}


                bloquear(true);
                //MDI_dgb_liquidacion.Enabled = false;
                //btnSave.Enabled = false;
                _CargarVentas(Convert.ToDateTime(fecha.Text));
                //ConsultaDatos();
                //_CalcularTotales("importe1");
                //_CalcularTotales("importe2");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void _CargarVentas(DateTime fecha)
        {
            DataTable Dt_glosa, Dt_name;
            string tipo_doc;
            string glosa;
            decimal importe;
            //decimal importetot;
            int fila;

            //importetot = 0;

            var Query = " SELECT tipodoc,('DE : '+MIN(numdoc)+ ' - ' +MAX(numdoc))name,sum(totimporte)total,tmm.fechdoc " +
                           " FROM tb_me_movimientoscab AS tmm	" +
                           " WHERE " +
                           " tmm.moduloid= '" + modulo + "' " +
                           " AND tmm.local= '" + local + "' " +
                           " AND tmm.tipodoc NOT IN('GI','GS','II') " +
                                       " AND tmm.fechdoc = '" + fecha.ToString("yyyyMMdd") + "' " +
                           " GROUP BY tipodoc,tmm.fechdoc ";


            var Query2 = " SELECT conceptoid, " +
                            "  conceptosigla, " +
                            " fila  " +
                            " FROM tb_t1_cajaconcepto AS ttc " +
                            " WHERE	LEFT(conceptoid,2) = '02' AND LEN(conceptoid) > 2 ";

            Dt_glosa = new DataTable();
            Dt_glosa = Consultas(Query).Tables[0];

            if (Dt_glosa.Rows.Count > 0)
            {
                for (var j = 0; j < Dt_glosa.Rows.Count; j++)
                {
                    Dt_name = new DataTable();
                    Dt_name = Consultas(Query2).Tables[0];

                    tipo_doc = Dt_glosa.Rows[j][0].ToString();

                    for (var i = 0; i < Dt_name.Rows.Count; i++)
                    {
                        if (tipo_doc.Trim() == Dt_name.Rows[i][1].ToString())
                        {
                            glosa = Dt_glosa.Rows[j][1].ToString();
                            importe = Convert.ToDecimal(Dt_glosa.Rows[j][2].ToString());
                            //importetot = importetot + importe;
                            fila = Convert.ToInt32(Dt_name.Rows[i][2].ToString());

                            TablaLiquidacion.Rows[fila]["glosa"] = glosa;
                            TablaLiquidacion.Rows[fila]["importe1"] = importe;

                            TablaLiquidacion.Rows[2]["importe1"] = Convert.ToDecimal(TablaLiquidacion.Rows[2]["importe1"].ToString()) + importe;
                        }
                    }
                }
            }

        }

        private DataSet Consultas(String Query)
        {
            var conex = new ConexionDA();
            using (var cnx = new SqlConnection(conex.empConexion(EmpresaID)))
            {
                using (var cmd = new SqlCommand("gspHelpSQL", cnx))
                {
                    var ds = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@sqlquery", SqlDbType.VarChar).Value = Query;
                    try
                    {
                        cnx.Open();
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        private DataTable _CargarDetalle()
        {
            var BL = new tb_t1_cajaconceptoBL();
            var BE = new tb_t1_cajaconcepto();
            BE.filtro = "1";
            TablaLiquidacion = BL.GetAll(EmpresaID, BE).Tables[0];
            return TablaLiquidacion;
        }

        private void _ArmandoTabla()
        {
            TablaLiquidacion_modal = new DataTable("TablaLiquidacion_modal");
            TablaLiquidacion_modal.Columns.Add("moduloid", typeof(String));
            TablaLiquidacion_modal.Columns.Add("local", typeof(String));
            TablaLiquidacion_modal.Columns.Add("fecha", typeof(DateTime));
            TablaLiquidacion_modal.Columns.Add("conceptoid", typeof(String));
            TablaLiquidacion_modal.Columns.Add("glosa", typeof(String));
            TablaLiquidacion_modal.Columns.Add("cajaaccionid", typeof(String));
            TablaLiquidacion_modal.Columns.Add("importe1", typeof(Decimal));
            TablaLiquidacion_modal.Columns["importe1"].DefaultValue = 0;
            TablaLiquidacion_modal.Columns.Add("importe2", typeof(Decimal));
            TablaLiquidacion_modal.Columns["importe2"].DefaultValue = 0;
            TablaLiquidacion_modal.Columns.Add("usuar", typeof(String));
            TablaLiquidacion_modal.Columns.Add("fecre", typeof(DateTime));
            TablaLiquidacion_modal.Columns.Add("feact", typeof(DateTime));

            //Tablabloqueo = new DataTable("TableLoadRowLock");
            //Tablabloqueo.Columns.Add("fila", typeof(String));
        }

        private void btn_aperturar_Click(object sender, EventArgs e)
        {
            try
            {
                var BE = new tb_t1_caja();
                var BL = new tb_t1_cajaBL();

                BE.moduloid = modulo.ToString();
                BE.local = local.ToString();
                BE.fecha = Convert.ToDateTime(fecha.Text);
                BE.tcambio = Convert.ToDecimal(txttcambio.Text);
                //BE.adminid = idadmin.Text.ToString();
                //BE.cajeroid = idcajero.Text.ToString();
                BE.apertura1 = monedan.Text.Trim() == "" ? 0 : Convert.ToDecimal(monedan.Text);
                BE.apertura2 = monedae.Text.Trim() == "" ? 0 : Convert.ToDecimal(monedae.Text);
                BE.cierre1 = 0;
                BE.cierre2 = 0;
                //BE.cerrado = chkcerrado.Checked;
                BE.usuar = VariablesPublicas.Usuar.Trim();

                if (TablaLiquidacion_modal != null)
                {
                    TablaLiquidacion_modal.Clear();
                }

                for (var i = 0; i < TablaLiquidacion.Rows.Count; i++)
                {
                    row = TablaLiquidacion_modal.NewRow();
                    row["moduloid"] = modulo.ToString();
                    row["local"] = local.ToString();
                    row["fecha"] = Convert.ToDateTime(fecha.Text);
                    row["conceptoid"] = TablaLiquidacion.Rows[i]["conceptoid"].ToString().Trim();
                    row["glosa"] = TablaLiquidacion.Rows[i]["glosa"].ToString().Trim();
                    row["cajaaccionid"] = TablaLiquidacion.Rows[i]["cajaaccionid"].ToString().Trim();
                    row["importe1"] = TablaLiquidacion.Rows[i]["importe1"].ToString().Trim();
                    row["importe2"] = TablaLiquidacion.Rows[i]["importe2"].ToString().Trim();
                    row["fecre"] = DateTime.Today;
                    row["feact"] = DateTime.Today;
                    row["usuar"] = VariablesPublicas.Usuar.Trim();

                    TablaLiquidacion_modal.Rows.Add(row);
                }

                TablaLiquidacion_modal.Rows[0]["importe1"] = monedan.Text.Trim() == "" ? 0 : Convert.ToDecimal(monedan.Text);
                TablaLiquidacion_modal.Rows[0]["importe2"] = monedae.Text.Trim() == "" ? 0 : Convert.ToDecimal(monedae.Text);

                TablaLiquidacion_modal.Rows[1]["importe1"] = monedan.Text.Trim() == "" ? 0 : Convert.ToDecimal(monedan.Text);
                TablaLiquidacion_modal.Rows[1]["importe2"] = monedae.Text.Trim() == "" ? 0 : Convert.ToDecimal(monedae.Text);

                if (BL.Insert(EmpresaID, BE, TablaLiquidacion_modal))
                {
                    MessageBox.Show("Datos Grabados Correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bloquear(false);
                    btn_nuevo.Enabled = true;
                    //btn_grabar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fecha_TextChanged(object sender, EventArgs e)
        {
            get_tipocambio(fecha.Text);
        }
        
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            fecha.EditValue = Convert.ToDateTime( gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "fecha").ToString());
            monedan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "apertura1").ToString();
            monedae.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "apertura2").ToString();
            chkcerrado.Checked = Convert.ToBoolean( gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cerrado").ToString());
            get_tipocambio(fecha.Text);
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                var BE = new tb_t1_caja();
                var BL = new tb_t1_cajaBL();

                BE.moduloid = modulo.ToString();
                BE.local = local.ToString();
                BE.fecha = Convert.ToDateTime(fecha.Text);
                BE.apertura1 = Convert.ToDecimal(monedan.Text);

                BE.cerrado = chkcerrado.Checked;
                BE.usuar = VariablesPublicas.Usuar.Trim();

                if (BL.UpdateApertura(EmpresaID, BE))
                {
                    MessageBox.Show("Datos Grabados Correctamente, ojo tiene que editar y grabar nuevamente la liquidación de caja de esta fecha !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bloquear(false);
                    btn_nuevo.Enabled = true;
                    //btn_grabar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

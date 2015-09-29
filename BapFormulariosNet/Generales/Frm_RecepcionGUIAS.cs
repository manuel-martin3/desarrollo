using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;
using LayerBusinessEntities;
using LayerBusinessLogic;

namespace BapFormulariosNet.Generales
{
    public partial class Frm_RecepcionGUIAS : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = VariablesPublicas.Dominioid;
        private String modulo = VariablesPublicas.Moduloid;
        private String local = VariablesPublicas.Local;
        private TextBox txtCDetalle = null;
        private DataTable Tabladetalleguias = new DataTable("detalleguias");


        public Frm_RecepcionGUIAS()
        {
            InitializeComponent();
        }


        private void Frm_RecepcionGUIAS_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID.Trim();
            Tabladetalleguias = new DataTable("detalleguias");

            Tabladetalleguias.Columns.Add("fechdoc", typeof(String));
            Tabladetalleguias.Columns.Add("local_destino", typeof(String));
            Tabladetalleguias.Columns.Add("local_emitido", typeof(String));
            Tabladetalleguias.Columns.Add("local_name", typeof(String));
            Tabladetalleguias.Columns.Add("doc", typeof(String));
            Tabladetalleguias.Columns.Add("totpzas", typeof(String));

            Tabladetalleguias.Columns.Add("tipodoc", typeof(String));
            Tabladetalleguias.Columns.Add("serdoc", typeof(String));
            Tabladetalleguias.Columns.Add("numdoc", typeof(String));
            Tabladetalleguias.Columns.Add("ctacte", typeof(String));
            Tabladetalleguias.Columns.Add("ctactename", typeof(String));
            Tabladetalleguias.Columns.Add("direcnume", typeof(String));
            Tabladetalleguias.Columns.Add("direcname", typeof(String));
            Tabladetalleguias.Columns.Add("direcdeta", typeof(String));
            Tabladetalleguias.Columns.Add("nmruc", typeof(String));
            Tabladetalleguias.Columns.Add("vista", typeof(String));
            CargarDocde_Traslado();
            form_bloqueado(true);
        }


        private void CargarDocde_Traslado()
        {
            var BL = new tb_60movimientoscabBL();
            var BE = new tb_60movimientoscab();

            BE.moduloid = modulo.ToString();
            BE.local = local.ToString();
            BE.tipodoc = "GS";

            Tabladetalleguias = BL.GetAll3(EmpresaID, BE).Tables[0];

            if (Tabladetalleguias.Rows.Count > 0)
            {
                dgb_aceptacionguias.DataSource = Tabladetalleguias;
            }
            else
            {
                dgb_aceptacionguias.DataSource = Tabladetalleguias;
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el formulario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void form_bloqueado(Boolean var)
        {
            btn_imprimir.Enabled = true;
            dgb_aceptacionguias.ReadOnly = !var;
            dgb_aceptacionguias.Columns["fechdoc"].ReadOnly = true;
            dgb_aceptacionguias.Columns["_local"].ReadOnly = true;
            dgb_aceptacionguias.Columns["_local_emitido"].ReadOnly = true;
            dgb_aceptacionguias.Columns["_local_name"].ReadOnly = true;
            dgb_aceptacionguias.Columns["doc"].ReadOnly = true;
            dgb_aceptacionguias.Columns["totpzas"].ReadOnly = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            form_bloqueado(true);
        }

        private void cancelar(int confirmar)
        {
            var sw_prosigue = true;
            if (confirmar == 1)
            {
                sw_prosigue = (MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }
            if (sw_prosigue)
            {
                form_bloqueado(false);
                var dt = dgb_aceptacionguias.DataSource as DataTable;
                if (dt.Rows.Count > 0)
                {
                    dt.Rows.Clear();
                }
            }
        }

        private void griddetalleocompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                var cantidad = dgb_aceptacionguias.Columns[dgb_aceptacionguias.CurrentCell.ColumnIndex].Name.ToUpper() == "cantidad".ToUpper();

                if (cantidad)
                {
                    dgb_aceptacionguias.CurrentRow.ReadOnly = true;
                }
            }
        }


        public static KeyEventHandler CapturarTeclaGRID
        {
            get
            {
                KeyEventHandler keypress = new KeyEventHandler(LecturaTecla);
                return keypress;
            }
        }


        private static void LecturaTecla(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                VariablesPublicas.PulsaAyudaArticulos = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F2)
            {
                VariablesPublicas.PulsaTeclaF2 = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F3)
            {
                VariablesPublicas.PulsaTeclaF3 = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.Enter)
            {
                VariablesPublicas.Enter = true;
                SendKeys.Send("\t");
            }
        }

        private void dgb_aceptacionguias_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_aceptacionguias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgb_aceptacionguias[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(39, 95, 178);
            dgb_aceptacionguias[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);
        }


        private void dgb_aceptacionguias_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgb_aceptacionguias.Columns[dgb_aceptacionguias.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
            {
                txtCDetalle = (TextBox)e.Control;
                txtCDetalle.MaxLength = 13;
                txtCDetalle.CharacterCasing = CharacterCasing.Upper;
                txtCDetalle.Text.Trim();
                e.Control.KeyDown += CapturarTeclaGRID;
            }
        }
        private void dgb_aceptacionguias_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgb_aceptacionguias[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }


        private void dgb_aceptacionguias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgb_aceptacionguias.Columns[e.ColumnIndex].Name.Equals("btn_ver"))
            {
                var _tipodoc = dgb_aceptacionguias.Rows[dgb_aceptacionguias.CurrentRow.Index].Cells["_tipodoc"].Value.ToString();
                var _serdoc = dgb_aceptacionguias.Rows[dgb_aceptacionguias.CurrentRow.Index].Cells["_serdoc"].Value.ToString();
                var _numdoc = dgb_aceptacionguias.Rows[dgb_aceptacionguias.CurrentRow.Index].Cells["_numdoc"].Value.ToString();
                var _localemitido = dgb_aceptacionguias.Rows[dgb_aceptacionguias.CurrentRow.Index].Cells["_local_emitido"].Value.ToString();

                try
                {
                    if (Tabladetalleguias.Rows.Count > 0)
                    {
                        var miForma = new D60ALMACEN.REPORTES.Frm_reportes();

                        miForma.dominioid = dominio.Trim();
                        miForma.moduloid = modulo.Trim();
                        miForma.local = _localemitido;
                        miForma.Text = "Reporte Movimientos de Productos";
                        miForma.formulario = "Frm_movimiento";
                        miForma.tipdoc = _tipodoc;
                        miForma.serdoc = _serdoc;
                        miForma.numdoc = _numdoc;
                        miForma.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

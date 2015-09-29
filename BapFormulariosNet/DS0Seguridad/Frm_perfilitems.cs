using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.DS0Seguridad
{
    public partial class Frm_perfilitems : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = string.Empty;
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = "0";
        private String ssModo = string.Empty;

        private String xIDPER = string.Empty;

        private Boolean procesado = false;

        private DataTable Tablaperfil;
        private DataTable Tablanuevoperfil;
        private DataRow row;

        public Frm_perfilitems()
        {
            InitializeComponent();
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                idper.Enabled = !var;
                nbper.Enabled = false;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_buscar.Enabled = false;
                btn_log.Enabled = true;
                btn_salir.Enabled = false;

                btn_cargar.Enabled = false;
                btn_limpiar.Enabled = false;

                groupDestino.Enabled = false;
                groupDestino.BackColor = Color.FromName("Control");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void form_bloquear_propied(Boolean var)
        {
            menid.Enabled = false;
            descr.Enabled = var;
            nivelacc.Enabled = var;
            habil.Enabled = var;
            btn_modificar.Enabled = var;
        }
        private void form_accion_cancelEdicion(int confirnar)
        {
            var sw_prosigue = true;
            if (confirnar == 1)
            {
                sw_prosigue = (MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }
            if (sw_prosigue)
            {
                limpiar_documento();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
                btn_buscar.Enabled = true;
                btn_cargar.Enabled = true;

                ssModo = string.Empty;
            }
        }
        private void form_cargar_datos(String posicion)
        {
            try
            {
                form_bloqueado(false);
                data_Perfil_admin(idper.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_Perfil_admin(String perfil)
        {
            try
            {
                TreeNode Tperfil;
                var BL = new perfilitemsBL();
                var BE = new tb_perfilitems();
                var dt = new DataTable();

                treeperfil.Nodes.Clear();

                if (perfil.Trim().Length != 9)
                {
                    MessageBox.Show("Seleccione un perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BE.idper = perfil.Trim();
                BE.plataforma = "1";
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    Tablaperfil = dt;

                    treeperfil.CheckBoxes = true;
                    foreach (DataRow DRmenu in dt.Rows)
                    {
                        Tperfil = new TreeNode();
                        Tperfil.Name = DRmenu["menid"].ToString();
                        Tperfil.Text = DRmenu["descr"].ToString();
                        Tperfil.ToolTipText = DRmenu["padid"].ToString();
                        Tperfil.Checked = true;
                        if (DRmenu["menid"].Equals(DRmenu["padid"]))
                        {
                            treeperfil.Nodes.Add(Tperfil);
                        }
                        Perfil_item_admin(ref Tperfil, dt);
                        CheckAllChildNodes(Tperfil, true);
                    }
                }
                else
                {
                    MessageBox.Show("No hay Datos !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
            }
        }
        private void Perfil_item_admin(ref TreeNode Tperfil, DataTable dtItems)
        {
            foreach (DataRow DRmenu in dtItems.Rows)
            {
                if (DRmenu["padid"].ToString().Equals(Tperfil.Name) && !DRmenu["menid"].Equals(DRmenu["padid"]))
                {
                    var Menuhijo = new TreeNode();
                    Menuhijo.Name = DRmenu["menid"].ToString();
                    Menuhijo.Text = DRmenu["descr"].ToString();
                    Menuhijo.ToolTipText = DRmenu["padid"].ToString();
                    Tperfil.Nodes.Add(Menuhijo);

                    Perfil_item_admin(ref Menuhijo, dtItems);
                }
            }
        }
        private void CheckAllChildNodes(TreeNode treeNode, Boolean nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (node.Checked)
                {
                    node.StateImageIndex = 1;
                }
                else
                {
                    node.StateImageIndex = 0;
                }
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void data_Perfil_user(String perfil)
        {
            try
            {
                TreeNode Tperfil;
                var BL = new perfilitemsBL();
                var BE = new tb_perfilitems();
                var dt = new DataTable();

                treeperfil.Nodes.Clear();

                if (perfil.Trim().Length != 9)
                {
                    MessageBox.Show("Seleccione un perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BE.idper = perfil.Trim();
                BE.plataforma = "1";
                dt = BL.GetAll_actives(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    Tablaperfil = dt;

                    treeperfil.CheckBoxes = true;
                    foreach (DataRow DRmenu in dt.Rows)
                    {
                        Tperfil = new TreeNode();
                        Tperfil.Name = DRmenu["menid"].ToString();
                        Tperfil.Text = DRmenu["descr"].ToString();
                        Tperfil.ToolTipText = DRmenu["padid"].ToString();
                        if (DRmenu["activo"].ToString().Trim().Length > 0)
                        {
                            Tperfil.Checked = Convert.ToBoolean(DRmenu["activo"]);
                        }
                        if (DRmenu["menid"].Equals(DRmenu["padid"]))
                        {
                            treeperfil.Nodes.Add(Tperfil);
                        }
                        Perfil_item_user(ref Tperfil, dt);
                    }
                }
                else
                {
                    MessageBox.Show("No hay Datos !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Perfil_item_user(ref TreeNode Tperfil, DataTable dtItems)
        {
            foreach (DataRow DRmenu in dtItems.Rows)
            {
                if (DRmenu["padid"].ToString().Equals(Tperfil.Name) && !DRmenu["menid"].Equals(DRmenu["padid"]))
                {
                    var Menuhijo = new TreeNode();
                    Menuhijo.Name = DRmenu["menid"].ToString();
                    Menuhijo.Text = DRmenu["descr"].ToString();
                    Menuhijo.ToolTipText = DRmenu["padid"].ToString();
                    if (DRmenu["activo"].ToString().Trim().Length > 0)
                    {
                        Menuhijo.Checked = Convert.ToBoolean(DRmenu["activo"]);
                    }
                    if (Convert.ToBoolean(DRmenu["habil"]) == false)
                    {
                        Menuhijo.ForeColor = Color.FromArgb(235, 167, 22);
                    }
                    Tperfil.Nodes.Add(Menuhijo);

                    Perfil_item_user(ref Menuhijo, dtItems);
                }
            }
        }

        private void data_cbo_perfil()
        {
            var test = new Dictionary<string, string>();
            test.Add(" ", "NINGUNO");
            test.Add("0", "ADMINISTRADOR(TODO)");
            test.Add("1", "REGISTRAR Y MODIFICAR");
            test.Add("2", "REGISTRAR");
            test.Add("3", "CONSULTAR");
            nivelacc.DataSource = new BindingSource(test, null);
            nivelacc.DisplayMember = "Value";
            nivelacc.ValueMember = "Key";
        }
        private void ValidaPerfil()
        {
            if (idper.Text.Trim().Length == 9)
            {
                var BL = new perfilBL();
                var BE = new tb_perfil();
                var dt = new DataTable();

                BE.idper = idper.Text.Trim();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    idper.Text = dt.Rows[0]["idper"].ToString().Trim();
                    nbper.Text = dt.Rows[0]["nbper"].ToString().Trim();
                }
                else
                {
                    idper.Text = string.Empty;
                    nbper.Text = string.Empty;
                }
            }
            else
            {
                idper.Text = string.Empty;
                nbper.Text = string.Empty;
            }
        }
        private void ValidaPerfil2()
        {
            if (idper2.Text.Trim().Length == 9)
            {
                if ( idper.Text.Trim().Substring(0, 6) == idper2.Text.Trim().Substring(0, 6) )
                {
                    var BL = new perfilBL();
                    var BE = new tb_perfil();
                    var dt = new DataTable();

                    BE.idper = idper2.Text.Trim();

                    dt = BL.GetAll(EmpresaID, BE).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        idper2.Text = dt.Rows[0]["idper"].ToString().Trim();
                        nbper2.Text = dt.Rows[0]["nbper"].ToString().Trim();
                    }
                    else
                    {
                        idper2.Text = string.Empty;
                        nbper2.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Perfil Destino no tiene el mismo DOMINIO y MODULO que el Perfil Origen !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    idper2.Text = string.Empty;
                    nbper2.Text = string.Empty;
                }
            }
            else
            {
                idper2.Text = string.Empty;
                nbper2.Text = string.Empty;
            }
        }

        private void solo_numero_enteros(object control, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' && e.KeyChar <= '9') && !(e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete && !(e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    if ((e.KeyChar) == (char)Keys.Tab)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData )
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.Send("\t");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public bool IsNumeric(String Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
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
        }

        private void Ayudaperfil(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA TABLA PERFIL>>";
                frmayuda.sqlquery = "SELECT idper, nbper FROM tb_perfil";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "PERFIL", "CODIGO" };
                frmayuda.columbusqueda = "idper,nbper";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeDatosDeAyuda;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeDatosDeAyuda(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                idper.Text = resultado1.Trim();
                nbper.Text = resultado1.Trim();
            }
        }

        private void Ayudaperfil2(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA TABLA PERFIL>>";
                frmayuda.sqlquery = "SELECT idper, nbper FROM tb_perfil";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "PERFIL", "CODIGO" };
                frmayuda.columbusqueda = "idper,nbper";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeDatosDeAyuda2;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeDatosDeAyuda2(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                idper2.Text = resultado1.Trim();
                nbper2.Text = resultado1.Trim();
            }
        }

        private void limpiar_documento()
        {
            try
            {
                xIDPER = string.Empty;

                idper.Text = string.Empty;
                nbper.Text = string.Empty;
                idper2.Text = string.Empty;
                nbper2.Text = string.Empty;
                treeperfil.Nodes.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void nuevo()
        {
            ssModo = "NEW";
            xIDPER = string.Empty;

            limpiar_documento();
            form_bloqueado(true);
            data_Perfil_admin(dominio.Trim() + modulo.Trim() + "000");
            idper.Enabled = true;
            idper.Focus();

            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
        }
        private void data_nuevoperfil()
        {
            Tablanuevoperfil = new DataTable("detallocompra");
            Tablanuevoperfil.Columns.Add("idper", typeof(String));
            Tablanuevoperfil.Columns.Add("plataforma", typeof(String));
            Tablanuevoperfil.Columns.Add("menid", typeof(String));
            Tablanuevoperfil.Columns.Add("padid", typeof(String));
            Tablanuevoperfil.Columns.Add("posic", typeof(String));
            Tablanuevoperfil.Columns.Add("descr", typeof(String));
            Tablanuevoperfil.Columns.Add("grupo", typeof(String));
            Tablanuevoperfil.Columns.Add("icono", typeof(String));
            Tablanuevoperfil.Columns.Add("habil", typeof(String));
            Tablanuevoperfil.Columns.Add("pgurl", typeof(String));
            Tablanuevoperfil.Columns.Add("nivelacc", typeof(String));
            Tablanuevoperfil.Columns.Add("dominioid", typeof(String));
            Tablanuevoperfil.Columns.Add("moduloid", typeof(String));
            Tablanuevoperfil.Columns.Add("local", typeof(String));

            if (Tablanuevoperfil != null)
            {
                Tablanuevoperfil.Clear();
            }

            var xaa = 0;
            foreach (TreeNode fila in treeperfil.Nodes)
            {
                if (fila.Checked)
                {
                    xaa++;
                    var rowtipodoc = Tablaperfil.Select("menid='" + fila.Name.ToString() + "'");
                    if (rowtipodoc.Length > 0)
                    {
                        foreach (DataRow dr in rowtipodoc)
                        {
                            row = Tablanuevoperfil.NewRow();
                            row["idper"] = idper.Text.Trim();
                            row["plataforma"] = dr["plataforma"].ToString().Trim();
                            row["menid"] = dr["menid"].ToString().Trim();
                            row["padid"] = dr["padid"].ToString().Trim();
                            row["posic"] = xaa.ToString();
                            row["descr"] = dr["descr"].ToString().Trim();
                            row["grupo"] = dr["grupo"].ToString().Trim();
                            row["icono"] = dr["icono"].ToString().Trim();
                            row["habil"] = dr["habil"].ToString().Trim();
                            row["pgurl"] = dr["pgurl"].ToString().Trim();
                            row["nivelacc"] = idper.Text.Trim().Substring(8).PadRight(5, '0');
                            row["dominioid"] = dr["dominioid"].ToString().Trim();
                            row["moduloid"] = dr["moduloid"].ToString().Trim();
                            row["local"] = dr["local"].ToString().Trim();
                            Tablanuevoperfil.Rows.Add(row);
                        }
                    }
                    node_nuevoperfil(fila);
                }
            }
        }
        private void node_nuevoperfil(TreeNode fila)
        {
            var xaa = 0;
            foreach (TreeNode node in fila.Nodes)
            {
                if (node.Checked)
                {
                    xaa++;
                    var rowtipodoc = Tablaperfil.Select("menid='" + node.Name.ToString() + "'");
                    if (rowtipodoc.Length > 0)
                    {
                        foreach (DataRow dr in rowtipodoc)
                        {
                            row = Tablanuevoperfil.NewRow();
                            row["idper"] = idper.Text.Trim();
                            row["plataforma"] = dr["plataforma"].ToString().Trim();
                            row["menid"] = dr["menid"].ToString().Trim();
                            row["padid"] = dr["padid"].ToString().Trim();
                            row["posic"] = xaa.ToString();
                            row["descr"] = dr["descr"].ToString().Trim();
                            row["grupo"] = dr["grupo"].ToString().Trim();
                            row["icono"] = dr["icono"].ToString().Trim();
                            row["habil"] = dr["habil"].ToString().Trim();
                            row["pgurl"] = dr["pgurl"].ToString().Trim();
                            row["nivelacc"] = idper.Text.Trim().Substring(8).PadRight(5, '0');
                            row["dominioid"] = dr["dominioid"].ToString().Trim();
                            row["moduloid"] = dr["moduloid"].ToString().Trim();
                            row["local"] = dr["local"].ToString().Trim();
                            Tablanuevoperfil.Rows.Add(row);
                        }
                    }
                    node_nuevoperfil(node);
                }
            }
        }

        private void data_nuevoperfil2()
        {
            Tablanuevoperfil = new DataTable("detallocompra");
            Tablanuevoperfil.Columns.Add("idper", typeof(String));
            Tablanuevoperfil.Columns.Add("plataforma", typeof(String));
            Tablanuevoperfil.Columns.Add("menid", typeof(String));
            Tablanuevoperfil.Columns.Add("padid", typeof(String));
            Tablanuevoperfil.Columns.Add("posic", typeof(String));
            Tablanuevoperfil.Columns.Add("descr", typeof(String));
            Tablanuevoperfil.Columns.Add("grupo", typeof(String));
            Tablanuevoperfil.Columns.Add("icono", typeof(String));
            Tablanuevoperfil.Columns.Add("habil", typeof(String));
            Tablanuevoperfil.Columns.Add("pgurl", typeof(String));
            Tablanuevoperfil.Columns.Add("nivelacc", typeof(String));
            Tablanuevoperfil.Columns.Add("dominioid", typeof(String));
            Tablanuevoperfil.Columns.Add("moduloid", typeof(String));
            Tablanuevoperfil.Columns.Add("local", typeof(String));

            if (Tablanuevoperfil != null)
            {
                Tablanuevoperfil.Clear();
            }

            var xaa = 0;
            foreach (TreeNode fila in treeperfil.Nodes)
            {
                if (fila.Checked)
                {
                    xaa++;
                    var rowtipodoc = Tablaperfil.Select("menid='" + fila.Name.ToString() + "'");
                    if (rowtipodoc.Length > 0)
                    {
                        foreach (DataRow dr in rowtipodoc)
                        {
                            row = Tablanuevoperfil.NewRow();
                            row["idper"] = idper2.Text.Trim();
                            row["plataforma"] = dr["plataforma"].ToString().Trim();
                            row["menid"] = dr["menid"].ToString().Trim();
                            row["padid"] = dr["padid"].ToString().Trim();
                            row["posic"] = xaa.ToString();
                            row["descr"] = dr["descr"].ToString().Trim();
                            row["grupo"] = dr["grupo"].ToString().Trim();
                            row["icono"] = dr["icono"].ToString().Trim();
                            row["habil"] = dr["habil"].ToString().Trim();
                            row["pgurl"] = dr["pgurl"].ToString().Trim();
                            row["nivelacc"] = idper2.Text.Trim().Substring(8).PadRight(5, '0');
                            row["dominioid"] = dr["dominioid"].ToString().Trim();
                            row["moduloid"] = dr["moduloid"].ToString().Trim();
                            row["local"] = dr["local"].ToString().Trim();
                            Tablanuevoperfil.Rows.Add(row);
                        }
                    }
                    node_nuevoperfil2(fila);
                }
            }
        }
        private void node_nuevoperfil2(TreeNode fila)
        {
            var xaa = 0;
            foreach (TreeNode node in fila.Nodes)
            {
                if (node.Checked)
                {
                    xaa++;
                    var rowtipodoc = Tablaperfil.Select("menid='" + node.Name.ToString() + "'");
                    if (rowtipodoc.Length > 0)
                    {
                        foreach (DataRow dr in rowtipodoc)
                        {
                            row = Tablanuevoperfil.NewRow();
                            row["idper"] = idper2.Text.Trim();
                            row["plataforma"] = dr["plataforma"].ToString().Trim();
                            row["menid"] = dr["menid"].ToString().Trim();
                            row["padid"] = dr["padid"].ToString().Trim();
                            row["posic"] = xaa.ToString();
                            row["descr"] = dr["descr"].ToString().Trim();
                            row["grupo"] = dr["grupo"].ToString().Trim();
                            row["icono"] = dr["icono"].ToString().Trim();
                            row["habil"] = dr["habil"].ToString().Trim();
                            row["pgurl"] = dr["pgurl"].ToString().Trim();
                            row["nivelacc"] = idper2.Text.Trim().Substring(8).PadRight(5, '0');
                            row["dominioid"] = dr["dominioid"].ToString().Trim();
                            row["moduloid"] = dr["moduloid"].ToString().Trim();
                            row["local"] = dr["local"].ToString().Trim();
                            Tablanuevoperfil.Rows.Add(row);
                        }
                    }
                    node_nuevoperfil2(node);
                }
            }
        }

        private void Insert()
        {
            try
            {
                if (idper.Text.Trim().Length != 9)
                {
                    MessageBox.Show("Ingrese Perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    data_nuevoperfil();
                    var BL = new perfilitemsBL();
                    var BE = new tb_perfilitems();
                    var Detalle = new tb_perfilitems.Item();
                    var ListaItems = new List<tb_perfilitems.Item>();

                    foreach (DataRow fila in Tablanuevoperfil.Rows)
                    {
                        Detalle = new tb_perfilitems.Item();

                        Detalle.idper = fila["idper"].ToString();
                        Detalle.plataforma = fila["plataforma"].ToString();
                        Detalle.menid = Convert.ToInt16(fila["menid"]);
                        Detalle.padid = Convert.ToInt16(fila["padid"]);
                        Detalle.posic = Convert.ToInt16(fila["posic"]);
                        Detalle.descr = fila["descr"].ToString();
                        Detalle.grupo = fila["grupo"].ToString();
                        Detalle.icono = fila["icono"].ToString();
                        Detalle.habil = Convert.ToBoolean(fila["habil"]);
                        Detalle.pgurl = fila["pgurl"].ToString();
                        Detalle.nivelacc = fila["nivelacc"].ToString();
                        Detalle.dominioid = fila["dominioid"].ToString();
                        Detalle.moduloid = fila["moduloid"].ToString();
                        Detalle.local = fila["local"].ToString();

                        ListaItems.Add(Detalle);
                    }
                    BE.idper = idper.Text.Trim();
                    BE.plataforma = "1";
                    BE.ListaItems = ListaItems;
                    if (BL.Insert_xml(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos grabados correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Insert2()
        {
            try
            {
                if (idper2.Text.Trim().Length != 9)
                {
                    MessageBox.Show("Ingrese Perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    data_nuevoperfil();
                    var BL = new perfilitemsBL();
                    var BE = new tb_perfilitems();
                    var Detalle = new tb_perfilitems.Item();
                    var ListaItems = new List<tb_perfilitems.Item>();

                    foreach (DataRow fila in Tablanuevoperfil.Rows)
                    {
                        Detalle = new tb_perfilitems.Item();

                        Detalle.idper = fila["idper"].ToString();
                        Detalle.plataforma = fila["plataforma"].ToString();
                        Detalle.menid = Convert.ToInt16(fila["menid"]);
                        Detalle.padid = Convert.ToInt16(fila["padid"]);
                        Detalle.posic = Convert.ToInt16(fila["posic"]);
                        Detalle.descr = fila["descr"].ToString();
                        Detalle.grupo = fila["grupo"].ToString();
                        Detalle.icono = fila["icono"].ToString();
                        Detalle.habil = Convert.ToBoolean(fila["habil"]);
                        Detalle.pgurl = fila["pgurl"].ToString();
                        Detalle.nivelacc = fila["nivelacc"].ToString();
                        Detalle.dominioid = fila["dominioid"].ToString();
                        Detalle.moduloid = fila["moduloid"].ToString();
                        Detalle.local = fila["local"].ToString();

                        ListaItems.Add(Detalle);
                    }
                    BE.idper = idper2.Text.Trim();
                    BE.plataforma = "1";
                    BE.ListaItems = ListaItems;
                    if (BL.Insert_xml(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos grabados correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Update()
        {
            try
            {
                if (idper.Text.Trim().Length != 9)
                {
                    MessageBox.Show("Ingrese Perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    data_nuevoperfil();
                    var BL = new perfilitemsBL();
                    var BE = new tb_perfilitems();
                    var Detalle = new tb_perfilitems.Item();
                    var ListaItems = new List<tb_perfilitems.Item>();

                    foreach (DataRow fila in Tablanuevoperfil.Rows)
                    {
                        Detalle = new tb_perfilitems.Item();

                        Detalle.idper = fila["idper"].ToString();
                        Detalle.plataforma = fila["plataforma"].ToString();
                        Detalle.menid = Convert.ToInt16(fila["menid"]);
                        Detalle.padid = Convert.ToInt16(fila["padid"]);
                        Detalle.posic = Convert.ToInt16(fila["posic"]);
                        Detalle.descr = fila["descr"].ToString();
                        Detalle.grupo = fila["grupo"].ToString();
                        Detalle.icono = fila["icono"].ToString();
                        Detalle.habil = Convert.ToBoolean(fila["habil"]);
                        Detalle.pgurl = fila["pgurl"].ToString();
                        Detalle.nivelacc = fila["nivelacc"].ToString();
                        Detalle.dominioid = fila["dominioid"].ToString();
                        Detalle.moduloid = fila["moduloid"].ToString();
                        Detalle.local = fila["local"].ToString();

                        ListaItems.Add(Detalle);
                    }
                    BE.idper = idper.Text.Trim();
                    BE.plataforma = "1";
                    BE.ListaItems = ListaItems;
                    if (BL.Update_xml(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos grabados correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Update2()
        {
            try
            {
                if (idper2.Text.Trim().Length != 9)
                {
                    MessageBox.Show("Ingrese Perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    data_nuevoperfil2();
                    var BL = new perfilitemsBL();
                    var BE = new tb_perfilitems();
                    var Detalle = new tb_perfilitems.Item();
                    var ListaItems = new List<tb_perfilitems.Item>();

                    foreach (DataRow fila in Tablanuevoperfil.Rows)
                    {
                        Detalle = new tb_perfilitems.Item();

                        Detalle.idper = fila["idper"].ToString();
                        Detalle.plataforma = fila["plataforma"].ToString();
                        Detalle.menid = Convert.ToInt16(fila["menid"]);
                        Detalle.padid = Convert.ToInt16(fila["padid"]);
                        Detalle.posic = Convert.ToInt16(fila["posic"]);
                        Detalle.descr = fila["descr"].ToString();
                        Detalle.grupo = fila["grupo"].ToString();
                        Detalle.icono = fila["icono"].ToString();
                        Detalle.habil = Convert.ToBoolean(fila["habil"]);
                        Detalle.pgurl = fila["pgurl"].ToString();
                        Detalle.nivelacc = fila["nivelacc"].ToString();
                        Detalle.dominioid = fila["dominioid"].ToString();
                        Detalle.moduloid = fila["moduloid"].ToString();
                        Detalle.local = fila["local"].ToString();

                        ListaItems.Add(Detalle);
                    }
                    BE.idper = idper2.Text.Trim();
                    BE.plataforma = "1";
                    BE.ListaItems = ListaItems;
                    if (BL.Update_xml(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos grabados correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Update_propied()
        {
            try
            {
                if (idper.Text.Trim().Length != 9)
                {
                    MessageBox.Show("Ingrese Perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (menid.Text.Trim().Length != 3)
                    {
                        MessageBox.Show("No existe Id Menu !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        data_nuevoperfil();
                        var BL = new perfilitemsBL();
                        var BE = new tb_perfilitems();

                        BE.idper = idper.Text.Trim();
                        BE.plataforma = "1";
                        BE.menid = Convert.ToInt16(menid.Text.Trim());
                        BE.descr = descr.Text.Trim();
                        if (nivelacc.SelectedIndex != -1 && nivelacc.SelectedValue.ToString().Trim().Trim().Length > 0)
                        {
                            BE.nivelacc = nivelacc.SelectedValue.ToString().PadRight(5, '0');
                        }
                        BE.habil = habil.Checked;

                        if (BL.Update_propied(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos Modificados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            data_Perfil_user(idper.Text.Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete()
        {
            try
            {
                if (idper.Text.Trim().Length != 9)
                {
                    MessageBox.Show("Seleccione Perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_condpagoBL();
                    var BE = new tb_condpago();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos Eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar_documento();
                        form_bloqueado(false);
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete2()
        {
            try
            {
                if (idper2.Text.Trim().Length != 9)
                {
                    MessageBox.Show("Seleccione Perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new perfilitemsBL();
                    var BE = new tb_perfilitems();

                    BE.idper = idper2.Text.Trim();
                    BL.Delete(EmpresaID, BE);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_perfilitems_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;
            dominio = VariablesPublicas.Dominioid.Trim();
            modulo = VariablesPublicas.Moduloid.Trim();
            local = VariablesPublicas.Local.Trim();

            data_cbo_perfil();
            limpiar_documento();
            form_bloqueado(false);
            form_bloquear_propied(false);

            btn_nuevo.Enabled = true;
            btn_buscar.Enabled = true;
            btn_salir.Enabled = true;

            btn_cargar.Enabled = true;
        }
        private void Frm_perfilitems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
            }

            if (e.Control && e.KeyCode == Keys.G)
            {
                if (btn_grabar.Enabled)
                {
                    btn_grabar_Click(sender, e);
                }
            }

            if (e.Control && e.KeyCode == Keys.N)
            {
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (btn_cancelar.Enabled)
                {
                    form_accion_cancelEdicion(1);
                }
                else
                {
                    btn_salir_Click(sender, e);
                }
            }
        }

        private void idper_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ayudaperfil(string.Empty);
            }
            if (idper.Text.Trim().Length == 9)
            {
                ValidaPerfil();
            }
        }
        private void treeperfil_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }
        private void treeperfil_AfterSelect(object sender, TreeViewEventArgs e)
        {
            menid.Text = string.Empty;
            descr.Text = string.Empty;
            habil.Checked = false;
            nivelacc.SelectedIndex = -1;
            if (e.Node.Checked)
            {
                var rowtipodoc = Tablaperfil.Select("menid='" + e.Node.Name.ToString() + "'");
                if (rowtipodoc.Length > 0)
                {
                    foreach (DataRow dr in rowtipodoc)
                    {
                        menid.Text = dr["menid"].ToString().Trim();
                        descr.Text = dr["descr"].ToString().Trim();
                        if (dr["habil"].ToString().Trim().Length > 0)
                        {
                            habil.Checked = Convert.ToBoolean(dr["habil"]);
                        }
                        if (dr["nivelacc"].ToString().Trim().Length > 0)
                        {
                            nivelacc.SelectedValue = dr["nivelacc"].ToString().Trim().Substring(0, 1);
                        }
                    }
                }
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar_documento();
            form_bloqueado(true);
            btn_cargar.Enabled = true;
            btn_limpiar.Enabled = false;
            btn_nuevo.Enabled = true;
            btn_buscar.Enabled = true;
            btn_salir.Enabled = true;
            idper.Enabled = true;
            idper.Focus();
        }
        private void btn_cargar_Click(object sender, EventArgs e)
        {
            data_Perfil_user(idper.Text.Trim());

            if (treeperfil.Nodes.Count > 0)
            {
                idper.Enabled = false;
                btn_editar.Enabled = true;
                btn_cargar.Enabled = false;
                btn_limpiar.Enabled = true;
                form_bloquear_propied(true);
            }
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            Update_propied();
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                nuevo();
            }
        }
        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1")
            {
                if (idper.Text.Trim().Length == 9)
                {
                    ssModo = "EDIT";
                    xIDPER = string.Empty;

                    form_bloqueado(true);
                    form_bloquear_propied(false);
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                }
            }
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }
        private void btn_grabar_Click(object sender, EventArgs e)
        {
            procesado = false;
            var sw_prosigue = false;
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                {
                    Insert();
                }
            }
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        Update();
                    }
                }
            }
            if (procesado)
            {
                limpiar_documento();
                form_bloqueado(false);
                form_bloquear_propied(false);
                idper.Text = string.Empty;

                btn_nuevo.Enabled = true;
                btn_buscar.Enabled = true;
                btn_salir.Enabled = true;
                btn_cargar.Enabled = true;
            }
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
        }
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
        }
        private void btn_buscar_Click(object sender, EventArgs e)
        {
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            form_bloqueado(true);
            groupDestino.Enabled = true;
            groupDestino.BackColor = Color.FromName("Info");
            btn_copiar.Enabled = true;
            btn_cancelar.Enabled = true;
            idper2.Enabled = true;
            idper2.Focus();
        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            procesado = false;
            var sw_prosigue = false;
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                {
                    Insert();
                }
            }
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Copiar a Perfil Destino ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        Update2();
                    }
                }
            }
            if (procesado)
            {
                try
                {
                    idper2.Text = string.Empty;
                    nbper2.Text = string.Empty;
                    treeperfil.Nodes.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                form_bloqueado(false);
                form_bloquear_propied(false);

                btn_nuevo.Enabled = true;
                btn_buscar.Enabled = true;
                btn_salir.Enabled = true;
                btn_cargar.Enabled = true;
            }

            groupDestino.BackColor = Color.FromName("Control");
            groupDestino.Enabled = false;
        }

        private void idper2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ayudaperfil2(string.Empty);
            }
            if (idper2.Text.Trim().Length == 9)
            {
                ValidaPerfil2();
            }
        }
    }
}

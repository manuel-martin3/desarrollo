using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.DL0Logistica.Procesos
{
    public partial class Form_ConstantesGenerales : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = "L0";
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String perianio = string.Empty;
        private String perimes = string.Empty;
        private String ssModo = "NEW";
        private String PERFILID = string.Empty;

        public Form_ConstantesGenerales()
        {
            InitializeComponent();
            EmpresaID = VariablesPublicas.EmpresaID.Trim();
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ssModo == "NEW")
                {
                    Insert();
                }
                else
                {
                    Update();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (DL0Logistica.MainLogistica)MdiParent;
            xxferfil = f.perfil.ToString();
            if (xxferfil.Trim().Length != 9)
            {
                MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PERFILID = xxferfil;
            var XTABLA_PERFIL = string.Empty;
            XTABLA_PERFIL = VariablesPublicas.GET_PARAMETROS_TABLA(xxferfil, Name);
            if (XTABLA_PERFIL.Trim().Length > 0 && XTABLA_PERFIL.Trim() != "0")
            {
                if (XTABLA_PERFIL.Trim().Length == 2)
                {
                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                }
                else
                {
                    if (XTABLA_PERFIL.Trim().Length == 6)
                    {
                        dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                        modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                    }
                    else
                    {
                        if (XTABLA_PERFIL.Trim().Length == 9)
                        {
                            dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                            modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                            local = XTABLA_PERFIL.Trim().Substring(6, 3);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("::: No puede accede a FORMULARIO. \n::: Es necesario DOMINIO, MODULO Y LOCAL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Insert()
        {
            var BL = new constantesgeneralesBL();
            var BE = new tb_constantesgenerales();

            BE.dominioid = dominio;
            BE.moduloid = modulo;
            BE.local = local;

            BE.perianio = sperianio.SelectedItem.ToString();
            BE.perimes = sperimes.SelectedValue.ToString().Trim().PadLeft(2, '0');


            BE.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
            BE.igv = Convert.ToDecimal(igv.Text.Trim().ToUpper());
            BE.inprec = inprec.Text.Trim().ToUpper();
            BE.tipfactura = tipfactura.Text.Trim().ToUpper();
            BE.tipboleta = tipboleta.Text.Trim().ToUpper();
            BE.tipordprod = tipordprod.Text.Trim().ToUpper();
            BE.tipordcomp = tipordcomp.Text.Trim().ToUpper();
            BE.tipproforma = tipproforma.Text.Trim().ToUpper();
            BE.tipguia1 = tipguia1.Text.Trim().ToUpper();
            BE.tipguia2 = tipguia2.Text.Trim().ToUpper();
            BE.tipguia3 = tipguia3.Text.Trim().ToUpper();
            BE.tipajusteing = tipajusteing.Text.Trim().ToUpper();
            BE.tipajustesal = tipajustesal.Text.Trim().ToUpper();
            BE.monedn = monedn.Text.Trim().ToUpper();
            BE.monede = monede.Text.Trim().ToUpper();
            BE.monedu = monedu.Text.Trim().ToUpper();
            BE.monednsimbolo = monednsimbolo.Text.Trim().ToUpper();
            BE.monedesimbolo = monedesimbolo.Text.Trim().ToUpper();
            BE.posl1 = Convert.ToInt16(posl1.Text.Trim().ToUpper());
            BE.longl1 = Convert.ToInt16(longl1.Text.Trim().ToUpper());
            BE.posl2 = Convert.ToInt16(posl2.Text.Trim().ToUpper());
            BE.longl2 = Convert.ToInt16(longl2.Text.Trim().ToUpper());
            BE.posl3 = Convert.ToInt16(posl3.Text.Trim().ToUpper());
            BE.longl3 = Convert.ToInt16(longl3.Text.Trim().ToUpper());
            BE.descl1 = descl1.Text.Trim().ToUpper();
            BE.descl2 = descl2.Text.Trim().ToUpper();
            BE.descl3 = descl3.Text.Trim().ToUpper();
            if (fechdigini.Text.Trim().Length == 0)
            {
                BE.fechdigini = Convert.ToDateTime("01/01/1900");
            }
            else
            {
                BE.fechdigini = Convert.ToDateTime(fechdigini.Text.Trim());
            }

            if (fechdigfin.Text.Trim().Length == 0)
            {
                BE.fechdigfin = Convert.ToDateTime("01/01/1900");
            }
            else
            {
                BE.fechdigfin = Convert.ToDateTime(fechdigfin.Text.Trim());
            }


            try
            {
                if (BL.Insert(EmpresaID, BE))
                {
                    if ((perianio != sperianio.SelectedValue) || (perimes != sperimes.SelectedValue))
                    {
                        Close();
                        VariablesPublicas.CerrarSession = true;
                        DL0Logistica.MainLogistica.ActiveForm.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Conectese Con Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void Update()
        {
            var BL = new constantesgeneralesBL();
            var BE = new tb_constantesgenerales();
            BE.dominioid = dominio;
            BE.moduloid = modulo;
            BE.local = local;

            BE.perianio = sperianio.SelectedItem.ToString();
            BE.perimes = sperimes.SelectedValue.ToString().Trim().PadLeft(2, '0');

            BE.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
            BE.igv = Convert.ToDecimal(igv.Text.Trim().ToUpper());
            BE.inprec = inprec.Text.Trim().ToUpper();
            BE.tipfactura = tipfactura.Text.Trim().ToUpper();
            BE.tipboleta = tipboleta.Text.Trim().ToUpper();
            BE.tipordprod = tipordprod.Text.Trim().ToUpper();
            BE.tipordcomp = tipordcomp.Text.Trim().ToUpper();
            BE.tipproforma = tipproforma.Text.Trim().ToUpper();
            BE.tipguia1 = tipguia1.Text.Trim().ToUpper();
            BE.tipguia2 = tipguia2.Text.Trim().ToUpper();
            BE.tipguia3 = tipguia3.Text.Trim().ToUpper();
            BE.tipajusteing = tipajusteing.Text.Trim().ToUpper();
            BE.tipajustesal = tipajustesal.Text.Trim().ToUpper();
            BE.monedn = monedn.Text.Trim().ToUpper();
            BE.monede = monede.Text.Trim().ToUpper();
            BE.monedu = monedu.Text.Trim().ToUpper();
            BE.monednsimbolo = monednsimbolo.Text.Trim().ToUpper();
            BE.monedesimbolo = monedesimbolo.Text.Trim().ToUpper();
            BE.posl1 = Convert.ToInt16(posl1.Text.Trim().ToUpper());
            BE.longl1 = Convert.ToInt16(longl1.Text.Trim().ToUpper());
            BE.posl2 = Convert.ToInt16(posl2.Text.Trim().ToUpper());
            BE.longl2 = Convert.ToInt16(longl2.Text.Trim().ToUpper());
            BE.posl3 = Convert.ToInt16(posl3.Text.Trim().ToUpper());
            BE.longl3 = Convert.ToInt16(longl3.Text.Trim().ToUpper());
            BE.descl1 = descl1.Text.Trim().ToUpper();
            BE.descl2 = descl2.Text.Trim().ToUpper();
            BE.descl3 = descl3.Text.Trim().ToUpper();
            if (fechdigini.Text.Trim().Length == 0)
            {
                BE.fechdigini = Convert.ToDateTime("01/01/1900");
            }
            else
            {
                BE.fechdigini = Convert.ToDateTime(fechdigini.Text.Trim());
            }

            if (fechdigfin.Text.Trim().Length == 0)
            {
                BE.fechdigfin = Convert.ToDateTime("01/01/1900");
            }
            else
            {
                BE.fechdigfin = Convert.ToDateTime(fechdigfin.Text.Trim());
            }

            BE.ctacteclie = "0000308";
            BE.ctacteinv = "0007483";

            try
            {
                if (BL.Update(EmpresaID, BE))
                {
                    if ((perianio != sperianio.SelectedValue) || (perimes != sperimes.SelectedValue))
                    {
                        Close();
                        VariablesPublicas.CerrarSession = true;
                        DL0Logistica.MainLogistica.ActiveForm.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Contacte con Sistemas");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_anular_Click(object sender, EventArgs e)
        {
            Delete();
            Nuevo();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            enabled_obj(true);
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Delete()
        {
            var BL = new constantesgeneralesBL();
            var BE = new tb_constantesgenerales();
            BE.dominioid = dominio;
            BE.moduloid = modulo;
            BE.local = local;

            try
            {
                if (BL.Delete(EmpresaID, BE))
                {
                    MessageBox.Show("Se eliminó con éxito");
                    Nuevo();
                }
                else
                {
                    MessageBox.Show("Contactese con Sistemas");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void llenarSPerimes()
        {
            var lista = new List<Item>();

            lista.Add(new Item("Enero", 01));
            lista.Add(new Item("Febrero", 02));
            lista.Add(new Item("Marzo", 03));
            lista.Add(new Item("Abril", 04));
            lista.Add(new Item("Mayo", 05));
            lista.Add(new Item("Junio", 06));
            lista.Add(new Item("Julio", 07));
            lista.Add(new Item("Agosto", 08));
            lista.Add(new Item("Setiembre", 09));
            lista.Add(new Item("Octubre", 10));
            lista.Add(new Item("Noviembre", 11));
            lista.Add(new Item("Diciembre", 12));

            sperimes.DisplayMember = "Name";
            sperimes.ValueMember = "Value";
            sperimes.DataSource = lista;
        }

        protected void enabled_obj(Boolean obj)
        {
            idconst.Enabled = obj;
            sperianio.Enabled = obj;
            sperimes.Enabled = obj;
            fechdigini.Enabled = obj;
            fechdigfin.Enabled = obj;
            tcamb.Enabled = obj;
            igv.Enabled = obj;
            inprec.Enabled = obj;
            tipfactura.Enabled = obj;
            tipboleta.Enabled = obj;
            tipordprod.Enabled = obj;
            tipordcomp.Enabled = obj;
            tipproforma.Enabled = obj;
            tipguia1.Enabled = obj;
            tipguia2.Enabled = obj;
            tipguia3.Enabled = obj;
            tipajusteing.Enabled = obj;
            tipajustesal.Enabled = obj;
            monedn.Enabled = obj;
            monede.Enabled = obj;
            monedu.Enabled = obj;
            monednsimbolo.Enabled = obj;
            monedesimbolo.Enabled = obj;
            posl1.Enabled = obj;
            longl1.Enabled = obj;
            posl2.Enabled = obj;
            longl2.Enabled = obj;
            posl3.Enabled = obj;
            longl3.Enabled = obj;
            descl1.Enabled = obj;
            descl2.Enabled = obj;
            descl3.Enabled = obj;
        }

        protected void Nuevo()
        {
            idconst.Text = string.Empty;
            fechdigini.Text = string.Empty;
            fechdigfin.Text = string.Empty;
            sperianio.SelectedText = Convert.ToString(DateTime.Now.Year);
            sperimes.SelectedValue = DateTime.Today.Month;
            tcamb.Text = "1";
            igv.Text = "18.0";
            inprec.Text = "N";
            tipfactura.Text = "FA";
            tipboleta.Text = "FV";
            tipordprod.Text = "OP";
            tipordcomp.Text = "OC";
            tipproforma.Text = "PR";
            tipguia1.Text = "GR";
            tipguia2.Text = "GV";
            tipguia3.Text = "GF";
            tipajusteing.Text = "II";
            tipajustesal.Text = "IS";
            monedn.Text = "S";
            monede.Text = "$";
            monedu.Text = "S";
            monednsimbolo.Text = "S/.";
            monedesimbolo.Text = "US$";
            posl1.Text = "0";
            longl1.Text = "0";
            posl2.Text = "0";
            longl2.Text = "0";
            posl3.Text = "0";
            longl3.Text = "0";
            descl1.Text = "LINEA";
            descl2.Text = "GRUPO";
            descl3.Text = "SUBGRUPO";
            enabled_obj(false);
            ssModo = "NEW";
        }

        private void Form_ConstantesGenerales_Load(object sender, EventArgs e)
        {
            PARAMETROS_TABLA();
            getYears();
            llenarSPerimes();
            data_constantesgenerales();
            enabled_obj(false);
        }

        private void getYears()
        {
            try
            {
                var anio = DateTime.Now.Year;
                for (var i = 2010; i <= anio; i++)
                {
                    sperianio.Items.Add(i.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void data_constantesgenerales()
        {
            var BL = new constantesgeneralesBL();
            var dt = new DataTable();

            var dominioid = string.Empty;
            var moduloid = string.Empty;
            var localid = string.Empty;

            dominioid = dominio;
            moduloid = modulo;
            localid = local;

            try
            {
                if (validar_registro(dominio, modulo, local) != 0)
                {
                    dt = BL.GetOne(EmpresaID, dominioid, moduloid, localid).Tables[0];

                    idconst.Text = dt.Rows[0]["dominioid"].ToString() + dt.Rows[0]["moduloid"].ToString() + dt.Rows[0]["local"].ToString();
                    sperianio.Text = dt.Rows[0]["perianio"].ToString().Trim();
                    var sperimes = Convert.ToInt32(dt.Rows[0]["perimes"].ToString());
                    this.sperimes.SelectedValue = sperimes;
                    fechdigini.Text = dt.Rows[0]["fechdigini"].ToString().Trim().Substring(0, 10);
                    fechdigfin.Text = dt.Rows[0]["fechdigfin"].ToString().Trim().Substring(0, 10);
                    tcamb.Text = dt.Rows[0]["tcamb"].ToString();
                    igv.Text = dt.Rows[0]["igv"].ToString();
                    inprec.Text = dt.Rows[0]["inprec"].ToString();
                    tipfactura.Text = dt.Rows[0]["tipfactura"].ToString();
                    tipboleta.Text = dt.Rows[0]["tipboleta"].ToString();
                    tipordprod.Text = dt.Rows[0]["tipordprod"].ToString();
                    tipordcomp.Text = dt.Rows[0]["tipordcomp"].ToString();
                    tipproforma.Text = dt.Rows[0]["tipproforma"].ToString();
                    tipguia1.Text = dt.Rows[0]["tipguia1"].ToString();
                    tipguia2.Text = dt.Rows[0]["tipguia2"].ToString();
                    tipguia3.Text = dt.Rows[0]["tipguia3"].ToString();
                    tipajusteing.Text = dt.Rows[0]["tipajusteing"].ToString();
                    tipajustesal.Text = dt.Rows[0]["tipajustesal"].ToString();
                    monedn.Text = dt.Rows[0]["monedn"].ToString();
                    monede.Text = dt.Rows[0]["monede"].ToString();
                    monedu.Text = dt.Rows[0]["monedu"].ToString();
                    monednsimbolo.Text = dt.Rows[0]["monednsimbolo"].ToString();
                    monedesimbolo.Text = dt.Rows[0]["monedesimbolo"].ToString();
                    posl1.Text = dt.Rows[0]["posl1"].ToString();
                    longl1.Text = dt.Rows[0]["longl1"].ToString();
                    posl2.Text = dt.Rows[0]["posl2"].ToString();
                    longl2.Text = dt.Rows[0]["longl2"].ToString();
                    posl3.Text = dt.Rows[0]["posl3"].ToString();
                    longl3.Text = dt.Rows[0]["longl3"].ToString();
                    descl1.Text = dt.Rows[0]["descl1"].ToString();
                    descl2.Text = dt.Rows[0]["descl2"].ToString();
                    descl3.Text = dt.Rows[0]["descl3"].ToString();
                    enabled_obj(false);
                    ssModo = "EDIT";
                }
                else
                {
                    ssModo = "NEW";
                    Nuevo();
                    enabled_obj(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int validar_registro(string dominioid, string moduloid, string local)
        {
            var contador = 0;
            var BL = new constantesgeneralesBL();
            var dt = new DataTable();

            dt = BL.GetOne(EmpresaID, dominioid, moduloid, local).Tables[0];

            foreach (DataRow fila in dt.Rows)
            {
                contador++;
            }
            return contador;
        }

        private void btn_editar_MouseEnter(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.ForeColor = Color.Black;
        }

        private void btn_editar_MouseLeave(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.ForeColor = Color.LightGray;
        }

        private void btn_grabar_MouseEnter(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.ForeColor = Color.Black;
        }

        private void btn_grabar_MouseLeave(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.ForeColor = Color.LightGray;
        }
    }
}

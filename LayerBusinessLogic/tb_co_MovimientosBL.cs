using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{  
    public class tb_co_MovimientosBL
    {
        public string Sql_Error = "";
        tb_co_MovimientosDA tablaDA = new tb_co_MovimientosDA();

        public bool Insert(string empresaid, tb_co_Movimientos BE)
        {           
            bool zreturn = tablaDA.Insert(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Update(string empresaid, tb_co_Movimientos BE)
        {
            
            bool zreturn = tablaDA.Update(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public bool Insert_Update(string empresaid, DataTable Cabecera, DataTable Detalle)
        {
            bool zreturn = tablaDA.Insert_Update(empresaid, Cabecera, Detalle);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool GetAllAsientoAutomaticoDestino(string empresaid, tb_co_Movimientos BE)
        {        
            bool zreturn = tablaDA.GetAllAsientoAutomaticoDestino(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public bool Delete(string empresaid, tb_co_Movimientos BE)
        {
            
            bool zreturn = tablaDA.Delete(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        //public DataSet GetAll(string empresaid, tb_co_Movimientos BE)
        //{
        //    return tablaDA.GetAll(empresaid, BE);
        //}

        public DataSet GetGeneraVoucherContable(string empresaid, tb_co_Movimientos BE)
        {
            DataSet zreturn = tablaDA.GetGeneraVoucherContable(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraIgv(string empresaid, tb_co_Movimientos BE)
        {         
            DataSet zreturn = tablaDA.GetGeneraIgv(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraSaldoCuenta(string empresaid, tb_co_Movimientos BE)
        {         
            DataSet zreturn = tablaDA.GetGeneraSaldoCuenta(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetGeneraReporteChequesGirados(string empresaid, tb_co_Movimientos BE)
        {
            DataSet zreturn = tablaDA.GetGeneraReporteChequesGirados(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetGeneraHojaTrabajo(string empresaid, tb_co_Movimientos BE)
        {           
            DataSet zreturn = tablaDA.GetGeneraHojaTrabajo(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraBalanceComprobacionDJ(string empresaid, tb_co_Movimientos BE)
        {          
            DataSet zreturn = tablaDA.GetGeneraBalanceComprobacionDJ(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraBalanceGeneral(string empresaid, tb_co_Movimientos BE)
        {
            DataSet zreturn = tablaDA.GetGeneraBalanceGeneral(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraAnexosBalanceGeneral(string empresaid, tb_co_Movimientos BE)
        {         
            DataSet zreturn = tablaDA.GetGeneraAnexosBalanceGeneral(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraEstadoGananciasPerdidas(string empresaid, tb_co_Movimientos BE)
        {        
            DataSet zreturn = tablaDA.GetGeneraEstadoGananciasPerdidas(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraEEFFmensual(string empresaid, tb_co_Movimientos BE)
        {        
            DataSet zreturn = tablaDA.GetGeneraEEFFmensual(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetGeneraBalanceGeneralBapSoft(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraBalanceGeneralBapSoft(empresaid, BE);
        }
        public DataSet GetGeneraAnexosBalanceGeneralBapSoft(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraAnexosBalanceGeneralBapSoft(empresaid, BE);
        }        
        
        public DataSet GetGeneraBalancexCcosto(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraBalancexCcosto(empresaid, BE);
        }
        public DataSet GetGeneraBalancexCcostoMensual(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraBalancexCcostoMensual(empresaid, BE);
        }
        public DataSet GetGeneraBalancexCcostoGeneral(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraBalancexCcostoGeneral(empresaid, BE);
        }
        public DataSet GetGeneraBalancexCcostoPlantilla(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraBalancexCcostoPlantilla(empresaid, BE);
        }
        public DataSet GetGeneraAnalisisCcosto(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraAnalisisCcosto(empresaid, BE);
        }

        public DataSet GetGeneraLibroCajaBancos(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraLibroCajaBancos(empresaid, BE);
        }
        public DataSet GetGeneraDataConciliacionBanacaria(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraDataConciliacionBanacaria(empresaid, BE);
        }
        public DataSet GetGeneraDataConsultaConciliacionBanacaria(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraDataConsultaConciliacionBanacaria(empresaid, BE);
        }

        public DataSet GetGeneraLibroDiarioGeneral(string empresaid, tb_co_Movimientos BE)
        {
            DataSet zreturn = tablaDA.GetGeneraLibroDiarioGeneral(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraLibroDiarioF51(string empresaid, tb_co_Movimientos BE)
        {         
            DataSet zreturn = tablaDA.GetGeneraLibroDiarioF51(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraLibroDiarioSimplificadoF52(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraLibroDiarioSimplificadoF52(empresaid, BE);
        }

        public DataSet GetGeneraLibroMayorGeneral(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraLibroMayorGeneral(empresaid, BE);
        }
        public DataSet GetGeneraLibroMayorF61(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraLibroMayorF61(empresaid, BE);
        }

        public DataSet GetGeneraLibroInventariosyBalances(string empresaid, tb_co_Movimientos BE)
        {      
            DataSet zreturn = tablaDA.GetGeneraLibroInventariosyBalances(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetAnalisiscuenta(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetAnalisiscuenta(empresaid, BE);
        }
        public DataSet GetGeneraLibroMayorAuxiliar(string empresaid, tb_co_Movimientos BE)
        {
            DataSet zreturn = tablaDA.GetGeneraLibroMayorAuxiliar(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraDocIngresados(string empresaid, tb_co_Movimientos BE)
        {
            DataSet zreturn = tablaDA.GetGeneraDocIngresados(empresaid, BE);
            //return tablaDA.GetGeneraDocIngresados(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraDiarioGeneralDocumentos(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraDiarioGeneralDocumentos(empresaid, BE);
        }

        public DataSet GetGeneraDiarioGeneralVouchersAnulados(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraDiarioGeneralVouchersAnulados(empresaid, BE);
        }

        public DataSet GetGeneraAnalisisGastosxFuncionAnalitico(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraAnalisisGastosxFuncionAnalitico(empresaid, BE);
        }
        public DataSet GetGeneraAnalisisGastosxFuncionResumen(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraAnalisisGastosxFuncionResumen(empresaid, BE);
        }

        public DataSet GetGeneraCuadroMensualSaldoDetalle(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraCuadroMensualSaldoDetalle(empresaid, BE);
        }
        public DataSet GetGeneraCuadroMensualSaldoGeneral(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraCuadroMensualSaldoGeneral(empresaid, BE);
        }

        public DataSet GetGeneraCuentaCorriente(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraCuentaCorriente(empresaid, BE);
        }
        public DataSet GetGeneraCuentaCorrientePC(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraCuentaCorrientePC(empresaid, BE);
        }
        public DataSet GetGeneraCuentaCorrienteCajaChica(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraCuentaCorrienteCajaChica(empresaid, BE);
        }
        public DataSet GetGeneraCuentaCorrienteCajaChica_CC(string empresaid, tb_co_Movimientos BE)
        {
            DataSet zreturn = tablaDA.GetGeneraCuentaCorrienteCajaChica_CC(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraCuentaCorrienteCajaChica_4010106(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraCuentaCorrienteCajaChica_4010106(empresaid, BE);
        }
        
        public DataSet GetGeneraReporteVcmtoLetras(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraReporteVcmtoLetras(empresaid, BE);
        }

        public DataSet GetGeneraPDBFormasPago(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraPDBFormasPago(empresaid, BE);
        }
        public DataSet GetGeneraDAOTComprasVentas(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraDAOTComprasVentas(empresaid, BE);
        }
        public DataSet GetGeneraRankingComprasVentas(string empresaid, tb_co_Movimientos BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetGeneraRankingComprasVentas(empresaid, BE);
        }

        public DataSet GetGeneraPDT0601Rta4taCag(string empresaid, tb_co_Movimientos BE)
        {
            DataSet zreturn = tablaDA.GetGeneraPDT0601Rta4taCag(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetVerificaCtaDestinoEnAsiento(string empresaid, tb_co_Movimientos BE)
        {
            DataSet zreturn = tablaDA.GetVerificaCtaDestinoEnAsiento(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public bool GetGeneraAjusteAsientos_tabla(string empresaid, tb_co_Movimientos BE, DataTable TablaDatos)
        {
            bool zreturn = tablaDA.GetGeneraAjusteAsientos_tabla(empresaid, BE, TablaDatos);
            Sql_Error = tablaDA.Sql_Error;
            //return tablaDA.GetGeneraAjusteAsientos_tabla(empresaid, BE, TablaDatos);
            return zreturn;
        }
        public bool GetGeneraAjusteAsientos(string empresaid, tb_co_Movimientos BE)
        {
            bool zreturn = tablaDA.GetGeneraAjusteAsientos(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            //return tablaDA.GetGeneraAjusteAsientos(empresaid, BE);
            return zreturn;
        }

        public bool GetGeneraAsientosAutomaticos_Destinos(string empresaid, tb_co_Movimientos BE)
        {
            bool zreturn = tablaDA.GetGeneraAsientosAutomaticos_Destinos(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            //return tablaDA.GetGeneraAsientosAutomaticos_Destinos(empresaid, BE);
            return zreturn;
        }

        public DataSet GetDetermina_IGV_Renta(string empresaid, tb_co_Movimientos BE)
        {
            DataSet zreturn = tablaDA.GetDetermina_IGV_Renta(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetReporte_IGV_Renta(string empresaid, tb_co_Movimientos BE)
        {
            DataSet zreturn = tablaDA.GetReporte_IGV_Renta(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetGenera_CuadroMensualVe_Co(string empresaid, tb_co_Movimientos BE)
        {
            DataSet zreturn = tablaDA.GetGenera_CuadroMensualVe_Co(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetGenera_AnalisisVentas(string empresaid, tb_co_Movimientos BE)
        {       
            DataSet zreturn = tablaDA.GetGenera_AnalisisVentas(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetGenera_ConsultaSunat(string empresaid, tb_co_Movimientos BE)
        {          
            DataSet zreturn = tablaDA.GetGenera_ConsultaSunat(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGenera_ConsultaSunatRXH(string empresaid, tb_co_Movimientos BE)
        {           
            DataSet zreturn = tablaDA.GetGenera_ConsultaSunatRXH(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetGenera_ConsultaSunatAct(string empresaid, tb_co_Movimientos BE)
        {
            DataSet zreturn = tablaDA.GetGenera_ConsultaSunatAct(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        #region Detalle Inventarios
        public DataSet GetGeneraFlujoEfectivo(string empresaid, tb_co_Movimientos BE)
        {        
            DataSet zreturn = tablaDA.GetGeneraFlujoEfectivo(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraFEfectivo_Consulta(string empresaid, tb_co_Movimientos BE)
        {            
            DataSet zreturn = tablaDA.GetGeneraFEfectivo_Consulta(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraFlujoEfectivo_Comparativo(string empresaid, tb_co_Movimientos BE)
        {          
            DataSet zreturn = tablaDA.GetGeneraFlujoEfectivo_Comparativo(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetGeneraF32DetalleCajaBancos(string empresaid, tb_co_Movimientos BE)
        {        
            DataSet zreturn = tablaDA.GetGeneraF32DetalleCajaBancos(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraFDetalleCuentas(string empresaid, tb_co_Movimientos BE)
        {       
            DataSet zreturn = tablaDA.GetGeneraFDetalleCuentas(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        #endregion

        #region Ajustes-Redondeos y Ajuste Dif.Cambio
        public DataSet GetGeneraAsientoAjusteDifRedondeo(string empresaid, tb_co_Movimientos BE)
        {           
            DataSet zreturn = tablaDA.GetGeneraAsientoAjusteDifRedondeo(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraAsientoAjusteDifCambio(string empresaid, tb_co_Movimientos BE)
        {       
            DataSet zreturn = tablaDA.GetGeneraAsientoAjusteDifCambio(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        #endregion

        #region  Apertura, Ajustes Dif.Cambio al cierre y Cierre Ejercicio
        public bool GetGeneraAsientoApertura(string empresaid, tb_co_Movimientos BE)
        {       
            bool zreturn = tablaDA.GetGeneraAsientoApertura(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        
        public bool GetGeneraAsientoDifCambioCierre(string empresaid, tb_co_Movimientos BE)
        {         
            bool zreturn = tablaDA.GetGeneraAsientoDifCambioCierre(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraAsientoDifCambioCierreConsulta(string empresaid, tb_co_Movimientos BE)
        {          
            DataSet zreturn = tablaDA.GetGeneraAsientoDifCambioCierreConsulta(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        
        public bool GetGeneraAsientoCierreEjercicio(string empresaid, tb_co_Movimientos BE)
        {        
            bool zreturn = tablaDA.GetGeneraAsientoCierreEjercicio(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        #endregion

        #region LIBROS ELECTRONICOS
        public DataSet GetGeneraPLE_Sunat101(string empresaid, tb_co_Movimientos BE)
        {          
            DataSet zreturn = tablaDA.GetGeneraPLE_Sunat101(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraPLE_Sunat102(string empresaid, tb_co_Movimientos BE)
        {          
            DataSet zreturn = tablaDA.GetGeneraPLE_Sunat102(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetGeneraPLE_Sunat301(string empresaid, tb_co_Movimientos BE)
        {          
            DataSet zreturn = tablaDA.GetGeneraPLE_Sunat301(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraPLE_Sunat302(string empresaid, tb_co_Movimientos BE)
        {          
            DataSet zreturn = tablaDA.GetGeneraPLE_Sunat302(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetGeneraPLE_Sunat041(string empresaid, tb_co_Movimientos BE)
        {         
            DataSet zreturn = tablaDA.GetGeneraPLE_Sunat041(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetGeneraPLE_SunatLibroDiario51(string empresaid, tb_co_Movimientos BE)
        {
            DataSet zreturn = tablaDA.GetGeneraPLE_SunatLibroDiario51(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraPLE_SunatLibroDiarioPC53(string empresaid, tb_co_Movimientos BE)
        {         
            DataSet zreturn = tablaDA.GetGeneraPLE_SunatLibroDiarioPC53(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetGeneraPLE_SunatLibroMayor61(string empresaid, tb_co_Movimientos BE)
        {         
            DataSet zreturn = tablaDA.GetGeneraPLE_SunatLibroMayor61(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        
        public DataSet GetGeneraPLE_SunatRegistroCompra81(string empresaid, tb_co_Movimientos BE)
        {        
            DataSet zreturn = tablaDA.GetGeneraPLE_SunatRegistroCompra81(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraPLE_SunatRegistroVentas141(string empresaid, tb_co_Movimientos BE)
        {           
            DataSet zreturn = tablaDA.GetGeneraPLE_SunatRegistroVentas141(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        #endregion

        #region // LIBROS Y/O REGISTROS FISCALIZACION
        public DataSet GetGeneraLibroDiario_Fiscalizacion(string empresaid, tb_co_Movimientos BE)
        {           
            DataSet zreturn = tablaDA.GetGeneraLibroDiario_Fiscalizacion(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraLibroMayor_Fiscalizacion(string empresaid, tb_co_Movimientos BE)
        {           
            DataSet zreturn = tablaDA.GetGeneraLibroMayor_Fiscalizacion(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetGeneraRegistroCompra_Fiscalizacion(string empresaid, tb_co_Movimientos BE)
        {         
            DataSet zreturn = tablaDA.GetGeneraRegistroCompra_Fiscalizacion(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetGeneraRegistroVentas_Fiscalizacion(string empresaid, tb_co_Movimientos BE)
        {          
            DataSet zreturn = tablaDA.GetGeneraRegistroVentas_Fiscalizacion(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        #endregion
    }
}

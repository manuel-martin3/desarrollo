USE [bapEmpresa02];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

delete  [dbo].[tb_perfilitems];
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[tb_perfilitems]([idper], [menid], [descr], [padid], [posic], [grupo], [icono], [habil], [pgurl], [nivelacc])
SELECT N'200200000', 100, N'Archivos', 100, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'200200000', 101, N'Pedidos', 100, 1, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'200200000', 102, N'Nuevo Pedido', 101, 1, NULL, NULL, 1, N'D20COMER/0200PEDID/pedido_registrar.aspx', NULL UNION ALL
SELECT N'200200000', 103, N'Modificar Pedido', 101, 2, NULL, NULL, 1, N'D20COMER/0200PEDID/pedido_modificar.aspx', NULL UNION ALL
SELECT N'200200000', 104, N'Consultar Pedido', 101, 3, NULL, NULL, 1, N'D20COMER/0200PEDID/pedido_consultar.aspx', NULL UNION ALL
SELECT N'200200000', 105, N'Documento de Tienda', 100, 2, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'200200000', 106, N'Nuevo Doc.Interno', 105, 1, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_movimiento_registrar.aspx', NULL UNION ALL
SELECT N'200200000', 107, N'Nueva Boleta', 105, 2, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_movimiento_bv.aspx', NULL UNION ALL
SELECT N'200200000', 108, N'Nueva Factura', 105, 3, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_movimiento_fa.aspx', NULL UNION ALL
SELECT N'200200000', 109, N'Nueva Nota Credito', 105, 4, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_movimiento_nc.aspx', NULL UNION ALL
SELECT N'200200000', 110, N'Nuevo Ticket', 105, 5, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_movimiento_tk.aspx', NULL UNION ALL
SELECT N'200200000', 111, N'Modificar Documento', 105, 6, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_movimiento_modificar.aspx', NULL UNION ALL
SELECT N'200200000', 112, N'Consultar Doc.Tienda', 105, 7, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_movimiento_consultar.aspx', NULL UNION ALL
SELECT N'200200000', 200, N'Catálogo', 200, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'200200000', 201, N'Tasa de Tributaria', 200, 1, NULL, NULL, 1, N'CATALOGO/GENERAL/cliente.aspx', NULL UNION ALL
SELECT N'200200000', 202, N'Tipo de Cambio', 200, 2, NULL, NULL, 1, N'CATALOGO/GENERAL/cliente.aspx', NULL UNION ALL
SELECT N'200200000', 203, N'Constantes Generales', 200, 3, NULL, NULL, 1, N'CATALOGO/GENERAL/constantesgenerales.aspx', NULL UNION ALL
SELECT N'200200000', 204, N'Serie de Documentos', 200, 4, NULL, NULL, 1, N'CATALOGO/GENERAL/modulolocaltipdocseries.aspx', NULL UNION ALL
SELECT N'200200000', 205, N'Tiendas', 200, 5, NULL, NULL, 1, N'CATALOGO/GENERAL/tiendas.aspx', NULL UNION ALL
SELECT N'200200000', 206, N'Clientes', 200, 6, NULL, NULL, 1, N'CATALOGO/GENERAL/cliente.aspx', NULL UNION ALL
SELECT N'200200000', 207, N'Cargos Laborales', 200, 7, NULL, NULL, 1, N'CATALOGO/GENERAL/vendedorcorporativo.aspx', NULL UNION ALL
SELECT N'200200000', 208, N'Personal de Tiendas', 200, 8, NULL, NULL, 1, N'CATALOGO/GENERAL/vendedorcorporativo.aspx', NULL UNION ALL
SELECT N'200200000', 209, N'Rubros Movto Caja', 200, 9, NULL, NULL, 1, N'CATALOGO/GENERAL/broker.aspx', NULL UNION ALL
SELECT N'200200000', 210, N'Conceptos Movto Caja', 200, 10, NULL, NULL, 1, N'CATALOGO/GENERAL/transportista.aspx', NULL UNION ALL
SELECT N'200200000', 300, N'Listados', 300, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'200200000', 301, N'Stocks', 300, 1, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'200200000', 302, N'Stock Artículo-Color-Talla', 301, 1, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_stock_artcoltall.aspx', NULL UNION ALL
SELECT N'200200000', 303, N'Stock por Artículo', 301, 2, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_stock_articulo.aspx', NULL UNION ALL
SELECT N'200200000', 304, N'Stock Artículos por Tienda', 301, 3, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_stock_artic_tienda.aspx', NULL UNION ALL
SELECT N'200200000', 305, N'Documentos', 300, 2, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'200200000', 306, N'Docu. Emitidos', 305, 1, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_docuemi.aspx', NULL UNION ALL
SELECT N'200200000', 307, N'Docu. Emitidos (Tickets)', 305, 2, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_docuemi_tickets.aspx', NULL UNION ALL
SELECT N'200200000', 308, N'Docu. Emitidos con Detalle', 305, 3, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_docuemi_condeta.aspx', NULL UNION ALL
SELECT N'200200000', 309, N'Docu. Emitidos de Venta', 305, 4, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_docuemi_venta.aspx', NULL UNION ALL
SELECT N'200200000', 310, N'Conciliaciones', 300, 3, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'200200000', 311, N'Listado de Inventarios', 310, 1, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_inventario.aspx', NULL UNION ALL
SELECT N'200200000', 312, N'Conc. de Inventario', 310, 2, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_conc_inv.aspx', NULL UNION ALL
SELECT N'200200000', 313, N'Conc. de Doc.Tienda', 310, 3, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_conc_doctda.aspx', NULL UNION ALL
SELECT N'200200000', 314, N'Conc. de Doc.Traspasos', 310, 3, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_conc_doctraspasos.aspx', NULL UNION ALL
SELECT N'200200000', 315, N'Ranking', 300, 4, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'200200000', 316, N'Rank Ventas x Tiendas', 315, 1, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_rank_vtas_tdas.aspx', NULL UNION ALL
SELECT N'200200000', 317, N'Rank Ventas x Vendedor', 315, 2, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_rank_vtas_vend.aspx', NULL UNION ALL
SELECT N'200200000', 318, N'Rank Ventas x Cliente', 315, 3, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_rank_vtas_cliente.aspx', NULL UNION ALL
SELECT N'200200000', 319, N'Analisis de Ventas', 315, 4, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'200200000', 320, N'Ventas x Artículo', 300, 5, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_vtas_articulo.aspx', NULL UNION ALL
SELECT N'200200000', 321, N'Ventas Artículo-Color-Talla', 320, 1, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_rank_vtas_artcoltall.aspx', NULL UNION ALL
SELECT N'200200000', 322, N'Ventas Diarias x Tienda', 320, 2, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_rank_vtas_diariasxtda.aspx', NULL UNION ALL
SELECT N'200200000', 323, N'Analisis por Semana', 320, 3, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_rank_vtas_analisisxsemana.aspx', NULL UNION ALL
SELECT N'200200000', 324, N'Stocks vs Ventas', 300, 6, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'200200000', 325, N'Stock vs Ventas x Artículo', 324, 1, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_stocksvsvtas_articulo.aspx', NULL
COMMIT;
RAISERROR (N'[dbo].[tb_perfilitems]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[tb_perfilitems]([idper], [menid], [descr], [padid], [posic], [grupo], [icono], [habil], [pgurl], [nivelacc])
SELECT N'200200000', 326, N'Stock vs Ventas x Articulo-Color-Talla', 324, 2, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_rank_stocksvsventas_artcoltall.aspx', NULL UNION ALL
SELECT N'200200000', 400, N'Procesos', 400, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'200200000', 500, N'Utilitarios', 500, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'200200000', 501, N'Impresion de CodBar', 500, 1, NULL, NULL, 1, N'D70PRODU/0100PRODU/pp_codigobarra.aspx', NULL UNION ALL
SELECT N'600200000', 100, N'Archivos', 100, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600200000', 101, N'Consultar Pedido', 100, 1, NULL, NULL, 1, N'D20COMER/0200PEDID/pedido_consultar.aspx', NULL UNION ALL
SELECT N'600200000', 102, N'Consultar OrdProd', 100, 2, NULL, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_consultar.aspx', NULL UNION ALL
SELECT N'600200000', 103, N'Documento de Almacén', 100, 3, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600200000', 104, N'Nuevo Documento', 103, 1, NULL, NULL, 1, N'D60ALMAC/0200PTERM/pt_movimiento_registrar.aspx', NULL UNION ALL
SELECT N'600200000', 105, N'Modificar Documento', 103, 2, NULL, NULL, 1, N'D60ALMAC/0200PTERM/pt_movimiento_modificar.aspx', NULL UNION ALL
SELECT N'600200000', 106, N'Consultar Doc.Almacén', 103, 3, NULL, NULL, 1, N'D60ALMAC/0200PTERM/pt_movimiento_consultar.aspx', NULL UNION ALL
SELECT N'600200000', 200, N'Catálogo', 200, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600200000', 201, N'Constantes Generales', 200, 1, NULL, NULL, 1, N'CATALOGO/GENERAL/constantesgenerales.aspx', NULL UNION ALL
SELECT N'600200000', 202, N'Serie de Documentos', 200, 2, NULL, NULL, 1, N'CATALOGO/GENERAL/modulolocaltipdocseries.aspx', NULL UNION ALL
SELECT N'600200000', 203, N'Clientes', 200, 3, NULL, NULL, 1, N'CATALOGO/GENERAL/cliente.aspx', NULL UNION ALL
SELECT N'600200000', 204, N'Agentes Vendedores', 200, 4, NULL, NULL, 1, N'CATALOGO/GENERAL/vendedorcorporativo.aspx', NULL UNION ALL
SELECT N'600200000', 205, N'Brokers', 200, 4, NULL, NULL, 1, N'CATALOGO/GENERAL/broker.aspx', NULL UNION ALL
SELECT N'600200000', 206, N'Transportistas', 200, 5, NULL, NULL, 1, N'CATALOGO/GENERAL/transportista.aspx', NULL UNION ALL
SELECT N'600200000', 300, N'Listados', 300, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600200000', 301, N'Stock Detallado', 300, 1, NULL, NULL, 1, N'D60ALMAC/0200PTERM/pt_stock_detallado.aspx', NULL UNION ALL
SELECT N'600200000', 302, N'Stock Resumido', 300, 2, NULL, NULL, 1, N'D60ALMAC/0200PTERM/pt_stock_resumido.aspx', NULL UNION ALL
SELECT N'600200000', 303, N'Kardex por Artículo', 300, 3, NULL, NULL, 1, N'D60ALMAC/0200PTERM/pt_kardex_articulo.aspx', NULL UNION ALL
SELECT N'600200000', 304, N'Kardex por Ord.Prod.', 300, 4, NULL, NULL, 1, N'D60ALMAC/0200PTERM/pt_kardex_ordprod.aspx', NULL UNION ALL
SELECT N'600200000', 305, N'Inventario', 300, 5, NULL, NULL, 1, N'D60ALMAC/0200PTERM/pt_inventario_listar.aspx', NULL UNION ALL
SELECT N'600200000', 306, N'Conciliación de Inventario', 300, 6, NULL, NULL, 1, N'D60ALMAC/0200PTERM/pt_inventario_conciliacion.aspx', NULL UNION ALL
SELECT N'600200000', 307, N'Ventas por Artículo', 300, 7, NULL, NULL, 1, N'D60ALMAC/0200PTERM/pt_ventas_articulo.aspx', NULL UNION ALL
SELECT N'600200000', 308, N'Ventas Netas por Cliente', 300, 8, NULL, NULL, 1, N'D60ALMAC/0200PTERM/pt_ventas_cliente.aspx', NULL UNION ALL
SELECT N'600200000', 309, N'Ventas Netas por Vendedor', 300, 9, NULL, NULL, 1, N'D60ALMAC/0200PTERM/pt_ventas_vendedor.aspx', NULL UNION ALL
SELECT N'600200000', 310, N'Ventas Netas al Personal', 300, 10, NULL, NULL, 1, N'D60ALMAC/0200PTERM/pt_ventas_personal.aspx', NULL UNION ALL
SELECT N'600200000', 400, N'Procesos', 400, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600200000', 500, N'Utilitarios', 500, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600200000', 501, N'Impresion de CodBar', 500, 1, NULL, NULL, 1, N'D70PRODU/0100PRODU/pp_codigobarra.aspx', NULL UNION ALL
SELECT N'501000000', 100, N'Archivos', 100, 0, 1, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'501000000', 101, N'Consulta al Kardex', 100, 1, 1, NULL, 1, N'D60ALMACEN/tb_rpt_kardex.aspx', NULL UNION ALL
SELECT N'501000000', 102, N'Consultar OrdProd', 100, 2, 1, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_consultar.aspx', NULL UNION ALL
SELECT N'501000000', 103, N'Rollos', 100, 3, 1, NULL, 1, N'D60ALMACEN/tb_producto_rollo.aspx', NULL UNION ALL
SELECT N'501000000', 104, N'Documento de Almacén', 100, 4, 1, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'501000000', 105, N'Emitir Documento', 104, 1, 1, NULL, 1, N'D60ALMACEN/tb_movimientorollo_mantenimiento.aspx', NULL UNION ALL
SELECT N'501000000', 200, N'Catálogo', 200, 0, 2, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'501000000', 201, N'Productos', 200, 1, 2, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'501000000', 202, N'Lineas', 201, 2, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_linea.aspx', NULL UNION ALL
SELECT N'501000000', 203, N'Proveedores', 201, 3, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_grupo.aspx', NULL UNION ALL
SELECT N'501000000', 204, N'Artículos', 201, 4, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_subgrupo.aspx', NULL UNION ALL
SELECT N'501000000', 205, N'Producto', 201, 5, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_productos.aspx', NULL UNION ALL
SELECT N'501000000', 206, N'Constantes Generales', 200, 2, 2, NULL, 1, N'D00MAESTROS/constantesgenerales.aspx', NULL UNION ALL
SELECT N'501000000', 207, N'Tipo de Documentos', 200, 3, 2, NULL, 1, N'D00MAESTROS/modulolocaltipdoc.aspx', NULL UNION ALL
SELECT N'501000000', 208, N'Serie de Documentos', 200, 4, 2, NULL, 1, N'D00MAESTROS/modulolocaltipdocseries.aspx', NULL UNION ALL
SELECT N'501000000', 209, N'Tributo-Tasa', 200, 5, 2, NULL, 1, N'D00MAESTROS/tributostasa.aspx', NULL UNION ALL
SELECT N'501000000', 210, N'Tipo de Cambio', 200, 6, 2, NULL, 1, N'D00MAESTROS/tipodecambio.aspx', NULL UNION ALL
SELECT N'501000000', 211, N'Tipos de Doc.Identidad', 200, 7, 2, NULL, 1, N'D00MAESTROS/tipdocidentidad.aspx', NULL
COMMIT;
RAISERROR (N'[dbo].[tb_perfilitems]: Insert Batch: 2.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[tb_perfilitems]([idper], [menid], [descr], [padid], [posic], [grupo], [icono], [habil], [pgurl], [nivelacc])
SELECT N'501000000', 212, N'Proveedor-Cliente', 200, 8, 2, NULL, 1, N'D00MAESTROS/cliente.aspx', NULL UNION ALL
SELECT N'501000000', 213, N'Transportistas', 200, 9, 2, NULL, 1, N'D00MAESTROS/transportistas.aspx', NULL UNION ALL
SELECT N'501000000', 214, N'Vendedores', 200, 10, 2, NULL, 1, N'D00MAESTROS/vendedorcorporativo.aspx', NULL UNION ALL
SELECT N'501000000', 215, N'Centros de Costo', 200, 11, 2, NULL, 1, N'D00MAESTROS/centrosdecosto.aspx', NULL UNION ALL
SELECT N'501000000', 300, N'Listados', 300, 0, 3, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'501000000', 301, N'Balance de Stock', 300, 1, 3, NULL, 1, N'D60ALMACEN/tb_balancestock.aspx', NULL UNION ALL
SELECT N'501000000', 302, N'Documentos del Período', 300, 2, 3, NULL, 1, N'D60ALMACEN/tb_local_reportediario.aspx', NULL UNION ALL
SELECT N'501000000', 303, N'Stock por Artículo', 300, 3, 3, NULL, 1, N'D60ALMACEN/tb_stock_articulo.aspx', NULL UNION ALL
SELECT N'501000000', 304, N'Stock por Rollos', 300, 4, 3, NULL, 1, N'D60ALMACEN/tb_stock_rollos.aspx', NULL UNION ALL
SELECT N'501000000', 305, N'Kardex por Artículo', 300, 5, 3, NULL, 1, N'D60ALMACEN/tb_kardex_articulo.aspx', NULL UNION ALL
SELECT N'501000000', 306, N'Kardex por Rollos', 300, 6, 3, NULL, 1, N'D60ALMACEN/tb_kardex_rollo.aspx', NULL UNION ALL
SELECT N'501000000', 307, N'Inventario', 300, 7, 3, NULL, 1, N'D60ALMACEN/tb_inventario_listar.aspx', NULL UNION ALL
SELECT N'501000000', 308, N'Consumos por OP', 300, 8, 3, NULL, 1, N'D60ALMACEN/tb_consumo_op.aspx', NULL UNION ALL
SELECT N'501000000', 400, N'Procesos', 400, 0, 4, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'501000000', 401, N'Reorganización', 400, 1, 4, NULL, 1, N'D60ALMACEN/tb_local_reorganizacion.aspx', NULL UNION ALL
SELECT N'501000000', 402, N'Toma de Inventario', 400, 2, 4, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'501000000', 403, N'Generar Archivo de Trabajo', 402, 1, 4, NULL, 1, N'D60ALMACEN/tb_inventario_generafilework.aspx', NULL UNION ALL
SELECT N'501000000', 404, N'Listado para Toma de Inventario', 402, 2, 4, NULL, 1, N'D60ALMACEN/tb_inventario_listadotoma.aspx', NULL UNION ALL
SELECT N'501000000', 405, N'Carga Masiva de Inventario', 402, 3, 4, NULL, 1, N'D60ALMACEN/tb_inventario_cargamasiva.aspx', NULL UNION ALL
SELECT N'501000000', 406, N'Transferencia a Archivo Trabajo', 402, 4, 4, NULL, 1, N'D60ALMACEN/tb_inventario_transferarchtrab.aspx', NULL UNION ALL
SELECT N'501000000', 407, N'Digitación Diferencias de Inventario', 402, 5, 4, NULL, 1, N'DD60ALMACEN/tb_inventario_digitacion.aspx', NULL UNION ALL
SELECT N'501000000', 408, N'Listado Diferencias de Inventario', 402, 6, 4, NULL, 1, N'D60ALMACEN/tb_inventario_listadodiferencias.aspx', NULL UNION ALL
SELECT N'501000000', 409, N'Conformidad Toma de Inventario', 402, 7, 4, NULL, 1, N'D60ALMACEN/tb_inventario_conformidad.aspx', NULL UNION ALL
SELECT N'501000000', 410, N'Cierre de Período', 400, 3, 4, NULL, 1, N'D60ALMACEN/tb_local_cierredeperiodo.aspx', NULL UNION ALL
SELECT N'501000000', 411, N'Reorganización de Histórico', 400, 4, 4, NULL, 1, N'D60ALMACEN/tb_local_reorganizacionhistorico.aspx', NULL UNION ALL
SELECT N'501000000', 412, N'Cierre de Período Inicio Operaciones', 400, 3, 4, NULL, 1, N'D60ALMACEN/tb_local_cierredeperiodo_inioperac.aspx', NULL UNION ALL
SELECT N'501000000', 500, N'Utilitarios', 500, 0, 5, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'501000000', 501, N'Borrado de Tablas', 500, 1, 5, NULL, 1, N'D60ALMACEN/tb_util_borratablas.aspx', NULL UNION ALL
SELECT N'501000000', 502, N'Copia de Tablas', 500, 2, 5, NULL, 1, N'D60ALMACEN/tb_util_copiatablas.aspx', NULL UNION ALL
SELECT N'501000000', 503, N'Exportación de Tablas', 500, 3, 5, NULL, 1, N'D60ALMACEN/tb_util_exportatablas.aspx', NULL UNION ALL
SELECT N'501000000', 504, N'Impresion de CodBar', 500, 4, 5, NULL, 1, N'D60ALMACEN/tb_codigobarra.aspx', NULL UNION ALL
SELECT N'600320000', 100, N'Archivos', 100, 0, 1, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600320000', 101, N'Consulta al Kardex', 100, 1, 1, NULL, 1, N'D60ALMACEN/tb_rpt_kardex.aspx', NULL UNION ALL
SELECT N'600320000', 102, N'Consultar OrdProd', 100, 2, 1, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_consultar.aspx', NULL UNION ALL
SELECT N'600320000', 103, N'Rollos', 100, 3, 1, NULL, 1, N'D60ALMACEN/tb_producto_rollo.aspx', NULL UNION ALL
SELECT N'600320000', 104, N'Documento de Almacén', 100, 4, 1, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600320000', 105, N'Emitir Documento', 104, 1, 1, NULL, 1, N'D60ALMACEN/tb_movimientorollo_mantenimiento.aspx', NULL UNION ALL
SELECT N'600320000', 200, N'Catálogo', 200, 0, 2, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600320000', 201, N'Productos', 200, 1, 2, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600320000', 202, N'Lineas', 201, 2, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_linea.aspx', NULL UNION ALL
SELECT N'600320000', 203, N'Proveedores', 201, 3, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_grupo.aspx', NULL UNION ALL
SELECT N'600320000', 204, N'Artículos', 201, 4, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_subgrupo.aspx', NULL UNION ALL
SELECT N'600320000', 205, N'Producto', 201, 5, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_productos.aspx', NULL UNION ALL
SELECT N'600320000', 206, N'Constantes Generales', 200, 2, 2, NULL, 1, N'D00MAESTROS/constantesgenerales.aspx', NULL UNION ALL
SELECT N'600320000', 207, N'Tipo de Documentos', 200, 3, 2, NULL, 1, N'D00MAESTROS/modulolocaltipdoc.aspx', NULL UNION ALL
SELECT N'600320000', 208, N'Serie de Documentos', 200, 4, 2, NULL, 1, N'D00MAESTROS/modulolocaltipdocseries.aspx', NULL UNION ALL
SELECT N'600320000', 209, N'Tributo-Tasa', 200, 5, 2, NULL, 1, N'D00MAESTROS/tributostasa.aspx', NULL UNION ALL
SELECT N'600320000', 210, N'Tipo de Cambio', 200, 6, 2, NULL, 1, N'D00MAESTROS/tipodecambio.aspx', NULL UNION ALL
SELECT N'600320000', 211, N'Tipos de Doc.Identidad', 200, 7, 2, NULL, 1, N'D00MAESTROS/tipdocidentidad.aspx', NULL UNION ALL
SELECT N'600320000', 212, N'Proveedor-Cliente', 200, 8, 2, NULL, 1, N'D00MAESTROS/cliente.aspx', NULL
COMMIT;
RAISERROR (N'[dbo].[tb_perfilitems]: Insert Batch: 3.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[tb_perfilitems]([idper], [menid], [descr], [padid], [posic], [grupo], [icono], [habil], [pgurl], [nivelacc])
SELECT N'600320000', 213, N'Transportistas', 200, 9, 2, NULL, 1, N'D00MAESTROS/transportistas.aspx', NULL UNION ALL
SELECT N'600320000', 214, N'Vendedores', 200, 10, 2, NULL, 1, N'D00MAESTROS/vendedorcorporativo.aspx', NULL UNION ALL
SELECT N'600320000', 215, N'Centros de Costo', 200, 11, 2, NULL, 1, N'D00MAESTROS/centrosdecosto.aspx', NULL UNION ALL
SELECT N'600320000', 300, N'Listados', 300, 0, 3, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600320000', 301, N'Balance de Stock', 300, 1, 3, NULL, 1, N'D60ALMACEN/tb_balancestock.aspx', NULL UNION ALL
SELECT N'600320000', 302, N'Documentos del Período', 300, 2, 3, NULL, 1, N'D60ALMACEN/tb_local_reportediario.aspx', NULL UNION ALL
SELECT N'600320000', 303, N'Stock por Artículo', 300, 3, 3, NULL, 1, N'D60ALMACEN/tb_stock_articulo.aspx', NULL UNION ALL
SELECT N'600320000', 304, N'Stock por Rollos', 300, 4, 3, NULL, 1, N'D60ALMACEN/tb_stock_rollos.aspx', NULL UNION ALL
SELECT N'600320000', 305, N'Kardex por Artículo', 300, 5, 3, NULL, 1, N'D60ALMACEN/tb_kardex_articulo.aspx', NULL UNION ALL
SELECT N'600320000', 306, N'Kardex por Rollos', 300, 6, 3, NULL, 1, N'D60ALMACEN/tb_kardex_rollo.aspx', NULL UNION ALL
SELECT N'600320000', 307, N'Inventario', 300, 7, 3, NULL, 1, N'D60ALMACEN/tb_inventario_listar.aspx', NULL UNION ALL
SELECT N'600320000', 308, N'Consumos por OP', 300, 8, 3, NULL, 1, N'D60ALMACEN/tb_consumo_op.aspx', NULL UNION ALL
SELECT N'600320000', 400, N'Procesos', 400, 0, 4, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600320000', 401, N'Reorganización', 400, 1, 4, NULL, 1, N'D60ALMACEN/tb_local_reorganizacion.aspx', NULL UNION ALL
SELECT N'600320000', 402, N'Toma de Inventario', 400, 2, 4, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600320000', 403, N'Generar Archivo de Trabajo', 402, 1, 4, NULL, 1, N'D60ALMACEN/tb_inventario_generafilework.aspx', NULL UNION ALL
SELECT N'600320000', 404, N'Listado para Toma de Inventario', 402, 2, 4, NULL, 1, N'D60ALMACEN/tb_inventario_listadotoma.aspx', NULL UNION ALL
SELECT N'600320000', 405, N'Carga Masiva de Inventario', 402, 3, 4, NULL, 1, N'D60ALMACEN/tb_inventario_cargamasiva.aspx', NULL UNION ALL
SELECT N'600320000', 406, N'Transferencia a Archivo Trabajo', 402, 4, 4, NULL, 1, N'D60ALMACEN/tb_inventario_transferarchtrab.aspx', NULL UNION ALL
SELECT N'600320000', 407, N'Digitación Diferencias de Inventario', 402, 5, 4, NULL, 1, N'DD60ALMACEN/tb_inventario_digitacion.aspx', NULL UNION ALL
SELECT N'600320000', 408, N'Listado Diferencias de Inventario', 402, 6, 4, NULL, 1, N'D60ALMACEN/tb_inventario_listadodiferencias.aspx', NULL UNION ALL
SELECT N'600320000', 409, N'Conformidad Toma de Inventario', 402, 7, 4, NULL, 1, N'D60ALMACEN/tb_inventario_conformidad.aspx', NULL UNION ALL
SELECT N'600320000', 410, N'Cierre de Período', 400, 3, 4, NULL, 1, N'D60ALMACEN/tb_local_cierredeperiodo.aspx', NULL UNION ALL
SELECT N'600320000', 411, N'Reorganización de Histórico', 400, 4, 4, NULL, 1, N'D60ALMACEN/tb_local_reorganizacionhistorico.aspx', NULL UNION ALL
SELECT N'600320000', 412, N'Cierre de Período Inicio Operaciones', 400, 3, 4, NULL, 1, N'D60ALMACEN/tb_local_cierredeperiodo_inioperac.aspx', NULL UNION ALL
SELECT N'600320000', 500, N'Utilitarios', 500, 0, 5, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600320000', 501, N'Borrado de Tablas', 500, 1, 5, NULL, 1, N'D60ALMACEN/tb_util_borratablas.aspx', NULL UNION ALL
SELECT N'600320000', 502, N'Copia de Tablas', 500, 2, 5, NULL, 1, N'D60ALMACEN/tb_util_copiatablas.aspx', NULL UNION ALL
SELECT N'600320000', 503, N'Exportación de Tablas', 500, 3, 5, NULL, 1, N'D60ALMACEN/tb_util_exportatablas.aspx', NULL UNION ALL
SELECT N'600320000', 504, N'Impresion de CodBar', 500, 4, 5, NULL, 1, N'D60ALMACEN/tb_codigobarra.aspx', NULL UNION ALL
SELECT N'600320001', 100, N'Archivos', 100, 0, 1, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600320001', 101, N'Consulta al Kardex', 100, 1, 1, NULL, 1, N'D60ALMACEN/tb_rpt_kardex.aspx', NULL UNION ALL
SELECT N'600320001', 102, N'Consultar OrdProd', 100, 2, 1, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_consultar.aspx', NULL UNION ALL
SELECT N'600320001', 103, N'Rollos', 100, 3, 1, NULL, 1, N'D60ALMACEN/tb_producto_rollo.aspx', NULL UNION ALL
SELECT N'600320001', 104, N'Documento de Almacén', 100, 4, 1, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600320001', 105, N'Emitir Documento', 104, 1, 1, NULL, 1, N'D60ALMACEN/tb_movimientorollo_mantenimiento.aspx', NULL UNION ALL
SELECT N'600320001', 200, N'Catálogo', 200, 0, 2, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600320001', 201, N'Productos', 200, 1, 2, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600320001', 202, N'Lineas', 201, 2, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_linea.aspx', NULL UNION ALL
SELECT N'600320001', 203, N'Proveedores', 201, 3, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_grupo.aspx', NULL UNION ALL
SELECT N'600320001', 204, N'Artículos', 201, 4, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_subgrupo.aspx', NULL UNION ALL
SELECT N'600320001', 205, N'Producto', 201, 5, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_productos.aspx', NULL UNION ALL
SELECT N'600320001', 212, N'Proveedor-Cliente', 200, 8, 2, NULL, 1, N'D00MAESTROS/cliente.aspx', NULL UNION ALL
SELECT N'600320001', 300, N'Listados', 300, 0, 3, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600320001', 301, N'Balance de Stock', 300, 1, 3, NULL, 1, N'D60ALMACEN/tb_balancestock.aspx', NULL UNION ALL
SELECT N'600320001', 302, N'Documentos del Período', 300, 2, 3, NULL, 1, N'D60ALMACEN/tb_local_reportediario.aspx', NULL UNION ALL
SELECT N'600320001', 308, N'Consumos por OP', 300, 8, 3, NULL, 1, N'D60ALMACEN/tb_consumo_op.aspx', NULL UNION ALL
SELECT N'600320001', 504, N'Impresion de CodBar', 500, 4, 5, NULL, 1, N'D60ALMACEN/tb_codigobarra.aspx', NULL UNION ALL
SELECT N'600330000', 100, N'Archivos', 100, 0, 1, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600330000', 101, N'Consulta al Kardex', 100, 1, 1, NULL, 1, N'D60ALMACEN/tb_rpt_kardex.aspx', NULL
COMMIT;
RAISERROR (N'[dbo].[tb_perfilitems]: Insert Batch: 4.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[tb_perfilitems]([idper], [menid], [descr], [padid], [posic], [grupo], [icono], [habil], [pgurl], [nivelacc])
SELECT N'600330000', 102, N'Consultar OrdProd', 100, 2, 1, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_consultar.aspx', NULL UNION ALL
SELECT N'600330000', 104, N'Documento de Almacén', 100, 4, 1, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600330000', 105, N'Emitir Documento', 104, 1, 1, NULL, 1, N'D60ALMACEN/tb_movimiento_mantenimiento.aspx', NULL UNION ALL
SELECT N'600330000', 200, N'Catálogo', 200, 0, 2, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600330000', 201, N'Productos', 200, 1, 2, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600330000', 202, N'Lineas', 201, 2, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_linea.aspx', NULL UNION ALL
SELECT N'600330000', 203, N'Proveedores', 201, 3, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_grupo.aspx', NULL UNION ALL
SELECT N'600330000', 204, N'Artículos', 201, 4, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_subgrupo.aspx', NULL UNION ALL
SELECT N'600330000', 205, N'Producto', 201, 5, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_productos.aspx', NULL UNION ALL
SELECT N'600330000', 206, N'Constantes Generales', 200, 2, 2, NULL, 1, N'D00MAESTROS/constantesgenerales.aspx', NULL UNION ALL
SELECT N'600330000', 207, N'Tipo de Documentos', 200, 3, 2, NULL, 1, N'D00MAESTROS/modulolocaltipdoc.aspx', NULL UNION ALL
SELECT N'600330000', 208, N'Serie de Documentos', 200, 4, 2, NULL, 1, N'D00MAESTROS/modulolocaltipdocseries.aspx', NULL UNION ALL
SELECT N'600330000', 209, N'Tributo-Tasa', 200, 5, 2, NULL, 1, N'D00MAESTROS/tributostasa.aspx', NULL UNION ALL
SELECT N'600330000', 210, N'Tipo de Cambio', 200, 6, 2, NULL, 1, N'D00MAESTROS/tipodecambio.aspx', NULL UNION ALL
SELECT N'600330000', 211, N'Tipos de Doc.Identidad', 200, 7, 2, NULL, 1, N'D00MAESTROS/tipdocidentidad.aspx', NULL UNION ALL
SELECT N'600330000', 212, N'Proveedor-Cliente', 200, 8, 2, NULL, 1, N'D00MAESTROS/cliente.aspx', NULL UNION ALL
SELECT N'600330000', 213, N'Transportistas', 200, 9, 2, NULL, 1, N'D00MAESTROS/transportistas.aspx', NULL UNION ALL
SELECT N'600330000', 214, N'Vendedores', 200, 10, 2, NULL, 1, N'D00MAESTROS/vendedorcorporativo.aspx', NULL UNION ALL
SELECT N'600330000', 215, N'Centros de Costo', 200, 11, 2, NULL, 1, N'D00MAESTROS/centrosdecosto.aspx', NULL UNION ALL
SELECT N'600330000', 300, N'Listados', 300, 0, 3, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600330000', 301, N'Balance de Stock', 300, 1, 3, NULL, 1, N'D60ALMACEN/tb_balancestock.aspx', NULL UNION ALL
SELECT N'600330000', 302, N'Documentos del Período', 300, 2, 3, NULL, 1, N'D60ALMACEN/tb_local_reportediario.aspx', NULL UNION ALL
SELECT N'600330000', 303, N'Stock por Artículo', 300, 3, 3, NULL, 1, N'D60ALMACEN/tb_stock_articulo.aspx', NULL UNION ALL
SELECT N'600330000', 304, N'Stock por Rollos', 300, 4, 3, NULL, 1, N'D60ALMACEN/tb_stock_rollos.aspx', NULL UNION ALL
SELECT N'600330000', 305, N'Kardex por Artículo', 300, 5, 3, NULL, 1, N'D60ALMACEN/tb_kardex_articulo.aspx', NULL UNION ALL
SELECT N'600330000', 306, N'Kardex por Rollos', 300, 6, 3, NULL, 1, N'D60ALMACEN/tb_kardex_rollo.aspx', NULL UNION ALL
SELECT N'600330000', 307, N'Inventario', 300, 7, 3, NULL, 1, N'D60ALMACEN/tb_inventario_listar.aspx', NULL UNION ALL
SELECT N'600330000', 308, N'Consumos por OP', 300, 8, 3, NULL, 1, N'D60ALMACEN/tb_consumo_op.aspx', NULL UNION ALL
SELECT N'600330000', 400, N'Procesos', 400, 0, 4, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600330000', 401, N'Reorganización', 400, 1, 4, NULL, 1, N'D60ALMACEN/tb_local_reorganizacion.aspx', NULL UNION ALL
SELECT N'600330000', 402, N'Toma de Inventario', 400, 2, 4, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600330000', 403, N'Generar Archivo de Trabajo', 402, 1, 4, NULL, 1, N'D60ALMACEN/tb_inventario_generafilework.aspx', NULL UNION ALL
SELECT N'600330000', 404, N'Listado para Toma de Inventario', 402, 2, 4, NULL, 1, N'D60ALMACEN/tb_inventario_listadotoma.aspx', NULL UNION ALL
SELECT N'600330000', 405, N'Carga Masiva de Inventario', 402, 3, 4, NULL, 1, N'D60ALMACEN/tb_inventario_cargamasiva.aspx', NULL UNION ALL
SELECT N'600330000', 406, N'Transferencia a Archivo Trabajo', 402, 4, 4, NULL, 1, N'D60ALMACEN/tb_inventario_transferarchtrab.aspx', NULL UNION ALL
SELECT N'600330000', 407, N'Digitación Diferencias de Inventario', 402, 5, 4, NULL, 1, N'DD60ALMACEN/tb_inventario_digitacion.aspx', NULL UNION ALL
SELECT N'600330000', 408, N'Listado Diferencias de Inventario', 402, 6, 4, NULL, 1, N'D60ALMACEN/tb_inventario_listadodiferencias.aspx', NULL UNION ALL
SELECT N'600330000', 409, N'Conformidad Toma de Inventario', 402, 7, 4, NULL, 1, N'D60ALMACEN/tb_inventario_conformidad.aspx', NULL UNION ALL
SELECT N'600330000', 410, N'Cierre de Período', 400, 3, 4, NULL, 1, N'D60ALMACEN/tb_local_cierredeperiodo.aspx', NULL UNION ALL
SELECT N'600330000', 411, N'Reorganización de Histórico', 400, 4, 4, NULL, 1, N'D60ALMACEN/tb_local_reorganizacionhistorico.aspx', NULL UNION ALL
SELECT N'600330000', 412, N'Cierre de Período Inicio de Operaciones', 400, 3, 4, NULL, 1, N'D60ALMACEN/tb_local_cierredeperiodo_inioperac.aspx', NULL UNION ALL
SELECT N'600330000', 500, N'Utilitarios', 500, 0, 5, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600330000', 501, N'Borrado de Tablas', 500, 1, 5, NULL, 1, N'D60ALMACEN/tb_util_borratablas.aspx', NULL UNION ALL
SELECT N'600330000', 502, N'Copia de Tablas', 500, 2, 5, NULL, 1, N'D60ALMACEN/tb_util_copiatablas.aspx', NULL UNION ALL
SELECT N'600330000', 503, N'Exportación de Tablas', 500, 3, 5, NULL, 1, N'D60ALMACEN/tb_util_exportatablas.aspx', NULL UNION ALL
SELECT N'600330000', 504, N'Impresion de CodBar', 500, 4, 5, NULL, 1, N'D60ALMACEN/tb_codigobarra.aspx', NULL UNION ALL
SELECT N'600330001', 100, N'Archivos', 100, 0, 1, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600330001', 101, N'Consulta al Kardex', 100, 1, 1, NULL, 1, N'D60ALMACEN/tb_rpt_kardex.aspx', NULL UNION ALL
SELECT N'600330001', 102, N'Consultar OrdProd', 100, 2, 1, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_consultar.aspx', NULL UNION ALL
SELECT N'600330001', 104, N'Documento de Almacén', 100, 4, 1, NULL, 1, N'main.aspx', NULL
COMMIT;
RAISERROR (N'[dbo].[tb_perfilitems]: Insert Batch: 5.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[tb_perfilitems]([idper], [menid], [descr], [padid], [posic], [grupo], [icono], [habil], [pgurl], [nivelacc])
SELECT N'600330001', 105, N'Emitir Documento', 104, 1, 1, NULL, 1, N'D60ALMACEN/tb_movimiento_mantenimiento.aspx', NULL UNION ALL
SELECT N'600330001', 200, N'Catálogo', 200, 0, 2, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600330001', 201, N'Productos', 200, 1, 2, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600330001', 202, N'Lineas', 201, 2, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_linea.aspx', NULL UNION ALL
SELECT N'600330001', 203, N'Proveedores', 201, 3, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_grupo.aspx', NULL UNION ALL
SELECT N'600330001', 204, N'Artículos', 201, 4, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_subgrupo.aspx', NULL UNION ALL
SELECT N'600330001', 205, N'Producto', 201, 5, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_productos.aspx', NULL UNION ALL
SELECT N'600330001', 300, N'Listados', 300, 0, 3, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600330001', 301, N'Balance de Stock', 300, 1, 3, NULL, 1, N'D60ALMACEN/tb_balancestock.aspx', NULL UNION ALL
SELECT N'600330001', 302, N'Documentos del Período', 300, 2, 3, NULL, 1, N'D60ALMACEN/tb_local_reportediario.aspx', NULL UNION ALL
SELECT N'600350000', 100, N'Archivos', 100, 0, 1, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600350000', 101, N'Consulta al Kardex', 100, 1, 1, NULL, 1, N'D60ALMACEN/tb_rpt_kardex.aspx', NULL UNION ALL
SELECT N'600350000', 102, N'Consultar OrdProd', 100, 2, 1, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_consultar.aspx', NULL UNION ALL
SELECT N'600350000', 104, N'Documento de Almacén', 100, 4, 1, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600350000', 105, N'Emitir Documento', 104, 1, 1, NULL, 1, N'D60ALMACEN/tb_movimiento_mantenimiento.aspx', NULL UNION ALL
SELECT N'600350000', 200, N'Catálogo', 200, 0, 2, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600350000', 201, N'Productos', 200, 1, 2, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600350000', 202, N'Lineas', 201, 2, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_linea.aspx', NULL UNION ALL
SELECT N'600350000', 203, N'Proveedores', 201, 3, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_grupo.aspx', NULL UNION ALL
SELECT N'600350000', 204, N'Artículos', 201, 4, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_subgrupo.aspx', NULL UNION ALL
SELECT N'600350000', 205, N'Producto', 201, 5, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_productos.aspx', NULL UNION ALL
SELECT N'600350000', 206, N'Constantes Generales', 200, 2, 2, NULL, 1, N'D00MAESTROS/constantesgenerales.aspx', NULL UNION ALL
SELECT N'600350000', 207, N'Tipo de Documentos', 200, 3, 2, NULL, 1, N'D00MAESTROS/modulolocaltipdoc.aspx', NULL UNION ALL
SELECT N'600350000', 208, N'Serie de Documentos', 200, 4, 2, NULL, 1, N'D00MAESTROS/modulolocaltipdocseries.aspx', NULL UNION ALL
SELECT N'600350000', 209, N'Tributo-Tasa', 200, 5, 2, NULL, 1, N'D00MAESTROS/tributostasa.aspx', NULL UNION ALL
SELECT N'600350000', 210, N'Tipo de Cambio', 200, 6, 2, NULL, 1, N'D00MAESTROS/tipodecambio.aspx', NULL UNION ALL
SELECT N'600350000', 211, N'Tipos de Doc.Identidad', 200, 7, 2, NULL, 1, N'D00MAESTROS/tipdocidentidad.aspx', NULL UNION ALL
SELECT N'600350000', 212, N'Proveedor-Cliente', 200, 8, 2, NULL, 1, N'D00MAESTROS/cliente.aspx', NULL UNION ALL
SELECT N'600350000', 213, N'Transportistas', 200, 9, 2, NULL, 1, N'D00MAESTROS/transportistas.aspx', NULL UNION ALL
SELECT N'600350000', 214, N'Vendedores', 200, 10, 2, NULL, 1, N'D00MAESTROS/vendedorcorporativo.aspx', NULL UNION ALL
SELECT N'600350000', 215, N'Centros de Costo', 200, 11, 2, NULL, 1, N'D00MAESTROS/centrosdecosto.aspx', NULL UNION ALL
SELECT N'600350000', 300, N'Listados', 300, 0, 3, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600350000', 301, N'Balance de Stock', 300, 1, 3, NULL, 1, N'D60ALMACEN/tb_balancestock.aspx', NULL UNION ALL
SELECT N'600350000', 302, N'Documentos del Período', 300, 2, 3, NULL, 1, N'D60ALMACEN/tb_local_reportediario.aspx', NULL UNION ALL
SELECT N'600350000', 303, N'Stock por Artículo', 300, 3, 3, NULL, 1, N'D60ALMACEN/tb_stock_articulo.aspx', NULL UNION ALL
SELECT N'600350000', 304, N'Stock por Rollos', 300, 4, 3, NULL, 1, N'D60ALMACEN/tb_stock_rollos.aspx', NULL UNION ALL
SELECT N'600350000', 305, N'Kardex por Artículo', 300, 5, 3, NULL, 1, N'D60ALMACEN/tb_kardex_articulo.aspx', NULL UNION ALL
SELECT N'600350000', 306, N'Kardex por Rollos', 300, 6, 3, NULL, 1, N'D60ALMACEN/tb_kardex_rollo.aspx', NULL UNION ALL
SELECT N'600350000', 307, N'Inventario', 300, 7, 3, NULL, 1, N'D60ALMACEN/tb_inventario_listar.aspx', NULL UNION ALL
SELECT N'600350000', 308, N'Consumos por OP', 300, 8, 3, NULL, 1, N'D60ALMACEN/tb_consumo_op.aspx', NULL UNION ALL
SELECT N'600350000', 400, N'Procesos', 400, 0, 4, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600350000', 401, N'Reorganización', 400, 1, 4, NULL, 1, N'D60ALMACEN/tb_local_reorganizacion.aspx', NULL UNION ALL
SELECT N'600350000', 402, N'Toma de Inventario', 400, 2, 4, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600350000', 403, N'Generar Archivo de Trabajo', 402, 1, 4, NULL, 1, N'D60ALMACEN/tb_inventario_generafilework.aspx', NULL UNION ALL
SELECT N'600350000', 404, N'Listado para Toma de Inventario', 402, 2, 4, NULL, 1, N'D60ALMACEN/tb_inventario_listadotoma.aspx', NULL UNION ALL
SELECT N'600350000', 405, N'Carga Masiva de Inventario', 402, 3, 4, NULL, 1, N'D60ALMACEN/tb_inventario_cargamasiva.aspx', NULL UNION ALL
SELECT N'600350000', 406, N'Transferencia a Archivo Trabajo', 402, 4, 4, NULL, 1, N'D60ALMACEN/tb_inventario_transferarchtrab.aspx', NULL UNION ALL
SELECT N'600350000', 407, N'Digitación Diferencias de Inventario', 402, 5, 4, NULL, 1, N'DD60ALMACEN/tb_inventario_digitacion.aspx', NULL UNION ALL
SELECT N'600350000', 408, N'Listado Diferencias de Inventario', 402, 6, 4, NULL, 1, N'D60ALMACEN/tb_inventario_listadodiferencias.aspx', NULL UNION ALL
SELECT N'600350000', 409, N'Conformidad Toma de Inventario', 402, 7, 4, NULL, 1, N'D60ALMACEN/tb_inventario_conformidad.aspx', NULL
COMMIT;
RAISERROR (N'[dbo].[tb_perfilitems]: Insert Batch: 6.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[tb_perfilitems]([idper], [menid], [descr], [padid], [posic], [grupo], [icono], [habil], [pgurl], [nivelacc])
SELECT N'600350000', 410, N'Cierre de Período', 400, 3, 4, NULL, 1, N'D60ALMACEN/tb_local_cierredeperiodo.aspx', NULL UNION ALL
SELECT N'600350000', 411, N'Reorganización de Histórico', 400, 4, 4, NULL, 1, N'D60ALMACEN/tb_local_reorganizacionhistorico.aspx', NULL UNION ALL
SELECT N'600350000', 412, N'Cierre de Período Inicio de Operaciones', 400, 3, 4, NULL, 1, N'D60ALMACEN/tb_local_cierredeperiodo_inioperac.aspx', NULL UNION ALL
SELECT N'600350000', 500, N'Utilitarios', 500, 0, 5, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600350000', 501, N'Borrado de Tablas', 500, 1, 5, NULL, 1, N'D60ALMACEN/tb_util_borratablas.aspx', NULL UNION ALL
SELECT N'600350000', 502, N'Copia de Tablas', 500, 2, 5, NULL, 1, N'D60ALMACEN/tb_util_copiatablas.aspx', NULL UNION ALL
SELECT N'600350000', 503, N'Exportación de Tablas', 500, 3, 5, NULL, 1, N'D60ALMACEN/tb_util_exportatablas.aspx', NULL UNION ALL
SELECT N'600350000', 504, N'Impresion de CodBar', 500, 4, 5, NULL, 1, N'D60ALMACEN/tb_codigobarra.aspx', NULL UNION ALL
SELECT N'600350001', 100, N'Archivos', 100, 0, 1, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600350001', 101, N'Consulta al Kardex', 100, 1, 1, NULL, 1, N'D60ALMACEN/tb_rpt_kardex.aspx', NULL UNION ALL
SELECT N'600350001', 102, N'Consultar OrdProd', 100, 2, 1, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_consultar.aspx', NULL UNION ALL
SELECT N'600350001', 104, N'Documento de Almacén', 100, 4, 1, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600350001', 105, N'Emitir Documento', 104, 1, 1, NULL, 1, N'D60ALMACEN/tb_movimiento_mantenimiento.aspx', NULL UNION ALL
SELECT N'600350001', 200, N'Catálogo', 200, 0, 2, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600350001', 201, N'Productos', 200, 1, 2, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600350001', 202, N'Lineas', 201, 2, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_linea.aspx', NULL UNION ALL
SELECT N'600350001', 203, N'Proveedores', 201, 3, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_grupo.aspx', NULL UNION ALL
SELECT N'600350001', 204, N'Artículos', 201, 4, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_subgrupo.aspx', NULL UNION ALL
SELECT N'600350001', 205, N'Producto', 201, 5, 2, NULL, 1, N'D60ALMACEN/CATALOGO/tb_productos.aspx', NULL UNION ALL
SELECT N'600350001', 212, N'Proveedor-Cliente', 200, 8, 2, NULL, 1, N'D00MAESTROS/cliente.aspx', NULL UNION ALL
SELECT N'600350001', 300, N'Listados', 300, 0, 3, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600350001', 301, N'Balance de Stock', 300, 1, 3, NULL, 1, N'D60ALMACEN/tb_balancestock.aspx', NULL UNION ALL
SELECT N'600350001', 302, N'Documentos del Período', 300, 2, 3, NULL, 1, N'D60ALMACEN/tb_local_reportediario.aspx', NULL UNION ALL
SELECT N'600390000', 100, N'Archivos', 100, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600390000', 101, N'Consulta al Kardex', 100, 1, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_rpt_kardex.aspx', NULL UNION ALL
SELECT N'600390000', 102, N'Consultar OrdProd', 100, 2, NULL, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_consultar.aspx', NULL UNION ALL
SELECT N'600390000', 103, N'Rollos', 100, 3, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_prodrollo.aspx', NULL UNION ALL
SELECT N'600390000', 104, N'Documento de Almacén', 100, 4, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600390000', 105, N'Nuevo Documento', 104, 1, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_movimiento_registrar.aspx', NULL UNION ALL
SELECT N'600390000', 106, N'Modificar Documento', 104, 2, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_movimiento_modificar.aspx', NULL UNION ALL
SELECT N'600390000', 107, N'Consultar Doc.Almacén', 104, 3, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_movimiento_consultar.aspx', NULL UNION ALL
SELECT N'600390000', 108, N'Documento de Almacén (Rollo)', 100, 5, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600390000', 109, N'Nuevo Documento (Rollo)', 108, 1, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_movimiento2_registrar.aspx', NULL UNION ALL
SELECT N'600390000', 110, N'Modificar Documento (Rollo)', 108, 2, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_movimiento2_modificar.aspx', NULL UNION ALL
SELECT N'600390000', 111, N'Consultar Doc.Almacén (Rollo)', 108, 3, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_movimiento2_consultar.aspx', NULL UNION ALL
SELECT N'600390000', 200, N'Catálogo', 200, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600390000', 201, N'Productos', 200, 1, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600390000', 202, N'Lineas', 201, 2, NULL, NULL, 1, N'CATALOGO/D60ALMAC/0390TELAC/mp_linea.aspx', NULL UNION ALL
SELECT N'600390000', 203, N'Proveedores', 201, 3, NULL, NULL, 1, N'CATALOGO/D60ALMAC/0390TELAC/mp_grupo.aspx', NULL UNION ALL
SELECT N'600390000', 204, N'Artículos', 201, 4, NULL, NULL, 1, N'CATALOGO/D60ALMAC/0390TELAC/mp_subgrupo.aspx', NULL UNION ALL
SELECT N'600390000', 205, N'Producto', 201, 5, NULL, NULL, 1, N'CATALOGO/D60ALMAC/0390TELAC/mp_productos.aspx', NULL UNION ALL
SELECT N'600390000', 206, N'Constantes Generales', 200, 2, NULL, NULL, 1, N'CATALOGO/GENERAL/constantesgenerales.aspx', NULL UNION ALL
SELECT N'600390000', 207, N'Tipo de Documentos', 200, 3, NULL, NULL, 1, N'CATALOGO/GENERAL/modulolocaltipdoc.aspx', NULL UNION ALL
SELECT N'600390000', 208, N'Serie de Documentos', 200, 4, NULL, NULL, 1, N'CATALOGO/GENERAL/modulolocaltipdocseries.aspx', NULL UNION ALL
SELECT N'600390000', 209, N'Tributo-Tasa', 200, 5, NULL, NULL, 1, N'CATALOGO/GENERAL/tributostasa.aspx', NULL UNION ALL
SELECT N'600390000', 210, N'Tipo de Cambio', 200, 6, NULL, NULL, 1, N'CATALOGO/GENERAL/tipodecambio.aspx', NULL UNION ALL
SELECT N'600390000', 211, N'Tipos de Doc.Identidad', 200, 7, NULL, NULL, 1, N'CATALOGO/GENERAL/tipdocidentidad.aspx', NULL UNION ALL
SELECT N'600390000', 212, N'Proveedor-Cliente', 200, 8, NULL, NULL, 1, N'CATALOGO/GENERAL/cliente.aspx', NULL UNION ALL
SELECT N'600390000', 213, N'Transportistas', 200, 9, NULL, NULL, 1, N'CATALOGO/GENERAL/transportistas.aspx', NULL UNION ALL
SELECT N'600390000', 214, N'Vendedores', 200, 10, NULL, NULL, 1, N'CATALOGO/GENERAL/vendedorcorporativo.aspx', NULL
COMMIT;
RAISERROR (N'[dbo].[tb_perfilitems]: Insert Batch: 7.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[tb_perfilitems]([idper], [menid], [descr], [padid], [posic], [grupo], [icono], [habil], [pgurl], [nivelacc])
SELECT N'600390000', 215, N'Centros de Costo', 200, 11, NULL, NULL, 1, N'CATALOGO/GENERAL/centrosdecosto.aspx', NULL UNION ALL
SELECT N'600390000', 300, N'Listados', 300, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600390000', 301, N'Balance de Stock', 300, 1, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_balancestock.aspx', NULL UNION ALL
SELECT N'600390000', 302, N'Diario de Almacén', 300, 2, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_diarioalmacen.aspx', NULL UNION ALL
SELECT N'600390000', 303, N'Stock por Artículo', 300, 3, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_stock_articulo.aspx', NULL UNION ALL
SELECT N'600390000', 304, N'Stock por Rollos', 300, 4, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_stock_rollos.aspx', NULL UNION ALL
SELECT N'600390000', 305, N'Kardex por Artículo', 300, 5, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_kardex_articulo.aspx', NULL UNION ALL
SELECT N'600390000', 306, N'Kardex por Rollos', 300, 6, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_kardex_rollo.aspx', NULL UNION ALL
SELECT N'600390000', 307, N'Inventario', 300, 7, NULL, NULL, 1, N'D60ALMAC/0320TELAC/pt_inventario_listar.aspx', NULL UNION ALL
SELECT N'600390000', 308, N'Consumos por OP', 300, 8, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_consumo_op.aspx', NULL UNION ALL
SELECT N'600390000', 400, N'Procesos', 400, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600390000', 401, N'Reorganización', 400, 1, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_local_reorganizacion.aspx', NULL UNION ALL
SELECT N'600390000', 402, N'Toma de Inventario', 400, 2, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600390000', 403, N'Generar Archivo de Trabajo', 402, 1, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_inventario_generafilework.aspx', NULL UNION ALL
SELECT N'600390000', 404, N'Listado para Toma de Inventario', 402, 2, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_inventario_listadotoma.aspx', NULL UNION ALL
SELECT N'600390000', 405, N'Carga Masiva de Inventario', 402, 3, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_inventario_cargamasiva.aspx', NULL UNION ALL
SELECT N'600390000', 406, N'Transferencia a Archivo Trabajo', 402, 4, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_inventario_transferarchtrab.aspx', NULL UNION ALL
SELECT N'600390000', 407, N'Digitación Diferencias de Inventario', 402, 5, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_inventario_digitacion.aspx', NULL UNION ALL
SELECT N'600390000', 408, N'Listado Diferencias de Inventario', 402, 6, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_inventario_listadodiferencias.aspx', NULL UNION ALL
SELECT N'600390000', 409, N'Conformidad Toma de Inventario', 402, 7, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_inventario_conformidad.aspx', NULL UNION ALL
SELECT N'600390000', 410, N'Cierre de Período', 400, 3, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_local_reorganizacion.aspx', NULL UNION ALL
SELECT N'600390000', 411, N'Reorganización de Histórico', 400, 4, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_local_reorganizacion.aspx', NULL UNION ALL
SELECT N'600390000', 500, N'Utilitarios', 500, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600390000', 501, N'Borrado de Tablas', 500, 1, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_util_borratablas.aspx', NULL UNION ALL
SELECT N'600390000', 502, N'Copia de Tablas', 500, 2, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_util_copiatablas.aspx', NULL UNION ALL
SELECT N'600390000', 503, N'Exportación de Tablas', 500, 3, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_util_exportatablas.aspx', NULL UNION ALL
SELECT N'600390000', 504, N'Impresion de CodBar', 500, 4, NULL, NULL, 1, N'D60ALMAC/0320TELAC/mp_codigobarra.aspx', NULL UNION ALL
SELECT N'600600000', 100, N'Archivos', 100, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600600000', 101, N'Consulta al Kardex', 100, 1, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_rpt_kardex.aspx', NULL UNION ALL
SELECT N'600600000', 102, N'Consultar OrdProd', 100, 2, NULL, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_consultar.aspx', NULL UNION ALL
SELECT N'600600000', 103, N'Documento de Almacén', 100, 3, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600600000', 104, N'Nuevo Documento', 103, 1, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_movimiento_registrar.aspx', NULL UNION ALL
SELECT N'600600000', 105, N'Modificar Documento', 103, 2, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/f_movimiento_modificar.aspx', NULL UNION ALL
SELECT N'600600000', 106, N'Consultar Doc.Almacén', 103, 3, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_movimiento_consultar.aspx', NULL UNION ALL
SELECT N'600600000', 200, N'Catálogo', 200, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600600000', 201, N'Activos Fijos', 200, 1, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600600000', 202, N'Estados', 201, 1, NULL, NULL, 1, N'CATALOGO/D60ALMAC/0600AFIJO/af_estadoactual.aspx', NULL UNION ALL
SELECT N'600600000', 203, N'Areas Usuarias', 201, 2, NULL, NULL, 1, N'CATALOGO/D60ALMAC/0600AFIJO/af_areausuaria.aspx', NULL UNION ALL
SELECT N'600600000', 204, N'Usuarios', 201, 3, NULL, NULL, 1, N'CATALOGO/D60ALMAC/0600AFIJO/af_usuario.aspx', NULL UNION ALL
SELECT N'600600000', 205, N'Lineas', 201, 4, NULL, NULL, 1, N'CATALOGO/D60ALMAC/0600AFIJO/af_linea.aspx', NULL UNION ALL
SELECT N'600600000', 206, N'Proveedores', 201, 5, NULL, NULL, 1, N'CATALOGO/D60ALMAC/0600AFIJO/af_grupo.aspx', NULL UNION ALL
SELECT N'600600000', 207, N'Artículos', 201, 6, NULL, NULL, 1, N'CATALOGO/D60ALMAC/0600AFIJO/af_subgrupo.aspx', NULL UNION ALL
SELECT N'600600000', 208, N'Producto', 201, 7, NULL, NULL, 1, N'CATALOGO/D60ALMAC/0600AFIJO/af_productos.aspx', NULL UNION ALL
SELECT N'600600000', 209, N'Constantes Generales', 200, 2, NULL, NULL, 1, N'CATALOGO/GENERAL/constantesgenerales.aspx', NULL UNION ALL
SELECT N'600600000', 210, N'Tipo de Documentos', 200, 3, NULL, NULL, 1, N'CATALOGO/GENERAL/modulolocaltipdoc.aspx', NULL UNION ALL
SELECT N'600600000', 211, N'Serie de Documentos', 200, 4, NULL, NULL, 1, N'CATALOGO/GENERAL/modulolocaltipdocseries.aspx', NULL UNION ALL
SELECT N'600600000', 212, N'Tributo-Tasa', 200, 5, NULL, NULL, 1, N'CATALOGO/GENERAL/tributostasa.aspx', NULL UNION ALL
SELECT N'600600000', 213, N'Tipo de Cambio', 200, 6, NULL, NULL, 1, N'CATALOGO/GENERAL/tipodecambio.aspx', NULL UNION ALL
SELECT N'600600000', 214, N'Tipos de Doc.Identidad', 200, 7, NULL, NULL, 1, N'CATALOGO/GENERAL/tipdocidentidad.aspx', NULL UNION ALL
SELECT N'600600000', 215, N'Proveedor-Cliente', 200, 8, NULL, NULL, 1, N'CATALOGO/GENERAL/cliente.aspx', NULL
COMMIT;
RAISERROR (N'[dbo].[tb_perfilitems]: Insert Batch: 8.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[tb_perfilitems]([idper], [menid], [descr], [padid], [posic], [grupo], [icono], [habil], [pgurl], [nivelacc])
SELECT N'600600000', 216, N'Transportistas', 200, 9, NULL, NULL, 1, N'CATALOGO/GENERAL/transportistas.aspx', NULL UNION ALL
SELECT N'600600000', 217, N'Vendedores', 200, 10, NULL, NULL, 1, N'CATALOGO/GENERAL/vendedorcorporativo.aspx', NULL UNION ALL
SELECT N'600600000', 218, N'Centros de Costo', 200, 11, NULL, NULL, 1, N'CATALOGO/GENERAL/centrosdecosto.aspx', NULL UNION ALL
SELECT N'600600000', 300, N'Listados', 300, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600600000', 301, N'Balance de Stock', 300, 1, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_balancestock.aspx', NULL UNION ALL
SELECT N'600600000', 302, N'Diario de Almacén', 300, 2, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_diarioalmacen.aspx', NULL UNION ALL
SELECT N'600600000', 400, N'Procesos', 400, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600600000', 401, N'Reorganización', 400, 1, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_local_reorganizacion.aspx', NULL UNION ALL
SELECT N'600600000', 402, N'Toma de Inventario', 400, 2, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600600000', 403, N'Listado para Toma de Inventario', 402, 1, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_inventario_listadotoma.aspx', NULL UNION ALL
SELECT N'600600000', 404, N'Digitación Diferencias de Inventario', 402, 2, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_inventario_digitacion.aspx', NULL UNION ALL
SELECT N'600600000', 405, N'Listado Diferencias de Inventario', 402, 3, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_inventario_listadodiferencias.aspx', NULL UNION ALL
SELECT N'600600000', 406, N'Conformidad Toma de Inventario', 402, 4, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_inventario_conformidad.aspx', NULL UNION ALL
SELECT N'600600000', 407, N'Cierre de Período', 400, 3, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_local_reorganizacion.aspx', NULL UNION ALL
SELECT N'600600000', 408, N'Reorganización de Histórico', 400, 4, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_local_reorganizacion.aspx', NULL UNION ALL
SELECT N'600600000', 500, N'Utilitarios', 500, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'600600000', 501, N'Borrado de Tablas', 500, 1, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_util_borratablas.aspx', NULL UNION ALL
SELECT N'600600000', 502, N'Copia de Tablas', 500, 2, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_util_copiatablas.aspx', NULL UNION ALL
SELECT N'600600000', 503, N'Exportación de Tablas', 500, 3, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_util_exportatablas.aspx', NULL UNION ALL
SELECT N'600600000', 504, N'Impresion de CodBar', 500, 4, NULL, NULL, 1, N'D60ALMAC/0600AFIJO/af_codigobarra.aspx', NULL UNION ALL
SELECT N'700900000', 1, N'Archivos', 1, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'700900000', 2, N'Pedidos', 1, 1, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'700900000', 3, N'Nuevo Pedido', 2, 1, NULL, NULL, 1, N'D20COMER/0200PEDID/pedido_registrar.aspx', NULL UNION ALL
SELECT N'700900000', 4, N'Modificar Pedido', 2, 2, NULL, NULL, 1, N'D20COMER/0200PEDID/pedido_modificar.aspx', NULL UNION ALL
SELECT N'700900000', 5, N'Consultar Pedido', 2, 3, NULL, NULL, 1, N'D20COMER/0200PEDID/pedido_consultar.aspx', NULL UNION ALL
SELECT N'700900000', 6, N'Orden Produccion', 1, 2, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'700900000', 7, N'Nueva OrdProd', 6, 1, NULL, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_registrar.aspx', NULL UNION ALL
SELECT N'700900000', 8, N'Modificar OrdProd', 6, 2, NULL, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_modificar.aspx', NULL UNION ALL
SELECT N'700900000', 9, N'Consultar OrdProd', 6, 3, NULL, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_consultar.aspx', NULL UNION ALL
SELECT N'700900000', 10, N'Catálogo', 10, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'700900000', 11, N'Constantes Generales', 10, 1, NULL, NULL, 1, N'CATALOGO/GENERAL/constantesgenerales.aspx', NULL UNION ALL
SELECT N'700900000', 12, N'Serie de Documentos', 10, 2, NULL, NULL, 1, N'CATALOGO/GENERAL/modulolocaltipdocseries.aspx', NULL UNION ALL
SELECT N'700900000', 13, N'Fases', 10, 3, NULL, NULL, 1, N'D07PRODU/0100PRODU/pp_fase.aspx', NULL UNION ALL
SELECT N'700900000', 14, N'Clientes', 10, 4, NULL, NULL, 1, N'CATALOGO/GENERAL/cliente.aspx', NULL UNION ALL
SELECT N'700900000', 15, N'Catalogación Telas', 10, 5, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'700900000', 16, N'Proveedores de Telas', 15, 1, NULL, NULL, 1, N'CATALOGO/D60ALMAC/mp_grupo.aspx', NULL UNION ALL
SELECT N'700900000', 17, N'Línea de Telas', 15, 2, NULL, NULL, 1, N'CATALOGO/D60ALMAC/mp_linea.aspx', NULL UNION ALL
SELECT N'700900000', 18, N'Artículo de Telas', 15, 3, NULL, NULL, 1, N'CATALOGO/D60ALMAC/mp_subgrupo.aspx', NULL UNION ALL
SELECT N'700900000', 19, N'Tallas', 10, 6, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_talla.aspx', NULL UNION ALL
SELECT N'700900000', 20, N'Colores', 10, 7, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_color.aspx', NULL UNION ALL
SELECT N'700900000', 21, N'Catalogación Prod Term', 10, 8, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'700900000', 22, N'Proveedores', 21, 1, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_grupo.aspx', NULL UNION ALL
SELECT N'700900000', 23, N'Estado/Situación', 21, 2, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_estado.aspx', NULL UNION ALL
SELECT N'700900000', 24, N'Marcas', 21, 3, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_marca.aspx', NULL UNION ALL
SELECT N'700900000', 25, N'Categorias', 21, 4, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_categoria.aspx', NULL UNION ALL
SELECT N'700900000', 26, N'Generos', 21, 5, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_genero.aspx', NULL UNION ALL
SELECT N'700900000', 27, N'Lineas', 21, 6, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_linea.aspx', NULL UNION ALL
SELECT N'700900000', 28, N'Modelos', 21, 7, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_modelo.aspx', NULL UNION ALL
SELECT N'700900000', 29, N'Estructuras', 21, 8, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_Estructura.aspx', NULL UNION ALL
SELECT N'700900000', 30, N'Tejidos', 21, 9, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_tejido.aspx', NULL
COMMIT;
RAISERROR (N'[dbo].[tb_perfilitems]: Insert Batch: 9.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[tb_perfilitems]([idper], [menid], [descr], [padid], [posic], [grupo], [icono], [habil], [pgurl], [nivelacc])
SELECT N'700900000', 31, N'Estaciones', 21, 10, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_estacion.aspx', NULL UNION ALL
SELECT N'700900000', 32, N'Temporada', 21, 11, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_temporada.aspx', NULL UNION ALL
SELECT N'700900000', 33, N'Entalle', 21, 12, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_entalle.aspx', NULL UNION ALL
SELECT N'700900000', 34, N'BotaPie', 21, 13, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_botapie.aspx', NULL UNION ALL
SELECT N'700900000', 35, N'Articulos', 21, 14, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_articulo.aspx', NULL UNION ALL
SELECT N'700900000', 36, N'Asignacion de Colores', 10, 9, NULL, NULL, 1, N'CATALOGO/D20COMER/pt_articulocolor.aspx', NULL UNION ALL
SELECT N'700900000', 50, N'Listados', 50, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'700900000', 51, N'Ordenes de Producción', 50, 1, NULL, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_listado.aspx', NULL UNION ALL
SELECT N'700900000', 52, N'Kardex por Fase', 50, 2, NULL, NULL, 1, N'D70PRODU/0100PRODU/ordenprod_fases_kardex.aspx', NULL UNION ALL
SELECT N'700900000', 70, N'Procesos', 70, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'700900000', 80, N'Utilitarios', 80, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'700900000', 81, N'Impresion de CodBar', 80, 1, NULL, NULL, 1, N'D70PRODU/0100PRODU/pp_codigobarra.aspx', NULL UNION ALL
SELECT N'700900000', 82, N'Usuarios', 80, 2, NULL, NULL, 1, N'mdo_maestros/usuarios.aspx', NULL UNION ALL
SELECT N'700900000', 83, N'Perfiles', 80, 3, NULL, NULL, 1, N'mdo_maestros/perfil.aspx', NULL UNION ALL
SELECT N'700900000', 84, N'Perfil Items', 80, 4, NULL, NULL, 1, N'mdo_maestros/perfilitems.aspx', NULL
COMMIT;
RAISERROR (N'[dbo].[tb_perfilitems]: Insert Batch: 10.....Done!', 10, 1) WITH NOWAIT;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[tb_perfilitems]([idper], [menid], [descr], [padid], [posic], [grupo], [icono], [habil], [pgurl], [nivelacc])
SELECT N'A00100000', 100, N'Tablas', 100, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'A00100000', 101, N'Plan Contable PCGE', 100, 1, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'A00100000', 102, N'Tipos de Diario', 100, 2, NULL, NULL, 1, N'D20COMER/0200PEDID/pedido_registrar.aspx', NULL UNION ALL
SELECT N'A00100000', 103, N'Centro de Costos', 100, 3, NULL, NULL, 1, N'D20COMER/0200PEDID/pedido_modificar.aspx', NULL UNION ALL
SELECT N'A00100000', 104, N'Tablas SUNAT', 100, 4, NULL, NULL, 1, N'D20COMER/0200PEDID/pedido_consultar.aspx', NULL UNION ALL
SELECT N'A00100000', 105, N'Clientes/Proveedores', 100, 5, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'A00100000', 106, N'Tipo de Cambio - SUNAT', 100, 6, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_movimiento_registrar.aspx', NULL UNION ALL
SELECT N'A00100000', 107, N'Tipo de Cambio Cierre Mensual', 100, 7, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_movimiento_bv.aspx', NULL UNION ALL
SELECT N'A00100000', 108, N'Detracciones - SPOT', 100, 8, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_movimiento_fa.aspx', NULL UNION ALL
SELECT N'A00100000', 109, N'Percepciones', 100, 9, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_movimiento_nc.aspx', NULL UNION ALL
SELECT N'A00100000', 110, N'Tributos', 100, 10, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_movimiento_tk.aspx', NULL UNION ALL
SELECT N'A00100000', 200, N'Información', 200, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'A00100000', 201, N'Movimiento', 200, 1, NULL, NULL, 1, N'CATALOGO/GENERAL/cliente.aspx', NULL UNION ALL
SELECT N'A00100000', 202, N'Ajuste por Diferencia de Cambio', 200, 2, NULL, NULL, 1, N'CATALOGO/GENERAL/cliente.aspx', NULL UNION ALL
SELECT N'A00100000', 203, N'Ajuste por Redondeo', 200, 3, NULL, NULL, 1, N'CATALOGO/GENERAL/constantesgenerales.aspx', NULL UNION ALL
SELECT N'A00100000', 300, N'Reporte', 300, 0, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'A00100000', 301, N'Plan Contable', 300, 1, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'A00100000', 400, N'Transferencias', 300, 2, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'A00100000', 401, N'Interface Programa Declación Anual de Operaciones con Terceros - DAOT', 300, 3, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'A00100000', 402, N'Interface Programa de Declaración de Beneficios - PDB', 301, 4, NULL, NULL, 1, N'D20COMER/0200TIDAS/p1_rpt_stock_artcoltall.aspx', NULL UNION ALL
SELECT N'A00100000', 500, N'Utilitarios', 300, 5, NULL, NULL, 1, N'main.aspx', NULL UNION ALL
SELECT N'A00100000', 501, N'Cierres Mensuales', 300, 6, NULL, NULL, 1, N'main.aspx', NULL 
COMMIT;
RAISERROR (N'[dbo].[tb_perfilitems]: Insert Batch: CONTABILIDAD.....Done!', 10, 1) WITH NOWAIT;
GO

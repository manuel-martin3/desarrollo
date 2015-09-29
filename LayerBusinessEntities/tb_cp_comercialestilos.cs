using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_cp_comercialestilos
    {
        private String _perianio;
        public String perianio
        {
            get { return _perianio; }

            set { _perianio = value; }
        }

        private String _empresa;
        public String empresa
        {
            get { return _empresa; }

            set { _empresa = value; }
        }

        private String _asiento;
        public String asiento
        {
            get { return _asiento; }

            set { _asiento = value; }
        }

        private String _itemsestilo;
        public String itemsestilo
        {
            get { return _itemsestilo; }

            set { _itemsestilo = value; }
        }

        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }

            set { _moduloid = value; }
        }

        private String _local;
        public String local
        {
            get { return _local; }

            set { _local = value; }
        }

        private String _estiloid;
        public String estiloid
        {
            get { return _estiloid; }

            set { _estiloid = value; }
        }

        private String _sufijo;
        public String sufijo
        {
            get { return _sufijo; }

            set { _sufijo = value; }
        }

        private String _imagenprenda;
        public String imagenprenda
        {
            get { return _imagenprenda; }

            set { _imagenprenda = value; }
        }

        private String _oproduccion;
        public String oproduccion
        {
            get { return _oproduccion; }

            set { _oproduccion = value; }
        }

        private String _divisionid;
        public String divisionid
        {
            get { return _divisionid; }

            set { _divisionid = value; }
        }

        private String _lineaid;
        public String lineaid
        {
            get { return _lineaid; }

            set { _lineaid = value; }
        }

        private String _observacion;
        public String observacion
        {
            get { return _observacion; }

            set { _observacion = value; }
        }

        private String _detalleprenda;
        public String detalleprenda
        {
            get { return _detalleprenda; }

            set { _detalleprenda = value; }
        }

        private String _hojaruta;
        public String hojaruta
        {
            get { return _hojaruta; }

            set { _hojaruta = value; }
        }

        private String _tipopedido;
        public String tipopedido
        {
            get { return _tipopedido; }

            set { _tipopedido = value; }
        }

        private Boolean _status;
        public Boolean status
        {
            get { return _status; }

            set { _status = value; }
        }

        private Boolean _terminado;
        public Boolean terminado
        {
            get { return _terminado; }

            set { _terminado = value; }
        }

        private DateTime? _fechtermino;
        public DateTime? fechtermino
        {
            get { return _fechtermino; }

            set { _fechtermino = value; }
        }

        private int _estiloorden;
        public int estiloorden
        {
            get { return _estiloorden; }

            set { _estiloorden = value; }
        }
    }
}

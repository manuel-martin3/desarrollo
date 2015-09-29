using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayerBusinessEntities
{
    public class tb_cm_equivalencia
    {

        private int _equiv_id;

        public int Equiv_id
        {
            get { return _equiv_id; }
            set { _equiv_id = value; }
        }
        private String _equiv_name;

        public String Equiv_name
        {
            get { return _equiv_name; }
            set { _equiv_name = value; }
        }
        
        private String _unmed1;
        public String Unmed1
        {
            get { return _unmed1; }
            set { _unmed1 = value; }
        }
        private String _unmed2;

        public String Unmed2
        {
            get { return _unmed2; }
            set { _unmed2 = value; }
        }
        private Decimal _equivalencia;

        public Decimal Equivalencia
        {
            get { return _equivalencia; }
            set { _equivalencia = value; }
        }

        private String Descripcion1;

        public String descripcion1
        {
            get { return Descripcion1; }
            set { Descripcion1 = value; }
        }

        private String Descripcion2;

        public String descripcion2
        {
            get { return Descripcion2; }
            set { Descripcion2 = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perfiles
{
    public partial class Form1 : Form
    {
        PermisoSimple ps1, ps2, ps3, ps4, ps5;
        PermisoCompuesto pc1, pc2, pc3;
        Usuario _u;
        Perfil _p01, _p02;
        public Form1()
        {
            InitializeComponent();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _u.Perfil = _p02; Mostrar(); 
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _u.Perfil = _p01; Mostrar(); 
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ejecutó la función 1");
        }
        private void nombredelafuncion(object sender, EventArgs e) { MessageBox.Show("Hicieron Click"); }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ejecutó la función 2"); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ejecutó la función 3"); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ejecutó la función 4"); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ejecutó la función 5"); 
        }
        private void Mostrar()
        {
            int _y = 20;
            List<Button> _b = new List<Button>();
         
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    (c as Button).Visible = false;
                    if (_u.Perfil.Validar(c.Tag.ToString().Split(',')[0]))
                    {
                        _b.Add(c as Button);
                    }
                }
            }
            _b.Sort(new Orden());
            foreach (Control c in _b){ c.Visible = true; c .Top = _y;_y += 55; } 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _u = new Usuario() { Nombre = "Juan", Apellido = "Perez" };
            ps1 = new PermisoSimple("001");
            ps2 = new PermisoSimple("002");
            ps3 = new PermisoSimple("003");
            ps4 = new PermisoSimple("004");
            ps5 = new PermisoSimple("005");

            pc1 = new PermisoCompuesto("C01");
            pc2 = new PermisoCompuesto("C02");
            pc3 = new PermisoCompuesto("C03");

            pc1.AgregarPermiso(ps1);
            pc1.AgregarPermiso(ps2);
            pc1.AgregarPermiso(ps3);
            pc1.AgregarPermiso(ps4);

            pc2.AgregarPermiso(pc1);
            pc2.AgregarPermiso(ps5);

            pc3.AgregarPermiso(ps1);
            pc3.AgregarPermiso(ps4);
            pc3.AgregarPermiso(ps5);

            _p01 = new Perfil(pc2);
            _p02 = new Perfil(pc3);

            _u.Perfil = _p01;
            Mostrar();
        }
    }
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Perfil Perfil { get; set; }
    }
    public class Perfil
    {
        PermisoCompuesto _pc;
        public Perfil(PermisoCompuesto pCompuesto) { _pc = pCompuesto; }
        public bool Validar(string pCodigo)
        {
            return _pc.RetornaPermisos().Exists(x => x.Codigo == pCodigo);
        }
    }

    public abstract class Permiso
    {
        string _codigo;
        public Permiso(string pCodigo)
        {
            _codigo = pCodigo;
        }
        public string Codigo 
        {
            get { return _codigo; } 
            set { _codigo = value; } 
        }
        //public bool SumaResta { get; set; }
        public abstract List<Permiso> RetornaPermisos();
    }

    public class PermisoSimple : Permiso
    {
        public PermisoSimple(string pCodigo) : base(pCodigo)
        {
        }
        public override List<Permiso> RetornaPermisos()
        {
            return new List<Permiso>() { this };
        }
    }
    public class PermisoCompuesto : Permiso
    {
        List<Permiso> _l;

        List<Permiso> _laux;
        public PermisoCompuesto(string pCodigo) : base(pCodigo)
        {
            _l = new List<Permiso>();
        }
        public void AgregarPermiso(Permiso Ppermiso)
        {
            _l.Add(Ppermiso);
        }
        public List<Permiso> Retornacomponentes()
        {
            return _l;
        }
        public override List<Permiso> RetornaPermisos()
        {

            _laux = new List<Permiso>();
            RecursivaRetornaPermisos(_l);

            return _laux;
        }
        private void RecursivaRetornaPermisos(List<Permiso> pLista)
        {
            foreach (Permiso p in pLista)
            {
                if (p is PermisoSimple)
                {
                    _laux.Add(p);
                }
                else 
                {
                    RecursivaRetornaPermisos((p as PermisoCompuesto).Retornacomponentes());
                }         
            }
        }
    }
    public class Orden : IComparer<Button>
    {
        public int Compare(Button x, Button y)
        {
            int rdo=0;
            if (int.Parse(x.Tag.ToString().Split(',')[1]) < int.Parse(y.Tag.ToString().Split(',')[1])) { rdo = -1; }
            if (int.Parse(x.Tag.ToString().Split(',')[1]) > int.Parse(y.Tag.ToString().Split(',')[1])) { rdo = 1; }
            return rdo;
        }
    }
}

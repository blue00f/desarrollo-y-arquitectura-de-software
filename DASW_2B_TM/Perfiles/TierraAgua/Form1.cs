using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TierraAgua
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Terreno _t = new TerrenoCompuesto(new List<Terreno>() { new Tierra(),
                                                                    new Agua(),
                                                                    new Tierra(),                                
                                                                    new TerrenoCompuesto(new List<Terreno>() { new Agua(),
                                                                                                               new Agua(),
                                                                                                               new Tierra(),
                                                                                                               new Tierra() }) });

            MessageBox.Show($"El % de Agua es.: {_t.PorcentajeAgua().ToString()}{Environment.NewLine}" +
                            $"El % de Tierra es: {_t.PorcentajeTierra().ToString()}");
        }
    }
    public abstract class Terreno
    {
        public abstract decimal PorcentajeAgua();
        public abstract decimal PorcentajeTierra();
    }
    public class Agua : Terreno
    {
        public override decimal PorcentajeAgua()
        {
            return 1;
        }
        public override decimal PorcentajeTierra()
        {
            return 0;
        }
    }
    public class Tierra : Terreno
    {
        public override decimal PorcentajeAgua()
        {
            return 0;
        }

        public override decimal PorcentajeTierra()
        {
            return 1;
        }
    }
    public class TerrenoCompuesto : Terreno
    {
        List<Terreno> _l;
        public TerrenoCompuesto(List<Terreno> pListaTerreno) { _l = pListaTerreno; }
        
        public override decimal PorcentajeAgua()
        {
            return RecursivaPorcentajeAgua(_l);
        }
        public override decimal PorcentajeTierra()
        {
            return RecursivaPorcentajeTierra(_l);
        }
        private decimal RecursivaPorcentajeAgua(List<Terreno> pListaTerreno)
        {
            decimal _acu = 0;
            foreach(Terreno t in pListaTerreno)
            {
                _acu += t.PorcentajeAgua();
            }
            return _acu / 4;
        }
        private decimal RecursivaPorcentajeTierra(List<Terreno> pListaTerreno)
        {
            decimal _acu = 0;
            foreach (Terreno t in pListaTerreno)
            {
                _acu += t.PorcentajeTierra();
            }
            return _acu / 4;
        }
    }
}

namespace Entidades
{
    public class BE_Prestamo : ICloneable
    {
        public BE_Prestamo() { }
        public BE_Prestamo(string pCodigo) { Codigo = pCodigo; }
        public BE_Prestamo(string pCodigo, decimal pMontoOtorgado, DateTime pfechaOtorgado, decimal pInteres, decimal pInteresPunitorio, DateTime pfechaVencimiento, DateTime pfechaDevolucion, BE_Persona pPersona, decimal pMontoDevuelto = 0) : this(new object[] { pCodigo, pMontoOtorgado, pfechaOtorgado, pInteres, pInteresPunitorio, pfechaVencimiento, pfechaDevolucion, pMontoDevuelto }, pPersona)
        { }
        public BE_Prestamo(object[] pItemArray,BE_Persona persona) : this(pItemArray[0].ToString()) 
        {
            MontoOtorgado = decimal.Parse(pItemArray[1].ToString());
            FechaOtorgado = DateTime.Parse(pItemArray[2].ToString());
            Interes = decimal.Parse(pItemArray[3].ToString());
            InteresPunitorio = decimal.Parse(pItemArray[4].ToString());
            FechaVencimiento = DateTime.Parse(pItemArray[5].ToString());
            FechaDevolucion = DateTime.Parse(pItemArray[6].ToString());
            MontoDevuelto = decimal.Parse(pItemArray[7].ToString());
            Persona = persona;
        }
        public string Codigo { get; set; }
        public decimal MontoOtorgado { get; set; }
        public DateTime FechaOtorgado { get; set; }
        public decimal Interes { get; set; }
        public decimal InteresPunitorio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public decimal MontoDevuelto { get; set; }
        public BE_Persona Persona { get; set; }

        public object Clone()
        {
            BE_Prestamo _pPrestamoClonado = this.MemberwiseClone() as BE_Prestamo;
            if (_pPrestamoClonado.Persona!=null)
            {
                _pPrestamoClonado.Persona = new BE_Persona(_pPrestamoClonado.Persona.DNI, _pPrestamoClonado.Persona.Nombre, _pPrestamoClonado.Persona.Apellido);
            }
            return _pPrestamoClonado;
        }
        public BE_Prestamo CloneTipado()
        {
            return Clone() as BE_Prestamo;
        }
    }


}

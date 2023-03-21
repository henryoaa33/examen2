using System;
using System.Collections.Generic;
using System.Text;

namespace examen002.Models
{
    [Serializable]
    public class Avioncomercial : Aereonave, Iporcioncombustible
    {

        public double capacidaddecombustible()
        {
            return 36000;
        }
        public override double ConsumoDespegue() => consumodespegue * 0.10;
        public override string Despegar()
        {
            double consumoDespegue = ConsumoDespegue();
            consumodespegue -= consumoDespegue;
            return "El avión comercial está despegando. Se han consumido " + consumoDespegue.ToString() + " galones de combustible.";
        }


        public override double ConsumoVolar() => consumovolar * 0.80;
        public override string Volar()
        {
            double consumoVolar = ConsumoVolar();
            consumovolar -= consumoVolar;
            return "El avión comercial está volando. Se han consumido " + consumoVolar.ToString() + " galones de combustible.";
        }

        public override double ConsumoAterrizar() => consumoaterrizar * 0.10;
        public override string Aterrizar()
        {
            double consumoAterrizar = ConsumoAterrizar();
            consumoaterrizar -= consumoAterrizar;
            return "El avión comercial está aterrizando. Se han consumido " + consumoAterrizar.ToString() + " galones de combustible.";
        }

        public int capacidadpasajeros { get; set; }
    }
}

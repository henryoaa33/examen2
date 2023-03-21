using System;
using System.Collections.Generic;
using System.Text;

namespace examen002.Models
{
    [Serializable]
    internal class Dirigible : Aereonave, Iporcioncombustible
    {

        public double capacidaddecombustible()
        {
            return 5000;
        }
        public override double ConsumoDespegue() => consumodespegue * 0.10;
        public override string Despegar()
        {
            double consumoDespegue = ConsumoDespegue();
            consumodespegue -= consumoDespegue;
            return "El dirigible está despegando. Se han consumido " + consumoDespegue.ToString() + " galones de combustible.";
        }


        public override double ConsumoVolar() => consumovolar * 0.80;
        public override string Volar()
        {
            double consumoVolar = ConsumoVolar();
            consumovolar -= consumoVolar;
            return "El avión está volando. Se han consumido " + consumoVolar.ToString() + " galones de combustible.";
        }

        public override double ConsumoAterrizar() => consumoaterrizar * 0.10;
        public override string Aterrizar()
        {
            double consumoAterrizar = ConsumoAterrizar();
            consumoaterrizar -= consumoAterrizar;
            return "El avión está aterrizando. Se han consumido " + consumoAterrizar.ToString() + " galones de combustible.";
        }

        public int capacidadhelio { get; set; }
    }
}

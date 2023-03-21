using examen002.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace examen002.ViewModel
{
    internal class ViewModelAereonave : INotifyPropertyChanged
    {
        public ViewModelAereonave()
        {

            AbrirListaAereonave();




            CrearAereonave = new Command(() =>
            {

                Aereonave c = new Aereonave()
                {
                    aereonave = this.aereonaveSelecionado,
                    persona = this.personaSeleccionada,
                    capacidadcombustible = this.capacidadcombustible,
                    distanciarecorrida = this.distanciarecorrida,
                    combustible = this.combustible,
                    consumomillas = this.combustible * this.distanciarecorrida


                };


                ListaAereonave.Add(c);


                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Aereonave2.aut");

                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, ListaAereonave);
                archivo.Close();


                App.Current.Properties["ListaAereonave"] = ListaAereonave;

            });


            CambioAereonave = new Command(() => {


                capacidadcombustible = aereonaveSelecionado.capacidadcombustible;
                distanciarecorrida = aereonaveSelecionado.distanciarecorrida;
                combustible = aereonaveSelecionado.combustible;


            });


        }

        private void AbrirListaAereonave()
        {
            try
            {

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "aereonave2.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                ListaAereonave = (ObservableCollection<Aereonave>)formatter.Deserialize(archivo);

                archivo.Close();

                App.Current.Properties["ListaAereonave"] = ListaAereonave;

            }
            catch (Exception ex)
            {
                ListaAereonave = new ObservableCollection<Aereonave>();

            }





        }



        ObservableCollection<Aereonave> listaAereonave = new ObservableCollection<Aereonave>();

        public ObservableCollection<Aereonave> ListaAereonave
        {
            get => listaAereonave;
            set
            {

                listaAereonave = value;
                var arg = new PropertyChangedEventArgs(nameof(ListaAereonave));
                PropertyChanged?.Invoke(this, arg);

            }
        }



        double consumoaterrizar;
        public double Consumoaterrizar
        {

            get => consumoaterrizar;
            set
            {
                consumoaterrizar = value;
                var arg = new PropertyChangedEventArgs(nameof(Consumoaterrizar));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        double consumovolar;
        public double Consumovolar
        {

            get => consumovolar;
            set
            {
                consumovolar = value;
                var arg = new PropertyChangedEventArgs(nameof(Consumovolar));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        double consumodespegue;
        public double Consumodespegue
        {

            get => consumodespegue;
            set
            {
                consumodespegue = value;
                var arg = new PropertyChangedEventArgs(nameof(Consumodespegue));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        double consumomillas;
        public double Consumomillas
        {

            get => consumomillas;
            set
            {
                consumomillas = value;
                var arg = new PropertyChangedEventArgs(nameof(Consumomillas));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        double combustible;
        public double Combustible
        {

            get => combustible;
            set
            {
                combustible = value;
                var arg = new PropertyChangedEventArgs(nameof(Combustible));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        double distanciarecorrida;
        public double Distanciarecorrida
        {

            get => distanciarecorrida;
            set
            {
                distanciarecorrida = value;
                var arg = new PropertyChangedEventArgs(nameof(Distanciarecorrida));
                PropertyChanged?.Invoke(this, arg);

            }
        }


        double capacidadcombustible;
        public double Capacidadcombustible
        {

            get => capacidadcombustible;
            set
            {
                capacidadcombustible = value;
                var arg = new PropertyChangedEventArgs(nameof(Capacidadcombustible));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        Aereonave aereonaveSelecionado = new Aereonave();
        public Aereonave AereonaveSeleccionado
        {

            get => aereonaveSelecionado;
            set
            {

                aereonaveSelecionado = value;
                var arg = new PropertyChangedEventArgs(nameof(AereonaveSeleccionado));
                PropertyChanged?.Invoke(this, arg);


            }

        }

        Persona personaSeleccionada = new Persona();
        public Persona PersonaSeleccionada
        {
            get => personaSeleccionada;
            set
            {

                personaSeleccionada = value;
                var arg = new PropertyChangedEventArgs(nameof(PersonaSeleccionada));
                PropertyChanged?.Invoke(this, arg);

            }

        }

        ObservableCollection<Persona> listaPersonas = new ObservableCollection<Persona>();
        public ObservableCollection<Persona> ListaPersonas
        {
            get => listaPersonas;
            set
            {
                listaPersonas = value;
                var arg = new PropertyChangedEventArgs(nameof(ListaPersonas));
                PropertyChanged?.Invoke(this, arg);
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public Command CrearAereonave { get; }
        public Command CambioAereonave { get; }
    }
}

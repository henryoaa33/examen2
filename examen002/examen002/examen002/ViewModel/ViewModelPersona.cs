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
    public class ViewModelPersona : INotifyPropertyChanged
    {

        public ViewModelPersona()
        {

            AbrirListaPersonas();



            CrearPersona = new Command(

                    () => {

                        Persona p = new Persona()
                        {

                            nombre = this.nombre,
                            numerolicencia = this.numerolicencia,

                        };


                        Mensaje = p.ToString();
                        ListaPersonas.Add(p);



                        BinaryFormatter formatter = new BinaryFormatter();
                        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "personas.aut");

                        Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                        formatter.Serialize(archivo, ListaPersonas);
                        archivo.Close();



                        App.Current.Properties["ListaPersonas"] = ListaPersonas;


                    }


                );


        }

        private void AbrirListaPersonas()
        {
            try
            {


                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "personas.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                ListaPersonas = (ObservableCollection<Persona>)formatter.Deserialize(archivo);

                archivo.Close();

                App.Current.Properties["ListaPersonas"] = ListaPersonas;

            }
            catch (Exception ex)
            {
                ListaPersonas = new ObservableCollection<Persona>();
            }





        }

        string nombre;

        public string Nombre
        {

            get => nombre;
            set
            {

                nombre = value;
                var arg = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, arg);


            }

        }

        string mensaje;

        public string Mensaje
        {

            get => mensaje;
            set
            {

                mensaje = value;
                var arg = new PropertyChangedEventArgs(nameof(Mensaje));
                PropertyChanged?.Invoke(this, arg);

            }

        }

        int numerolicencia;

        public int Numerolicencia
        {

            get => numerolicencia;
            set
            {

                numerolicencia = value;
                var arg = new PropertyChangedEventArgs(nameof(Numerolicencia));
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





        public Command CrearPersona { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

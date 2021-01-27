using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheroes
{
    class MainWindowVM : INotifyPropertyChanged
    {
        public Superheroe superheroe;
        public ObservableCollection<Superheroe> listaSuperHeroes;
        private ServicioSuperheroe _servicio;
        string contador;
        string max;

        public MainWindowVM()
        {
            _servicio = new ServicioSuperheroe();
            listaSuperHeroes = _servicio.ObtenerPersonas();
            superheroe = new Superheroe();
            contador = "1";
            max = listaSuperHeroes.Count().ToString();
        }

        public void HeroeAnterior()
        {
            int aux = int.Parse(contador);
            if(aux > 1)
            {
                superheroe = listaSuperHeroes[aux - 1];
                aux++;
                contador = aux.ToString();
            }
        }
        public void HeroeSiguiente()
        {
            int aux = int.Parse(contador);
            int maxAux = int.Parse(max);
            if(aux <= maxAux - 1)
            {
                superheroe = listaSuperHeroes[aux];
                aux++;
                contador = aux.ToString();
            }
        }
        public void ReiniciarSuperHeroe()
        {
            superheroe = new Superheroe() { Heroe = true};
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Examen2_R_H25_Partie2
{
    public class Examen2ViewModel : INotifyPropertyChanged
    {
        // TODO : Ajouter des propriétés avec encapsulation pour le binding
        // Les propriétés sont 2 ObservableCollection : Bibliotheque et Panier,
        // et 2 Livres : celui sélectionné dans le DataGrid et celui sélectionné dans le ListBox.
        // Ajouter aussi les 3 ICommand pour le binding sur les boutons et le menu.


        public Examen2ViewModel()
        {
            // TODO : Lire le fichier JSON pour initialiser et remplir la Bibliotheque; 


            // TODO : Initialiser le panier à une liste vide


            // TODO : Initialiser les RelayCommand pour attacher les boutons à leurs gestionnaires d'évènements


        }

        // Gestionnaires d'évènements
        private void Emprunter()
        {
            // TODO : Ajouter le livre selectionné au panier

        }
        private void Retourner()
        {
            // TODO : Supprimer le livre à retourner du panier

        }

        private void Save()
        {
            // TODO : Sauvegarder la Bibliotheque dans le fichier json

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

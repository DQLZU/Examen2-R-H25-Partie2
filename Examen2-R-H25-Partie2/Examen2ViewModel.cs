using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Examen2_R_H25_Partie2
{
    public class Examen2ViewModel : INotifyPropertyChanged
    {


        //Notes de cours consulte pour vérifier la syntaxe

        private ObservableCollection<Livre> _listeLivres;
        public ObservableCollection<Livre> ListeLivres
        {
            get { return _listeLivres; }
            set
            {
                _listeLivres = value;
                OnPropertyChanged(nameof(_listeLivres));
            }
        }

        private ObservableCollection<Livre> _listePanier;
        public ObservableCollection<Livre> ListePanier
        {
            get { return _listePanier; }
            set
            {
                _listePanier = value;
                OnPropertyChanged(nameof(_listePanier));
            }
        }

        private Livre _livreSelectionne;
        public Livre LivreSelectionne
        {
            get { return _livreSelectionne; }
            set 
            {
                _livreSelectionne = value;
                OnPropertyChanged(nameof(_livreSelectionne));
            }
        }

        private Livre _livreSelectList;
        public Livre LivreSelecList
        {
            get { return _livreSelectList; }
            set
            {
                _livreSelectList = value;
                OnPropertyChanged(nameof(_livreSelectList));
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(_message));
            }

        }

        private int _currentIndex;
        public int CurrentIndex
        {
            get => _currentIndex;

            set
            {
                if (_currentIndex != value && value >= 0 && value < ListeLivres.Count)
                {
                    _currentIndex = value;
                    OnPropertyChanged(nameof(CurrentIndex));
                }
            }
        }


        public ICommand SaveCommand { get; }
        public ICommand EmprunterCommand { get; }
        public ICommand RetournerCommand { get; }

        public Examen2ViewModel()
        {

            try
            {
                string file = "livres.json";
                string listeJson = File.ReadAllText(file);
                ListeLivres = JsonSerializer.Deserialize<ObservableCollection<Livre>>(listeJson);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        
            ListePanier = new ObservableCollection<Livre>();
            _currentIndex = 0;
            _livreSelectionne = new Livre();
            _livreSelectList = new Livre();

            SaveCommand = new RelayCommand(Save);
            EmprunterCommand = new RelayCommand(Emprunter);
            RetournerCommand = new RelayCommand(Retourner);

            Message = "";

        }

        // Gestionnaires d'évènements
        private void Emprunter()
        {
            // TODO : Ajouter le livre selectionné au panier
            try 
            {
                LivreSelectionne = ListeLivres[_currentIndex];
                ListePanier.Add(LivreSelectionne);
                
            }
            catch (Exception ex) 
            {
                Message = ex.Message;
            }
        }
        private void Retourner()
        {
            // TODO : Supprimer le livre à retourner du panier
            try
            {
                LivreSelectionne = ListePanier[_currentIndex];
                ListePanier.Remove(LivreSelectionne);
                
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

        }

        private void Save()
        {
            // TODO : Sauvegarder la Bibliotheque dans le fichier json
            string file = "ListeLivres.json";
            string listeJson = JsonSerializer.Serialize(ListeLivres);
            File.WriteAllText(file, listeJson);
            Message = "Liste des livres sauvegardés";
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }


 }


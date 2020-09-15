﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.BO;

namespace TP2
{
    class Program
    {

        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();
        static void Main(string[] args)
        {

            InitialiserDatas();

            //Afficher la liste des prénoms des auteurs dont le nom commence par "G" 

            foreach (var item in ListeAuteurs.Where(x => x.Nom.StartsWith("G")))
            {
                Console.WriteLine(item.Prenom);
            }

            // Afficher l’auteur ayant écrit le plus de livres 

          


            //Afficher le nombre moyen de pages par livre par auteur 

             foreach (var item in ListeLivres.GroupBy(x=>x.Auteur))
              {
                Console.WriteLine(item.Average(x => x.NbPages));
              }

            //Afficher le titre du livre avec le plus de pages 

            var livre = ListeLivres.Max(i => i.NbPages);
           // var titre = ListeLivres.Where(i => i. == );

            //Afficher combien ont gagné les auteurs en moyenne (moyenne des factures) 
            Console.WriteLine(ListeAuteurs.SelectMany(x => x.Factures).Average(x => x.Montant));

            //Afficher les auteurs et la liste de leurs livres 

            foreach (var item in ListeLivres.GroupBy(x => x.Auteur))
            {
                Console.WriteLine(item.Key);

            }

            //Afficher les titres de tous les livres triés par ordre alphabétique 
            foreach (var item in ListeLivres.OrderBy(x =>x.Titre))
            {
                Console.WriteLine(item.Titre);
            }
            //Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne 

            //Afficher l'auteur ayant écrit le moins de livres 

            Console.ReadKey();

        }//fin main


        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }//fin class
}

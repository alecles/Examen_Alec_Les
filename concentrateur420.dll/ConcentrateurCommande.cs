using System;
using System.Collections.Generic;
using System.Text;

namespace Concentrateur420
{
    sealed public partial class Concentrateur
    {
        public string ExecuterCommande(string ligneCommande)
        {
            if (ligneCommande == "" || ligneCommande == null)
            {
                throw new C420Exception("Commande vide");
            }

            else
            {
                string[] lignesCommandes = ligneCommande.Split(' ');

                
                switch(lignesCommandes[0])
                {
                    case "CZ": ValiderParametres(lignesCommandes, 2); CreerZone(lignesCommandes[1]);
                        break;

                    case "SZ": ValiderParametres(lignesCommandes, 2); SupprimerZone(lignesCommandes[1]);
                        break;

                    case "AZ": ValiderParametres(lignesCommandes, 2); ActiverZone(lignesCommandes[1]);
                        break;

                    case "EZ": ValiderParametres(lignesCommandes, 2); EteindreZone(lignesCommandes[1]);
                        break;

                    case "CL": ValiderParametres(lignesCommandes, 3); CreerLumiere(lignesCommandes[1], lignesCommandes[2]);
                        break;

                    case "CD": ValiderParametres(lignesCommandes, 3); CreerDetecteur(lignesCommandes[1], lignesCommandes[2]);
                        break;

                    case "CC": ValiderParametres(lignesCommandes, 3); CreerControleur(lignesCommandes[1], lignesCommandes[2]);
                        break;

                    case "SA": ValiderParametres(lignesCommandes, 3); SupprimerAppareil(lignesCommandes[1], lignesCommandes[2]);
                        break;

                    case "AA": ValiderParametres(lignesCommandes, 3); ActiverAppareil(lignesCommandes[1], lignesCommandes[2]);
                        break;

                    case "PA": ValiderParametres(lignesCommandes, 4); ParametrerAppareil(lignesCommandes[1], lignesCommandes[2], lignesCommandes[3]);
                        break;

                    case "E": ValiderParametres(lignesCommandes, 1);
                        break;

                    case "H": ValiderParametres(lignesCommandes, 1); Console.WriteLine(GetAide());
                        break;

                    case "Q": ValiderParametres(lignesCommandes, 1);
                        break;

                    default: throw new C420Exception("Commande invalide");                       
                }

                return GetEtat();
            }           
        }

        private void ValiderParametres(string[] parametres, int nbParametres)
        {
            if (parametres.Length == nbParametres)
            {

            }

            else
                throw new C420Exception("Les nombres de parametres ne sont pas équivalent");
        }

        private string GetAide()
        {
            return GetAideGeneral() + GetAideZone() + GetAideAppareil();
        }

        private string GetAideGeneral()
        {
            return "COMMANDES GENERALES\n"
            + " E Consulter l'etat du concentrateur\n"
            + " H Recevoir de l'aide sur les commandes\n"
            + " Q Quitter\n";
        }

        private string GetAideZone()
        {
            return "COMMANDES DE ZONES\n"
            + " CZ {ID_ZONE} Creer une ZONE\n"
            + " > CZ MA_ZONE Creer la zone MA_ZONE\n"
            + " SZ {ID_ZONE} Supprimer une zone\n"
            + " > SZ MA_ZONE Supprimer la zone MA_ZONE\n"
            + " AZ {ID_ZONE} Activer tous les appareils d'une ZONE\n"
            + " > AZ MA_ZONE Activer tous les appareils de la zone MA_ZONE\n"
            + " EZ {ID_ZONE} Eteindre tous les appareils d'une ZONE \n"
            + " > AZ MA_ZONE Eteindre tous les appareils de la zone MA_ZONE\n";
        }

        private string GetAideAppareil()
        {
            return "COMMANDES D'APPAREIL\n"
            + " C{L|D|C} {ID_ZONE} {ID_APPAREIL}) Creer un appareil dans une zone\n"
            + " > CL MA_ZONE L1 creer une LUMIERE avec l'identifiant L1 dans MA_ZONE\n"
            + " > CD MA_ZONE D1 creer un DETECTEUR avec l'identifiant D1 dans MA_ZONE\n"
            + " > CC MA_ZONE C1 creer un CONTROLEUR avec l'identifiant C1 dans MA_ZONE\n"
            + " SA {ID_ZONE} {ID_APPAREIL} Supprimer un appareil dans une zone\n"
            + " > SL MA_ZONE L1 Supprimer l'appareil L1 dans MA_ZONE\n"
            + " AA {ID_ZONE} {ID_APPAREIL} Activer un appareil d'une ZONE \n"
            + " > AA MA_ZONE L1 Activer l'appareil L1 de la zone MA_ZONE\n"
            + " EA {ID_ZONE} {ID_APPAREIL} Eteindre un appareil d'une ZONE\n"
            + " > EA MA_ZONE L1 Eteindre l'appareil L1 de la zone MA_ZONE\n"
            + " PA {ID_ZONE} {ID_APPAREIL} {MIN-MAX} Parametrer un appareil d'une ZONE avec une valeur entre MIN-MAX(inclusivement)\n"
            + " > PA MA_ZONE L1 40 Parametrer l'appareil L1 de la zone MA_ZONE avec une valeur de 40\n";
        }
    }
}

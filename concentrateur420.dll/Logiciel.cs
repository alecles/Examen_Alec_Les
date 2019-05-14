using System;
using System.Collections.Generic;
using System.Text;

namespace Concentrateur420
{
    public class Logiciel
    {
        private Concentrateur concentrateur;
        private int luminosite;
        private int temperature;
        private int nbLumieres;
        private int nbThermosthat;
        private bool lumieresAllumees;

        private const string CUISINE = "CUISINE";
        private const string PREF_LUM = "L_";
        private const string PREF_THERM = "T_";
        private const int LUMINOSITE_MIN = 50;
        private const int LUMINOSITE_MAX = 200;
        private const int TEMPERATURE_MIN = 17;
        private const int TEMPERATURE_MAX = 23;
        private const int NB_LUMIERES_MAX = 5;
        private const int NB_THERMOSTHAT_MAX = 2;

        public Logiciel()
        {
            concentrateur = new Concentrateur(""); //*
            concentrateur.CreerZone(CUISINE);
            nbLumieres = 0;
            nbThermosthat = 0;
            luminosite = LUMINOSITE_MIN;
            temperature = TEMPERATURE_MIN;
            lumieresAllumees = true;
        }

        public void AjouterLumiere()
        {
            if (nbLumieres > NB_LUMIERES_MAX)
            {
                throw new C420Exception("Le nombre de lumière dépasse le maximum de lumière possible");
            }

            else
            {
                Lumiere lumiere = new Lumiere("L_"+nbLumieres);
                nbLumieres++;

                concentrateur.ActiverAppareil(CUISINE, "L_" + nbLumieres);//*
            }
        }

        public void SupprimerLumiere()
        {
            if (nbLumieres < 0)
            {
                throw new C420Exception("Le nombre de lumière est plus bas que le minimum de lumière possible");
            }

            else
                nbLumieres--; //*
        }

        public void AugmenterLuminosite()
        {
            luminosite += 25; //*
        }

        public void DiminuerLuminosite()
        {
            luminosite -= 25; //*
        }

        public void AllumerEteindreLumieres()
        {
            if (lumieresAllumees == true)
                lumieresAllumees = false;

            else
                lumieresAllumees = true;
        }

        public void AjouterThermosthat()
        {
            if (nbThermosthat > NB_THERMOSTHAT_MAX)
            {
                throw new C420Exception("Le nombre de thermosthat est plus haut que le nombre de thermosthat possible");
            }

            else
            {
                Controleur thermosthat = new Controleur("T_" + nbThermosthat);
                nbThermosthat++;


                concentrateur.ActiverAppareil(CUISINE, "T_" + nbThermosthat); //*
            }
                
        }

        public void SupprimerThermosthat()
        {
            if (nbThermosthat < 0)
            {
                throw new C420Exception("Le nombre de thermosthat est plus bas que le minimum de thermosthat possible");
            }

            else
            {
                nbThermosthat--; //*
            }
                
        }

        public void AugmenterTemperature()
        {
            temperature += 1;
        }

        public void DiminuerTemperature()
        {
            temperature -= 1;
        }

        public string GetEtat()
        {
            if (lumieresAllumees == true)
                return "> "+nbLumieres+" lumieres allumees "+NB_LUMIERES_MAX+"\n" +
                    "> "+nbThermosthat+" thermosthats actifs "+NB_THERMOSTHAT_MAX;

            else
                return "Tout est noir";
        }

    }
}

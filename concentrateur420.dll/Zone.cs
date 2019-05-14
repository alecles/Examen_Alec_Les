using System;
using System.Collections.Generic;
using System.Text;

namespace Concentrateur420
{
    internal class Zone
    {
        private string id;
        private List<Appareil> appareils = new List<Appareil>();

        public string Id
        {
            get
            {
                return id;
            }
        }

        public Zone(string idZone)
        {
            id = idZone;
        }

        public void Activer()
        {
            for (int i = 0; i < appareils.Count; i++)
            {
                appareils[i].Actif = true;
            }
        }

        public void Eteindre()
        {
            for (int i = 0; i < appareils.Count; i++)
            {
                appareils[i].Actif = false;
            }
        }

        public void CreerLumiere(string idLumiere)
        {
            foreach (Appareil appareil in appareils)
            {          
                GetAppareil(idLumiere);

                if (appareil.Id != idLumiere)
                {
                    appareils.Add(appareil);
                }

                else
                    throw new C420Exception("La lumière existe déjà dans la zone.", this);
            }
        }

        public void CreerDetecteur(string idDetecteur)
        {
            foreach (Appareil appareil in appareils)
            {
                GetAppareil(idDetecteur);

                if (appareil.Id != idDetecteur)
                {
                    appareils.Add(appareil);
                }

                else
                    throw new C420Exception("Le détecteur existe déjà dans la zone.", this);
            }
        }

        public void CreerControleur(string idControleur)
        {
            foreach (Appareil appareil in appareils)
            {
                GetAppareil(idControleur);

                if (appareil.Id != idControleur)
                {
                    appareils.Add(appareil);
                }

                else
                    throw new C420Exception("Le contrôleur existe déjà dans la zone.", this);
            }
        }

        public void SupprimerAppareil(string idAppareil)
        {
            foreach(Appareil appareil in appareils)
            {   
                GetAppareil(idAppareil);

                if (idAppareil == null)
                {
                    throw new C420Exception("Le controleur n'existe pas.", this);
                }

                else
                    appareils.Remove(appareil);
            }
        }

        public void ActiverAppareil(string idAppareil)
        {
            foreach(Appareil appareil in appareils)
            {          
                GetAppareil(idAppareil);

                if (idAppareil == null)
                {
                    throw new C420Exception("L'appareil n'existe pas.", this);
                }

                else
                    appareil.Actif = true;
            }
        }

        public void EteindreAppareil(string idAppareil)
        {
            foreach (Appareil appareil in appareils)
            {
                GetAppareil(idAppareil);

                if (idAppareil == null)
                {
                    throw new C420Exception("L'appareil n'existe pas.", this);
                }

                else
                    appareil.Actif = false;
            }          
        }

        public void ParametrerAppareil(string idAppareil, int valeur)
        {
            foreach(Appareil appareil in appareils)
            {
                GetAppareil(idAppareil);

                if (idAppareil == null)
                {
                    throw new C420Exception("L'appareil n'existe pas.", this);
                }

                else
                    appareil.Valeur = Convert.ToInt32(Console.ReadLine());
            }         
        }

        public override string ToString()
        {
            return base.ToString();
        }
        
        private Appareil GetAppareil(string idAppareil)
        {
            for (int i = 0; i < appareils.Count; i++)
            {
                if (appareils[i].Id == idAppareil)
                {
                    return appareils[i];
                }
            }  
            
            return null;
        }
    }
}

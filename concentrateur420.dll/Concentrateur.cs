using System;
using System.Collections.Generic;
using System.Text;

namespace Concentrateur420
{
    sealed public partial class Concentrateur
    {
        private string id;
        private List<Zone> zones = new List<Zone>();

        public string Id
        {
           get
           {
               return id;
           }
        }

        public Concentrateur(string id)
        {
            this.id = id;
        }

        internal void CreerZone(string idZone)
        {
            foreach(Zone zone in zones)
            {
                GetZone(idZone);

                if (zone.Id != idZone)
                {
                    zones.Add(zone);
                }
                else
                    throw new C420Exception("La zone existe déjà.");
            }          
        }

        internal void SupprimerZone(string idZone)
        {
            foreach (Zone zone in zones)
            {
                GetZone(idZone);

                if (zone.Id == idZone)
                {
                    zones.Remove(zone);
                }
                else
                    throw new C420Exception("La zone n'existe pas.");
            }
        }

        internal void ActiverZone(string idZone)
        {
            foreach (Zone zone in zones)
            {
                GetZone(idZone);

                if (zone.Id == idZone)
                {
                    zone.Activer();
                }
                else
                    throw new C420Exception("La zone n'existe pas.");
            }
        }

        internal void EteindreZone(string idZone)
        {
            foreach (Zone zone in zones)
            {
                GetZone(idZone);

                if (zone.Id == idZone)
                {
                    zone.Eteindre();
                }
                else
                    throw new C420Exception("La zone n'existe pas.");
            }
        }

        internal void CreerLumiere(string idZone, string idLumiere)
        {
            foreach (Zone zone in zones)
            {
                if (zone.Id == idZone)
                {
                    CreerLumiere(idZone, idLumiere);
                }
                else
                    throw new C420Exception("La zone n'existe pas.");
            }
        }

        internal void CreerDetecteur(string idZone, string idDetecteur)
        {
            foreach (Zone zone in zones)
            {
                if (zone.Id == idZone)
                {
                    CreerDetecteur(idZone, idDetecteur);
                }
                else
                    throw new C420Exception("La zone n'existe pas.");
            }
        }

        internal void CreerControleur(string idZone, string idControleur)
        {
            foreach (Zone zone in zones)
            {
                if (zone.Id == idZone)
                {
                    CreerControleur(idZone, idControleur);
                }
                else
                    throw new C420Exception("La zone n'existe pas.");
            }
        }

        internal void SupprimerAppareil(string idZone, string idAppareil)
        {
            foreach (Zone zone in zones)
            {
                if (zone.Id == idZone)
                {
                    SupprimerAppareil(idZone, idAppareil);
                }
                else
                    throw new C420Exception("La zone n'existe pas.");
            }
        }

        internal void ActiverAppareil(string idZone, string idAppareil)
        {
            foreach (Zone zone in zones)
            {
                if (zone.Id == idZone)
                {
                    ActiverAppareil(idZone, idAppareil);
                }
                else
                    throw new C420Exception("La zone n'existe pas.");
            }
        }

        internal void EteindreAppareil(string idZone, string idAppareil)
        {
            foreach (Zone zone in zones)
            {
                if (zone.Id == idZone)
                {
                    EteindreAppareil(idZone, idAppareil);
                }
                else
                    throw new C420Exception("La zone n'existe pas.");
            }
        }

        internal void ParametrerAppareil(string idZone, string idAppareil, int valeur)
        {
            foreach (Zone zone in zones)
            {
                if (zone.Id == idZone)
                {
                    ParametrerAppareil(idZone, idAppareil, valeur);
                }
                else
                    throw new C420Exception("La zone n'existe pas.");
            }
        }

        internal void ParametrerAppareil(string idZone, string idAppareil, string valeur)
        {
            foreach (Zone zone in zones)
            {
                if (zone.Id == idZone)
                {
                    try
                    {
                        Convert.ToInt32(valeur);
                    }

                    catch(C420Exception e)
                    {
                        throw new C420Exception("La conversion est invalide", e);
                    }

                    ParametrerAppareil(idZone, idAppareil, valeur);
                }
                else
                    throw new C420Exception("La zone n'existe pas.");
            }
        }

        internal string GetEtat()
        {
            return "{CONCENTRATEUR:{id:"+id+"nbZones:"+zones.Count+"}\n" +
                "{ZONE:{id:" + id + "nbAppareils:}";
        }

        private Zone GetZone(string idZone)
        {
            for (int i = 0; i < zones.Count; i++)
            {
                if (zones[i].Id == idZone)
                {
                    return zones[i];
                }
            }

            return null;
        }
    }
}

using System;

namespace Concentrateur420
{
    internal class Appareil
    {
        private string id;
        private bool actif;
        private int valeurMin;
        private int valeur;
        private int valeurMax;


        public string Id
        {
            get
            {
                return id;
            }
        }

        public bool Actif
        {
            get
            {
                return actif;
            }

            set
            {
                actif = value;
            }
        }

        public int Valeur
        {
            get
            {
                return valeur;
            }

            set
            {
                valeur = value;
            }
        }

        public int GetValeurMin()
        {
            return valeurMin;
        }

        public int GetValeurMax()
        {
            return valeurMax;
        }

        protected Appareil(string idAppareil, int valeurMin, int valeurMax)
        {
            id = idAppareil;
            valeur = this.valeurMin;
            this.valeurMax = valeurMax;

            if (valeur < this.valeurMin || valeur > this.valeurMax)
            {
                throw new C420Exception("La température est plus basse que la température minimale ou plus haute que la température maximale.", this);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Concentrateur420
{
    public class C420Exception : Exception
    {
        private Appareil appareil;
        private Zone zone;

        public C420Exception(string message)
        {

        }

        public C420Exception(string message, Exception innerException)
        {

        }

        internal C420Exception(string message, Zone zone)
        {

        }

        internal C420Exception(string message, Appareil appareil)
        {

        }

        public override string ToString()
        {
            string info = DateTime.Now.ToLocalTime() + Message + StackTrace;

            if (InnerException != null)
            {
                info += InnerException.Message;
            }

            else if (appareil != null)
            {
                info += appareil.ToString();
            }

            else if (zone != null)
            {
                info += zone.ToString();
            }

            return info;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBaseDeDonneeIII
{
    public static class Session
    {
        public static int NoUtilisateur;
        public static int NoType;  
        public static string NomUtilisateur;

        public static bool EstAdmin
        {
            get { return NoType == 1; }
        }
    }
}

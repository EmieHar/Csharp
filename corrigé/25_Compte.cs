using System;
using System.Collections.Generic;
using System.IO;

namespace CompteBancaire
{
    class Compte
    {
        //Champs
        private string prenom;
        private string nom;

        protected string typeCompte;

        protected double solde;
        private double depot;
        private double retrait;

        // Propriétés
        public string TypeCompte
        { get { return this.typeCompte; } }

        public double Retrait
        {
            get { return this.retrait; }
            set { this.retrait = value; }
        }
        public double Depot
        {
            get { return this.depot; }
            set { this.depot = value; }
        }

        public double Solde
        { get { return this.solde; } }

        // Constructeurs
        public Compte()
        {
            prenom = "Julie";
            nom = "Dupont";
        }

        // Méthodes
        // Calcul du solde général (remise à zéro des valeurs)
        public void SoldeGeneral()
        {
            solde = solde + depot - retrait;
            depot = 0;
            retrait = 0;
        }

        // Calcule le solde lorsque le retrait est égal à zéro
        public void SoldeDepot(double montant)
        {
            depot = montant;
            retrait = 0;
            solde = solde + depot - retrait;
        }

        // Calcule le solde lorsque le dépôt est égal à zéro
        public void SoldeRetrait(double montant)
        {
            retrait = montant;
            depot = 0;
            solde = solde + depot - retrait;
        }

        // Affiche le menu de la banque en ligne
        public void AfficherMenu()
        {
            Console.WriteLine("Veuillez sélectionner une option ci-dessous :");
            Console.WriteLine("[I] Afficher les informations sur le titulaire du compte");
            Console.WriteLine("[CB] Compte courant - Consulter le solde");
            Console.WriteLine("[CD] Compte courant - Déposer des fonds");
            Console.WriteLine("[CW] Compte courant - Retirer des fonds");
            Console.WriteLine("[SB] Compte épargne - Consulter le solde");
            Console.WriteLine("[SD] Compte épargne - Déposer des fonds");
            Console.WriteLine("[SW] Compte épargne - Retirer des fonds");
            Console.WriteLine("[X] Quitter");
        }

        // Informations sur le compte
        public string InfoCompte()
        {
            string infoCompte = ("Propriétaire : " + prenom + " " + nom);
            return infoCompte;
        }

        // Écrire toutes les transactions dans le journal. 
        public void EcrireResume(IList<string> transactions, string nomFichier)
        {
            using (StreamWriter resume = new StreamWriter(nomFichier + ".txt", true))
            {
                foreach (string transaction in transactions)
                {
                    resume.WriteLine(transaction);
                }
            }
        }
    }
}
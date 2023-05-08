using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Création des comptes
        CompteCourant compteCourant = new CompteCourant("John Doe", "1234567890", 1000);
        CompteEpargne compteEpargne = new CompteEpargne("John Doe", "0987654321", 5000, 0.02);

        // Boucle principale de l'application
        bool quitter = false;
        while (!quitter)
        {
            Console.WriteLine("Veuillez sélectionner une option ci-dessous :");
            Console.WriteLine("[I] Voir les informations sur le titulaire du compte");
            Console.WriteLine("[CS] Compte courant - Consulter le solde");
            Console.WriteLine("[CD] Compte courant - Déposer des fonds");
            Console.WriteLine("[CR] Compte courant - Retirer des fonds");
            Console.WriteLine("[ES] Compte épargne - Consulter le solde");
            Console.WriteLine("[ED] Compte épargne - Déposer des fonds");
            Console.WriteLine("[ER] Compte épargne - Retirer des fonds");
            Console.WriteLine("[X] Quitter");

            string choix = Console.ReadLine().ToUpper();

            switch (choix)
            {
                case "I":
                    Console.WriteLine(compteCourant.Titulaire);
                    break;

                case "CS":
                    Console.WriteLine("Solde du compte courant : " + compteCourant.Solde + " €");
                    break;

                case "CD":
                    Console.WriteLine("Quel montant souhaitez-vous déposer ?");
                    double depotCC = Convert.ToDouble(Console.ReadLine());
                    compteCourant.Deposer(depotCC);
                    Console.WriteLine("Vous avez déposé : " + depotCC + " €.");
                    break;

                case "CR":
                    Console.WriteLine("Quel montant souhaitez-vous retirer ?");
                    double retraitCC = Convert.ToDouble(Console.ReadLine());
                    if (compteCourant.Retirer(retraitCC))
                    {
                        Console.WriteLine("Vous avez retiré : " + retraitCC + " €.");
                    }
                    else
                    {
                        Console.WriteLine("Retrait impossible : solde insuffisant.");
                    }
                    break;

                case "ES":
                    Console.WriteLine("Solde du compte épargne : " + compteEpargne.Solde + " €");
                    break;

                case "ED":
                    Console.WriteLine("Quel montant souhaitez-vous déposer ?");
                    double depotCE = Convert.ToDouble(Console.ReadLine());
                    compteEpargne.Deposer(depotCE);
                    Console.WriteLine("Vous avez déposé : " + depotCE + " €.");
                    break;

                case "ER":
                    Console.WriteLine("Quel montant souhaitez-vous retirer ?");
                    double retraitCE = Convert.ToDouble(Console.ReadLine());
                    if (compteEpargne.Retirer(retraitCE))
                    {
                        Console.WriteLine("Vous avez retiré : " + retraitCE + " €.");
                    }
                    else
                    {
                        Console.WriteLine("Retrait impossible : solde insuffisant.");
                    }
                    break;

                case "X":
                    quitter = true;
                    break;

                default:
                    Console.WriteLine("Option invalide.");
                    break;
            }

            Console.WriteLine("Appuyez sur Entrée pour continuer...");
            Console.ReadLine();
            Console.Clear();
        }

            // Écriture des transactions dans un fichier texte
      StreamWriter sw = new StreamWriter("transactions.txt");
      sw.WriteLine("Transactions compte courant :");
      foreach (Transaction transaction in compteCourant.Transactions)
      {
          sw.WriteLine(transaction);
      }
      sw.WriteLine();
      sw.WriteLine("Transactions compte épargne :");
      foreach (Transaction transaction in compteEpargne.Transactions)
      {
          sw.WriteLine(transaction);
      }
      sw.Close();
  }
}


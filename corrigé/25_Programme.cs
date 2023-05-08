using System;
using System.Collections.Generic;

namespace CompteBancaire
{
    class Programme
    {
        static void Main(string[] args)
        {
            // Instanciation des objets
            Compte compte = new Compte(); // Création de notre client unique
            Cheque cheque = new Cheque(2000); // Compte courant  
            Epargne epargne = new Epargne(10000); // Compte épargne  

            // Paramètres string du nom du client et du compte pour le streamwriter.  
            string streamInfoClient = (compte.InfoCompte());
            string typeCompteCheque = (cheque.TypeCompte);
            string typeCompteEpargne = (epargne.TypeCompte);

            IList<string> resumeCheque = new List<string>();
            IList<string> resumeEpargne = new List<string>();

            resumeCheque.Add(typeCompteCheque);
            resumeCheque.Add(streamInfoClient);

            resumeEpargne.Add(typeCompteEpargne);
            resumeEpargne.Add(streamInfoClient);

            string choixUtilisateur = ""; // moyen de sortir de la boucle do-while du menu

            do
            {
                // Les entrées pour chaque liste qui doivent être faites à l'intérieur de la boucle.
                string entreDepotCheque = ($"Transaction: +${cheque.Depot} à {DateTime.Now.ToString()} Solde actuel : ${cheque.Solde}");
                string entreRetraitCheque = ($"Transaction: +${cheque.Retrait} a {DateTime.Now.ToString()} Solde actuel : ${cheque.Solde}");
                string entreDepotEpargne = ($"Transaction: +${epargne.Depot} à {DateTime.Now.ToString()} Solde actuel : ${epargne.Solde}");
                string entreRetraitEpargne = ($"Transaction: +${epargne.Retrait} à {DateTime.Now.ToString()} Solde actuel : ${epargne.Solde}");

                // Cheque
                if (cheque.Depot > 0)
                {
                    resumeCheque.Add(entreDepotCheque);
                    cheque.Depot = 0;
                }

                if (cheque.Retrait > 0)
                {
                    resumeCheque.Add(entreRetraitCheque);
                    cheque.Retrait = 0;
                }

                // Epargne
                if (epargne.Retrait > 0)
                {
                    resumeEpargne.Add(entreDepotEpargne);
                    epargne.Depot = 0;
                }

                if (epargne.Retrait > 0)
                {
                    resumeEpargne.Add(entreRetraitEpargne);
                    epargne.Retrait = 0;
                }

                // Menu Banque en ligne : ce menu est une boucle do-while avec une instruction switch imbriquée.
                // Les choix sont les suivants : Information sur le client, Informations sur le compte (pour chaque type de compte), Dépôt (pour chacun), Retrait (pour chacun) ou Quitter. 

                Console.WriteLine("Appuyez sur Entrée pour afficher le menu");
                Console.ReadLine();

                compte.AfficherMenu(); // Le menu de la banque en ligne
                choixUtilisateur = Console.ReadLine(); // Opération du menu que l'utilisateur a choisit

                switch (choixUtilisateur.ToUpper())
                {
                    case "I": // Afficher les informations sur le client
                        Console.Clear();
                        Console.WriteLine(compte.InfoCompte());
                        break;
                    case "CS": // Afficher le solde du compte courant
                        Console.Clear();
                        compte.SoldeGeneral();
                        Console.WriteLine("Solde compte courant : " + cheque.Solde + " €.");
                        break;
                    case "ES": // Afficher le solde du compte épargne
                        Console.Clear();
                        epargne.SoldeGeneral();
                        Console.WriteLine("Solde compte épargne : " + epargne.Solde + " €.");
                        break;
                    case "CD": // Effectuer un dépôt sur le compte courant
                        Console.Clear();
                        Console.WriteLine("Quel montant souhaitez-vous déposer ?");
                        cheque.Depot = double.Parse(Console.ReadLine());
                        Console.WriteLine("Vous avez déposé : " + cheque.Depot + " €");
                        cheque.SoldeDepot(cheque.Depot);
                        break;
                    case "ED": //Effectuer un dépôt sur le compte épargne
                        Console.Clear();
                        Console.WriteLine("Quel montant souhaitez-vous déposer ?");
                        epargne.Depot = double.Parse(Console.ReadLine());
                        Console.WriteLine("Vous avez déposé : " + epargne.Depot + " €.");
                        epargne.SoldeDepot(epargne.Depot);
                        break;
                    case "CR": // Effectuer un retrait sur le compte courant
                        Console.Clear();
                        Console.WriteLine("Quel montant souhaitez-vous retirer ?");
                        compte.Retrait = double.Parse(Console.ReadLine());
                        Console.WriteLine("Vous avez retiré : " + compte.Retrait + " €.");
                        compte.SoldeRetrait(compte.Retrait);
                        break;
                    case "ER": // Effectuer un retrait sur le compte épargne
                        Console.Clear();
                        Console.WriteLine("Quel montant souhaitez-vous retirer ?");
                        epargne.Retrait = double.Parse(Console.ReadLine());
                        Console.WriteLine("Vous avez retiré : " + epargne.Retrait + " €.");
                        epargne.SoldeRetrait(epargne.Retrait);
                        break;
                    case "X": // Quitter
                        Console.Clear();
                        compte.EcrireResume(resumeCheque, "Courant");
                        compte.EcrireResume(resumeEpargne, "Epargne");
                        Console.WriteLine("Merci et à bientôt !");
                        Environment.Exit(0);
                        break;
                }
            } while (choixUtilisateur.ToUpper() != "X");
        }
    }
}
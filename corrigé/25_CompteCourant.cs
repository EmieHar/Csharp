namespace CompteBancaire
{
    class Cheque : Compte
    {
        // Constructeur
        public Cheque(double solde)
        {
            this.solde = solde;
            typeCompte = "Compte courant";
        }
    }
}
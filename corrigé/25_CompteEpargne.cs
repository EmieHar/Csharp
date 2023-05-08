namespace CompteBancaire
{
    class Epargne : Compte
    {
        // Constructeur
        public Epargne(double solde) : base()
        {
            this.solde = solde;
            typeCompte = "Compte Épargne";
        }
    }
}
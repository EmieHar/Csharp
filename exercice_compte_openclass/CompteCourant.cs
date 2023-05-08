public class CompteCourant : Compte
{
public CompteCourant(string titulaire, string numero, double soldeInitial) : base(titulaire, numero, soldeInitial)
{
}


public override bool Retirer(double montant)
{
    if (Solde >= montant)
    {
        Solde -= montant;
        Transactions.Add(new Transaction(montant, "Retrait"));
        return true;
    }
    else
    {
        return false;
    }
}
}

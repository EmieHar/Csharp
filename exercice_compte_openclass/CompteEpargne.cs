public class CompteEpargne : Compte
{
public double TauxInteret { get; }


public CompteEpargne(string titulaire, string numero, double soldeInitial, double tauxInteret) : base(titulaire, numero, soldeInitial)
{
    TauxInteret = tauxInteret;
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

public override void Deposer(double montant)
{
    Solde += montant * (1 + TauxInteret);
    Transactions.Add(new Transaction(montant, "Dépôt avec intérêts"));
}
}

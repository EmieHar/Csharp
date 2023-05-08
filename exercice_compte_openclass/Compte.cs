using System.Collections.Generic;

public abstract class Compte
{
public string Titulaire { get; }
public string Numero { get; }
public double Solde { get; protected set; }
public List<Transaction> Transactions { get; }



public Compte(string titulaire, string numero, double soldeInitial)
{
    Titulaire = titulaire;
    Numero = numero;
    Solde = soldeInitial;
    Transactions = new List<Transaction>();
}

public virtual void Deposer(double montant)
{
    Solde += montant;
    Transactions.Add(new Transaction(montant, "Dépôt"));
}

public abstract bool Retirer(double montant);
}

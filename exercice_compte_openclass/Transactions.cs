using System;

public class Transaction
{
public DateTime Date { get; }
public double Montant { get; }
public string Type { get; }


public Transaction(double montant, string type)
{
    Date = DateTime.Now;
    Montant = montant;
    Type = type;
}

public override string ToString()
{
    return $"{Date} : {Type} de {Montant} €.";
}
}

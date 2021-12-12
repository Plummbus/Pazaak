using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private string playerName;
    [SerializeField]
    private int credits;
    [SerializeField]
    private int betAmount;

    public Card[] hand;


    public void setName(string n)
    {
        this.playerName = n;
    }

    public void setBetAmount(int amount)
    {
        this.betAmount = amount;
    }

    public string getName()
    {
        return this.name;
    }

    public int getCredits()
    {
        return this.credits;
    }

    public int getBetAmount()
    {
        return this.betAmount;
    }

    public bool isBetValid(int amount)
    {
        if (amount <= this.credits)
        {
            return true;
        }
        return false;
    }

    public void makeBet(int amount)
    {
        if (this.isBetValid(amount))
        {
            this.setBetAmount(amount);
            this.credits -= amount;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public HandCard[] hand;
    public string playerName;
    public int credits;
    public int betAmount;


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
        return this.playerName;
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

[System.Serializable]
public class HandCard
{
    public int modifier;

    public HandCard(int value)
    {
        this.modifier = value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IListExtensions
{
    /// <summary>
    /// Shuffles the element order of the specified list.
    /// </summary>
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}

public class DeckManager : MonoBehaviour
{

    void Start()
    {
        Deck testDeck = createDeck();
        printSize(testDeck);
        printDeckToConsole(testDeck);
    }

    public Deck createDeck()
    {
        Deck deck = new Deck();
        int[] cardValues = cardValueShuffle();
        for (int i = 0; i < cardValues.Length; i++)
        {
            deck.push(cardValues[i]);   //push method contains Card constructor
        }

        return deck;
    }

    public int[] cardValueShuffle()
    {
        //ArrayList nonShuffledArray = new ArrayList();   //putting values in here first so we can randomly pop off a value and not worry about shifting indices
        List<int> tempArray = new List<int>();
        //int[] shuffledArray = new int[40];  //final order of our deck before we make the stack. game uses a 40 card deck.
        
        for (int i = 1; i < 11; i++)    //selects values from 1 - 10
        {
            for (int j = 0; j < 4; j++) //will add currently selected value to nonShuffledArray: 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, etc....
            {
                tempArray.Add(i);
            }
        }

        tempArray.Shuffle();
        int[] shuffledArray = tempArray.ToArray();
        return shuffledArray;
    }

    //for testing purposes
    public void printSize(Deck deck)
    {
        Debug.Log("Size of current deck: " + deck.size());
    }

    //for testing purposes
    public void printDeckToConsole(Deck deck)
    {
        Card current = deck.getHead();
        while (current != null)
        {
            string message = "Card value: " + current.getValue();
            Debug.Log(message);
            current = current.getNext();
        }
    }

}

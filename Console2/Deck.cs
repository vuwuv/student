using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Deck
{
    public enum Suit { Spades, Hearts, Diamonds, Clubs };
    public enum Number { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };

    public class Card
    {

        public Suit suit;
        public Number number;

        public Card(Suit suit, Number number)
        {
            this.suit = suit;
            this.number = number;
        }
    }

    private Card[] deck;

    public Deck(Number minNumber)
    {
        List<Card> cards = new List<Card>();

        foreach (Number number in Enum.GetValues(typeof(Number)))
        {
            if (number < minNumber) continue;

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                cards.Add(new Card(suit, number));
            }
        }

        this.deck = cards.ToArray();
    }

    private Card this[int i]
    {
        get { return this.deck[i]; }
        set { this.deck[i] = value; }
    }

    public void Mix()
    {
        Random random = new Random();
        this.deck = this.deck.OrderBy(card => { return random.Next(); }).ToArray();
    }

    public Card Distribution()
    {
        Random rand = new Random();
        Card result = this.deck[rand.Next(this.deck.Length)];
        return result;
    }

    public Card[] Distribution6()
    {
        //List<Card> deck = new List<Card>(this.deck.Where(card => card.Present));
        List<Card> deck = new List<Card>(this.deck);
        Random rnd = new Random();
        List<Card> cards = new List<Card>();
        do
        {
            Card result = this.deck[rnd.Next(this.deck.Length)];
            cards.Add(result);
            deck.Remove(result);
        } while (cards.Count != 6);

        return cards.ToArray();
    }
}
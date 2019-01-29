using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
	public Deck deck;

    public Cell[] fieldCells;
    public CardObject[] cardsType;
    public Card cardPrefab;

	private Stack<Card> startCardsStack;
	private List<Card> allCards;

    void Start()
    {
		// Create card objects
        allCards = CreateCards();
		// Mixed cards
        var mixedCards = MixDeck(allCards);
		// Save last mixed cards
		startCardsStack = mixedCards;
		// Fill field cells
        FillField(mixedCards);
		// Fill deck
		deck.closedCards = mixedCards;
    }

    private List<Card> CreateCards()
    {
        List<Card> cardList = new List<Card>(GameConstants.MAX_CARDS);
        for (int cardID = 0; cardID < GameConstants.MAX_CARDS / cardsType.Length; cardID++)
        {
            for (int type = 0; type < cardsType.Length; type++)
            {
                var card = GameObject.Instantiate<Card>(cardPrefab);
                card.transform.SetParent(deck.closedCardsCell, true);
                card.transform.localScale = Vector3.one;
                card.transform.localPosition = Vector2.zero;
                card.name = string.Format("Card_{0}", cardID);
                card.SetParams(cardID, cardsType[type]);
                cardList.Add(card);
            }
        }
        return cardList;
    }

    private Stack<Card> MixDeck(List<Card> cardsList)
    {
        var stack = new Stack<Card>(GameConstants.MAX_CARDS);
        while (cardsList.Count > 0)
        {
            var randomID = UnityEngine.Random.Range(0, cardsList.Count);
            var card = cardsList[randomID];
            cardsList.Remove(card);
            stack.Push(card);
        }
        return stack;
    }

    public void FillField(Stack<Card> cadrs)
    {
        for (int col = 0; col < fieldCells.Length; col++)
        {
            for (int row = 0; row <= col; row++)
            {
                fieldCells[col].AddCard(cadrs.Pop(), row == col);
            }
        }
    }
}

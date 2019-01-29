using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Deck : MonoBehaviour
{
    public Transform closedCardsCell, openedCardsCell;
    public Stack<Card> closedCards;
    public Stack<Card> openedCards;

    void Start()
    {
        openedCards = new Stack<Card>();
    }

    private void OpenCard()
    {
        var card = closedCards.Pop();
        if (card != null)
        {
            openedCards.Push(card);
            card.transform.SetParent(openedCardsCell, true);
            card.transform.localPosition = Vector2.zero;
            card.ShowCard(true);
        }
    }

    private void ResetDeck()
    {
        while(openedCards.Count > 0)
        {
            var card = openedCards.Pop();
            closedCards.Push(card);
            card.transform.SetParent(closedCardsCell, true);
            card.transform.localPosition = Vector2.zero;
            card.ShowCard(false);
        }
    }

    public void OnClick()
    {
        if (closedCards.Count > 0)
        {
            OpenCard();
        }
        else
        {
            ResetDeck();
        }
    }
}

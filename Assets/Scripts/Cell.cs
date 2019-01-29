using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    private Card currentCard;
	private int row = 0;

    public void AddCard(Card card, bool showCard = false)
    {
        card.transform.SetParent(currentCard == null ? transform : currentCard.transform);
        card.transform.localPosition = new Vector2(0, currentCard == null ? 0 : -30);
        card.ShowCard(showCard);
        currentCard = card;
		row++;
    }
}

using UnityEngine;

[CreateAssetMenu(fileName="Card", menuName="Create card")]
public class CardObject : ScriptableObject
{
    public enum CardTypes { CLUBS, SPADES, DIAMONDS, HEARTS }

	public CardTypes type;
    public Sprite typeSprite;
}

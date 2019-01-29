using UnityEngine.UI;
using UnityEngine;

public class Card : MonoBehaviour
{

    [SerializeField] private CardObject cardParams;
    [SerializeField] private Image[] typeImages;
    [SerializeField] private Image bg;
    [SerializeField] private Text idText;
    [SerializeField] private GameObject parts;

    private int id;

    public void SetParams(int id, CardObject card)
    {
        cardParams = card;
        SetId(id);
        for (int i = 0; i < typeImages.Length; i++)
        {
            typeImages[i].sprite = cardParams.typeSprite;
        }
    }

    public void ShowCard(bool show)
    {
        parts.SetActive(show);
        bg.color = show ? Color.white : Color.gray;
    }

    private void SetId(int id)
    {
        this.id = id;
        switch (id)
        {
            case 0:
                idText.text = "A";
                break;
            case 1:
                idText.text = "2";
                break;
            case 2:
                idText.text = "3";
                break;
            case 3:
                idText.text = "4";
                break;
            case 4:
                idText.text = "5";
                break;
            case 5:
                idText.text = "6";
                break;
            case 6:
                idText.text = "7";
                break;
            case 7:
                idText.text = "8";
                break;
            case 8:
                idText.text = "9";
                break;
            case 9:
                idText.text = "10";
                break;
            case 10:
                idText.text = "J";
                break;
            case 11:
                idText.text = "Q";
                break;
            case 12:
                idText.text = "K";
                break;
        }
    }
}

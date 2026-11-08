using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "CardSO")]

public class CardSO : ScriptableObject
{
    public int cardIndex;
    public string cardName;
    public string cardDetails;

    public int cardValue;

    public CardSuite cardSuite;

    //public Sprite cardSprite;
}
public enum CardSuite
{
    Red,
    Blue,
    Green,
    Yellow
}

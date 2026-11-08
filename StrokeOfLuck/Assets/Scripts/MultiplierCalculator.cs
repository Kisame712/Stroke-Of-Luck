using UnityEngine;
using System;
using System.Collections.Generic;

public class MultiplierCalculator : MonoBehaviour
{
    [SerializeField] private CardSelector cardSelector;

    private List<BaseCard> selectedCards;
    private float multiplier;

    private void Awake()
    {
        multiplier = 0f;
    }

    public float GetMultiplierValue()
    {
        multiplier = MultiplierTable();
        return multiplier;
    }

    private float MultiplierTable()
    {
        selectedCards = cardSelector.GetSelectedCards();
        if(selectedCards.Count == 0)
        {
            return 0f;
        }

        float multiplierValue = 0f;
        switch (selectedCards.Count)
        {
            case 1:
                multiplierValue = 1f;
                break;
            case 2:
                // Could be a Pair
                CardSO cardSO1 = selectedCards[0].GetCardSO();
                CardSO cardSO2 = selectedCards[1].GetCardSO();

                if(cardSO1.cardValue == cardSO2.cardValue)
                {
                    multiplierValue = 2f;
                }
                else
                {
                    multiplierValue = 1f;
                }
                break;
            case 3:
                // Could be Three of a Kind
                cardSO1 = selectedCards[0].GetCardSO();
                cardSO2 = selectedCards[1].GetCardSO();
                CardSO cardSO3 = selectedCards[2].GetCardSO();

                if(cardSO1.cardValue == cardSO2.cardValue && cardSO1.cardValue == cardSO3.cardValue)
                {
                    multiplierValue = 4f;
                }
               
                // Could have a pair

                else if(cardSO1.cardValue == cardSO2.cardValue || cardSO2.cardValue == cardSO3.cardValue || cardSO1.cardValue == cardSO3.cardValue)
                {
                    multiplierValue = 2f;
                }

                // None of a kind
                else
                {
                    multiplierValue = 1f;
                }
                break;
            case 4:
                cardSO1 = selectedCards[0].GetCardSO();
                cardSO2 = selectedCards[1].GetCardSO();
                cardSO3 = selectedCards[2].GetCardSO();
                CardSO cardSO4 = selectedCards[3].GetCardSO();

                // Four of a Kind
                if(cardSO1.cardValue == cardSO2.cardValue && cardSO1.cardValue == cardSO3.cardValue && cardSO3.cardValue == cardSO4.cardValue)
                {
                    multiplierValue = 8f;
                }

                // Two Pairs
                else if((cardSO1.cardValue == cardSO2.cardValue && cardSO3.cardValue == cardSO4.cardValue && cardSO1.cardValue != cardSO3.cardValue) || (cardSO1.cardValue == cardSO3.cardValue && cardSO2.cardValue == cardSO4.cardValue && cardSO1.cardValue!=cardSO2.cardValue) || (cardSO1.cardValue == cardSO4.cardValue && cardSO2.cardValue == cardSO3.cardValue && cardSO1.cardValue != cardSO2.cardValue))
                {
                    multiplierValue = 6f;
                }

                // Three of a Kind
                else if ((cardSO1.cardValue == cardSO2.cardValue && cardSO1.cardValue == cardSO3.cardValue && cardSO1.cardValue!=cardSO4.cardValue) ||  (cardSO1.cardValue == cardSO2.cardValue && cardSO1.cardValue == cardSO4.cardValue && cardSO1.cardValue != cardSO3.cardValue) || (cardSO2.cardValue == cardSO3.cardValue && cardSO2.cardValue == cardSO4.cardValue && cardSO2.cardValue != cardSO1.cardValue))
                {
                    multiplierValue = 4f;
                }

                // Pair
                else if(cardSO1.cardValue == cardSO2.cardValue || cardSO1.cardValue == cardSO3.cardValue || cardSO1.cardValue == cardSO4.cardValue || cardSO2.cardValue == cardSO3.cardValue || cardSO2.cardValue == cardSO4.cardValue || cardSO3.cardValue == cardSO4.cardValue)
                {
                    multiplierValue = 2f;
                }

                // None of a Kind
                else
                {
                    multiplierValue = 1f;
                }

                break;
            case 5:
                cardSO1 = selectedCards[0].GetCardSO();
                cardSO2 = selectedCards[1].GetCardSO();
                cardSO3 = selectedCards[2].GetCardSO();
                cardSO4 = selectedCards[3].GetCardSO();
                CardSO cardSO5 = selectedCards[4].GetCardSO();

                List<int> cardValueList = new List<int> { cardSO1.cardValue, cardSO2.cardValue, cardSO3.cardValue, cardSO4.cardValue, cardSO5.cardValue};
                cardValueList.Sort();

                // Straight Flush
                if (cardValueList[4] == cardValueList[3] + 1 && cardValueList[4] == cardValueList[2] + 2 && cardValueList[4] == cardValueList[1] + 3 && cardValueList[4] == cardValueList[0] + 4 && cardSO1.cardSuite == cardSO2.cardSuite && cardSO1.cardSuite == cardSO3.cardSuite && cardSO1.cardSuite == cardSO4.cardSuite && cardSO1.cardSuite == cardSO5.cardSuite)
                {
                    multiplierValue = 32f;                    
                }
                // Straight
                else if (cardValueList[4] == cardValueList[3] + 1 && cardValueList[4] == cardValueList[2] + 2 && cardValueList[4] == cardValueList[1] + 3 && cardValueList[4] == cardValueList[0] + 4 && (cardSO1.cardSuite != cardSO2.cardSuite || cardSO1.cardSuite != cardSO3.cardSuite || cardSO1.cardSuite != cardSO4.cardSuite || cardSO1.cardSuite != cardSO5.cardSuite))
                {
                    multiplierValue = 16f;
                }
                // Flush
                else if (cardValueList[4] - cardValueList[0] > 4 && cardSO1.cardSuite == cardSO2.cardSuite && cardSO1.cardSuite == cardSO3.cardSuite && cardSO1.cardSuite == cardSO4.cardSuite && cardSO1.cardSuite == cardSO5.cardSuite)
                {
                    multiplierValue = 12f;
                }

                // Prime pair punch (3 of a kind + pair combo)
                else if ((cardSO1.cardValue == cardSO2.cardValue && cardSO1.cardValue == cardSO3.cardValue && cardSO4.cardValue == cardSO5.cardValue && cardSO1.cardValue!=cardSO4.cardValue) || (cardSO1.cardValue == cardSO2.cardValue && cardSO1.cardValue == cardSO4.cardValue && cardSO3.cardValue == cardSO5.cardValue && cardSO1.cardValue != cardSO3.cardValue) 
                    || (cardSO1.cardValue == cardSO2.cardValue && cardSO1.cardValue == cardSO5.cardValue && cardSO3.cardValue == cardSO4.cardValue && cardSO1.cardValue != cardSO3.cardValue) || (cardSO1.cardValue == cardSO3.cardValue && cardSO1.cardValue == cardSO4.cardValue && cardSO2.cardValue == cardSO5.cardValue && cardSO1.cardValue != cardSO2.cardValue)
                    || (cardSO1.cardValue == cardSO3.cardValue && cardSO1.cardValue == cardSO5.cardValue && cardSO2.cardValue == cardSO4.cardValue && cardSO1.cardValue != cardSO2.cardValue) || (cardSO1.cardValue == cardSO4.cardValue && cardSO1.cardValue == cardSO5.cardValue && cardSO2.cardValue == cardSO3.cardValue && cardSO1.cardValue != cardSO2.cardValue)
                    || (cardSO2.cardValue == cardSO3.cardValue && cardSO2.cardValue == cardSO4.cardValue && cardSO1.cardValue == cardSO5.cardValue && cardSO1.cardValue != cardSO2.cardValue) || (cardSO2.cardValue == cardSO3.cardValue && cardSO2.cardValue == cardSO5.cardValue && cardSO1.cardValue == cardSO4.cardValue && cardSO1.cardValue != cardSO2.cardValue)
                    || (cardSO2.cardValue == cardSO4.cardValue && cardSO2.cardValue == cardSO5.cardValue && cardSO1.cardValue == cardSO3.cardValue && cardSO1.cardValue != cardSO2.cardValue) || (cardSO3.cardValue == cardSO4.cardValue && cardSO3.cardValue == cardSO5.cardValue && cardSO1.cardValue == cardSO2.cardValue && cardSO1.cardValue != cardSO3.cardValue))
                {
                    multiplierValue = 10f;
                }

                // Four of a Kind

                // Two Pairs

                // Three of a Kind

                // Pair

                // None of a Kind
                else
                {
                    multiplierValue = 1f;
                }
                break;
        }

        return multiplierValue;
    }
    
}

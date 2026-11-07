using UnityEngine;
using System.Collections.Generic;
public class CardSelector : MonoBehaviour
{
    private List<BaseCard> selectedCards;

    private void Awake()
    {
        selectedCards = new List<BaseCard>();
    }
    private void Start()
    {
        BaseCard.OnAnyBaseCardClicked += BaseCard_OnAnyBaseCardClicked;
    }

    private void OnDestroy()
    {
        BaseCard.OnAnyBaseCardClicked -= BaseCard_OnAnyBaseCardClicked;
    }

    private void BaseCard_OnAnyBaseCardClicked(object sender, BaseCard.OnAnyBaseCardClickedEventArgs e)
    {
        if(e.isSelected == false)
        {
            e.baseCard.SetIsSelected(true);
            selectedCards.Add(e.baseCard);
        }
        else
        {
            if (selectedCards.Contains(e.baseCard))
            {
                selectedCards.Remove(e.baseCard);
                e.baseCard.SetIsSelected(false);
            }

            else
            {
                Debug.Log("Card was not present!! Logical error");
            }
        }

        Debug.Log("selected cards list size- " + selectedCards.Count);
    }
}

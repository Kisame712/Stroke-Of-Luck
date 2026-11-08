using UnityEngine;
using System.Collections.Generic;
public class CardSelector : MonoBehaviour
{
    [SerializeField] private int maxSelections;
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
        if(selectedCards.Count == maxSelections)
        {
            return;
        }

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
                Debug.LogError("Card was not present!! Logical error");
            }
        }

    }

    public List<BaseCard> GetSelectedCards()
    {
        return selectedCards;
    }
}

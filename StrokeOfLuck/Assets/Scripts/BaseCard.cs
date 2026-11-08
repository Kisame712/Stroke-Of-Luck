using UnityEngine;
using System;
using UnityEngine.UI;
public class BaseCard : MonoBehaviour
{
    [SerializeField] private CardSO cardSO;
    private bool isSelected;
    public static event EventHandler<OnAnyBaseCardClickedEventArgs> OnAnyBaseCardClicked;

    public class OnAnyBaseCardClickedEventArgs : EventArgs
    {
        public BaseCard baseCard;
        public bool isSelected;
    }

    private Button cardButton;

    private void Awake()
    {
        cardButton = GetComponent<Button>();
        isSelected = false;
    }

    private void Start()
    {
        cardButton.onClick.AddListener(() =>
        {
            OnAnyBaseCardClicked?.Invoke(this, new OnAnyBaseCardClickedEventArgs { baseCard = this, isSelected = isSelected});
        });
    }

    public void SetIsSelected(bool isSelected)
    {
        this.isSelected = isSelected;
    }

    public CardSO GetCardSO()
    {
        return cardSO;
    }
}

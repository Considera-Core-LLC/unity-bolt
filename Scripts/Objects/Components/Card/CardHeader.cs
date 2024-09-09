using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Libraries.Bolt.Objects.Components.Card
{
    public class CardHeader : 
        BaseComponent, 
        IEndDragHandler, 
        IDragHandler
    {
        // Height = Top Padding + Top Row Height + Bottom Row Height + Bottom Padding
        private bool _expanded;
        private bool _hasMore;
        private Card _card;
        private LayoutElement _layoutElement;
        [SerializeField] private EmptyComponent _titleTopRow;
        [SerializeField] private EmptyComponent _titleBottomRow;
        [SerializeField] private TMP_Text _cardTitle;
        [SerializeField] private GameObject _cardMore;

        private float HeaderHeight =>
            PaddingTopHeight + _titleTopRow.Height + _titleBottomRow.Height + PaddingBottomHeight;
        
        private LayoutElement LayoutElement =>
            GetComponent(ref _layoutElement);

        public IObject Build(
            Card card, 
            Color titleColor,
            string titleText = "",
            bool hasMore = false,
            bool expanded = false)
        {
            _expanded = expanded;
            _card = card;
            _cardTitle.color = titleColor;
            _cardTitle.SetText(titleText);
            _cardMore.SetActive(hasMore);

            return this;
        }

        public override void OnStart()
        {
            _titleBottomRow.SetActive(_expanded);
            LayoutElement.preferredHeight = HeaderHeight;
        }

        public void OnEndDrag(PointerEventData eventData) => 
            _card.StopMoving(eventData);

        public void OnDrag(PointerEventData eventData) => 
            _card.Move(eventData);

        public void SetHeaderText(string text) =>
            _cardTitle.SetText(text);
    }
}
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Libraries.Bolt.Objects.Components.Card
{
    [DisallowMultipleComponent]
    public class Card : HitboxComponent
    {
        private CardHeader _header;
        private CardBody _body;
        private Image _background;
        private Outline _outline;
        [SerializeField] private Color _cardColor = Color.white;
        [SerializeField] private Color _outlineColor = Color.white;
        [SerializeField] private Color _headerTitleColor = Color.white;

        public CardHeader Header =>
            GetComponentInChildren(ref _header);
        
        public CardBody Body =>
            GetComponentInChildren(ref _body);

        private Image Background =>
            GetComponent(ref _background);

        private Outline Outline =>
            GetComponent(ref _outline);

        public IObject Build(
            string title = "", 
            bool hasMore = false,
            bool expanded = false)
        {
            Header.Build(this, _headerTitleColor, title, hasMore, expanded);
            Background.color = _cardColor;
            Outline.effectColor = _outlineColor;

            return this;
        }

        public override void OnStart() => 
            Header.OnStart();

        public void StopMoving(PointerEventData eventData)
        {
            var newPosition = (Vector2)Rect.localPosition;
            newPosition.x = Mathf.Round(newPosition.x / 32) * 32;
            newPosition.y = Mathf.Round(newPosition.y / 32) * 32;
            Rect.localPosition = newPosition;
        }

        public void Move(PointerEventData eventData) => 
            base.Move(eventData.delta);
    }
}
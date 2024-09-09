using Libraries.Bolt.Objects.Components.Card;

namespace Libraries.Bolt.Extensions.UI.Cards
{
    public abstract class CardExtension : BaseExtension
    {
        private Card _card;
        
        protected Card Card => 
            GetComponent(ref _card);
        
        protected CardHeader CardHeader =>
            Card.Header;
    }
}
using UnityEngine;

namespace Libraries.Bolt.Objects.Components
{
    public class HitboxComponent : BaseComponent
    {
        protected void Move(Vector2 delta) => 
            Rect.position += (Vector3)delta;
    }
}
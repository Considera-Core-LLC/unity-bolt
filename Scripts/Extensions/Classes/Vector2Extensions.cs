using UnityEngine;

namespace Libraries.Bolt.Extensions.Classes
{
    public static class Vector2Extensions
    {
        public static Vector2 ToVector2(this int x) =>
            x * Vector2.one;
        
        public static Vector2 ToVector2(this float x) =>
            x * Vector2.one;
        
        public static Vector2 ToVector2(this double x) =>
            (x >= float.MaxValue ? float.MaxValue : (float)x) * Vector2.one;
    }
}
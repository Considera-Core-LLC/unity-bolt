using UnityEngine;

namespace Libraries.Bolt.Extensions.Classes
{
    public static class ColorExtensions
    {
        public static Color SetAlpha(this Color c, float a) =>
            new(c.r, c.g, c.b, a);
    }
}
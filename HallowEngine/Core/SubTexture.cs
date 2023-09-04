using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallowEngine.Core
{
    public static class SubTexture
    {
        public static Texture2D GetSubTexture(Texture2D tex, Rectangle rect)
        {
            Color[] texData = new Color[tex.Width * tex.Height];
            tex.GetData(texData);

            Color[] rectData = new Color[rect.Width * rect.Height];
            for (int x = 0; x < rect.Width; x++)
                for (int y = 0; y < rect.Height; y++)
                    rectData[x + y * rect.Width] = texData[x + rect.X + (y + rect.Y) * tex.Width];
            var subTex = new Texture2D(StaticRefs.graphicsDevice, rect.Width, rect.Height);
            subTex.SetData(rectData);
            return subTex;
        }
    }
}

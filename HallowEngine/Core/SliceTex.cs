using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HallowEngine.Core
{
    /// <summary>
    /// A 9-slice texture
    /// </summary>
    public class SliceTex
    {
        private Texture2D[] slices = new Texture2D[9];
        Point padding;

        public SliceTex(Texture2D tex)
        {
            padding = new Point(tex.Width/3, tex.Height/3);
            int sliceIndex = 0;
            for(int x = 0; x < tex.Width; x += padding.X)
            {
                for(int y = 0; y < tex.Height; y += padding.Y)
                {
                    slices[sliceIndex] = SubTexture.GetSubTexture(tex, new Rectangle(new Point(x, y), padding));
                    sliceIndex++;
                }
            }
        }

        public SliceTex(Texture2D tex, Point padding)
        {
            this.padding = padding;
            slices[0] = SubTexture.GetSubTexture(tex, new Rectangle(0, 0, padding.X, padding.Y));
            slices[1] = SubTexture.GetSubTexture(tex, new Rectangle(padding.X, 0, tex.Width - padding.X * 2, padding.Y));
            slices[2] = SubTexture.GetSubTexture(tex, new Rectangle(tex.Width - padding.X, 0 , padding.X, padding.Y));
            slices[3] = SubTexture.GetSubTexture(tex, new Rectangle(0, padding.Y, padding.X, tex.Height - padding.Y * 2));
            slices[4] = SubTexture.GetSubTexture(tex, new Rectangle(padding.X, padding.Y, tex.Width - padding.X * 2, tex.Height - padding.Y * 2));
            slices[5] = SubTexture.GetSubTexture(tex, new Rectangle(tex.Width - padding.X, padding.Y, padding.X, tex.Height - padding .Y * 2));
            slices[6] = SubTexture.GetSubTexture(tex, new Rectangle(0, tex.Height - padding.Y, padding.X, padding.Y));
            slices[7] = SubTexture.GetSubTexture(tex, new Rectangle(padding.X, tex.Height - padding.Y, tex.Width - padding.X * 2, padding.Y));
            slices[8] = SubTexture.GetSubTexture(tex, new Rectangle(tex.Width - padding.X, tex.Height - padding.Y, padding.X, padding.Y));
        }

        public void DrawSlices(SpriteBatch spriteBatch, Rectangle rect, Color color)
        {
            spriteBatch.Draw(slices[0], new Rectangle(rect.X, rect.Y, padding.X, padding.Y), color);
            spriteBatch.Draw(slices[1], new Rectangle(rect.X + padding.X, rect.Y, rect.Width - padding.X * 2, padding.Y), color);
            spriteBatch.Draw(slices[2], new Rectangle(rect.Right - padding.X, rect.Y, padding.X, padding.Y), color);
            spriteBatch.Draw(slices[3], new Rectangle(rect.X, rect.Y + padding.Y, padding.X, rect.Height - padding.Y * 2), color);
            spriteBatch.Draw(slices[4], new Rectangle(rect.X + padding.X, rect.Y + padding.Y, rect.Width - padding.X * 2, rect.Height - padding.Y * 2), color);
            spriteBatch.Draw(slices[5], new Rectangle(rect.Right - padding.X, rect.Y + padding.Y, padding.X, rect.Height - padding.Y * 2), color);
            spriteBatch.Draw(slices[6], new Rectangle(rect.X, rect.Bottom - padding.Y, padding.X, padding.Y), color);
            spriteBatch.Draw(slices[7], new Rectangle(rect.X + padding.X, rect.Bottom - padding.Y, rect.Width - padding.X * 2, padding.Y), color);
            spriteBatch.Draw(slices[8], new Rectangle(rect.Right - padding.X, rect.Bottom - padding.Y, padding.X, padding.Y), color);
        }
    }
}

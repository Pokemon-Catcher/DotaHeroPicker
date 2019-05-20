using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Hero.ImageEditor
{
    class ImageEdit
    {
        public static void Tint(Image source, float r, float g, float b)
        {
            ColorPalette newPalette = source.Palette;
            Color[] colors = newPalette.Entries;
            for(int i=0; i < colors.Length; i++) {
                float newR = colors[i].R + (255 - colors[i].R) * r;
                float newG = colors[i].G + (255 - colors[i].G) * g;
                float newB = colors[i].B + (255 - colors[i].B) * b;
                colors[i] = Color.FromArgb((int)newR, (int)newG, (int)newB);
                newPalette.Entries.SetValue(colors[i], i);
            }
            source.Palette = newPalette;
        }
    }
}
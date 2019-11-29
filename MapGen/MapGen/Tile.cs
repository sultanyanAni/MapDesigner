using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGen
{
    class Tile
    {
        public Texture2D Image { get; set; }
        public Vector2 Position { get; set; }

        public Tile(Texture2D img, Vector2 pos)
        {
            Image = img;
            Position = pos;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Image, Position, Color.White);
        }
    }
}

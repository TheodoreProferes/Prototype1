using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
namespace SMFL_Test
{
    public class WorldTile
    {
        private Texture texture;
        private Sprite sprite;

        public float friction
        {
            get;
            protected set;
        }
        public WorldTile(string imgPath, Vector2f origin, float friction)
        {
            texture = new Texture(imgPath);
            sprite = new Sprite(texture);
            sprite.Origin = origin;
            this.friction = friction;
        }

    

        public void Update(GameLoop gameLoop)
        {

        }
        public FloatRect Bounds()
        {
            return sprite.GetGlobalBounds();
        }

        public void Render(GameLoop gameLoop)
        {
            gameLoop.window.Draw(sprite);
        }

    }
}

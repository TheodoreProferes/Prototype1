using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace SMFL_Test
{
    public class PhysicsObject
    {
        protected Texture texture;
        protected Sprite sprite;
        protected float mass;
        protected Vector2f velocity = new Vector2f(0, 0);
        

        public PhysicsObject(string imgPath, float mass)
        {
            texture = new Texture(imgPath);
            texture.Smooth = true;
            sprite = new Sprite(texture);
            this.mass = mass;
        }
        public bool DetectCollision(FloatRect collisionBounds, float friction)
        {
            FloatRect thisGlobalBound = sprite.GetGlobalBounds();
            if (sprite.GetGlobalBounds().Intersects(collisionBounds))
            {
                if ((thisGlobalBound.Left > collisionBounds.Left && thisGlobalBound.Left < (collisionBounds.Left)+collisionBounds.Width) || (thisGlobalBound.Left+ thisGlobalBound.Width > collisionBounds.Left && thisGlobalBound.Left + thisGlobalBound.Width < (collisionBounds.Left) + collisionBounds.Width))
                {
                    if (velocity.Y > 0){
                        velocity.Y = 0;
                        sprite.Position = new Vector2f(sprite.Position.X, collisionBounds.Top - thisGlobalBound.Height);
                    }
                    else if (velocity.Y < 0)
                    {
                        velocity.Y = 0;
                        sprite.Position = new Vector2f(sprite.Position.X, collisionBounds.Top + collisionBounds.Height);
                    }
                    if (velocity.X > 0)
                    {
                        velocity.X -= friction;
                    }
                    else if (velocity.X < 0)
                    {
                        velocity.X += friction;
                    }
                }
                else if ((thisGlobalBound.Top > collisionBounds.Top && thisGlobalBound.Top < (collisionBounds.Top) + collisionBounds.Height) || (thisGlobalBound.Top + thisGlobalBound.Height > collisionBounds.Top && thisGlobalBound.Top + thisGlobalBound.Top < (collisionBounds.Top) + collisionBounds.Height))
                {
                    if (velocity.X > 0)
                    {
                        velocity.X = 0;
                        sprite.Position = new Vector2f(collisionBounds.Left - thisGlobalBound.Width, sprite.Position.Y);
                    }
                    else if (velocity.X < 0)
                    {
                        velocity.X = 0;
                        sprite.Position = new Vector2f(collisionBounds.Left + collisionBounds.Width, sprite.Position.Y);
                    }
                    if (velocity.Y > 0)
                    {
                        velocity.Y -= 9.8f * friction / 60f;
                    }
                    else if (velocity.Y < 0)
                    {
                        velocity.Y += 9.8f * friction / 60f;
                    }
                }
            }
            return sprite.GetGlobalBounds().Intersects(collisionBounds);
        }
        public void Update()
        {
            sprite.Position += velocity / 60;
            velocity.Y += 9.8f;
        }
        public void Render(GameLoop gameLoop)
        {
            gameLoop.window.Draw(sprite);
        }
    }
}

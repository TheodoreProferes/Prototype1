using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace SMFL_Test
{
    public class Player : PhysicsObject
    {
        public float maxspeed = 500;
        public float movespeed = 5;
        public Player(string imgPath, float mass) : base(imgPath, mass)
        {

        }

        public void Move()
        {
            if(Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                if (velocity.X > -maxspeed)
                {
                    velocity.X -= movespeed;
                }
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                if (velocity.X < maxspeed)
                {
                    velocity.X += movespeed;
                }
            }

        }

        
    }
}

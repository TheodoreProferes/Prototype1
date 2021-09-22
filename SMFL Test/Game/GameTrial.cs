using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace SMFL_Test
{
    public class GameTrial : GameLoop
    {
        public Player ball;
        public WorldTile floor;
        public const uint defaultWindowHeight = 1080;
        public const uint defaultWindowWidth = 1920;
        public const string defaultWindowTitle = "Test Game";

        public GameTrial() : base(defaultWindowWidth, defaultWindowHeight, defaultWindowTitle, Color.White)
        {
        }

        public override void Load()
        {
            ball = new Player("./img/circle.png", 1);
            floor = new WorldTile("./img/rectangle.png", new Vector2f(0,-500), 5);
        }

        public override void Initialise()
        {

        }

        public override void Update(GameTime gameTime)
        {
            ball.DetectCollision(floor.Bounds(), floor.friction);
            ball.Move();
            ball.Update();
        }

        public override void Render(GameTime gameTime)
        {
            ball.Render(this);
            floor.Render(this);
            
        }
    }
}

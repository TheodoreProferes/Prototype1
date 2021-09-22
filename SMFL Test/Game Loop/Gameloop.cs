using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;


namespace SMFL_Test
{
    public abstract class GameLoop
    {
        public const int targetFps = 60;
        public const float timeUntilUpdate = 1f / targetFps;

        public RenderWindow window
        {
            get;
            protected set;
        }

        public GameTime GameTime
        {
            get;
            protected set;
        }

        public Color windowClearColour
        {
            get;
            protected set;
        }

        protected GameLoop(uint windowWidth, uint windowHeight, string windowTitle, Color windowClearColour)
            {
            this.windowClearColour = windowClearColour;
            this.window = new RenderWindow(new VideoMode(windowWidth, windowHeight), windowTitle);
            this.GameTime = new GameTime();
            window.Closed += WindowClosed;
            }

        public void Run()
        {
            Load();
            Initialise();

            float totalTimeBeforeUpdate = 0f;
            float previousTimeElapsed = 0f;
            float deltaTime = 0f;
            float totalTimeElapsed = 0f;

            Clock clock = new Clock();

            while (window.IsOpen)
            {
                window.DispatchEvents();

                totalTimeElapsed = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTimeElapsed - previousTimeElapsed;
                previousTimeElapsed = totalTimeElapsed;

                totalTimeBeforeUpdate += deltaTime;

                if(totalTimeBeforeUpdate >= timeUntilUpdate)
                {
                    GameTime.Update(totalTimeBeforeUpdate, clock.ElapsedTime.AsSeconds());
                    totalTimeBeforeUpdate = 0f;

                    Update(GameTime);

                    window.Clear(windowClearColour);
                    Render(GameTime);
                    window.Display();

                }

            }

        }

        public abstract void Load();
        public abstract void Initialise();
        public abstract void Update(GameTime gameTime);
        public abstract void Render(GameTime gameTime);

        private void WindowClosed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}

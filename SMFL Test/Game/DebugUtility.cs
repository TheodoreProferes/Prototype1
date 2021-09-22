using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
namespace SMFL_Test
{
    public static class DebugUtility
    {
        public const string consoleFontPath = "./fonts/arial.ttf";
        public static Font consoleFont;
        public static void Load()
        {
            consoleFont = new Font(consoleFontPath);
        }

        public static void DrawPerformaceData(GameLoop gameLoop, Color fontColor)
        {
            if (consoleFont == null)
            {
                return;
            }

            string totalTimeElapsedStr = gameLoop.GameTime.TotalTimeElapsed.ToString("0.000");
            string deltaTimeStr = gameLoop.GameTime.DeltaTime.ToString("0.00000");
            float fps = 1f / gameLoop.GameTime.DeltaTime;
            string fpsStr = fps.ToString("0.00");

            Text textA = new Text(totalTimeElapsedStr, consoleFont, 14);
            textA.Position = new Vector2f(4f, 8f);
            textA.Color = fontColor;

            Text textB = new Text(deltaTimeStr, consoleFont, 14);
            textB.Position = new Vector2f(4f, 28f);
            textB.Color = fontColor;

            Text textC = new Text(fpsStr, consoleFont, 14);
            textC.Position = new Vector2f(4f, 48f);
            textC.Color = fontColor;

            gameLoop.window.Draw(textA);
            gameLoop.window.Draw(textB);
            gameLoop.window.Draw(textC);
        }

    }
}

using Raylib_cs;
using Cycle.Game.Casting;


namespace Cycle.Game.Services
{
    /// <summary>
    /// <para>Detects player input.</para>
    /// <para>
    /// The responsibility of a KeyboardService is to detect player key presses and translate them 
    /// into a point representing a direction.
    /// </para>
    /// </summary>
    public class KeyboardService
    {
        private int cellSize = 15;

        /// <summary>
        /// Constructs a new instance of KeyboardService using the given cell size.
        /// </summary>
        /// <param name="cellSize">The cell size (in pixels).</param>
        public KeyboardService(int cellSize)
        {
            this.cellSize = cellSize;
        }

        /// <summary>
        /// Gets the selected direction based on the currently pressed keys.
        /// </summary>
        /// <returns>The direction as an instance of Point.</returns>
        public Point GetDirection(string player)
        {
            int dx = 0;
            int dy = 0;

            if (player == "player1"){
                if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                {
                    dx = -1;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                {
                    dx = 1;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    dy = -1;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    dy = 1;
                }
            }
            else if (player == "player2"){
                if (Raylib.IsKeyDown(KeyboardKey.KEY_J))
                {
                    dx = -1;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_L))
                {
                    dx = 1;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_I))
                {
                    dy = -1;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_K))
                {
                    dy = 1;
                }
            }

            Point direction = new Point(dx, dy);
            direction = direction.Scale(cellSize);

            return direction;
        }
    }
}
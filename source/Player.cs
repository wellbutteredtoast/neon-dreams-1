using System;
using Raylib_cs;
using MoonSharp.Interpreter;
using System.Numerics;

namespace NeonDreams
{
    public class Player
    {
        // Player variables
        internal string PlayerName { get; private set; }
        internal Vector2 PlayerPosition { get; private set; }
        private float Speed = 200f;
        private int Size = 32;

        // Player methods
        public Player(string name)
        {
            PlayerName = name;
            PlayerPosition = new Vector2(400, 300);
        }

        public void Update(float DeltaTime)
        {
            Vector2 tempPos = PlayerPosition;
            
            // Controls
            if (Raylib.IsKeyDown(KeyboardKey.W) || Raylib.IsKeyDown(KeyboardKey.Up))
                tempPos.Y -= Speed * DeltaTime;
            if (Raylib.IsKeyDown(KeyboardKey.S) || Raylib.IsKeyDown(KeyboardKey.Down))
                tempPos.Y += Speed * DeltaTime;
            if (Raylib.IsKeyDown(KeyboardKey.A) || Raylib.IsKeyDown(KeyboardKey.Left))
                tempPos.X -= Speed * DeltaTime;
            if (Raylib.IsKeyDown(KeyboardKey.D) || Raylib.IsKeyDown(KeyboardKey.Right))
                tempPos.X += Speed * DeltaTime;

            PlayerPosition = tempPos;
        }

        public void Draw()
        {
            Raylib.DrawRectangle((int)PlayerPosition.X, (int)PlayerPosition.Y, Size, Size, Color.Blue);
        }
    }
}
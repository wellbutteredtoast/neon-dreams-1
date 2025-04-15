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

        // Player methods
        public Player(string name)
        {
            PlayerName = name;
        }

        public void Update(float DeltaTime)
        {

        }

        public void Draw()
        {
            
        }
    }
}
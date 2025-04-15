using Raylib_cs;
using MoonSharp.Interpreter;
using System;
using System.IO;

namespace NeonDreams
{
    public class Program
    {
        // This checks for a dummy file located at './assets/mods/template/init.lua'
        // If it finds it and can run the code in there, we're good and ret 0
        // Otherwise, it returns any int > 0, and then things are bad.
        internal static bool ExternalLuaSelfTest()
        {
            string FileToCheck = "assets/mods/template/init.lua";

            if (!File.Exists(FileToCheck))
            {
                Raylib.TraceLog(TraceLogLevel.Fatal, $"Lua mod file not found: {FileToCheck}");
                return false;
            }

            try
            {
                string luaCode = File.ReadAllText(FileToCheck);
                Script luaScript = new Script();
                luaScript.DoString(luaCode);
                return true;
            }
            catch (Exception ex)
            {
                Raylib.TraceLog(TraceLogLevel.Fatal, $"Failed to run Lua mod script: {ex.Message}");
                return false;
            }
        }

        // Internal does not refer to the lua interpreter built into MoonSharp
        // but rather the Lua files in './assets/lua_internal'
        // This self test checks for a huge list of files that all have to exist
        // for the game to even continue initalizing.
        private static bool InternalLuaSelfTest()
        {
            string LDirectory = "assets/lua_internal";

            if (!Directory.Exists(LDirectory))
            {
                Raylib.TraceLog(TraceLogLevel.Fatal, $"Lua internal directory is missing! Validate this game using Steam ASAP!");
                return false;
            }
            
            string[] CoreFiles = new string[]
            {
                "__hello.lua"
            };

            foreach (string file in CoreFiles)
            {
                string FullPath = Path.Combine(LDirectory, file);
                if (!File.Exists(FullPath))
                {
                    Raylib.TraceLog(TraceLogLevel.Fatal, $"Core file {file} is missing!");
                    return false;
                }
            }

            return true;
        }

        public static void Main(String[] args)
        {
            // Raylib init
            int WindowWidth = 640;
            int WindowHeight = 480;
            int RefreshRate = 60;

            Raylib.TraceLog(TraceLogLevel.Info, "Neon Dreams started.");
            Raylib.InitAudioDevice();
            Raylib.InitWindow(WindowWidth, WindowHeight, "Neon Dreams");
            Raylib.SetTargetFPS(RefreshRate);
            Raylib.TraceLog(TraceLogLevel.Debug, "Raylib started.");
            Raylib.TraceLog(TraceLogLevel.Info, "Initalizing subsystems.");
            Raylib.TraceLog(TraceLogLevel.Info, "Running health check on Lua...");
            bool IsModdedLuaOK = ExternalLuaSelfTest();
            bool IsInternalLuaOK = InternalLuaSelfTest();

            if (!IsModdedLuaOK)
                throw new Exception("Testing file (assets/mods/template/init.lua) couldn't be loaded!");
                Environment.Exit(-1);
            
            if (!IsInternalLuaOK)
                throw new Exception("Core Lua data missing! Neon Dreams cannot continue loading.");
                Environment.Exit(-1);

            // Rendering loop
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.White);
                    Raylib.DrawFPS(0, 0);
                Raylib.EndDrawing();
            }
        }
    }
}
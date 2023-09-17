// <copyright file="Game.cs" company="KnightsOfOrange">
// Copyright © 2020,2023 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine
{
    using System;
    using KnightsOfOrange.Engine.Abstraction;
    using Serilog;
    using SFML.Graphics;
    using SFML.System;
    using SFML.Window;

    public abstract class Game : IGame
    {
        private uint width;
        private uint height;
        private string title;
        private uint frameRate = 30;
        private Clock clock;
        private bool isFrameLocked = true;

        protected Game(uint width, uint height, string title)
        {
            this.width = width;
            this.height = height;
            this.title = title;
            Window = new RenderWindow(new VideoMode(this.width, this.height), this.title);
            Window.Closed += this.WindowOnClosed;
            this.clock = new Clock();
            Window.KeyPressed += Input.OnKeyPress;
            Window.KeyReleased += Input.OnKeyRelease;
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(".log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            if (this.isFrameLocked)
            {
                Window.SetFramerateLimit(this.frameRate);
            }
        }

        public static TimeManager Time { get; } = new TimeManager();

        public static InputManager Input { get; } = new InputManager();

        public void Run()
        {
            while (Window.IsOpen)
            {
                this.StepFrame();
            }

            Log.CloseAndFlush();
        }

        private void StepFrame()
        {
            Window.Clear();
            Window.DispatchEvents();
            SceneManager.CurrentScene.Step();
            Window.Display();
            Time.DeltaTime = this.clock.Restart().AsSeconds();
            Log.Information("FPS: {fps}", 1.0f / Time.DeltaTime);
        }

        public void Dispose()
        {
        }

        public static ISceneManager SceneManager { get; private set; } = new SceneManager();

        public static RenderWindow Window { get; private set; }

        public abstract void Init();

        public IScene CreateScene(string id, string name)
        {
            return SceneManager.CreateScene(id, name);
        }

        private void WindowOnClosed(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            (sender as RenderWindow ?? throw new ArgumentNullException(nameof(sender))).Close();
        }
    }
}

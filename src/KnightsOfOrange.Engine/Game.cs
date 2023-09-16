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
            window = new RenderWindow(new VideoMode(this.width, this.height), this.title);
            window.Closed += this.WindowOnClosed;
            this.clock = new Clock();
            this.SceneManager = new SceneManager();
            window.KeyPressed += Input.OnKeyPress;
            window.KeyReleased += Input.OnKeyRelease;
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(".log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            if (this.isFrameLocked)
            {
                window.SetFramerateLimit(this.frameRate);
            }
        }

        private static TimeManager time;

        public static TimeManager Time => time ??= new TimeManager();

        private static InputManager input;

        public static InputManager Input => input ??= new InputManager();

        public void Run()
        {
            while (window.IsOpen)
            {
                this.StepFrame();
            }

            Log.CloseAndFlush();
        }

        private void StepFrame()
        {
            window.Clear();
            window.DispatchEvents();
            this.SceneManager.GetCurrentScene().Step();
            window.Display();
            Time.DeltaTime = this.clock.Restart().AsSeconds();
            Log.Information("FPS: {fps}", 1.0f / Time.DeltaTime);
        }

        public void Dispose()
        {
        }

        public ISceneManager SceneManager { get; }

        private static RenderWindow window;

        public static RenderWindow Window => window;

        public abstract void Init();

        public void AddScene(IScene scene)
        {
            this.SceneManager.AddScene(scene);
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

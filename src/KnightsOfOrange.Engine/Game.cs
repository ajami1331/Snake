// <copyright file="Game.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine
{
    using System;
    using KnightsOfOrange.Engine.Abstraction;
    using SFML.Graphics;
    using SFML.System;
    using SFML.Window;

    public abstract class Game : IGame
    {
        private uint width;
        private uint height;
        private string title;
        private RenderWindow window;
        private uint frameRate = 30;
        private float accumulator;
        private float timeStep;
        private Clock clock;

        protected Game(uint width, uint height, string title)
        {
            this.width = width;
            this.height = height;
            this.title = title;
            this.window = new RenderWindow(new VideoMode(width, height), title);
            this.window.Closed += this.WindowOnClosed;
            this.timeStep = 1.0f / this.frameRate;
            this.accumulator = 0.0f;
            this.clock = new Clock();
            this.SceneManager = new SceneManager();
            this.window.KeyPressed += InputManager.OnKeyPress;
            this.window.KeyReleased += InputManager.OnKeyRelease;
            WindowManager.Window = this.window;
        }

        public void Run()
        {
            while (this.window.IsOpen)
            {
                this.accumulator += this.clock.Restart().AsSeconds();
                while (this.accumulator >= this.timeStep)
                {
                    this.window.Clear();
                    this.window.DispatchEvents();
                    this.SceneManager.GetCurrentScene().Step();
                    this.window.Display();
                    this.clock.Restart();
                    this.window.SetFramerateLimit(this.frameRate);
                }
            }
        }

        public void Dispose()
        {
        }

        public ISceneManager SceneManager { get; }

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

            this.accumulator = 0;
        }
    }
}

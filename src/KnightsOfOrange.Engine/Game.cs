// <copyright file="Game.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine
{
    using System;
    using KnightsOfOrange.Engine.Abstraction;
    using SFML.Graphics;
    using SFML.Window;

    public abstract class Game : IGame
    {
        private uint width;
        private uint height;
        private string title;
        private RenderWindow window;

        protected Game(uint width, uint height, string title)
        {
            this.width = width;
            this.height = height;
            this.title = title;
            this.window = new RenderWindow(new VideoMode(width, height), title);
            this.window.Closed += this.WindowOnClosed;
        }

        public void Run()
        {
            while (this.window.IsOpen)
            {
                this.window.Clear();
                this.window.DispatchEvents();
            }
        }

        public void Dispose()
        {
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

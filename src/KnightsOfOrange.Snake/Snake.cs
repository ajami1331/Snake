// <copyright file="Snake.cs" company="KnightsOfOrange">
// Copyright © 2020,2023 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Snake
{
    using System;
    using System.Reflection;
    using KnightsOfOrange.Engine;
    using KnightsOfOrange.Engine.Abstraction;
    using KnightsOfOrange.Snake.GameObjects;
    using KnightsOfOrange.Snake.Scenes;

    public class Snake : Game
    {
        public Snake()
            : base(640, 480, "Snake")
        {

        }

        public override void Init()
        {
            this.AddScene(new Gameplay());
            this.Run();
        }

        public void Dispose()
        {
        }
    }
}

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

    public class Snake : Game
    {
        public Snake()
            : base(640, 480, "Snake")
        {

        }

        public override void Init()
        {
            var scene1 = this.CreateScene(Guid.NewGuid().ToString(), "Scene1");
            new SnakePlayer();
            new Apple();
            this.Run();
        }

        public void Dispose()
        {
        }
    }
}

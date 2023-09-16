// <copyright file="Snake.cs" company="KnightsOfOrange">
// Copyright © 2020,2023 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Snake
{
    using System;
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
            Scene scene1 = new Scene(Guid.NewGuid().ToString(), "Scene1");
            new SnakePlayer(scene1);
            this.AddScene(scene1);
            this.Run();
        }

        public void Dispose()
        {
        }
    }
}

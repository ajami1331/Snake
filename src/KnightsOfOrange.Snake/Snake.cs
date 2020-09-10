// <copyright file="Snake.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.TicTacToe
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
            scene1.GameObjectManager.GameObjects.Add(new SnakePlayer());
            this.AddScene(scene1);
            this.Run();
        }

        public void Dispose()
        {
        }
    }
}

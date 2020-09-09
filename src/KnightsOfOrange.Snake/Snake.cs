// <copyright file="Game.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.TicTacToe
{
    using System;
    using KnightsOfOrange.Engine;
    using KnightsOfOrange.Engine.Abstraction;

    public class Snake : Game
    {
        public Snake()
            : base(200, 200, "Tic Tac Toe")
        {

        }

        public override void Init()
        {
            Scene scene1 = new Scene(Guid.NewGuid().ToString(), "Scene1");
            this.AddScene(scene1);
            this.Run();
        }

        public void Dispose()
        {
        }
    }
}

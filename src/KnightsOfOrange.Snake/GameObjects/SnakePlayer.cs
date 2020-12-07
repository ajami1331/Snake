// <copyright file="SnakePlayer.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Snake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KnightsOfOrange.Engine;

    public class SnakePlayer : GameObject
    {
        public SnakePlayer()
            : base("Player")
        {
            this.Components.Add(new Transform(this));
            this.Components.Add(new PlayerController(this));
        }
    }
}

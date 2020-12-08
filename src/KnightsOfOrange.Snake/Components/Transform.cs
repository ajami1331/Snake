// <copyright file="Transform.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Snake.Components
{
    using System;
    using KnightsOfOrange.Engine;
    using KnightsOfOrange.Engine.Abstraction;
    using Serilog;
    using SFML.System;

    public class Transform : Component
    {
        public Vector2f Position { get; set; }

        public Transform(IGameObject owner)
            : base(owner, "Transform")
        {
            this.Position = new Vector2f(100, 100);
        }

        public override void LateUpdate()
        {
            base.LateUpdate();
        }
    }
}

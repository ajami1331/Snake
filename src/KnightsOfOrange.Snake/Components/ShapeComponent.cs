// <copyright file="ShapeComponent.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Snake.Components
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KnightsOfOrange.Engine;
    using KnightsOfOrange.Engine.Abstraction;
    using SFML.Graphics;
    using SFML.System;

    public class ShapeComponent : Component
    {
        private Vector2f partSize;
        private Color color = Color.Green;
        public RectangleShape Shape;
        private float halfStep = 8f;

        public ShapeComponent(IGameObject owner, Vector2f position)
            : base(owner, "ShapeComponent")
        {
            this.partSize = new Vector2f(16, 16);
            this.Shape = new RectangleShape(this.partSize)
            {
                FillColor = this.color,
                Position = position,
            };
        }

        public override void Update()
        {
            base.Update();
        }

        public override void LateUpdate()
        {
            if (this.Shape.Position.X + this.halfStep > Game.Window.Size.X)
            {
                this.Shape.Position = new Vector2f(this.halfStep, this.Shape.Position.Y);
            }

            if (this.Shape.Position.X < 0)
            {
                this.Shape.Position = new Vector2f(Game.Window.Size.X - this.halfStep, this.Shape.Position.Y);
            }

            if (this.Shape.Position.Y + this.halfStep > Game.Window.Size.Y)
            {
                this.Shape.Position = new Vector2f(this.Shape.Position.X, this.halfStep);
            }

            if (this.Shape.Position.Y < 0)
            {
                this.Shape.Position = new Vector2f(this.Shape.Position.X, Game.Window.Size.Y - this.halfStep);
            }

            base.LateUpdate();
        }

        public override void Draw()
        {
            Game.Window.Draw(this.Shape);
            base.Draw();
        }
    }
}

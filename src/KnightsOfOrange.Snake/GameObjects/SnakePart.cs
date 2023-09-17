// <copyright file="SnakePart.cs" company="KnightsOfOrange">
// Copyright © 2023 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Snake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KnightsOfOrange.Engine;
    using KnightsOfOrange.Engine.Abstraction;
    using Serilog;
    using SFML.Graphics;
    using SFML.System;

    public class SnakePart : GameObject
    {
        private Vector2f partSize;
        private Color color = Color.Green;
        public RectangleShape Shape;
        private float halfStep = 8f;

        public SnakePart(Vector2f position)
            : base("ShapeObject")
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
            if (this.Shape.Position.X + this.Shape.Size.X > Game.Window.Size.X)
            {
                this.Shape.Position = new Vector2f(0, this.Shape.Position.Y);
            }

            if (this.Shape.Position.X < 0)
            {
                this.Shape.Position = new Vector2f(Game.Window.Size.X - this.Shape.Size.X, this.Shape.Position.Y);
            }

            if (this.Shape.Position.Y + this.Shape.Size.Y > Game.Window.Size.Y)
            {
                this.Shape.Position = new Vector2f(this.Shape.Position.X, 0);
            }

            if (this.Shape.Position.Y < 0)
            {
                this.Shape.Position = new Vector2f(this.Shape.Position.X, Game.Window.Size.Y - this.Shape.Size.Y);
            }

            base.LateUpdate();
        }

        public override void Draw()
        {
            Game.Window.Draw(Shape);
            base.Draw();
        }
    }
}

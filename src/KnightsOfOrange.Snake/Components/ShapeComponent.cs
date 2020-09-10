// <copyright file="ShapeComponent.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Snake.GameObjects
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
            this.Shape = new RectangleShape(this.partSize);
            this.Shape.FillColor = this.color; ;
            this.Shape.Position = position;
        }

        public override void Update()
        {

            base.Update();
        }

        public override void LateUpdate()
        {
            if (this.Shape.Position.X + this.halfStep > WindowManager.Window.Size.X)
            {
                this.Shape.Position = new Vector2f(this.halfStep, this.Shape.Position.Y);
            }

            if (this.Shape.Position.X - this.halfStep < 0)
            {
                this.Shape.Position = new Vector2f(WindowManager.Window.Size.X - this.halfStep, this.Shape.Position.Y);
            }

            if (this.Shape.Position.Y + this.halfStep > WindowManager.Window.Size.Y)
            {
                this.Shape.Position = new Vector2f(this.Shape.Position.X, this.halfStep);
            }

            if (this.Shape.Position.Y - this.halfStep < 0)
            {
                this.Shape.Position = new Vector2f(this.Shape.Position.X, WindowManager.Window.Size.Y - this.halfStep);
            }
            base.LateUpdate();
        }

        public override void Draw()
        {
            WindowManager.Window.Draw(Shape);
            base.Draw();
        }
    }
}

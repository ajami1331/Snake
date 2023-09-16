// <copyright file="ShapeObject.cs" company="KnightsOfOrange">
// Copyright © 2023 KnightsOfOrange. All Rights Reserved.
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

    public class ShapeObject : GameObject
    {
        private Vector2f partSize;
        private Color color = Color.Green;
        public RectangleShape Shape;
        private readonly Scene currentScene;
        private float halfStep = 8f;

        public ShapeObject(Vector2f position, Scene currentScene)
            : base("ShapeObject")
        {
            this.partSize = new Vector2f(16, 16);
            this.Shape = new RectangleShape(this.partSize)
            {
                FillColor = this.color,
                Position = position,
            };
            this.currentScene = currentScene ?? throw new ArgumentNullException();
            this.currentScene.GameObjectManager.AddGameObject(this);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void LateUpdate()
        {
            if (this.Shape.Position.X + halfStep > Game.Window.Size.X)
            {
                this.Shape.Position = new Vector2f(halfStep, this.Shape.Position.Y);
            }

            if (this.Shape.Position.X < 0)
            {
                this.Shape.Position = new Vector2f(Game.Window.Size.X - halfStep, this.Shape.Position.Y);
            }

            if (this.Shape.Position.Y + halfStep > Game.Window.Size.Y)
            {
                this.Shape.Position = new Vector2f(this.Shape.Position.X, halfStep);
            }

            if (this.Shape.Position.Y < 0)
            {
                this.Shape.Position = new Vector2f(this.Shape.Position.X, Game.Window.Size.Y - halfStep);
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

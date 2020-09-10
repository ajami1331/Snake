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
        private List<RectangleShape> shapes;
        private Transform transfrom;

        public ShapeComponent(IGameObject owner)
            : base(owner, "ShapeComponent")
        {
            this.partSize = new Vector2f(16, 16);
            this.shapes = new List<RectangleShape>();
            this.transfrom = this.GetComponent<Transform>("Transform");
            this.GrowSnake(new Vector2f(0, 0));
        }

        private void GrowSnake(Vector2f position)
        {
            RectangleShape newShape = new RectangleShape(this.partSize);
            newShape.FillColor = this.color;;
            newShape.Position = position;
            this.shapes.Add(newShape);
        }

        public override void Update()
        {

            base.Update();
        }

        public override void Draw()
        {
            foreach (RectangleShape shape in this.shapes)
            {
                RectangleShape newShape = new RectangleShape(shape);
                newShape.Position += this.transfrom.Position;
                WindowManager.Window.Draw(newShape);
            }

            base.Draw();
        }
    }
}

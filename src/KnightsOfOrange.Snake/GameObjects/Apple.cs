// <copyright file="Apple.cs" company="KnightsOfOrange">
// Copyright © 2023 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Snake.GameObjects
{
    using System;
    using KnightsOfOrange.Engine;
    using KnightsOfOrange.Engine.Abstraction;
    using SFML.Graphics;
    using SFML.System;

    public class Apple : GameObject
    {
        private Vector2f partSize;
        private Color color = Color.Yellow;
        public RectangleShape Shape;
        private float halfStep = 8f;
        private SnakePlayer player;

        public Apple(IScene scene)
            : base("Apple", scene)
        {
            this.partSize = new Vector2f(16, 16);
            Random random = new Random();
            this.Shape = new RectangleShape(this.partSize)
            {
                FillColor = this.color,
                Position = new Vector2f(random.Next(0, (int)Game.Window.Size.X / 16) * 16, random.Next(0, (int)Game.Window.Size.Y / 16) * 16),
            };
            this.player = (SnakePlayer)scene.GameObjectManager.GetGameObjectByName("Player");
        }

        public override void Update()
        {
            bool grow = false;
            foreach (var shape in this.player.Shapes)
            {
                if (this.player.IsCollision(this.Shape.GetGlobalBounds(), shape.Shape.GetGlobalBounds()))
                {
                    Random random = new Random();
                    this.Shape.Position = new Vector2f(random.Next(0, (int)Game.Window.Size.X / 16) * 16, random.Next(0, (int)Game.Window.Size.Y / 16) * 16);
                    grow = true;
                }

            }

            if (grow)
            {
                this.player.GrowSnake();
            }

            base.Update();
        }

        public override void LateUpdate()
        {
            base.LateUpdate();
        }

        public override void Draw()
        {
            Game.Window.Draw(this.Shape);
            base.Draw();
        }
    }
}

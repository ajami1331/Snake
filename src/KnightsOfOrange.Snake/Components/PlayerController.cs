// <copyright file="PlayerController.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Snake.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using KnightsOfOrange.Engine;
    using KnightsOfOrange.Engine.Abstraction;
    using Serilog;
    using SFML.System;

    public class PlayerController : Component
    {
        private Transform transfrom;
        private Vector2f velocity;
        private float halfStep = 8f;
        private IList<ShapeComponent> shapes;
        private Vector2f lastPosition;

        public PlayerController(IGameObject owner)
            : base(owner, "PlayerController")
        {
            this.transfrom = this.GetComponent<Transform>("Transform");
            this.shapes = new List<ShapeComponent>();
            this.GrowSnake(this.transfrom.Position);
            this.GrowSnake(this.transfrom.Position - new Vector2f(16, 0));
            this.GrowSnake(this.transfrom.Position - new Vector2f(32, 0));
            this.GrowSnake(this.transfrom.Position - new Vector2f(48, 0));
            this.velocity = default(Vector2f);
            this.GoRight();
        }

        public override void Update()
        {
            this.CheckAndSetVelocity();

            this.ApplyVelocityAndVerify();

            this.lastPosition = this.shapes.Last().Shape.Position;

            for (int index = this.shapes.Count - 2; index >= 0; index--)
            {
                this.shapes[index + 1].Shape.Position = new Vector2f(this.shapes[index].Shape.Position.X, this.shapes[index].Shape.Position.Y);
            }

            this.shapes.First().Shape.Position = this.transfrom.Position;

            base.Update();
        }

        public override void Draw()
        {
            this.transfrom.Position = this.shapes.First().Shape.Position;
            base.Draw();
        }

        private void GrowSnake(Vector2f position)
        {
            this.shapes.Add(new ShapeComponent(this.Owner, position));
            this.Owner.BindComponent(this.shapes.Last());
        }

        private void ApplyVelocityAndVerify()
        {
            this.transfrom.Position += this.velocity;
        }

        private void CheckAndSetVelocity()
        {
            if (InputManager.GetButton("left"))
            {
                this.GoLeft();
            }

            if (InputManager.GetButton("right"))
            {
                this.GoRight();
            }

            if (InputManager.GetButton("up"))
            {
                this.GoUp();
            }

            if (InputManager.GetButton("down"))
            {
                this.GoDown();
            }
        }

        private void GoRight()
        {
            Log.Information("right");
            this.velocity.X = 8;
            this.velocity.Y = 0;
        }

        private void GoUp()
        {
            Log.Information("up");
            this.velocity.X = 0;
            this.velocity.Y = -8;
        }

        private void GoDown()
        {
            Log.Information("down");
            this.velocity.X = 0;
            this.velocity.Y = 8;
        }

        private void GoLeft()
        {
            Log.Information("left");
            this.velocity.X = -8;
            this.velocity.Y = 0;
        }
    }
}

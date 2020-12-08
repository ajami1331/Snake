// <copyright file="PlayerController.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

using SFML.Graphics;

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
        private IList<ShapeComponent> shapes;
        private Vector2f lastPosition;
        private Direction currentDirection = Direction.Right;
        private float movementSpeed = 500;

        private enum Direction
        {
            Left,
            Up,
            Right,
            Down,
        }

        public PlayerController(IGameObject owner)
            : base(owner, "PlayerController")
        {
            this.transfrom = this.GetComponent<Transform>("Transform");
            this.shapes = new List<ShapeComponent>();
            this.GrowSnake(this.transfrom.Position);
            this.velocity = default(Vector2f);
            this.GoRight();
        }

        public override void Update()
        {
            for (int i = 0; i < this.shapes.Count; i++)
            {

                this.shapes[i].Shape.FillColor = Color.Green;
            }

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

        public override void LateUpdate()
        {
            for (int i = 1; i < this.shapes.Count; i++)
            {
                if (this.IsCollision(this.shapes[i].Shape.GetGlobalBounds(), this.shapes[0].Shape.GetGlobalBounds()))
                {
                    this.shapes[i].Shape.FillColor = Color.Red;
                    this.shapes[0].Shape.FillColor = Color.Blue;
                }
            }

            base.LateUpdate();
        }

        private bool IsCollision(FloatRect rect1, FloatRect rect2)
        {
            return rect1.Left < rect2.Left + rect2.Width &&
                    rect1.Left + rect1.Width > rect2.Left &&
                    rect1.Top < rect2.Top + rect2.Height &&
                    rect1.Top + rect1.Height > rect2.Top;
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
            this.transfrom.Position += this.velocity * Game.Time.DeltaTime * this.movementSpeed;
        }

        private void CheckAndSetVelocity()
        {
            if (Game.Input.GetButton("left") && this.currentDirection != Direction.Right)
            {
                this.GoLeft();
            }

            if (Game.Input.GetButton("right") && this.currentDirection != Direction.Left)
            {
                this.GoRight();
            }

            if (Game.Input.GetButton("up") && this.currentDirection != Direction.Down)
            {
                this.GoUp();
            }

            if (Game.Input.GetButton("down") && this.currentDirection != Direction.Up)
            {
                this.GoDown();
            }
        }

        private void GoRight()
        {
            this.velocity.X = 1;
            this.velocity.Y = 0;
            this.currentDirection = Direction.Right;
        }

        private void GoUp()
        {
            this.velocity.X = 0;
            this.velocity.Y = -1;
            this.currentDirection = Direction.Up;
        }

        private void GoDown()
        {
            this.velocity.X = 0;
            this.velocity.Y = 1;
            this.currentDirection = Direction.Down;
        }

        private void GoLeft()
        {
            this.velocity.X = -1;
            this.velocity.Y = 0;
            this.currentDirection = Direction.Left;
        }
    }
}

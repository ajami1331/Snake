// <copyright file="SnakePlayer.cs" company="KnightsOfOrange">
// Copyright © 2020,2023 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Snake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using KnightsOfOrange.Engine;
    using SFML.Graphics;
    using SFML.System;

    public class SnakePlayer : GameObject
    {
        private Vector2f position;
        private Vector2f velocity;
        private IList<SnakePart> shapes;
        private Vector2f lastPosition;
        private Direction currentDirection = Direction.Right;
        private float accumlatedTimeSinceLastMove = 0f;
        private readonly float movementWindow = 0.1f;
        private int lim = 6;

        private enum Direction
        {
            Left,
            Up,
            Right,
            Down,
        }

        public IList<SnakePart> Shapes => this.shapes;

        public SnakePlayer()
            : base("Player")
        {
            Random random = new Random();
            this.shapes = new List<SnakePart>();
            this.position = new Vector2f(random.Next(0, (int)Game.Window.Size.X / 16) * 16, random.Next(0, (int)Game.Window.Size.Y / 16) * 16);
            this.velocity = default(Vector2f);
            this.GoRight();
            this.GrowSnake(this.position);
        }

        public override void Update()
        {

            this.CheckAndSetVelocity();

            this.ApplyVelocityAndVerify();

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

        public bool IsCollision(FloatRect rect1, FloatRect rect2)
        {
            return rect1.Left < rect2.Left + rect2.Width &&
                    rect1.Left + rect1.Width > rect2.Left &&
                    rect1.Top < rect2.Top + rect2.Height &&
                    rect1.Top + rect1.Height > rect2.Top;
        }

        public override void Draw()
        {
            this.position = this.shapes.First().Shape.Position;
            base.Draw();
        }

        public void GrowSnake()
        {
            this.GrowSnake(this.lastPosition);
        }

        private void GrowSnake(Vector2f position)
        {
            this.shapes.Add(new SnakePart(position));
        }

        private void ApplyVelocityAndVerify()
        {
            this.accumlatedTimeSinceLastMove += Game.Time.DeltaTime;
            if (this.accumlatedTimeSinceLastMove <= this.movementWindow)
            {
                return;
            }

            this.accumlatedTimeSinceLastMove = 0f;
            this.position += this.velocity * this.shapes[0].Shape.Size.Y;

            this.lastPosition = this.shapes.Last().Shape.Position;

            for (int index = this.shapes.Count - 1; index > 0; index--)
            {
                this.shapes[index].Shape.Position = new Vector2f(this.shapes[index - 1].Shape.Position.X, this.shapes[index - 1].Shape.Position.Y);
            }

            this.shapes.First().Shape.Position = this.position;

            for (int i = 0; i < this.shapes.Count; i++)
            {

                this.shapes[i].Shape.FillColor = Color.Green;
            }
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

// <copyright file="PlayerController.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

using SFML.System;

namespace KnightsOfOrange.Snake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using KnightsOfOrange.Engine;
    using KnightsOfOrange.Engine.Abstraction;

    public class PlayerController : Component
    {
        private Transform transfrom;

        public PlayerController(IGameObject owner)
            : base(owner, "PlayerController")
        {
            this.transfrom = this.GetComponent<Transform>("Transform");
        }

        public override void Update()
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

            base.Update();
        }

        private void GoRight()
        {
            Console.WriteLine("right");
            this.transfrom.Position += new Vector2f(8, 0);
        }

        private void GoUp()
        {
            Console.WriteLine("up");
            this.transfrom.Position -= new Vector2f(0, 8);
        }

        private void GoDown()
        {
            Console.WriteLine("down");
            this.transfrom.Position += new Vector2f(0, 8);
        }

        private void GoLeft()
        {
            Console.WriteLine("left");
            this.transfrom.Position -= new Vector2f(8, 0);
        }
    }
}

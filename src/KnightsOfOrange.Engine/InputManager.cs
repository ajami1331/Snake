// <copyright file="InputManager.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine
{
    using System;
    using System.Collections.Generic;
    using KnightsOfOrange.Engine.Abstraction;
    using SFML.Window;

    public class InputManager
    {
        private readonly Dictionary<Keyboard.Key, string> mappedEvent;
        private readonly Dictionary<string, bool> isPressed;

        public InputManager()
        {
            this.mappedEvent = new Dictionary<Keyboard.Key, string>();
            this.isPressed = new Dictionary<string, bool>();
            this.MapKey(Keyboard.Key.A, "left");
            this.MapKey(Keyboard.Key.A, "left");
            this.MapKey(Keyboard.Key.S, "down");
            this.MapKey(Keyboard.Key.D, "right");
            this.MapKey(Keyboard.Key.W, "up");
            this.MapKey(Keyboard.Key.Left, "left");
            this.MapKey(Keyboard.Key.Down, "down");
            this.MapKey(Keyboard.Key.Right, "right");
            this.MapKey(Keyboard.Key.Up, "up");
        }

        /// <summary>Maps the key against a name.</summary>
        /// <param name="key">The key.</param>
        /// <param name="name">The name.</param>
        public void MapKey(Keyboard.Key key, string name)
        {
            this.mappedEvent.TryAdd(key, name);
            this.isPressed.TryAdd(name, false);
        }

        /// <summary>Called when [key press].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        public void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (!this.mappedEvent.ContainsKey(e.Code))
            {
                return;
            }

            string name = this.mappedEvent[e.Code];
            this.isPressed[name] = true;
        }

        /// <summary>Called when [key release].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        public void OnKeyRelease(object sender, KeyEventArgs e)
        {
            if (!this.mappedEvent.ContainsKey(e.Code))
            {
                return;
            }

            string name = this.mappedEvent[e.Code];
            this.isPressed[name] = false;
        }

        /// <summary>Gets the state of the button.</summary>
        /// <param name="button">The button.</param>
        /// <returns>Returns true if button is pressed, else returns false.</returns>
        public bool GetButton(string button)
        {
            return this.isPressed[button];
        }
    }
}

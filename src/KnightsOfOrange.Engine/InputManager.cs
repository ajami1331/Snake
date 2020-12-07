// <copyright file="InputManager.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine
{
    using System;
    using System.Collections.Generic;
    using KnightsOfOrange.Engine.Abstraction;
    using SFML.Window;

    public static class InputManager
    {
        private static readonly Dictionary<Keyboard.Key, string> mappedEvent;
        private static readonly Dictionary<string, bool> isPressed;

        static InputManager()
        {
            mappedEvent = new Dictionary<Keyboard.Key, string>();
            isPressed = new Dictionary<string, bool>();
            MapKey(Keyboard.Key.A, "left");
            MapKey(Keyboard.Key.A, "left");
            MapKey(Keyboard.Key.S, "down");
            MapKey(Keyboard.Key.D, "right");
            MapKey(Keyboard.Key.W, "up");
            MapKey(Keyboard.Key.Left, "left");
            MapKey(Keyboard.Key.Down, "down");
            MapKey(Keyboard.Key.Right, "right");
            MapKey(Keyboard.Key.Up, "up");
        }

        /// <summary>Maps the key against a name.</summary>
        /// <param name="key">The key.</param>
        /// <param name="name">The name.</param>
        public static void MapKey(Keyboard.Key key, string name)
        {
            mappedEvent.TryAdd(key, name);
            isPressed.TryAdd(name, false);
        }

        /// <summary>Called when [key press].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        public static void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (!mappedEvent.ContainsKey(e.Code))
            {
                return;
            }

            string name = mappedEvent[e.Code];
            isPressed[name] = true;
        }

        /// <summary>Called when [key release].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        public static void OnKeyRelease(object sender, KeyEventArgs e)
        {
            if (!mappedEvent.ContainsKey(e.Code))
            {
                return;
            }

            string name = mappedEvent[e.Code];
            isPressed[name] = false;
        }

        /// <summary>Gets the state of the button.</summary>
        /// <param name="button">The button.</param>
        /// <returns>Returns true if button is pressed, else returns false.</returns>
        public static bool GetButton(string button)
        {
            return isPressed[button];
        }
    }
}

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
        private static Dictionary<Keyboard.Key, string> mappedEvent;
        private static Dictionary<string, bool> isPressed;

        private static event EventHandler<InputEventArgs> fireNewInput;

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

        public static void MapKey(Keyboard.Key key, string name)
        {
            mappedEvent.TryAdd(key, name);
            isPressed.TryAdd(name, false);
        }

        public static void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (!mappedEvent.ContainsKey(e.Code))
            {
                return;
            }

            string name = mappedEvent[e.Code];
            isPressed[name] = true;
        }

        public static void OnKeyRelease(object sender, KeyEventArgs e)
        {
            if (!mappedEvent.ContainsKey(e.Code))
            {
                return;
            }

            string name = mappedEvent[e.Code];
            isPressed[name] = false;
        }

        public static bool GetButton(string button)
        {
            return isPressed[button];
        }
    }

    public class InputEventArgs
    {
        public string MappedInput { get;  }

        public InputEventArgs(string mappedInput)
        {
            this.MappedInput = mappedInput;
        }
    }
}

// <copyright file="IGame.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine.Abstraction
{
    using System;

    public interface IGame : IDisposable
    {
        static ISceneManager SceneManager { get; }

        static InputManager Input { get; }

        static TimeManager Time { get; }

        void Init();

        IScene CreateScene(string id, string name);
    }
}

// <copyright file="IGame.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine.Abstraction
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface ISceneManager
    {
        int CurrentSceneIndex { get; }

        IList<IScene> Scenes { get; }

        IScene GetCurrentScene();

        void AddScene(IScene scene);
    }
}

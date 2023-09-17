// <copyright file="ISceneManager.cs" company="KnightsOfOrange">
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

        IScene CurrentScene { get; }

        IScene CreateScene(string id, string name);
    }
}

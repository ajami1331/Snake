// <copyright file="IGame.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine.Abstraction
{
    using System;
    using System.Collections.Generic;

    public interface IGameObjectManager
    {
        IList<IGameObject> GameObjects { get; }

        void Update();

        void LateUpdate();

        void Draw();
    }
}

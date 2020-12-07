// <copyright file="IScene.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine.Abstraction
{
    using System;

    public interface IScene
    {
        string Id { get; }

        string Name { get; }

        IGameObjectManager GameObjectManager { get; }

        void Step();
    }
}

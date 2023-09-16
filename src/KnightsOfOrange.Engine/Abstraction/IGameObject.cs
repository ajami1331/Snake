// <copyright file="IGameObject.cs" company="KnightsOfOrange">
// Copyright © 2020,2023 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine.Abstraction
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IGameObject
    {
        string Id { get; }

        string Name { get; set; }

        void Update();

        void LateUpdate();

        void Draw();
    }
}

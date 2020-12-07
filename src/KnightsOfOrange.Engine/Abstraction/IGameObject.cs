// <copyright file="IGameObject.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
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

        IList<IComponent> Components { get; }

        void BindComponent<TComponent> (TComponent component)
            where TComponent : IComponent;

        TComponent GetComponent<TComponent>(string name)
            where TComponent : class, IComponent;

        IComponent GetComponent(string name);

        void Update();

        void LateUpdate();

        void Draw();
    }
}

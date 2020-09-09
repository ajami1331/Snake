// <copyright file="GameObject.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine
{
    using System;
    using System.Collections.Generic;
    using KnightsOfOrange.Engine.Abstraction;

    public abstract class GameObject: IGameObject
    {
        public string Id { get; }

        public string Name { get; set; }

        public GameObject()
        {

        }

        public IList<IComponent> Components => throw new NotImplementedException();

        public void BindComponent<TComponent>(TComponent component) where TComponent : IComponent
        {
            throw new NotImplementedException();
        }

        public IComponent GetComponent(string name)
        {
            throw new NotImplementedException();
        }
    }
}

// <copyright file="Component.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine
{
    using System;
    using System.Linq;
    using KnightsOfOrange.Engine.Abstraction;

    public abstract class Component : IComponent
    {
        public Component(IGameObject owner, string name)
        {
            this.Owner = owner;
            this.Name = name;
        }

        public IGameObject Owner { get; }

        public string Name { get; }

        public TComponent GetComponent<TComponent>(string name)
            where TComponent : class, IComponent
        {
            return this.Owner.GetComponent<TComponent>(name);
        }

        public IComponent GetComponent(string name)
        {
            return this.Owner.GetComponent(name);
        }

        public virtual void Update()
        {
        }

        public virtual void LateUpdate()
        {
        }

        public virtual void Draw()
        {
        }
    }
}

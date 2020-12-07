// <copyright file="GameObject.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using KnightsOfOrange.Engine.Abstraction;

    public class GameObject: IGameObject
    {
        protected GameObject()
            : this(Guid.NewGuid().ToString(), string.Empty)
        {
        }

        protected GameObject(string name)
            : this(Guid.NewGuid().ToString(), name)
        {
        }

        protected GameObject(string id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Components = new List<IComponent>();
        }

        public string Id { get; }

        public string Name { get; set; }

        public IList<IComponent> Components { get; }

        public void BindComponent<TComponent>(TComponent component)
            where TComponent : IComponent
        {
            this.Components.Add(component);
        }

        public TComponent GetComponent<TComponent>(string name)
            where TComponent : class, IComponent
        {
            return this.Components.FirstOrDefault(c => c.Name.Equals(name)) as TComponent;
        }

        public IComponent GetComponent(string name)
        {
            return this.Components.FirstOrDefault(c => c.Name.Equals(name));
        }

        public void Update()
        {
            foreach (IComponent component in this.Components)
            {
                component.Update();
            }
        }

        public void LateUpdate()
        {
            foreach (IComponent component in this.Components)
            {
                component.LateUpdate();
            }
        }

        public void Draw()
        {
            foreach (IComponent component in this.Components)
            {
                component.Draw();
            }
        }
    }
}

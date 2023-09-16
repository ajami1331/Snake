// <copyright file="GameObject.cs" company="KnightsOfOrange">
// Copyright © 2020,2023 KnightsOfOrange. All Rights Reserved.
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
        }

        public string Id { get; }

        public string Name { get; set; }

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

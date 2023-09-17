// <copyright file="GameObject.cs" company="KnightsOfOrange">
// Copyright © 2020,2023 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using KnightsOfOrange.Engine.Abstraction;

    public class GameObject : IGameObject
    {
        protected GameObject()
            : this(Guid.NewGuid().ToString(), string.Empty, Game.SceneManager.CurrentScene)
        {
        }

        protected GameObject(string name, IScene scene)
            : this(Guid.NewGuid().ToString(), name, scene)
        {
        }

        protected GameObject(string id, string name, IScene scene)
        {
            this.Id = id;
            this.Name = name;
            this.Scene = scene;
            this.Scene.GameObjectManager.AddGameObject(this);
        }

        public string Id { get; }

        public string Name { get; set; }

        public IScene Scene { get; private set; }

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

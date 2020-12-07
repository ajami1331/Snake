// <copyright file="Scene.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine
{
    using System;
    using System.Linq;
    using KnightsOfOrange.Engine.Abstraction;

    public class Scene : IScene
    {
        public Scene()
            : this(Guid.NewGuid().ToString(), string.Empty)
        {

        }

        public Scene(string id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.GameObjectManager = new GameObjectManager();
        }

        public string Id { get; }

        public string Name { get; }

        public IGameObjectManager GameObjectManager { get; }

        public void Step()
        {
            this.GameObjectManager.Update();
            this.GameObjectManager.LateUpdate();
            this.GameObjectManager.Draw();
        }
    }
}

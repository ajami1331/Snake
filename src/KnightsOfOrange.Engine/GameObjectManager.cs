// <copyright file="GameObjectManager.cs" company="KnightsOfOrange">
// Copyright © 2020,2023 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using KnightsOfOrange.Engine.Abstraction;

    public class GameObjectManager : IGameObjectManager
    {
        public GameObjectManager()
        {
            this.GameObjects = new List<IGameObject>();
            this.tempGameObjects = new List<IGameObject>();
        }

        public IList<IGameObject> GameObjects { get; }

        private readonly List<IGameObject> tempGameObjects;

        public void Update()
        {
            this.MoveTempGameObjectsToMainList();
            foreach (IGameObject gameObject in this.GameObjects)
            {
                gameObject.Update();
            }
        }

        public void LateUpdate()
        {
            this.MoveTempGameObjectsToMainList();
            foreach (IGameObject gameObject in this.GameObjects)
            {
                gameObject.LateUpdate();
            }
        }

        public void Draw()
        {
            this.MoveTempGameObjectsToMainList();
            foreach (IGameObject gameObject in this.GameObjects)
            {
                gameObject.Draw();
            }
        }

        public void AddGameObject(IGameObject gameObject)
        {
            this.tempGameObjects.Add(gameObject);
        }

        public IGameObject GetGameObjectByName(string name)
        {
           return this.GameObjects.FirstOrDefault(go => go.Name == name) ?? this.tempGameObjects.First(go => go.Name == name);
        }

        private void MoveTempGameObjectsToMainList()
        {
            foreach (IGameObject gameObject in this.tempGameObjects)
            {
                this.GameObjects.Add(gameObject);
            }

            this.tempGameObjects.Clear();
        }
    }
}

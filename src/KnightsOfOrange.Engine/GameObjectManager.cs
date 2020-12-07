// <copyright file="GameObjectManager.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
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
        }

        public IList<IGameObject> GameObjects { get; }

        public void Update()
        {
            foreach (IGameObject gameObject in this.GameObjects)
            {
                gameObject.Update();
            }
        }

        public void LateUpdate()
        {
            foreach (IGameObject gameObject in this.GameObjects)
            {
                gameObject.LateUpdate();
            }
        }

        public void Draw()
        {
            foreach (IGameObject gameObject in this.GameObjects)
            {
                gameObject.Draw();
            }
        }
    }
}

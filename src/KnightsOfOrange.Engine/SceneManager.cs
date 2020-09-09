// <copyright file="Component.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using KnightsOfOrange.Engine.Abstraction;

    public class SceneManager : ISceneManager
    {
        public SceneManager()
        {
            this.Scenes = new List<IScene>();
            this.CurrentSceneIndex = 0;
        }

        public int CurrentSceneIndex { get; }

        public IList<IScene> Scenes { get; }

        public IScene GetCurrentScene()
        {
            if (this.CurrentSceneIndex >= this.Scenes.Count)
            {
                throw new IndexOutOfRangeException();
            }

            return this.Scenes[this.CurrentSceneIndex];
        }

        public void AddScene(IScene scene)
        {
            this.Scenes.Add(scene);
        }
    }
}

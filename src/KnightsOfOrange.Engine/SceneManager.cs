// <copyright file="SceneManager.cs" company="KnightsOfOrange">
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

        public IScene CurrentScene => this.GetCurrentScene();

        public IScene CreateScene(string id, string name)
        {
            this.Scenes.Add(new Scene(id, name));
            return this.Scenes.Last();
        }

        private IScene GetCurrentScene()
        {
            if (this.CurrentSceneIndex >= this.Scenes.Count)
            {
                throw new IndexOutOfRangeException();
            }

            return this.Scenes[this.CurrentSceneIndex];
        }
    }
}

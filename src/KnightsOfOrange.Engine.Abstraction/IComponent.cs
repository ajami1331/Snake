// <copyright file="IComponent.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine.Abstraction
{
    public interface IComponent
    {
        IGameObject Owner { get; }

        string Name { get; }

        TComponent GetComponent<TComponent>(string name)
            where TComponent : class, IComponent;

        IComponent GetComponent(string name);

        void Update();

        void LateUpdate();

        void Draw();
    }
}

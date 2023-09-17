namespace KnightsOfOrange.Snake.Scenes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using KnightsOfOrange.Engine;
    using KnightsOfOrange.Snake.GameObjects;

    public class Gameplay : Scene
    {
        public Gameplay()
            : base(Guid.NewGuid().ToString(), "Gameplay")
        {
            new SnakePlayer(this);
            new Apple(this);
        }
    }
}

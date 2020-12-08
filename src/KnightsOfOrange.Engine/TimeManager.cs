// <copyright file="TimeManager.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SFML.System;

    public class TimeManager
    {

        public TimeManager()
        {
        }

        public float DeltaTime { get; internal set; }
    }
}

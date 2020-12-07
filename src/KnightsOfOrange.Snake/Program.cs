// <copyright file="Program.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.Snake
{
    using System;
    using KnightsOfOrange.Engine.Abstraction;
    using Serilog;

    class Program
    {
        static void Main(string[] args)
        {
            Log.Information("Game Started");

            using (IGame game = new Snake())
            {
                game.Init();
            }
        }
    }
}

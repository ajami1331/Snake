// <copyright file="Program.cs" company="KnightsOfOrange">
// Copyright © 2020 KnightsOfOrange. All Rights Reserved.
// </copyright>

namespace KnightsOfOrange.TicTacToe
{
    using System;
    using KnightsOfOrange.Engine.Abstraction;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (IGame game = new Snake())
            {
                game.Init();
            }
        }
    }
}

﻿namespace BckGmmn.Core
{
    public interface IGame
    {
        IPlayer PlayerA { get; }
        IPlayer PlayerB { get; }
        GameState GameState { get; }
        PlayerId Turn { get; set; }
        PlayerId Winner { get; }
        IBoard Board { get; }


        // void Initialize();
        void Start();
        void Abort();
    }
}
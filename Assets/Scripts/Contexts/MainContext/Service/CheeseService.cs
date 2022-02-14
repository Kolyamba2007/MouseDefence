using Enums;
using System;
using UnityEngine;

public class CheeseService : ICheeseService
{
    [Inject] public ICheeseState CheeseState { get; set; }
    [Inject] public UpdateCheeseCountSignal UpdateCheeseCountSignal { get; set; }

    public void SetCount(int count, Mode mode)
    {
        switch (mode)
        {
            case Mode.Assignment:
                CheeseState.Count = count;
                break;
            case Mode.Addition:
                CheeseState.Count += count;
                break;
            case Mode.Subtraction:
                CheeseState.Count -= count;
                break;
        }
        
        if (CheeseState.Count < 0)
            throw new Exception("You are trying to assign a value less than zero!");
        else
            UpdateCheeseCountSignal.Dispatch(CheeseState.Count);
    }

    public int Count => CheeseState.Count;
}
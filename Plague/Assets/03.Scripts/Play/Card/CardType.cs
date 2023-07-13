using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    FieldItem = 0,
    FieldPN,

    HandItem  = 10,
    HandPN,
}

public enum Ending
{
    None = 0,
    Clear = 1,

    Energy = 10,
    Infection,
}

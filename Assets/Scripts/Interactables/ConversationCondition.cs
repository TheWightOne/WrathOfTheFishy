using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is a class that holds conditions that devs can set in the unity scene
//these conditions will gate off conversations until the player has met the conditions
//Examples: player talked to someone yet? how many times?

public enum Characters{
    NONE,
    BROC,
    CLYDE,
    CORNELIUS,
    DARWIN,
    OLLIVER,
    POM,
    TRUBIE
}

public enum ComparativeOperators{
    GREATER_THAN,
    GREATER_OR_EQUAL,
    LESS_THAN,
    LESS_OR_EQUAL,
    EQUAL
}
[System.Serializable]
public class ConversationCondition
{
    public Characters referencedCharacter = 0;
    public ComparativeOperators comparativeOperator = 0;
    [Range(0, 10)]
    public int timesTalked = 0;
}

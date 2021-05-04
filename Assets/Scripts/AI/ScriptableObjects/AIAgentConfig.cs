using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AIAgentConfig : ScriptableObject
{
    public float maxTime = 1;
    public float minDistance = 2;

    public float maxSightDistance = 5.0f;

    public float attackTime = 2f;
}

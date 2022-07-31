using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    internal void SetDestination(Vector3 position)
    {
        GetComponent<AIPath>().destination = position;
    }
}

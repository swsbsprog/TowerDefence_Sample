using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeCollider : MonoBehaviour
{
    Tower tower;
    private void Awake() =>
        tower = GetComponentInParent<Tower>();  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        tower.AddTarget(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tower.RemoveTarget(collision);
    }
}

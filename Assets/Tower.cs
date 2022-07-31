using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerType type;
    public Transform target;

    public List<Transform> testList;
    public HashSet<Transform> targets = new HashSet<Transform>(); // 중복으로 넣을 수 없다
    // -> 중복으로 들어가지 않는다.
    internal void AddTarget(Collider2D collision)
    {
        //collision을 공격하자.
        targets.Add(collision.transform);
    }

    internal void RemoveTarget(Collider2D collision)
    {
        targets.Remove(collision.transform);
    }
    public float coolTime = 1;
    public float nextUseableTime = 0;
    public Weapon weapon;
    public Transform weaponRegenPoint;
    private void Update()
    {
        if (targets.Count == 0)
            return;

        if (target == null && targets.Count > 0)
            target = targets.First();

        if (Time.time < nextUseableTime)
            return;
        // 미사일 발사.
        nextUseableTime = Time.time + coolTime;
        var newWeapon = Instantiate(weapon);
        newWeapon.transform.position = weaponRegenPoint.position;
        newWeapon.destination = target.position;
    }
}

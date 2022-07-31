using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    static public BuildManager instance;
    private void Awake() => instance = this;
    private void OnDestroy() => instance = null;

    internal void Build(TowerType type, Vector3 spawnPos)
    {
        // type에 해당하는 골드 감소.
        Tower newTowerPrefab = GetPrefab(type);
        Tower newTower = Instantiate(newTowerPrefab);
        newTower.transform.position = spawnPos;
    }

    public List<Tower> towers;
    private Tower GetPrefab(TowerType type)
    {
        return towers.Where(x => x.type == type)
            .First();
    }
}

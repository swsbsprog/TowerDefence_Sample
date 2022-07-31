using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
    Arrow,
    Shied,
    Magic,
    Bomb,
}
public class WeaponButton : MonoBehaviour
{
    public TowerType type;

    public void OnClickBuildTower()
    {
        var spawnPos = WeaponSelectUI.instance.posTr.position;
        print(type + $"을 {spawnPos}에 건설하자");
        BuildManager.instance.Build(type, spawnPos);
    }
}

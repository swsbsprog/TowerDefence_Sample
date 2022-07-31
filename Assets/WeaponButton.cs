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

    public GameObject icon;
    public GameObject checkMark;
    public void Init()
    {
        icon.SetActive(true);
        checkMark.SetActive(false);
    }
    public void OnClickBuildTower()
    {
        if (checkMark.activeSelf == false)
            return;

        var spawnPos = WeaponSelectUI.instance.posTr.position;
        print(type + $"을 {spawnPos}에 건설하자");
        BuildManager.instance.Build(type, spawnPos);
    }
}

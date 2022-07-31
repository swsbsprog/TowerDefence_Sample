using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    void OnMouseDown()
    {
        print("메뉴 표시");
        WeaponSelectUI.instance.Show(transform.position);
    }
}

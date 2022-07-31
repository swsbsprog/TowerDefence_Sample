using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectUI : MonoBehaviour
{
    static public WeaponSelectUI instance;
    public Transform posTr;
    private void Awake()
    {
        instance = this;
        posTr.gameObject.SetActive(false);
    }

    private void OnDestroy() => instance = null;
  
    internal void Show(Vector3 position)
    {
        posTr.gameObject.SetActive(true);
        posTr.position = position;
        GetComponent<Animator>().Play("Show", 0, 0);
    }
}

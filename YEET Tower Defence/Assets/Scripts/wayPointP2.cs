using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayPointP2 : MonoBehaviour {

    public static Transform[] wayPointsP2;

    void Awake()
    {
        wayPointsP2 = new Transform[transform.childCount];
        for (int i = 0; i < wayPointsP2.Length; i++)
        {
            wayPointsP2[i] = transform.GetChild(i);
        }
    }
}

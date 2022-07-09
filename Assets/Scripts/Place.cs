using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public static List<GameObject> sidewalks;
    private void Awake()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Sidewalk"); //tim tat ca cac le duong
        sidewalks = new List<GameObject>(temp);
    }
}

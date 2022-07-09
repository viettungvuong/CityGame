using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public class Destination
    {
        public float x;
        public float z;
    }
    static List<GameObject> sidewalks;
    public static List<Destination> destinations;

    private void Awake()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Sidewalk"); //tim tat ca cac le duong
        sidewalks = new List<GameObject>(temp);
    }
    void createDestinations()
    {
        foreach(GameObject go in sidewalks)
        {
            float startX = go.transform.position.x;
            float endX = go.transform.position.x + go.transform.lossyScale.x;
            float startZ = go.transform.position.z;
            float endZ = go.transform.position.z + go.transform.lossyScale.z; //lay diem dau va diem cuoi cua le duong
        }
    }
}

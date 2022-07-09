using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public static Place instance;
    public class Destination
    {
        public float x;
        public float z;
        public Destination(float x, float z)
        {
            this.x = x;
            this.z = z;
        }
        public void display()
        {

        }
    }
    List<GameObject> sidewalks;

    private void Awake()
    {
        instance = this;
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Sidewalk"); //tim tat ca cac le duong
        sidewalks = new List<GameObject>(temp);
    }
    public Destination createDestination()
    {
        int r = Random.Range(0, sidewalks.Count);
        GameObject go = sidewalks[r];
        float startX = go.transform.position.x;
        float endX = go.transform.position.x + go.transform.lossyScale.x;
        float startZ = go.transform.position.z;
        float endZ = go.transform.position.z + go.transform.lossyScale.z; //lay diem dau va diem cuoi cua le duong
        float x = Random.Range(startX, endX);
        float z = Random.Range(startZ, endZ);
        Destination goTo = new Destination(x, z); //tao destination moi
        return goTo;

    }
}

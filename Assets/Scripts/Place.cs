using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTAssets.EasyMinimapSystem;



public class Place : MonoBehaviour
{
    public static Place instance;
    public MinimapRoutes route;
    List<GameObject> places;

    private void Awake()
    {
        instance = this;
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Building"); //tim tat ca cac building
        places = new List<GameObject>(temp);
    }
    Transform getRandom()
    {
        int c = Random.Range(0, places.Count);
        return places[c].transform;
    }
    public void getNewDestination()
    {
        route.startingPoint = this.transform; //lay vi tri hien tai lam diem xuat phat cua xe
        Game.destination = route.destinationPoint = getRandom(); //chinh route diem den
    }
}

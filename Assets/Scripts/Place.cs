using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTAssets.EasyMinimapSystem;



public class Place : MonoBehaviour
{
    public Sprite minimapIndicator;
    public MinimapRenderer minimapRenderer;
    public static Place instance;
    public MinimapRoutes route;
    List<GameObject> places;
    public GameObject player;
    public TMPro.TextMeshProUGUI distanceShow;
    private void Awake()
    {
        instance = this;
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Destination"); //tim tat ca cac building co the den
        places = new List<GameObject>(temp);
    }
    Transform getRandom()
    {
        int c = Random.Range(0, places.Count);
        return places[c].transform;
    }
    public void getNewDestination()
    {
        route.startingPoint = player.transform; //lay vi tri hien tai lam diem xuat phat cua xe
        Transform goTo = getRandom();

        Game.destination = route.destinationPoint = goTo; //chinh route diem den
        MinimapItem showMinimap = route.destinationPoint.gameObject.AddComponent(typeof(MinimapItem)) as MinimapItem;
        showMinimap.itemSprite = minimapIndicator;
        showMinimap.sizeOnMinimap = new Vector3(20, 0, 20);
        showMinimap.spriteColor = Color.red;
        showMinimap.sizeOnHighlight = 35; //de destination xuat hien tren minimap
        showMinimap.enabled = true;
        float distance = route.GetCurrentGeneratedRouteIfIsCalculingAndShowingRoutes()
        .totalDistanceOfRouteSinceStartPointToDestination; //tim khoang cach
        setTime(distance);
        minimapRenderer.AddMinimapItemToBeHighlighted(showMinimap); //them vao renderer
        route.StartCalculatingAndShowRotesToDestination();
    }
    private void Update()
    {
        float distance = route.GetCurrentGeneratedRouteIfIsCalculingAndShowingRoutes()
                .totalDistanceOfRouteSinceStartPointToDestination;
        if (Game.destination != null)
            distanceShow.text = "Distance: " + ((int)Mathf.Round(distance))
                .ToString() + "m";
    }
    void setTime(float distance)
    {
        if (distance > 0 && distance < 400)
        {
            Game.time = 20;
        }
        else if (distance >= 400 && distance < 1000)
        {
            Game.time = 40;
        }
        else if (distance >= 1000 && distance < 1500)
        {
            Game.time = 75;
        }
        else if (distance >= 1500 && distance < 2000)
        {
            Game.time = 100;
        }
        else
        {
            Game.time = 120;
        }
    }
}

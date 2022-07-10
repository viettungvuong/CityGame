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
    public MinimapText distanceShow;
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
        minimapRenderer.AddMinimapItemToBeHighlighted(showMinimap); //them vao renderer
        route.StartCalculatingAndShowRotesToDestination();
        Debug.Log(route.destinationPoint);
    }
    private void Update()
    {
        if (Game.destination != null)
            distanceShow.textToRender = ((int)Mathf.Round(route.GetCurrentGeneratedRouteIfIsCalculingAndShowingRoutes()
                .totalDistanceOfRouteSinceStartPointToDestination))
                .ToString() + "m";
    }
}

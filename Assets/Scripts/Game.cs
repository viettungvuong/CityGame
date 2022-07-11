using System.Collections;
using System.Collections.Generic;
using MTAssets.EasyMinimapSystem;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Transform player;
    static bool start = true;
    public static Transform destination;
    public static float time = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            Place.instance.route.StopCalculatingAndHideRotesToDestination();
            start = false;
            Place.instance.getNewDestination(); //tim dia diem den moi
        }
        if (reached())
        {
            destination.GetComponent<MinimapItem>().enabled = false;
            start = true; //start cho moi
        }

    }

    bool reached()
    {
        if (destination == null)
            return false;
        if (Vector3.Distance(player.position, destination.position) < 5)
            return true;
        return false;
    }
}

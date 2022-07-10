using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Transform player;
    static bool start = true;
    public static Transform destination;
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
            start = true; //start cho moi
    }

    bool reached()
    {
        if (destination == null)
            return false;
        if (Vector3.Distance(player.position, destination.position) < 100)
            return true;
        return false;
    }
}

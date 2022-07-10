using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Transform player;
    public static bool newMission = false;
    public static Transform destination;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (reached())
        {
            Place.instance.getNewDestination();
        }
    }

    bool reached()
    {
        if (Vector3.Distance(player.position, destination.position) < 100)
            return true;
        return false;
    }
}

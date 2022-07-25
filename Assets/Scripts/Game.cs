using System.Collections;
using System.Collections.Generic;
using MTAssets.EasyMinimapSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Transform player;
    static bool start = true;
    public static Transform destination;
    public static float time = 0;
    public static bool timerOn = false;
    public TMPro.TextMeshProUGUI timerShow;
    public static float health = 100; //suc khoe xe
    public Slider slider;
    public TrafficSystem ts;
    public static GameObject pausePanel;
    public static bool moved = false;
    List<Vector3> places;
    Vector3 startingPoint;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        //Vector3[] temp = {
        //    new Vector3(-1458.1f,0,237.5f),
        //    new Vector3(-1457.98f,0,415.3f),
        //    new Vector3(-1658.45f,0,430.23f),
        //    new Vector3(-1248f,0,407.2f),
        //    new Vector3(-1148.3f,0,407.2f),
        //    new Vector3(-1138.1f,0,271.2f),
        //    new Vector3(-1138.1f,0,375.9f),
        //    new Vector3(-960.2f,0,375.9f),
        //    new Vector3(-658.3f,0,375.9f),
        //    new Vector3(-658.3f,0,276.2f),
        //    new Vector3(-658.3f,0,57f),
        //    new Vector3(-260.2f,0,57f),
        //    new Vector3(-356.8f,0,57f),
        //    new Vector3(-158,0,-133),
        //    new Vector3(-158,0,166.2f),
        //    new Vector3(39.18f,0,166.2f),
        //    new Vector3(39.18f,0,353),
        //    new Vector3(141.1f,0,772.4f),
        //    new Vector3(544.47f,0,675.94f),
        //    new Vector3(542.8f,0,343),
        //    new Vector3(638.3f,0,81),
        //    new Vector3(1135.5f,0,81),
        //    new Vector3(1236,0,523.7f),
        //    new Vector3(1137.65f,0,543.72f),
        //    new Vector3(1036.5f,0,727.7f),
        //};
        //places = new List<Vector3>(temp);
        //Vector3 chosen = places[Random.Range(0, places.Count)];
        //Debug.Log(chosen);
        //startingPoint = player.position = chosen;
        //Debug.Log(player.position);
        ////ts.LoadCars(0); //de tim cach random xe traffic
        pausePanel = GameObject.FindGameObjectWithTag("pausePanel");
        pausePanel.SetActive(false);
    }
    //private void LateUpdate()
    //{
    //    if (!moved)
    //        player.position = startingPoint;
    //}
    // Update is called once per frame
    void Update()
    {
        if (start)
        {

            if (Place.instance.route != null)
                Place.instance.route.StopCalculatingAndHideRotesToDestination();
            Place.instance.getNewDestination(); //tim dia diem den moi
            start = false;
        }
        if (reached())
        {
            destination.GetComponent<MinimapItem>().enabled = false;
            start = true; //start cho moi
        }
        if (timerOn)
        {
            if (time > 0)
            {
                Debug.Log(player.position);
                time -= Time.deltaTime;
                timerShow.text = ((int)Mathf.Round(time)).ToString() + "s";
                UpdateHealth();
                if (health <= 0)
                    Lose();
            }
            else
            {
                Lose(); //thua
                time = 0;
                timerShow.text = "0s";
                timerOn = false;
            }
        }

    }
    private void UpdateHealth()
    {
        slider.value = health;
        Image fillArea = slider.gameObject.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Image>();
        if (health < 60)
            fillArea.color = Color.yellow;
        else if (health < 30)
            fillArea.color = Color.red;
    }
    bool reached()
    {
        if (destination == null)
            return false;
        if (Vector3.Distance(player.position, destination.position) < 5)
            return true;
        return false;
    }

    public static void Lose()
    {
        Time.timeScale = 0; //ngung game
    }

    public static void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public static void Continue()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public static void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}

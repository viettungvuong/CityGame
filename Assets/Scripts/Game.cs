using System.Collections;
using System.Collections.Generic;
using MTAssets.EasyMinimapSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Transform player;
    public static bool start = false;
    public static Transform destination;
    public static float time = 0;
    public static bool timerOn = false;
    public TMPro.TextMeshProUGUI timerShow;
    public static float health = 100; //suc khoe xe
    public Slider slider;
    public TrafficSystem ts;
    public TMPro.TextMeshProUGUI reachedNoti;
    public static int reachedNums = 0;
    public TMPro.TextMeshProUGUI reachedNumsShow; //hien thi so diem da den

    public static GameObject losePanel;

    public static TMPro.TextMeshProUGUI scoreText;

    public TMPro.TextMeshProUGUI mileage;

    public GameObject reachedPanel;

    public static GameObject pausePanel;
    public static bool moved = false;

    public static int score = 0;

    public static int tempScore = 0;

    public AudioClip audio;

    List<Vector3> places;
    Vector3 startingPoint;

    private void Awake()
    {
        Time.timeScale = 1;
        health = 100;
        score = 0;
        tempScore = 0;
        moved = false;
        timerOn = false;
        start = false; //ktra xem da bat game hay chua
        Application.targetFrameRate = 60;
        reachedNoti.text = "";
        AudioListener.volume = 1; //tat het moi am thanh

    }
    void Start()
    {
        timerOn = false;
        pausePanel = GameObject.FindGameObjectWithTag("pausePanel");
        pausePanel.SetActive(false);
        scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<TMPro.TextMeshProUGUI>();
        losePanel = GameObject.FindGameObjectWithTag("losePanel");
        losePanel.SetActive(false); //an menu luc thua

    }
    //private void LateUpdate()
    //{
    //    if (!moved)
    //        player.position = startingPoint;
    //}
    // Update is called once per frame
    IEnumerator reachedNotiShow()
    {
        reachedPanel.SetActive(true);
        reachedNoti.text = "Destination Reached"; //thong bao da den dia diem
        reachedNums++;
        yield return new WaitForSeconds(5.0f);
        reachedNoti.text = "";
        reachedPanel.SetActive(false);
    }
    void Update()
    {
        mileage.text = score.ToString();
        reachedNumsShow.text = reachedNums.ToString();
        if (start)
        {

            if (Place.instance.route != null)
                Place.instance.route.StopCalculatingAndHideRotesToDestination(); //luc nay la da xong, ngung tinh toan duong cu
            Place.instance.getNewDestination(); //tim dia diem den moi
            start = false;
            //them cai doi may giay nua

        }
        if (reached())
        {
            destination.GetComponent<MinimapItem>().enabled = false;
            AudioSource audiosrc = GetComponent<AudioSource>();
            audiosrc.PlayOneShot(audio);
            StartCoroutine(reachedNotiShow()); //hien thong bao da den
            reachedNoti.text = ""; //thong bao da den dia diem
            start = true; //start cho moi
            score += tempScore;
            tempScore = 0;
        }
        if (timerOn)
        {
            if (time > 0) //timer
            {
                //Debug.Log(player.position);
                time -= Time.deltaTime;
                timerShow.text = ((int)Mathf.Round(time)).ToString();
                UpdateHealth();
                if (health <= 0)
                    Lose();
            }
            else
            {
                Lose(); //thua
                time = 0;
                timerShow.text = "0";
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
        if (health < 30)
            fillArea.color = Color.red;
    }
    bool reached()
    {
        if (destination == null)
            return false;
        if (Vector3.Distance(player.position, destination.position) <= 25)
            return true;
        return false;
    }

    public static void Lose()
    {
        losePanel.SetActive(true);
        scoreText.text = score.ToString();
        AudioListener.volume = 0; //tat het moi am thanh
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

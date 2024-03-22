using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerCalibration : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject timerTextHide;

    private bool startTimer;
    private float secondsCount = 10;
    private int minuteCount = 0;
    public static float count = 0;

    private void Start()
    {
        //DontDestroyOnLoad(this);


    }
    void Update()
    {
        if (count <= 0)
        {
            //SceneManager.LoadScene("Ending");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            timerTextHide.SetActive(true);
            startTimer = true;
        }
        if (startTimer)
        {
            UpdateTimerUI();

        }
    }

    //call this on update
    public void UpdateTimerUI()
    {
        //Debug.Log(count);

        //set timer UI
        secondsCount -= Time.deltaTime;
        count -= Time.deltaTime;
        timerText.text = minuteCount + ":" + ((int)secondsCount).ToString("00");
        if (secondsCount <= 00)
        {
            timerTextHide.SetActive(false);
            SceneManager.LoadScene("Gameplay");
            //minuteCount--;
            //secondsCount = 10;
        }

    }
}
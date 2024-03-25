using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class TimerCalibration : MonoBehaviour
{
    public AudioCheck audioCheck;
    public AudioControl audioControl;

    public TextMeshProUGUI timerText;
    public GameObject timerTextHide;

    private bool startTimer;
    private float secondsCount = 10;
    private int minuteCount = 0;
    public static float count = 0;
    public List<int> values;
    public int addedUp;
    public int average;

    public int lowerAvg;
    public int upperAvg;

    private void Start()
    {
        //DontDestroyOnLoad(this);
        audioCheck = GameObject.Find("Arduino").GetComponent<AudioCheck>();
        audioControl = GameObject.Find("AudioControl").GetComponent<AudioControl>();


    }
    void Update()
    {
        if (count <= 0)
        {
            //SceneManager.LoadScene("Ending");
        }

        if (audioCheck.green == true)
        {
            timerTextHide.SetActive(true);
            startTimer = true;
        }
        if(startTimer == true && secondsCount >= 00)
        {
            values.Add(audioCheck.audioLevel);

            Debug.Log("All numbers: " + values);

        }
        if (startTimer)
        {
            UpdateTimerUI();

        }


        //Debug.Log(audioCheck.audioLevel);

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
            Debug.Log("All numbers: "+ values);
            timerTextHide.SetActive(false);
            
            foreach (int item in values)
            {
                addedUp += item;
                //Debug.Log("total: " + addedUp);
            }

            average = addedUp / values.Count;
            lowerAvg = average + 5;
            upperAvg = average + 10;
            Debug.Log("average: " + average);
            getVolumeAvg();
            SceneManager.LoadScene("Gameplay");

            //minuteCount--;
            //secondsCount = 10;
        }

    }
    public void getVolumeAvg()
    {
        audioControl.average = average;
        audioControl.lowerAvg = lowerAvg;
        audioControl.upperAvg = upperAvg;
    }
}

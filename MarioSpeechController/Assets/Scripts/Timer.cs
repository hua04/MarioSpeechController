using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float secondsCount;
    private int minuteCount = 1;
    public static float count=60;


    private void Start()
    {
        //DontDestroyOnLoad(this);

    }
    void Update()
    {
        UpdateTimerUI();

        if (count <= 0)
        {
            SceneManager.LoadScene("Ending");
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
            
            minuteCount--;
            secondsCount = 60;
        }

    }
}
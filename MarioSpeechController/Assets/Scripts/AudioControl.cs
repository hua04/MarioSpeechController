using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioControl : MonoBehaviour
{
    //public TimerCalibration timerCalibration;
    public AudioCheck audioCheck;

    public int average;
    public int lowerAvg;
    public int upperAvg;
    public bool speaking;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            if (audioCheck.audioLevel > lowerAvg)
            {
                audioCheck.ButtonAndAudio();
                Debug.Log("speaking" + "current:" + audioCheck.audioLevel + "avg:" + average);
                speaking = true;

            }
            else
            {
                Debug.Log("not speaking");
                speaking = false;
            }

            if (audioCheck == null)
            {
                audioCheck = GameObject.Find("Arduino").GetComponent<AudioCheck>();
            }

        }
        if(SceneManager.GetActiveScene().name == "Start")
        {
            Destroy(gameObject);
        }
       

    }


}

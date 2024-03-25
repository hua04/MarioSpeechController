using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextScroller : MonoBehaviour
{
    public AudioCheck audioCheck;

    [SerializeField][TextArea] private string[] script;
    [SerializeField] private float textSpeed = 0.01f;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI scriptText;
    
    

    public Animator continueText;
    public Animator speechText;

    private int currentText = 0;
    public bool textDone = false;
  
    public void Start()
    {
        audioCheck = GameObject.Find("Arduino").GetComponent<AudioCheck>();
        StartCoroutine(AnimateText());
        
        
    }
    void Update()
    {

        if (currentText < script.Length - 1 && textDone == true)
        {
            continueText.SetBool("Continue",true);
            if (audioCheck.yellow == true)
            {
                scriptText.text = "";
                textDone = false;
                currentText++;
                StartCoroutine(AnimateText());
                continueText.SetBool("Continue", false);

            }
        }

        if (currentText >= script.Length - 1 && textDone == true)
        {
           speechText.SetBool("Visible", true);
            if (audioCheck.yellow == true)
            {
                SceneManager.LoadScene("Calibration");
                speechText.SetBool("Visible", false);
            }
        }

    }
    IEnumerator AnimateText()
    {
        for (int i = 0; i < script[currentText].Length + 1; i++)
        {
            scriptText.text = script[currentText].Substring(0, i);

            yield return new WaitForSeconds(textSpeed);

            if (i == script[currentText].Length)
            {
                Debug.Log("TextDone");
                //dialogueNoises.Stop();
                textDone = true;
            }
        }


    }


}

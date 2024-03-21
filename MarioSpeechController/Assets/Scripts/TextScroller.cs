using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextScroller : MonoBehaviour
{
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
        StartCoroutine(AnimateText());
        
        
    }
    void Update()
    {

        if (currentText < script.Length - 1 && textDone == true)
        {
            continueText.SetBool("Continue",true);
            if (Input.GetKeyDown(KeyCode.A))
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
            if (Input.GetKeyDown(KeyCode.A))
            {
                SceneManager.LoadScene("Gameplay");
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

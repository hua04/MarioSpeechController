using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public AudioCheck audioCheck;

    public string nextScene;
    public string otherScene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (audioCheck == null)
        {
            audioCheck = GameObject.Find("Arduino").GetComponent<AudioCheck>();
        }
        if (audioCheck.yellow == true && nextScene != "None")
        {
            SceneChange(nextScene);
        }
        if (audioCheck.red == true && otherScene!= "None")
        {
            SceneChange(otherScene);
        }
    }

    public void SceneChange(string sceneName) 
    {
        if (sceneName == "Start")
        {
            Destroy(GameObject.Find("Arduino"));
        }
        SceneManager.LoadScene(sceneName);
        
    }
}

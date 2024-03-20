using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextScene;
    public string otherScene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && nextScene != "None")
        {
            SceneChange(nextScene);
        }
        if (Input.GetKeyDown(KeyCode.S)&& otherScene!= "None")
        {
            SceneChange(otherScene);
        }
    }

    public void SceneChange(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }
}

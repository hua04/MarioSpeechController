using TMPro;
using UnityEngine;

public class ScoreAssignment : MonoBehaviour
{
    public TMP_Text scoreText1;
    public TMP_Text scoreText2;

    public Score scoreScript;
    // Start is called before the first frame update
    void Start()
    {
        scoreScript = GameObject.Find("Score").GetComponent<Score>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText1.text = "Goomba Approval: " + scoreScript.g + "%\r\nCheepCheep Approval: " + scoreScript.b + "%\r\nToad Approval: " + scoreScript.y + "%\r\nKoopa Approval: " + scoreScript.b + "%";
        scoreText2.text = "Goomba Approval: " + scoreScript.g + "%\r\nCheepCheep Approval: " + scoreScript.b + "%\r\nToad Approval: " + scoreScript.y + "%\r\nKoopa Approval: " + scoreScript.b + "%";

    }
}

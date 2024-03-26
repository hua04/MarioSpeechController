using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteSpawner spriteSpawner;
    public int y;
    public int r;
    public int g;
    public int b;

    void Start()
    {
        DontDestroyOnLoad(this);
        if (SceneManager.GetActiveScene().name == "Win")
        {
            y = spriteSpawner.Yscore;
            r = spriteSpawner.Rscore;
            g = spriteSpawner.Gscore;
            b = spriteSpawner.Bscore;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            y = spriteSpawner.Yscore;
            r = spriteSpawner.Rscore;
            g = spriteSpawner.Gscore;
            b = spriteSpawner.Bscore;

        }

        if (SceneManager.GetActiveScene().name == "Start")
        {
            Destroy(gameObject);
        }

    }
}

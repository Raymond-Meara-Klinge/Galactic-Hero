using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    int lives = 3;

    [SerializeField]
    int scored;

    [SerializeField]
    TextMeshProUGUI living;

    [SerializeField]
    TextMeshProUGUI score;

    [SerializeField]
    TextMeshProUGUI starlings;

    public int starNum;

    Shot shot;

    void Awake()
    {
        starNum = GameObject.FindGameObjectsWithTag("Starling").Length;
        shot = FindObjectOfType<Shot>();
        int numSesh = FindObjectsOfType<GameSession>().Length;
        if (numSesh > 1)
        {
            Destroy (gameObject);
        }
        else
        {
            DontDestroyOnLoad (gameObject);
        }
    }

    void Start()
    {
        living.text = lives.ToString("Lives  0");
        score.text = scored.ToString("Score  00000000");
        starlings.text = starNum.ToString("Starlings Remaining  00");
    }

    public void Scoring(int addedPoints)
    {
        scored += addedPoints;
        score.text = scored.ToString("Score  00000000");
    }

    public void Stars()
    {
        GetStarNum();
        starlings.text = starNum.ToString("Starlings Remaining  00");
    }

    int GetStarNum()
    {
        return starNum;
    }

    public void PlayDeaths()
    {
        if (lives > 0)
        {
            Kill();
        }
        else if (lives <= 0)
        {
            Restart();
        }
    }

    public void Kill()
    {
        lives--;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene (currentScene);
        living.text = lives.ToString();
    }

    void Restart()
    {
        FindObjectOfType<ScenePersist>().ResetPersist();
        SceneManager.LoadScene(0);
        Destroy (gameObject);
    }
}

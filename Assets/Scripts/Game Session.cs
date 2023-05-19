using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    int lives = 3;

    [SerializeField]
    public float playHP = 75f;

    [SerializeField]
    int scored;

    [SerializeField]
    TextMeshProUGUI living;

    [SerializeField]
    TextMeshProUGUI score;

    [SerializeField]
    TextMeshProUGUI starlings;

    [SerializeField]
    Slider hpSlider;

    PlayerMove playa;

    LevelManager lvlMan;

    public int starNum;

    Shot shot;

    void Awake()
    {
        starNum = GameObject.FindGameObjectsWithTag("Starling").Length + GameObject.FindGameObjectsWithTag("Boss").Length;
        shot = GetComponent<Shot>();
        int numSesh = FindObjectsOfType<GameSession>().Length;
        lvlMan = FindObjectOfType<LevelManager>();
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
        PlayerPrefs
            .SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        living.text = lives.ToString("Lives  0");
        score.text = scored.ToString("Score  00000000");
        starlings.text = starNum.ToString("Starlings Remaining  00");
        if (lvlMan.sceneNum == 6)
        {
            hpSlider.maxValue = GetHP();
        }
    }

    void Update()
    {
        GetStarNum();
        starlings.text = starNum.ToString("Starlings Remaining  00");
        if (lvlMan.sceneNum == 6)
        {
            hpSlider.value = GetHP();
        }
    }

    public void Scoring(int addedPoints)
    {
        scored += addedPoints;
        score.text = scored.ToString("Score  00000000");
    }

    private float GetHP()
    {
        return playHP;
    }

    int GetStarNum()
    {
        return starNum;
    }

    public void PlayDeaths()
    {
        if (lives > 1)
        {
            Kill();
        }
        else if (lives <= 1)
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
        SceneManager.LoadScene(2);
        Destroy (gameObject);
    }
}

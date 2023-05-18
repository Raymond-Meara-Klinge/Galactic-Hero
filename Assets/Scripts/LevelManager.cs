using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    float waitLoad = 1f;

    private List<int> sceneHistory = new List<int>();

    GameSession session;

    int sceneNum;

    void Start()
    {
        session = FindObjectOfType<GameSession>();
        DontDestroyOnLoad(this.gameObject);
        sceneHistory.Add(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update() {
        sceneNum = GetScene();
        UpdateScene(sceneNum);
    }

    public void LoadMenu()
    {
        LoadScene(0);
    }

    public void LoadSelect()
    {
        LoadScene(1);
    }

    public void LoadGO()
    {
        StartCoroutine(WaitLoad(2, waitLoad));
    }

    public void LoadOV()
    {
        LoadScene(3);
    }

    public void Load1()
    {
        LoadScene(4);
    }

    public void Load2()
    {
        LoadScene(5);
    }

    public void Load3()
    {
        LoadScene(6);
    }


    public void LoadVictory()
    {
        LoadScene(7);
    }

    public void LoadPrev()
    {
        Debug.Log(PlayerPrefs.GetInt("SavedScene"));
        LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }

    void UpdateScene(int scene)
    {
        if (scene >= 4 && scene < 6 && session.starNum <= 0)
        {
            LoadScene(sceneHistory[0]);
        }
        else 
        {
            return;
        }
    }

    void LoadScene(int scene)
    {
        sceneHistory.Add (scene);
        SceneManager.LoadScene (scene);
    }

    int GetScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void Quit()
    {
        Debug.Log("WTF Man?");
        Application.Quit();
    }

    IEnumerator WaitLoad(int scene, float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadScene (scene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    float waitLoad = 1f;

    private List<int> sceneHistory = new List<int>();

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        sceneHistory.Add(SceneManager.GetActiveScene().buildIndex);
    }

    public void Load1()
    {
        LoadScene(3);
    }

    public void Load2()
    {
        LoadScene(4);
    }

    // public void Load3()
    // {
    //     LoadScene("Level 3");
    // }
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

    public void LoadVictory()
    {
        LoadScene(5);
    }

    public void LoadPrev()
    {
        Debug.Log(PlayerPrefs.GetInt("SavedScene"));
        LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }

    void LoadScene(int scene)
    {
        sceneHistory.Add (scene);
        SceneManager.LoadScene (scene);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    float waitLoad = 1f;

    public void Load1()
    {
        LoadScene("Level 1");
    }
    public void Load2()
    {
        LoadScene("Level 2");
    }
    public void Load3()
    {
        LoadScene("Level 3");
    }

    public void LoadMenu()
    {
        LoadScene("Main Menu");
    }

    public void LoadSelect()
    {
        LoadScene("Select");
    }

    public void LoadGO()
    {
        StartCoroutine(WaitLoad("Game Over", waitLoad));
    }

    public void LoadVictory()
    {
        LoadScene("Victory");
    }

    void LoadScene(string scene)
    {
        SceneManager.LoadScene (scene);
    }

    public void Quit()
    {
        Debug.Log("WTF Man?");
        Application.Quit();
    }

    IEnumerator WaitLoad(string scene, float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadScene (scene);
    }
}

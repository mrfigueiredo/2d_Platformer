using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Load(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void Load(string s)
    {
        SceneManager.LoadScene(s);
    }
    public void LoadAsync(int i)
    {
        SceneManager.LoadSceneAsync(i);
    }

    public void LoadAsync(string s)
    {
        SceneManager.LoadSceneAsync(s);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

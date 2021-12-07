using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static string PreviousScene;

    public static void LoadScene(string name)
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }

    public void LoadPrevious()
    {
        print(PreviousScene);
        SceneManager.LoadScene(PreviousScene);
    }
}

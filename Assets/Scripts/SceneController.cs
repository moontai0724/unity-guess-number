using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static string[] scenes = new string[] { "Menu_1", "Menu_2", "E2P", "End_Good", "End_Bad" };
    private static int sceneIndex = 0;
    void Start()
    {
        SceneManager.LoadSceneAsync(scenes[sceneIndex], LoadSceneMode.Additive);
    }

    void Update()
    {
        if (Input.anyKeyDown && sceneIndex < 2)
            nextScene();
        else if (Input.GetKeyDown(KeyCode.R) && sceneIndex > 2)
            resetScene();
    }

    public static void nextScene(int sceneAmount = 0)
    {
        // Go to the next scene.
        SceneManager.UnloadSceneAsync(scenes[sceneIndex]);
        if (sceneIndex < scenes.Length)
        {
            sceneIndex += sceneAmount;
            SceneManager.LoadScene(scenes[++sceneIndex], LoadSceneMode.Additive);
        }
    }

    private void resetScene()
    {
        SceneManager.UnloadSceneAsync(scenes[sceneIndex]);
        sceneIndex = 0;
        SceneManager.LoadScene(scenes[sceneIndex], LoadSceneMode.Additive);
    }
}

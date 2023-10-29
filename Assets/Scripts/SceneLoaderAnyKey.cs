using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderAnyKey : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    [SerializeField]
    float delay;

    float elapsed = 0;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        elapsed += Time.deltaTime;
        if (Input.anyKeyDown && !Input.GetButtonDown("Quit") && !Input.GetButtonDown("Screenshot") && elapsed >= delay)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}

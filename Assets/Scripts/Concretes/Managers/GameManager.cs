using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void LoadNextSceneWithID(int nextSceneId)
    {
        SceneManager.LoadScene(nextSceneId); //loads next scene by given buildIndex value...
    }
    
    public void LoadNextSceneWithAutomatic()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads next scene automaticly... maybe we can use
    }
}

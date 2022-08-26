using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorMenu : MonoBehaviour
{
    public GameObject audioManager;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("menu");

    }
    public void Sair()
    {
        Application.Quit();
    }

    public void ProximaScena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        DontDestroyOnLoad(audioManager);
    }
}

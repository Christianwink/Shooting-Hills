using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GerenciadorScrip : MonoBehaviour
{
    public float pontacao;
    public TMP_Text texto;

    private void Update()
    {
        int pontuUi = Mathf.RoundToInt(pontacao);
        texto.text = "Pontuação " + pontuUi;
    }
    public void Sair()
    {
        Application.Quit();
    }
    public void Voltar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

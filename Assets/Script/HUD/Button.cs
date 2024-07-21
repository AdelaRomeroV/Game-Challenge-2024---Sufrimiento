using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject video;
    [SerializeField] private GameObject panelPausa;

    public void Reiniciar()
    {
        SceneManager.LoadScene("Minigame");
        Time.timeScale = 1.0f;
    }
    public void VerPublicidad()
    {
        video.SetActive(true);
    }
    public void Menu()
    {
        Time.timeScale = 0f;
        panelPausa.SetActive(true);
    }
    public void Continuar()
    {
        Time.timeScale = 1f;
        panelPausa.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}

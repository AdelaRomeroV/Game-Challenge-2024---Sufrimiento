using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject video;
    [SerializeField] private GameObject panelPausa;
    [SerializeField] private Mov player;
    [SerializeField] private AudioSource music;

    private void Awake()
    {
        player = FindAnyObjectByType<Mov>();
    }

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
        player.pause = true;
        panelPausa.SetActive(true);
    }
    public void Continuar()
    {
        Time.timeScale = 1f;
        player.pause = false;
        panelPausa.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void AlternarMute()
    {
        if (music.mute == true) music.mute = false;
        else music.mute = true;
    }
}

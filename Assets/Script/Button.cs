using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject video;

    public void Reiniciar()
    {
        SceneManager.LoadScene("Minigame");
        Time.timeScale = 1.0f;
    }
    public void VerPublicidad()
    {
        video.SetActive(true);
    }
}

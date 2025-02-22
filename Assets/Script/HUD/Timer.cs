using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public int timer = 5;
    [SerializeField] GameObject panelText;
    [SerializeField] GameObject player;
    [SerializeField] GameObject panelRevive;
    [SerializeField] GameObject nam;
    private void OnEnable()
    {
        txt = GetComponent<TextMeshProUGUI>();
        Time.timeScale = 1f;
        StartCoroutine(Cronometro());
    }
    IEnumerator Cronometro()
    {
        while (timer >= 0)
        {
            txt.text = timer.ToString();

            yield return new WaitForSeconds(1f);
            timer--;
        }
        if (timer <= 0)
        {
            timer = 5;
            txt.text = timer.ToString();
            panelText.SetActive(false);
            nam.SetActive(true);
            player.SetActive(true);
            panelRevive.SetActive(false);
        }

    }
}

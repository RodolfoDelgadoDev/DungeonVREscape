using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] float startTime = 5f;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] AudioSource audioTimer;

    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Timer()
    {
        timer = startTime;

        do
        {
            timer -= Time.deltaTime;
            slider.value = timer / startTime;
            FormatText();
            if(slider.value == 0.4f)
            {
                audioTimer.Play();
            }
            yield return null;
        }
        while (timer > 0);
        if (slider.value == 0)
            SceneManager.LoadScene(0);
    }

    private void FormatText()
    {

        int seconds = (int)(timer);
        timerText.text = "";
        if (seconds > 0) { timerText.text += seconds; }
        if (seconds == (int)(startTime) / 2)
        {
            Color32 col = new Color(1.0f, 0.92f, 0.016f, 1.0f);
            timerText.color = col;
        }
        else if (seconds == (int)(startTime) / 4)
        {
            timerText.color = new Color32(222, 41, 22, 255);
        }
    }
}

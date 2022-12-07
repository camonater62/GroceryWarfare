using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public GameObject panel;
    public GameObject win;
    public GameObject lose;
    public float timeTrigger = 300.0f;


    private float totalTime = 0f;
    private bool displaying = false;

    public void Setup()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;

        totalTime = 0.0f;
        displaying = false;

        panel.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);

        Time.timeScale = 1;
    }

    public void Display(string status) {
        panel.SetActive(true);

        if (status == "win") {
            win.SetActive(true);
        }
        if (status == "lose") {
            lose.SetActive(true);
        }

        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        displaying = true;

        Time.timeScale = 0;
    }

    void Update() {
        if (!displaying) {
            totalTime += Time.deltaTime;

            if (totalTime >= timeTrigger) {
                Display("win");
            }
        }
    }
}

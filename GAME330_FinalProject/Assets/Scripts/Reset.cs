using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public GameObject tower;
    public Text timer;
    public Text timerWatch;
    public float startTime;
    public GameObject levelComplete;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        //startTime = 30;
    }

    // Update is called once per frame
    void Update()
    {
        float t = startTime - Time.time;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timer.text = minutes + ":" + seconds;
        timerWatch.text = minutes + ":" + seconds;

        if (t <= 0)
        {
            timer.text = "0:0";
            timerWatch.text = "0.0";
            levelComplete.SetActive(true);
            StartCoroutine(LoadNextLevel(3));
        }
    }

    private IEnumerator LoadNextLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        sceneNum++;
        SceneManager.LoadScene(sceneNum);

    }
}

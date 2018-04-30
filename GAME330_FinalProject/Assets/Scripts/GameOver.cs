using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject tower;
    public GameObject explosion;
    public AudioSource audioSource;
    public AudioClip explode;

    // Use this for initialization
    void Start()
    {
        explosion.SetActive(true);
        audioSource.PlayOneShot(explode);
        //Destroy(tower);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetButton("Fire2"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private IEnumerator FreezeTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0;
    }

}

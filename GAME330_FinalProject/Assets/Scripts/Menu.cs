﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject menu;
    public GameObject controls;
    public GameObject title;
    public GameObject rules;
    public Animator simonXAnimator;
    public AnimationClip simonX;
    public bool menuIsActive;
    public AudioSource audioSource;
    public AudioClip button;

    // Use this for initialization
    void Start () {
        menuIsActive = false;
        StartCoroutine(SetMenuActive(7));   //(simonX.length));
        //Controls.color = TextColor;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButton("Fire3") && menuIsActive)
        {
            controls.SetActive(true);
            title.SetActive(false);
            rules.SetActive(false);
            audioSource.PlayOneShot(button);
        }
        else if (Input.GetButton("Jump") && menuIsActive)
        {
            controls.SetActive(false);
            title.SetActive(false);
            rules.SetActive(true);
            audioSource.PlayOneShot(button);
        }
        else if (Input.GetButton("Fire2") && menuIsActive)
        {
            Application.Quit();
            audioSource.PlayOneShot(button);
        }
        else if (Input.GetButton("Fire1") && menuIsActive)
        {
            SceneManager.LoadScene("SimonXTestbed");
            audioSource.PlayOneShot(button);
        }
        else if (menuIsActive)
        {

        }
    }

    private IEnumerator SetMenuActive(float time)
    {
        yield return new WaitForSeconds(time);

        menu.SetActive(true);
        title.SetActive(true);
        menuIsActive = true;
    }

}

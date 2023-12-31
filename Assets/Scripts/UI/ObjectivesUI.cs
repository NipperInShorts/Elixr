using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;


public class ObjectivesUI : MonoBehaviour
{
    [SerializeField] public TMP_Text npcObjective;
    [SerializeField] public TMP_Text cratesObjective;
    [SerializeField] public TMP_Text squeezeToTalk;
    [SerializeField] public TMP_Text toggleSails;

    public UnityEvent onFinishCrates;

    private bool hasCompletedNpcObjective;
    private float cratesTotal;
    private float cratesTossed = 0;
    private bool showSqueezeToTalk = true;

    private void Awake()
    {
        cratesTotal = GameObject.FindGameObjectsWithTag("Crate").Length;
        cratesObjective.text = $"Crates Tossed: {cratesTossed}/{cratesTotal}";
        cratesObjective.gameObject.SetActive(false);
        squeezeToTalk.gameObject.SetActive(false);
        toggleSails.gameObject.SetActive(false);
    }

    // Arguably shouldn't be in here
    // Should have an event that updates crates
    // and the UI subscribes to applicable events 
    public void UpdateCratesTossed() {
        if (cratesTossed < cratesTotal) {
            cratesTossed += 1;
        }
        


        cratesObjective.text = $"Crates Tossed: {cratesTossed}/{cratesTotal}";
        if (cratesTossed >= cratesTotal)
        {
            cratesObjective.gameObject.SetActive(false);
            onFinishCrates?.Invoke();
            Loader.Load(Loader.Scene.MainMenu);
        }
    }

    public void CompleteNpcObjective() {
        showSqueezeToTalk = false;
        HideSqueezeToTalk();
        npcObjective.gameObject.SetActive(false);
        cratesObjective.gameObject.SetActive(true);
    }

    public void ShowSqueezeToTalk() {
        if (showSqueezeToTalk)
        {
            squeezeToTalk.gameObject.SetActive(true);
        }
    }

    public void HideSqueezeToTalk()
    {
        squeezeToTalk.gameObject.SetActive(false);
    }

    public void ShowActivateSails()
    {
        toggleSails.gameObject.SetActive(true);    
    }

    public void HideActivateSails()
    {
        toggleSails.gameObject.SetActive(false);
    }
}

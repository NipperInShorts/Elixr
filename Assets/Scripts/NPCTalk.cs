using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCTalk : MonoBehaviour
{

    private AudioSource m_narration;
    public UnityEvent onTalkStart;
    public UnityEvent onTalkEnd;

    private bool hasStarted = false;
    private bool isPlaying = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        m_narration = GetComponent<AudioSource>();
    }

    private void Update() {
    isPlaying = m_narration.isPlaying;
        if (hasStarted)
        {
            if (!isPlaying)
            {
                EndTalkAnimation();
            }
        }
    }


    public void StartTalkAnimation() {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("startNarration", true);
        if (!hasStarted) {
            m_narration.Play();
            hasStarted = true;
            onTalkStart?.Invoke();
        }
    }


    public void EndTalkAnimation()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("startNarration", false);
        onTalkEnd?.Invoke();        
    }
}

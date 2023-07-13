using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailsActivation : MonoBehaviour
{

    GameObject[] fullSails;
    GameObject[] rolledSails;

    bool m_showFullSails = false;

    // Start is called before the first frame update
    void Awake()
    {
        fullSails = GameObject.FindGameObjectsWithTag("FullSails");
        rolledSails = GameObject.FindGameObjectsWithTag("RolledSails");
        SetSails();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSails() {
        m_showFullSails = !m_showFullSails;

        SetSails();
    }

    private void SetSails() {
        if (m_showFullSails)
        {
            for (int index = 0; index < fullSails.Length; index++)
            {
                fullSails[index].SetActive(true);
            }
            for (int index = 0; index < rolledSails.Length; index++)
            {
                rolledSails[index].SetActive(false);
            }
        }
        else
        {
            for (int index = 0; index < fullSails.Length; index++)
            {
                fullSails[index].SetActive(false);
            }
            for (int index = 0; index < rolledSails.Length; index++)
            {
                rolledSails[index].SetActive(true);
            }
        }
    }

}

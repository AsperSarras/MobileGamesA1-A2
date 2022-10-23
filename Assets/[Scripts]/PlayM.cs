/*
 * PlayM
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Plays BackgroundMusic and touch sound for Start and End Scnenes
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayM : MonoBehaviour
{
    public AudioSource m_Clip;
    public AudioSource m_Click;
    // Start is called before the first frame update
    void Start()
    {
        m_Clip.Play();
    }

    void Update()
    {
        foreach (var touch in Input.touches)
        {
            m_Click.Play();
        }
    }

}

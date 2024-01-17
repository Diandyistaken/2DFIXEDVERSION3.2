using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip dashS; 
    [SerializeField] private AudioClip footStepS; 
    [SerializeField] private AudioClip swingS; 
    [SerializeField] private AudioClip arrowS; 
    [SerializeField] private AudioClip staffS; 
    [SerializeField] private AudioClip deathS; 

   

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }


    public void DashS()
    {
        audioSource.PlayOneShot(dashS);
    }
    
    public void FootStepsS()
    {
        audioSource.PlayOneShot(footStepS);
    }

    public void SwingS()
    {
        audioSource.PlayOneShot(swingS);
    }

    public void ArrowS()
    {
        audioSource.PlayOneShot(arrowS);
    }

    public void StaffS()
    {
        audioSource.PlayOneShot(staffS);
    }

    public void DeathS()
    {
        audioSource.PlayOneShot(deathS);
    }
}


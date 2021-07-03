using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLetter : MonoBehaviour
{

    public GameObject LetterBlocker;
    public AudioSource SoundTrue;
    public AudioSource SoundFalse;

    void OnTriggerEnter(Collider other){
        if(gameObject.CompareTag("CubeTrue")){
            ScoringSystem.theScore += 50;
            SoundTrue.Play();
            Destroy(gameObject);
            LetterBlocker.SetActive(false);
        }else if(gameObject.CompareTag("CubeFalse")){
            SoundFalse.Play();
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [Header("�ȴ� �Ҹ� ����")]
    [SerializeField]
    private List<AudioClip> walkAudio;

    private AudioSource walkAudioSource;

    private void Awake()
    {
        walkAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) return;        
        
        if (other.transform.CompareTag("Desert"))
        {
            walkAudioSource.clip = walkAudio[0];
        }
        else if (other.transform.CompareTag("StoneRoad"))
        {
            walkAudioSource.clip = walkAudio[1];
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Turret"))
        {
            walkAudioSource.clip = walkAudio[2];
        }

        walkAudioSource.Play();
    }
}

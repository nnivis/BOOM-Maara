using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOOM
{
    public class SoundComponent : MonoBehaviour
    {
        [SerializeField] AudioClip _sound;
        AudioSource _audioSource;

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound()
        {
            _audioSource.PlayOneShot(_sound);
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMeneger1 : SignalMeneger
{
    [SerializeField] private AudioSource _audioForCutScene1;
    public override void SoundMenegerPlay(AudioSource audio)
    {
        audio.Play();
    }

    public override void SoundMenegerStop(AudioSource audio)
    {
        audio = _audioForCutScene1;
        audio.Stop();
    }
}

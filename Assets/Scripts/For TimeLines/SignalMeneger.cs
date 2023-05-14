using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SignalMeneger : MonoBehaviour
{
    public abstract void SoundMenegerPlay(AudioSource audio);

    public abstract void SoundMenegerStop(AudioSource audio);
}

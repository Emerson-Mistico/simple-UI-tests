using Screens;
using UnityEngine;

public class ButtonPlay : MonoBehaviour
{

    public ParticleSystem particleToPlay;
    public void OnClick()
    {
        particleToPlay.Play();
    }
}

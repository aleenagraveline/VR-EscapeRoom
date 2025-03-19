using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public class PlaySoundOnGrab : MonoBehaviour
{
    [SerializeField] private XRRayInteractor ray;
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable firstCube;
    [SerializeField] private AudioSource clangingNoise;

    private bool soundHasNotPlayed = true;

    public void PlaySound()
    {
        if(ray.interactablesSelected[0] == firstCube && soundHasNotPlayed)
        {
            clangingNoise.Play();
            soundHasNotPlayed = false;
        }   
    }
}

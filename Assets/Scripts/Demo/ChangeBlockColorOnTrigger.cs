using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ChangeBlockColorOnTrigger : MonoBehaviour
{
    public Color colorToSet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            other.gameObject.GetComponent<MeshRenderer>().material.color = colorToSet;
            other.gameObject.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask("Red");
        }
    }

}

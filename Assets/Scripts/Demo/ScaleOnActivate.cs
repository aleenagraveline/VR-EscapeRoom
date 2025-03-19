using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ScaleOnActivate : MonoBehaviour
{
    public GameObject block;
    XRGrabInteractable interactable;

    private void OnEnable()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.activated.AddListener(OnActivate);
        interactable.deactivated.AddListener(OnDeactivate);
    }

    private void OnDisable()
    {
        interactable.activated.RemoveListener(OnActivate);
        interactable.deactivated.RemoveListener(OnDeactivate);
    }

    public void OnActivate(ActivateEventArgs args)
    {
        Debug.Log("OnActivate");
        block.transform.localScale = new Vector3(2f, 2f, 2f);
    }

    public void OnDeactivate(DeactivateEventArgs args)
    {
        Debug.Log("OnDeactivate");
        block.transform.localScale = new Vector3(1f, 1f, 1f);
    }


}

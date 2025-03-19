using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeOnActivate : MonoBehaviour
{
    public GameObject block;
    XRGrabInteractable interactable;

    Color defaultColor;
    Vector3 defaultSize;
    Material material;

    private void OnEnable()
    {
        material = block.GetComponent<MeshRenderer>().material;        
        interactable = GetComponent<XRGrabInteractable>();

        defaultColor = material.color;
        defaultSize = block.transform.localScale;

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
        material.color = Color.green;

        // note that scaling ONLY works if it's you are altering the scale
        // of a transform that's NOT on the Grab Interactable like Scaleable Red Block

        // that transform is being overwritten as you move
        // see inspector position update as you grab
        block.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    public void OnDeactivate(DeactivateEventArgs args)
    {
        Debug.Log("OnDeactivate");
        material.color = defaultColor;
        block.transform.localScale = defaultSize;
    }


}

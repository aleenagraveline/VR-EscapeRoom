using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeInSocket : MonoBehaviour
{
    XRSocketInteractor socketInteractor;
    Color defaultColor;

    private void OnEnable()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.selectEntered.AddListener(ObjectAttachedEvent);
        socketInteractor.selectExited.AddListener(ObjectDetachedEvent);
    }
    private void OnDisable()
    {
        socketInteractor.selectEntered.RemoveListener(ObjectAttachedEvent);
        socketInteractor.selectExited.RemoveListener(ObjectDetachedEvent);
    }
    public void ObjectAttachedEvent(SelectEnterEventArgs args)
    {
        Material materialOfObject = args.interactableObject.transform.GetComponent<MeshRenderer>().material;
        defaultColor = materialOfObject.color;

        materialOfObject.color = Color.white;
    }
    public void ObjectDetachedEvent(SelectExitEventArgs args)
    {
        Material materialOfObject = args.interactableObject.transform.GetComponent<MeshRenderer>().material;

        materialOfObject.color = defaultColor;
    }

}

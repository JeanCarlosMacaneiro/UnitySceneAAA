using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class InteractableArea : MonoBehaviour {

    [SerializeField]
    private ActionSteps actionsOnTriggerEnter;
    [SerializeField]
    private ActionSteps actionsOnTriggerExit;
    [SerializeField]
    private ActionSteps actionsInteraction;
    [SerializeField]
    private bool interactOnce;
    private bool AlreadyInteracting;
    private CanvasController canvasController;

    private void Start()
    {
        canvasController = GameObject.FindGameObjectWithTag(Constants.TagObjectName.CanvasController.ToString()).GetComponent<CanvasController>();

        if (interactOnce)
        {
            AlreadyInteracting = false;
        }
    }

    private void OnDisable()
    {
        canvasController.DisableTextInterationKey();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals(Constants.TagObjectName.Player.ToString()))
        {
            canvasController.EnableTextInterationKey();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!AlreadyInteracting)
            {
                actionsInteraction.StartActionSteps(gameObject);
                AlreadyInteracting = true;
            }
            else if (!interactOnce)
            {
                actionsInteraction.StartActionSteps(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvasController.DisableTextInterationKey();
    }

    
}

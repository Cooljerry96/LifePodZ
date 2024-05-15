using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class HighlightedObjectRotator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float torqueStrength = 50f;
    private Rigidbody rb;
    private bool isHighlighted = false;
    private Quaternion initialRotation;
    private RectTransform rect;

    void Start()
    {
        // Get the Rigidbody component attached to the object
        rb = GetComponent<Rigidbody>();
        rect = GetComponent<RectTransform>();
        initialRotation = GetComponent<RectTransform>().rotation;
    }

    void FixedUpdate()
    {
        // Rotate the object if it is highlighted
        if (isHighlighted)
        {
            // Apply torque to rotate the object around its local up axis
            rb.AddTorque(transform.forward * torqueStrength * Time.deltaTime);
        }

        if (rect.rotation == initialRotation && isHighlighted == false)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    // Called when the pointer enters the UI element
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHighlighted = true;
    }

    // Called when the pointer exits the UI element
    public void OnPointerExit(PointerEventData eventData)
    {
        isHighlighted = false;
    }

   
}

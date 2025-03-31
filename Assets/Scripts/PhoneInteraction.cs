using UnityEngine;

public class PhoneInteraction : MonoBehaviour
{
    public Transform phone;
    public Transform phoneViewPosition;
    public Transform phoneHiddenPosition;
    public float moveSpeed = 5f;  // Adjust to change speed of movement
    private bool isPhoneOut = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  
        {
            isPhoneOut = !isPhoneOut;
        }

        Transform targetPosition = isPhoneOut ? phoneViewPosition : phoneHiddenPosition;

        phone.localPosition = Vector3.Lerp(phone.localPosition, targetPosition.localPosition, Time.deltaTime * moveSpeed);
        phone.localRotation = Quaternion.Lerp(phone.localRotation, targetPosition.localRotation, Time.deltaTime * moveSpeed);

    }
}
using UnityEngine;
using System.Collections;

public class PhoneInteraction : MonoBehaviour
{
    public Transform phone;
    public Transform phoneViewPosition;
    public Transform phoneHiddenPosition;
    public GameObject phoneUI; 
    public float moveSpeed = 5f;
    public float turnOnDelay = 1.5f;
    private bool isPhoneOut = false;

    void Start()
    {
        phoneUI.SetActive(false); // Ensure UI starts hidden
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  
        {
            isPhoneOut = !isPhoneOut;
            Debug.Log("P was pressed! Phone Out: " + isPhoneOut);
            
            if (isPhoneOut)
            {
                StartCoroutine(EnablePhoneUIWithDelay(0.5f)); // Enable UI with delay
            }
        }

        // Move the phone smoothly between positions
        Transform targetPosition = isPhoneOut ? phoneViewPosition : phoneHiddenPosition;
        phone.localPosition = Vector3.Lerp(phone.localPosition, targetPosition.localPosition, Time.deltaTime * moveSpeed);
        phone.localRotation = Quaternion.Lerp(phone.localRotation, targetPosition.localRotation, Time.deltaTime * moveSpeed);

        // Disable UI when phone is fully hidden
        if (!isPhoneOut && Vector3.Distance(phone.localPosition, phoneHiddenPosition.localPosition) < turnOnDelay)
        {
            phoneUI.SetActive(false);
        }
    }
    
    IEnumerator EnablePhoneUIWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        phoneUI.SetActive(true);
    }
}
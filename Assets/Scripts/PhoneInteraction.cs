using UnityEngine;
using System.Collections;

public class PhoneInteraction : MonoBehaviour
{
    public Transform phone;
    public Transform phoneViewPosition;
    public Transform phoneHiddenPosition;
    public GameObject phoneUI; 
    public CharacterController playerController;
    public Transform playerCamera;
    public MonoBehaviour cameraController;
    
    public float moveSpeed = 5f;
    public float turnOnDelay = 1.5f;
    public float phoneDistance = 0.4f;
    
    private bool isPhoneOut = false;

    void Start()
    {
        phoneUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        
        // Adjust phoneViewPosition to match player's camera view
        phoneViewPosition.position = playerCamera.position + playerCamera.forward * phoneDistance;
        phoneViewPosition.rotation = playerCamera.rotation * Quaternion.Euler(0, -90, 0);

        
        if (Input.GetKeyDown(KeyCode.E))  
        {
            isPhoneOut = !isPhoneOut;
            
            if (isPhoneOut)
            {
                StartCoroutine(EnablePhoneUIWithDelay(0.5f));
                PausePlayerMovement(true);
                PauseCameraRotation(true);
            }
            else
            {
                phoneUI.SetActive(false);
                PausePlayerMovement(false);
                PauseCameraRotation(false);
            }
        }

        // Move the phone smoothly between positions
        Transform targetPosition = isPhoneOut ? phoneViewPosition : phoneHiddenPosition;
        phone.position = Vector3.Lerp(phone.position, targetPosition.position, Time.deltaTime * moveSpeed);
        phone.rotation = Quaternion.Lerp(phone.rotation, targetPosition.rotation, Time.deltaTime * moveSpeed);

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
    
    void PausePlayerMovement(bool isPaused)
    {
        if (playerController != null)
        {
            playerController.enabled = !isPaused;
        }
        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
    }
    
    void PauseCameraRotation(bool isPaused)
    {
        if (cameraController != null)
        {
            cameraController.enabled = !isPaused;
        }
    }
}
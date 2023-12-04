using UnityEngine;
using UnityEngine.UIElements;

public class ForceShieldController : MonoBehaviour
{
    public GameObject forceShield;
    public bool isShieldOn = false;
    public Rigidbody2D playerRigidbody;
    public float pushbackForce = 10f;
    public Transform playerTransform;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            
            ActivateShield();   

        }

        if (Input.GetMouseButtonUp(1))
        {
           DeactiveShield();
        }

        if (isShieldOn)
        {
            UpdateShieldPosition();
        }
    }

    void ActivateShield()
    {
        if (!isShieldOn)
        {
            forceShield.SetActive(true);
            isShieldOn = true;
            ApplyPushback();
            Debug.Log("Shield Activated");

        }
    }


    void DeactiveShield()
    {

        if (isShieldOn)
        {
            forceShield.SetActive(false);
            isShieldOn = false;
            Debug.Log("Shield Deactivated");

        }
    }
    void ApplyPushback()
    {
        if (playerRigidbody != null)
        {
            // Adjust the direction and magnitude of the pushback as needed
            playerRigidbody.AddForce(-transform.forward * pushbackForce, ForceMode2D.Impulse);
        }
    }

    public bool IsShieldActive
    {
        get { return isShieldOn; }
    }

    void UpdateShieldPosition()
    {
        if (playerTransform != null)
        {
            forceShield.transform.position = playerTransform.position;
          
        }
    }

}
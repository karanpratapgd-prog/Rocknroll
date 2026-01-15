using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public TMP_Text countText;
    public TMP_Text winText;

    public float speed = 10.0f;
    private Rigidbody rb;
    private int count;

    private float movementX;
    private float movementY;
    void Start()
    {
        count = 0;
        SetCountText();
        rb = GetComponent<Rigidbody>();
        winText.gameObject.SetActive(false);   
    }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;  
            SetCountText ();
        }
    }

    void SetCountText()
    {
        countText.text = "Count :" + count.ToString();
        if (count >= 12)
        {
            winText.gameObject.SetActive(true);
        }
    }
}

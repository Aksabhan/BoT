using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class AvatarBase : MonoBehaviour
{
    public Stats stats;

    public float speed = 10f;

    private Vector2 moveInput;
    private Vector2 cryDirection;
    private Rigidbody2D rb2d;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Yup");
        //ToDo: Check If I do have a key!
        if (other.TryGetComponent<IUnlockable>(out IUnlockable unlockable)) {
            unlockable.Unlock();
        }
        /* IUnlockable unlockable2 = null;
         if (other.TryGetComponent<IUnlockable>(out unlockable2)) {
             unlockable.Unlock();
         }*/

        if (other.TryGetComponent<IPickable>(out IPickable pickable)) {
            SO_Pickup temp =  pickable.PickItUp();
        }


    }

    public void Move(InputAction.CallbackContext context) {
        moveInput = context.ReadValue<Vector2>();
       rb2d.linearVelocity = speed * moveInput;
        //rb2d.AddRelativeForce(moveInput*speed*10f);
    }

    public void Cry(InputAction.CallbackContext context) {
        cryDirection = context.ReadValue<Vector2>();
        Debug.Log(moveInput);
    }
}

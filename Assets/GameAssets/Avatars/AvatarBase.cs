using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class AvatarBase : MonoBehaviour
{
    public SO_Stats stats;

    public float speed = 10f;
    //NEW!!!
    public List<SO_Pickup> pickupList = new List<SO_Pickup>();
    private Dictionary<SO_Pickup, int> pickupInventory = new Dictionary<SO_Pickup, int>();
    //END NEW
    private Vector2 moveInput;
    private Vector2 cryDirection;
    private Rigidbody2D rb2d;

   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        foreach(SO_Pickup p in pickupList) {
            pickupInventory.Add(p, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("Yup");
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
            AddPickupToInventory(temp);
            
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

    private void AddPickupToInventory(SO_Pickup pickup) {
        pickupInventory[pickup] += 1;
        Debug.Log(string.Format("The player now has {0} {1}",pickupInventory[pickup], pickup.name));
    }
}

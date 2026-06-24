using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class Pickup_Base : MonoBehaviour, IPickable {
    
    public SO_Pickup type;
    private SpriteRenderer sr;

    public void Start() {
        sr = GetComponent<SpriteRenderer> ();
        sr.sprite = type.visual;
    }

    public SO_Pickup PickItUp() {
        Destroy(this.gameObject);
        return type;
    }
}

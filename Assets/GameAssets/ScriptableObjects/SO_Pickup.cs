using UnityEngine;

[CreateAssetMenu(fileName = "SO_Pickup", menuName = "Scriptable Objects/SO_Pickup")]
public class SO_Pickup : ScriptableObject
{
    public Sprite visual;
    public SO_PickupType type;
}

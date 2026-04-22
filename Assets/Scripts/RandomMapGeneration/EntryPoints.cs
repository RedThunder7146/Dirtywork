using UnityEngine;

public class EntryPoints : MonoBehaviour
{
    private bool isOccupied = false;

    public void SetOccupied(bool value = true) => isOccupied = value;

    public bool IsOccupied() => isOccupied;
}

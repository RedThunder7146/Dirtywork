using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.VisionOS;
using UnityEngine;

public class HousePart : MonoBehaviour
{
    public enum HousePartType
    {
        Room,
        Hallway
    }

    [SerializeField]

    private LayerMask roomsLayerMask;

    [SerializeField]
    private HousePartType housePartType;

    [SerializeField]

    private GameObject fillerWall;

    public List<Transform> entrypoints;

    public new Collider collider;

    public bool HasAvaliableEntrypoint(out Transform entrypoint)
    {
        Transform resultingEntry = null;
        bool result = false;

        int totalRetries = 100;
        int retryIndex = 0;

        if (entrypoints.Count == 1)
        {
            Transform entry = entrypoints[0];
            if (entry.TryGetComponent<EntryPoints>(out EntryPoints res))
            {
                if (res.IsOccupied())
                {
                    result = false;
                    resultingEntry = null;
                }
                else
                {
                    result = true;
                    resultingEntry = entry;
                    res.SetOccupied();
                }
                entrypoint = resultingEntry;
                return result;
            }
        }

        while (resultingEntry == null && retryIndex < totalRetries)
        {
            int randomEntryIndex = Random.Range(0, entrypoints.Count);

            Transform entry = entrypoints[randomEntryIndex];
            
            if (entry.TryGetComponent<EntryPoints>(out EntryPoints entryPoint))
            {
                if (!entryPoint.IsOccupied())
                {
                    resultingEntry = entry;
                    result = true;
                    entryPoint.SetOccupied();
                    break;
                }
            }
            retryIndex++;
        }

        entrypoint = resultingEntry;

        return result;

        
    }

    public void UnuseEntrypoint(Transform entrypoint)
    {
        if (entrypoint.TryGetComponent<EntryPoints>(out EntryPoints entry))
        {
            entry.SetOccupied(false);
        }

    }

    public void FillEmptyDoors()
    {
        entrypoints.ForEach((entry) =>
        {
            if (entry.TryGetComponent(out EntryPoints entryPoint))
                if (!entryPoint.IsOccupied())
                {
                    GameObject wall = Instantiate(fillerWall);
                    wall.transform.position = entry.transform.position;
                    wall.transform.rotation = entry.transform.rotation;
                }
        });
            
    }


}

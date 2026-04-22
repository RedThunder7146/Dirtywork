using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class HouseGenerator : MonoBehaviour
{

    public static HouseGenerator Instance { get; private set; }

    [SerializeField]

    private GameObject enterance;

    [SerializeField]

    private List<GameObject> rooms;

    [SerializeField]

    private List<GameObject> hallways;

    [SerializeField]

    private List<GameObject> alternateEnterances;

    private GameObject door;

    [SerializeField]
    private int noOfRooms = 10;

    [SerializeField]

    private LayerMask roomsLayerMask;

    private List<HousePart>  generatedRooms;

    private bool isGenerated;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        generatedRooms = new List<HousePart>();
    }

    public void StartGeneration()
    {
        Generate();
        GenerateAlternateEntrances();
        FillEmptyEntrances();
        isGenerated = true;
    }

    private void Generate()
    {
        for (int i = 0; i < noOfRooms - alternateEnterances.Count; i++)
        {
            if (generatedRooms.Count < 1)
            {
                GameObject generatedRoom = Instantiate(enterance, transform.position, transform.rotation);

                generatedRoom.transform.SetParent(null);

                if (generatedRoom.TryGetComponent<HousePart>(out HousePart housePart))
                {
                    generatedRooms.Add(housePart);
                }
            }

            else
            {
                bool shouldPlaceHallway = Random.Range(0f, 1f) > 0.5f;
                HousePart randomGeneratedRoom = null;
                Transform room1EntryPoint = null;
                int totalRetries = 100;
                int retryIndex = 0;

                while (randomGeneratedRoom == null && retryIndex < totalRetries)
                {
                    int randomLinkRoomIndex = Random.Range(0, generatedRooms.Count);
                    HousePart roomToTest = generatedRooms[randomLinkRoomIndex];
                    if (roomToTest.HasAvaliableEntrypoint(out room1EntryPoint))
                    {
                        randomGeneratedRoom = roomToTest;
                        break;
                    }
                    retryIndex++;

                }

                GameObject doorToAlign = Instantiate(door, transform.position, transform.rotation);

                if (shouldPlaceHallway)
                {
                    int randomIndex = Random.Range(0, hallways.Count);
                    GameObject generatedHallway = Instantiate(hallways[randomIndex], transform.position, transform.rotation);
                    generatedHallway.transform.SetParent(null);
                    if (generatedHallway.TryGetComponent<HousePart>(out HousePart housePart))
                    {
                        if (housePart.HasAvaliableEntrypoint(out Transform room2Entrypoint))
                        {
                            generatedRooms.Add(housePart);
                            doorToAlign.transform.position = room1EntryPoint.transform.position;
                            doorToAlign.transform.rotation = room1EntryPoint.transform.rotation;
                            AlignRooms(randomGeneratedRoom.transform, generatedHallway.transform, room1EntryPoint, room2Entrypoint);

                            if (HandleInter)
                        }
                    }
                }

            }
        }
    }


    private void FillEmptyEntrances()
    {
        generatedRooms.ForEach(room => room.FillEmptyDoors());
    }

    private bool HandleIntersection(HousePart housePart);

    private void AlignRooms





    
}

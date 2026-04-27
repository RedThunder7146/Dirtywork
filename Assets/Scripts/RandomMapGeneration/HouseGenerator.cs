using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class HouseGenerator : MonoBehaviour
{

    public static HouseGenerator Instance { get; private set; }

    [SerializeField]

    private GameObject enterance;

    [SerializeField]

    private List<GameObject> rooms;

    [SerializeField]

    private List<GameObject> specialRooms;

    [SerializeField]

    private List<GameObject> hallways;

    [SerializeField]

    private List<GameObject> alternateEnterances;

    [SerializeField]

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
        StartGeneration();
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
                Transform room1Entrypoint = null;
                int totalRetries = 100;
                int retryIndex = 0;

                while (randomGeneratedRoom == null && retryIndex < totalRetries)
                {
                    int randomLinkRoomIndex = Random.Range(0, generatedRooms.Count);
                    HousePart roomToTest = generatedRooms[randomLinkRoomIndex];
                    if (roomToTest.HasAvaliableEntrypoint(out room1Entrypoint))
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
                            doorToAlign.transform.position = room1Entrypoint.transform.position;
                            doorToAlign.transform.rotation = room1Entrypoint.transform.rotation;
                            AlignRooms(randomGeneratedRoom.transform, generatedHallway.transform, room1Entrypoint, room2Entrypoint);

                            if (HandleIntersection(housePart))
                            {
                                housePart.UnuseEntrypoint(room2Entrypoint);
                                randomGeneratedRoom.UnuseEntrypoint(room1Entrypoint);
                                RetryPlacement(generatedHallway, doorToAlign);
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    GameObject generatedRoom;

                    if (specialRooms.Count > 0)
                    {
                        bool shouldPlaceSpecialRoom = Random.Range(0f, 1f) > 0.9f;

                        if(shouldPlaceSpecialRoom)
                        {
                            int randomIndex = Random.Range(0, rooms.Count);
                            generatedRoom = Instantiate(specialRooms[randomIndex], transform.position, transform.rotation);
                        }
                        else
                        {
                            int randomIndex = Random.Range(0, rooms.Count);
                            generatedRoom = Instantiate(rooms[randomIndex], transform.position, transform.rotation);
                        }
                    }

                    else
                    {
                        int randomIndex = Random.Range(0, rooms.Count);
                        generatedRoom = Instantiate(rooms[randomIndex], transform.position, transform.rotation);
                    }

                    generatedRoom.transform.SetParent(null);

                    if (generatedRoom.TryGetComponent<HousePart>(out HousePart housePart))
                    {
                        if (housePart.HasAvaliableEntrypoint(out Transform room2Entrypoint))
                        {
                            generatedRooms.Add(housePart);
                            doorToAlign.transform.position = room1Entrypoint.transform.position;
                            doorToAlign.transform.rotation = room1Entrypoint.transform.rotation;
                            AlignRooms(randomGeneratedRoom.transform, generatedRoom.transform, room1Entrypoint, room2Entrypoint);

                            if (HandleIntersection(housePart))
                            {
                                housePart.UnuseEntrypoint(room2Entrypoint);
                                randomGeneratedRoom.UnuseEntrypoint(room1Entrypoint);
                                RetryPlacement(generatedRoom, doorToAlign);
                                continue;
                            }
                        }
                    }
                }

            }
        }
    }

    private void GenerateAlternateEntrances()
    {
        if (alternateEnterances.Count < 1) return;

        for (int i = 0; i < alternateEnterances.Count; i++)
        {
            {
                HousePart randomGeneratedRoom = null;
                Transform room1Entrypoint = null;
                int totalRetries = 100;
                int retryIndex = 0;

                while(randomGeneratedRoom == null && retryIndex < totalRetries)
                {
                    int randomLinkRoomIndex = Random.Range(0, generatedRooms.Count);
                    HousePart roomToTest = generatedRooms[randomLinkRoomIndex];
                    if (roomToTest.HasAvaliableEntrypoint(out room1Entrypoint))
                    {
                        randomGeneratedRoom = roomToTest;
                        break;
                    }
                    retryIndex++;
                }

                int randomIndex = Random.Range(0, alternateEnterances.Count);
                GameObject generatedRoom = Instantiate(alternateEnterances[randomIndex], transform.position, transform.rotation);

                generatedRoom.transform.SetParent(null);
                GameObject doorToAlign = Instantiate(door, transform.position, transform.rotation);

                if (generatedRoom.TryGetComponent<HousePart>(out HousePart housePart))
                {
                    if (housePart.HasAvaliableEntrypoint(out Transform room2Entrypoint))
                    {
                        generatedRooms.Add(housePart);
                        doorToAlign.transform.position = room1Entrypoint.transform.position;
                        doorToAlign.transform.rotation = room1Entrypoint.transform.rotation;
                        AlignRooms(randomGeneratedRoom.transform, generatedRoom.transform, room1Entrypoint, room2Entrypoint);

                        if (HandleIntersection(housePart))
                        {
                            housePart.UnuseEntrypoint(room2Entrypoint);
                            randomGeneratedRoom.UnuseEntrypoint(room1Entrypoint);
                            RetryPlacement(generatedRoom, doorToAlign);
                            continue;
                        }
                    }

                }
            }
        }
    }

    private void RetryPlacement(GameObject itemToPlace, GameObject doorToPlace)
    {
        HousePart randomGeneratedRoom = null;
        Transform room1Entrypoint = null;
        int totalRetries = 100;
        int retryIndex = 0;

        while (randomGeneratedRoom == null && retryIndex < totalRetries)
        {
            int randomLinkRoomIndex = Random.Range(0, generatedRooms.Count - 1);
            HousePart roomToTest = generatedRooms[randomLinkRoomIndex];
            if(roomToTest.HasAvaliableEntrypoint(out room1Entrypoint))
            {
                randomGeneratedRoom = roomToTest;
                break;
            }
            retryIndex++;
        }
        if (itemToPlace.TryGetComponent<HousePart>(out HousePart housePart))
        {
            if (housePart.HasAvaliableEntrypoint(out Transform room2Entrypoint))
            {
                doorToPlace.transform.position = room1Entrypoint.transform.position;
                doorToPlace.transform.rotation = room1Entrypoint.transform.rotation;
                AlignRooms(randomGeneratedRoom.transform, itemToPlace.transform, room1Entrypoint, room2Entrypoint);

                if (HandleIntersection(housePart))
                {
                    housePart.UnuseEntrypoint(room2Entrypoint);
                    randomGeneratedRoom.UnuseEntrypoint(room1Entrypoint);
                    RetryPlacement(itemToPlace, doorToPlace);
                }
            }
            
        }
    }

    private void FillEmptyEntrances()
    {
        generatedRooms.ForEach(room => room.FillEmptyDoors());
    }

    private bool HandleIntersection(HousePart housePart)
    {
        bool didIntersect = false;

        Collider[] hits = Physics.OverlapBox(housePart.collider.bounds.center, housePart.collider.bounds.size /2, Quaternion.identity, roomsLayerMask);

        foreach (Collider hit in hits)
        {
            if (hit == housePart.collider) continue;

            if (hit != housePart.collider)
            {
                didIntersect = true; 
                break;
            }
        }

        return didIntersect;
    }

    private void AlignRooms(Transform room1, Transform room2, Transform room1Entry, Transform room2Entry)
    {
        float angle = Vector3.Angle(room1Entry.forward, room2Entry.forward);
        room2.TransformPoint(room2Entry.position);
        room2.eulerAngles = new Vector3(room2.eulerAngles.x, room2.eulerAngles.y + angle, room2.eulerAngles.z);
        Vector3 offset = room1Entry.position - room2Entry.position;
        room2.position += offset;
        Physics.SyncTransforms();
    }

    public List<HousePart> GetGeneratedRooms() => generatedRooms;

    public bool IsGenerated() => isGenerated;



    
}

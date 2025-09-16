using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonManager : MonoBehaviour
{
    public static PersonManager Instance; 
    [SerializeField] GameObject personPrefab;
    [SerializeField] Transform spawnLocation;
    [SerializeField] List<Waypoint> waypoints;


    [SerializeField] float moveSpeed;

    //Will change depending on game mode and location
    //Neg = Easy, Pos = Hard
    [Range(-5f, 5f)] public float difficulty;
    [SerializeField] RamenStand ramenStand;
    IngredientDatabase ingredientDatabase = new IngredientDatabase();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }
    public void StartGame()
    {
        StartCoroutine(SpawnPerson(4));
    }
    public Ingredient GenerateRandomIngredient()
    {
        return ingredientDatabase.PickRandomIngredient();
    }

    IEnumerator SpawnPerson(int personCount)
    {
        for (int i = 0; i < personCount; i++)
        {
            Person person = Instantiate(personPrefab, spawnLocation.position,
        spawnLocation.rotation).GetComponent<Person>();
            Debug.Log("Person Created");
            //allPeople.Add(person);
            StartCoroutine(MovePerson(person));
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator MovePerson(Person person)
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            Transform target = waypoints[i].transform;
            person.canMoveToNextWaypoint = false;
            // Move until reaching the current waypoint
            while (Vector3.Distance(person.transform.position, target.position) > 0.1f)
            {
                Vector3 dir = (target.position - person.transform.position).normalized;
                person.transform.position += dir * moveSpeed * Time.deltaTime;
                yield return null; // wait until next frame
            }
            StartCoroutine(DestinationAnalysis(waypoints[i], person));
            yield return new WaitUntil(() => person == null || person.canMoveToNextWaypoint);
            if (person.didNotOrder)
            {
                i = waypoints.Count - 1;
            }
            if(person == null)
            {
                yield break;
            }
        }
    }
    IEnumerator DestinationAnalysis(Waypoint waypoint, Person person)
    {
        if(waypoint.destination == Waypoint.Destination.Path)
        {
            yield return person.canMoveToNextWaypoint = true;
        }
        else if (waypoint.destination == Waypoint.Destination.Shop)
        {
            bool x = ramenStand.OrderingRamen(person);
            yield return new WaitForSeconds(1f); //Wait for menu and order
            if(x)
            {
                yield return person.canMoveToNextWaypoint = true;
            }
            else
            {
                person.canMoveToNextWaypoint = true;
                yield return person.didNotOrder = true;
            }
                
        }
        else if (waypoint.destination == Waypoint.Destination.Table)
        {
            yield return new WaitForSeconds(1f); //Wait for eating
            person.SayRamenOpinion();
            yield return person.canMoveToNextWaypoint = true;
        }
        else if (waypoint.destination == Waypoint.Destination.End)
        {
            // Cleanup before destroying
            /*if (allPeople.Contains(person))
            {
                allPeople.Remove(person);
            }*/

            Debug.Log($"Deleting Person: {person.uniqueID}");

            // Destroy GameObject
            Destroy(person.gameObject);

            yield break; // stop this coroutine for this person
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonManager : MonoBehaviour
{
    [SerializeField] GameObject personPrefab;
    [SerializeField] Transform spawnLocation;
    [SerializeField] List<Waypoint> waypoints;
    [SerializeField] float moveSpeed;

    private int activePeople = 0;

    private int Yabai, Oishii, Umai, Ehhhhhhh, Mazui;

    public void StartGame()
    {
        RamenStand.Instance.MakeRamen();
        StartCoroutine(SpawnPerson(4));
    }

    IEnumerator SpawnPerson(int personCount)
    {
        for (int i = 0; i < personCount; i++)
        {
            Town.Instance.TownData.ShuffleLocals();
            for (int j = 0; j < Town.Instance.TownData.Locals.Count; j++)
            {
                SpawnAndTrackPerson(Town.Instance.TownData.Locals[j]);
                yield return new WaitForSeconds(1f);

                // Special persons
                for (int k = 0; k < Town.Instance.TownData.SpecialPersons.Count; k++)
                {
                    if (RNG.NextFloat() <= Town.Instance.TownData.SpecialPersonShowRate[k])
                    {
                        SpawnAndTrackPerson(Town.Instance.TownData.SpecialPersons[k]);
                        yield return new WaitForSeconds(1f);
                    }
                }
            }
        }
    }

    private void SpawnAndTrackPerson(PersonData data)
    {
        Person person = Instantiate(personPrefab, spawnLocation.position, spawnLocation.rotation)
                            .GetComponent<Person>();
        person.InitPerson(data);
        activePeople++; // increment counter
        StartCoroutine(MovePerson(person));
    }

    IEnumerator MovePerson(Person person)
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            Transform target = waypoints[i].transform;
            person.canMoveToNextWaypoint = false;

            while (Vector3.Distance(person.transform.position, target.position) > 0.1f)
            {
                person.transform.position += (target.position - person.transform.position).normalized * moveSpeed * Time.deltaTime;
                yield return null;
            }

            StartCoroutine(DestinationAnalysis(waypoints[i], person));
            yield return new WaitUntil(() => person == null || person.canMoveToNextWaypoint);

            if (person.didNotOrder) i = waypoints.Count - 2;
            if (person == null) yield break;
        }

        // Person reached end
        FinishPerson(person);
    }

    IEnumerator DestinationAnalysis(Waypoint waypoint, Person person)
    {
        if (waypoint.destination == Waypoint.Destination.Path)
        {
            person.canMoveToNextWaypoint = true;
        }
        else if (waypoint.destination == Waypoint.Destination.Shop)
        {
            bool ordered = RamenStand.Instance.OrderingRamen(person);
            yield return new WaitForSeconds(1f);
            person.canMoveToNextWaypoint = true;
            if (!ordered) person.didNotOrder = true;
        }
        else if (waypoint.destination == Waypoint.Destination.Table)
        {
            yield return new WaitForSeconds(1f);
            CountOpinions(person.SayRamenOpinion());
            person.canMoveToNextWaypoint = true;
        }
        else if (waypoint.destination == Waypoint.Destination.End)
        {
            FinishPerson(person);
        }
    }

    private void FinishPerson(Person person)
    {
        if (person != null) Destroy(person.gameObject);
        activePeople--;
        if (activePeople <= 0)
        {
            ListOpinions();
        }
    }

    void CountOpinions(int count)
    {
        switch (count)
        {
            case 0: Yabai++; break;
            case 1: Oishii++; break;
            case 2: Umai++; break;
            case 3: Ehhhhhhh++; break;
            case 4: Mazui++; break;
        }
    }
    void ListOpinions()
    {
        Debug.Log(Yabai + " - Yabai");
        Debug.Log(Oishii + " - Oishii");
        Debug.Log(Ehhhhhhh + " - Ehhhhhh");
        Debug.Log(Mazui + " - Mazui");
    }
}

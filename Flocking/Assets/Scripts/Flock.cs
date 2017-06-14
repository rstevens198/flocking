using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

    public float speed = 0.01f;
    float rotationSpeed = 1.0f;

    Vector3 AverageHeading;
    Vector3 averagePosition;


    public float neighborDistance = 10.0f;
	
    // Use this for initialization
	void Start () {
        speed = Random.Range(1, 8);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Random.Range(0, 5) < 3)
            ApplyRules();
        transform.Translate(Time.deltaTime * speed, 0, 0);

        // check to see if we need to loop back to the other side of the screen
        CheckXAxis();
        CheckYAxis();
        this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);

    }

    void CheckXAxis()
    {
        
            if (transform.position.x < -59 || transform.position.x > 59)
                transform.position = new Vector3(transform.position.x * -1, 0, transform.position.z);
        
    }

    void CheckYAxis()
    {
        
            if (transform.position.z < -27 || transform.position.z > 27)
                transform.position = new Vector3(transform.position.x, 0, transform.position.z * -1);
        
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = GlobalFlock.allFish;
        Vector3 vCenter = Vector3.zero;
        Vector3 vAvoid = Vector3.zero;
        float groupSpeed = 0.1f;

        Vector3 goalPos = GlobalFlock.goalPos;

        float dist;

        int groupSize = 0;
        foreach( GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if (dist <= neighborDistance)
                {
                    vCenter += go.transform.position;
                    groupSize++;

                    if(dist < 10.0f)
                    {
                        vAvoid = vAvoid + (this.transform.position - go.transform.position);
                    }

                    Flock anotherFlock = go.GetComponent<Flock>();
                    if (groupSpeed + anotherFlock.speed > 10)
                        anotherFlock.speed = Random.Range(anotherFlock.speed - 5, anotherFlock.speed);
                    if (anotherFlock.speed <= 0)
                        anotherFlock.speed = Random.Range(1, 2);

                    groupSpeed = groupSpeed + anotherFlock.speed;
                }
            }
        }

        if(groupSize > 0)
        {
            vCenter = vCenter / groupSize + (goalPos - this.transform.position);
            speed = groupSpeed / groupSize;

            Vector3 direction = (vCenter + vAvoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        }

    }
}

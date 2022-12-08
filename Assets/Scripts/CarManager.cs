using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{

    private List<GameObject> cars = new();
    private float totalTime;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++) {
            cars.Add(transform.GetChild(i).gameObject);
        }
        Debug.Log(transform.childCount);
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        for (int i = 0; i < cars.Count; i++) {
            float xcomp = 5000 * Time.deltaTime * Mathf.Sin(totalTime + 100 * i);
            float ycomp = 0;
            float zcomp = 5000 * Time.deltaTime * Mathf.Cos(totalTime + 200 * i);
            Rigidbody body = cars[i].GetComponent<Rigidbody>();
            body.AddForce(xcomp, ycomp, zcomp);

            // Rotate wheels
            for (int j = 0; j < cars[i].transform.childCount - 1; j++) {
                Transform wheel = cars[i].transform.GetChild(j);
                wheel.Rotate(1000 * Time.deltaTime, 0, 0);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Gumdrop : MonoBehaviour
{
    private NavMeshAgent _agent;

    public GameObject Player;

    public float EnemyDistanceRun = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position,Player.transform.position);

        Debug.Log("Distance: " + distance);

        if(distance < EnemyDistanceRun)
        {
            Vector3 dirtoPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position + dirtoPlayer;

            _agent.SetDestination(newPos);
        }
    }

     void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            print("im in collision");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

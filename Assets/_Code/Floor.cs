using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Floor : MonoBehaviour
{
    private int missedItems;
    public ParticleSystem explosion;
    public string gameplayLevelName;

    // Use this for initialization
    void Start ()
    {
        missedItems = 0;	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision collision) {
        missedItems++;

        if(missedItems == 10)
        {
            SceneManager.LoadScene(gameplayLevelName);
        }

        GameObject collisionWith = collision.gameObject;
        Transform collisionTransform = collisionWith.transform;
        Vector3 explosionPosition = new Vector3(collisionTransform.position.x, collisionTransform.position.y, collisionTransform.position.z);
        ParticleSystem instantiatedExplosion = Instantiate(explosion, explosionPosition, Quaternion.Euler(-90, 0, 0));
        Destroy(instantiatedExplosion, 5);
        Destroy(collisionWith);
    }
}

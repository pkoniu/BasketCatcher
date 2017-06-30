using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PatrykKonior

public class BasketController : MonoBehaviour
{
    public float speed;
    public Vector2 movementRange;
    public ParticleSystem fireworks;

    private ScoreManager scoreManager;

	// Use this for initialization
	void Start ()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        speed = 7.5f;
        movementRange = new Vector2(6, 6);
	}
	
	// Update is called once per frame
	void Update ()
    {
        float ix = Input.GetAxis("Horizontal");
        float iy = Input.GetAxis("Vertical");
        float dt = Time.deltaTime;

        float dx = this.speed * dt * ix;
        float dy = this.speed * dt * iy;

        Vector3 currentPos = transform.position;
        Vector3 deltaPos = new Vector3(dx, currentPos.y, dy);
        Vector3 newPos = currentPos + deltaPos;

        float newX = Mathf.Clamp(newPos.x, -movementRange.x, movementRange.x);
        float newY = deltaPos.y;
        float newZ = Mathf.Clamp(newPos.z, -movementRange.y, movementRange.y);
        transform.position = new Vector3(newX, newY, newZ);
	}

    public void OnTriggerEnter(Collider collider)
    {
        GameObject collidedWithGO = collider.gameObject;
        Primitive collidedWithPrimitive = collidedWithGO.GetComponent<Primitive>();

        if (collidedWithPrimitive) {
            Transform collisionTransform = collidedWithGO.transform;
            Vector3 fireworksPosition = new Vector3(collisionTransform.position.x, collisionTransform.position.y, collisionTransform.position.z);
            ParticleSystem instantiatedFireworks = Instantiate(fireworks, fireworksPosition, Quaternion.Euler(-90, 0, 0));
            Destroy(instantiatedFireworks, 5);

            scoreManager.AddPoints(collidedWithPrimitive.points);
            Destroy(collidedWithGO);
        }
    }
}

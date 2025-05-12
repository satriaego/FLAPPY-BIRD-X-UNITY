using UnityEngine;

public class codeRintangan : MonoBehaviour
{
    public static float globalSpeed = 13;  // static variable
    public float deathZone = -45;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
    if (!kecerdasan.isGameStarted)
        return;
        transform.position = transform.position + (Vector3.left * globalSpeed) * Time.deltaTime;
        if(transform.position.x < deathZone){
            Debug.Log("pipeDel..");
            Destroy(gameObject);
        }
    }
}

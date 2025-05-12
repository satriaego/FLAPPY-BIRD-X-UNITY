using Unity.VisualScripting;
using UnityEngine;
public class trigerScript : MonoBehaviour
{
    public kecerdasan logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic"). GetComponent <kecerdasan>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);
            gameObject.SetActive(false);
        }
    }
}

using UnityEngine;

public class aronaScript : MonoBehaviour
{
    public kecerdasan logic;
    public AudioSource aronaAudio;
    public Rigidbody2D aronaRigidbody;
    public float velocityArona;
    public float pithcSong;
    public bool aroanLive = true;
    public codeRintangan mami;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aronaAudio = GameObject.Find("song").GetComponent<AudioSource>();
        aronaRigidbody = GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("logic"). GetComponent <kecerdasan>();
        mami = GameObject.FindGameObjectWithTag("mami"). GetComponent<codeRintangan>();
            // Atur gravitasi hanya jika game belum dimulai
    if (!kecerdasan.isGameStarted)
        aronaRigidbody.gravityScale = 0;
    else
        aronaRigidbody.gravityScale = 2; // Sesuai yang kamu pakai di STARTUI()
    }

    // Update is called once per frame
    void Update()
    {
    if (!kecerdasan.isGameStarted)
        return;
        if(Input.GetKeyDown(KeyCode.Space) && aroanLive)
        {
            aronaRigidbody.linearVelocity = Vector2.up * velocityArona;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        codeRintangan.globalSpeed = 5; // Change global speed
        aroanLive = false;
        aronaRigidbody.AddForce(new Vector2(-3, 3) * 100); // knockback
        aronaRigidbody.AddTorque(200); // spin effect
        aronaAudio.pitch = pithcSong;

    }
}

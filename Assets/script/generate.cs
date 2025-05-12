using UnityEngine;

public class generate : MonoBehaviour
{
    public GameObject rintangan;
    public float jarakAntarRintangan = 20f;
    public float offsetTinggi = 10f;

    private float jarakTempuh = 0f; // total jarak seolah-olah berjalan


    void Start()
    {
        generateGen();

    }
    
    void Update()

    {
    if (!kecerdasan.isGameStarted)
        return;

        // Tambah jarak berdasarkan kecepatan global
        jarakTempuh += codeRintangan.globalSpeed * Time.deltaTime;

        // Debug log untuk lihat progress
        Debug.Log("Jarak tempuh: " + jarakTempuh);

        if (jarakTempuh >= jarakAntarRintangan)
        {
            generateGen();
            jarakTempuh = 0f;
        }
    }


    void generateGen()
    {
        float lowestPoint = transform.position.y - offsetTinggi;
        float HighPoint = transform.position.y + offsetTinggi;
        Instantiate(rintangan, new Vector3(transform.position.x, Random.Range(lowestPoint, HighPoint), 0), transform.rotation);
    }
}

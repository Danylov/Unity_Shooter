using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float shotReloadTime = 10.0f;
    [SerializeField] private GameObject rocketPrefab; 
    private float shotReloadRemainTime;
    private int currEnemyNumber;
    private GameObject tmpRocket;
    private SpawnManager spawnManager;

    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
    }
    
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began) || 
            (Input.GetKeyDown(KeyCode.Space))) LaunchRocket();
        if (0.0 < shotReloadRemainTime) shotReloadRemainTime -= Time.deltaTime;
    }
   
    void LaunchRocket()
    {
        if (shotReloadRemainTime <= 0.0)
        {
            if (currEnemyNumber < spawnManager.enemiesNumber - 1) currEnemyNumber++;
            else currEnemyNumber = 0;
            GameObject currEnemy = spawnManager.GetEnemy(currEnemyNumber);
            tmpRocket = Instantiate(rocketPrefab, transform.position + Vector3.up, Quaternion.identity);
            tmpRocket.GetComponent<RocketBehaviour>().Fire(currEnemy.transform);
            shotReloadRemainTime = shotReloadTime;
        }
    }
}
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 2f;

    [SerializeField] private GameObject _ballSpawnObject;

    [SerializeField] private GameObjectArrayVariable _objects;

    private GameObject[] _balls;

    private float _time = 0f;

    private float _ballSpawnYPosition;

    private GameObject _queuedBall;
    
    [SerializeField] private Transform _spawnPos;


    private GameObject _nextBall;

    [SerializeField] private SpriteRenderer _queuedBallImage;

    private SpriteRenderer _spawnSprite;

    [SerializeField] private Camera _camera;


    private Vector3 _originalSize;
    private Vector3 _shrunkenSize;

    private bool _growBall = true;


    public int _ballCount { get; private set; } = 0;
    
    public int _blendWaitCount {get; private set;} = 50;


    [SerializeField] private Honse _honse;
    
    private void Start()
    {
        _balls = _objects.objects;
        _ballSpawnYPosition = _ballSpawnObject.transform.position.y;
        _nextBall = CreateBall();
        _nextBall.SetActive(false);

        _queuedBall = CreateBall();
        _queuedBall.SetActive(false);

        _spawnSprite = _spawnPos.GetComponent<SpriteRenderer>();

        _originalSize = _spawnPos.localScale;
        _shrunkenSize = _originalSize * 0.1f;

        _spawnPos.localScale = _shrunkenSize;
    }


    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; // Set a reasonable z-coordinate for the 2D plane

        // Convert the mouse position to world space
        Vector3 worldPosition = _camera.ScreenToWorldPoint(mousePosition);


/*        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject.CompareTag("PlayArea"))
        {
        }
*/
        _spawnPos.position = new Vector3(worldPosition.x, _ballSpawnYPosition, worldPosition.z);



        if (_time > 0f)
        {
            // Subtract the difference of the last time the method has been called
            _time -= Time.deltaTime;
        }

        Debug.Log("Grow Ball: " + _growBall);

        if (_growBall)
        {
            _spawnPos.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
        }

        if (Vector3.Distance(_spawnPos.localScale, _originalSize) <= 0.1f)
        {
            _spawnPos.localScale = _originalSize;
            _growBall = false;
        }


        if (_time <= 0f)
        {

            _spawnSprite.enabled = true;
            _spawnSprite.sprite = _nextBall.GetComponent<SpriteRenderer>().sprite;
            _queuedBallImage.sprite = _queuedBall.GetComponent<SpriteRenderer>().sprite;
            
        }


        if (Input.GetMouseButtonDown(0) && _time <= 0f && _growBall == false && _honse._moveHonse == false) // Check for left mouse button click
        {

            _nextBall.SetActive(true);
            _nextBall.transform.position = _spawnPos.position;
            GameObject currentBall = _nextBall;
            

            _time = _spawnDelay;

            _nextBall = _queuedBall;
            _nextBall.SetActive(false);

            _queuedBall = CreateBall();
            _queuedBall.SetActive(false);

            _spawnPos.localScale = _shrunkenSize;
            _growBall = true;
            _spawnSprite.enabled = false;

            _ballCount++;

        }
    }

    public GameObject CreateBall()
    {
        // Instantiates a ball here
        return Instantiate(_balls[Random.Range(0, Mathf.FloorToInt(_balls.Length / 2))], _spawnPos.position, Quaternion.identity);
    }


    private void BlendFruit()
    {

    }
}


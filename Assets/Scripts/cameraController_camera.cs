using UnityEngine;
using System.Collections;

public class cameraController_camera : MonoBehaviour {

    public float rotateTime = 1.0f;

    private bool _isTweening = false;
    public bool _isRotating = false;
    private bool _isAdjustingCamera = false;
    private bool CharStarted = false;
    //private DisablePlayer _disablePlayer;
    private GameObject crystal;

    //main camera
    private GameObject mainCamera;

    //game over controll
    private GameOver Isgameover;

    private GameObject player1;
    private GameObject player2;
    private GameObject player3;
    private float worldCenterY;

    private GameObject lastPlaying;

    Vector3 targetPos;

    public float timeAdjustingCamera = 0.5f;



    // Use this for initialization
    void Start()
    {
        crystal = GameObject.FindGameObjectWithTag("crystal");
        gameObject.transform.position = new Vector3(crystal.transform.position.x, -10, crystal.transform.position.z);
        gameObject.transform.rotation = Quaternion.identity;
        player1 = GameObject.FindGameObjectWithTag("blue");
        player2 = GameObject.FindGameObjectWithTag("red");
        player3 = GameObject.FindGameObjectWithTag("green");

        StartCoroutine(enablePlayersStart());
        StartCoroutine(disablePlayersStart());
       
        lastPlaying = player1;
        worldCenterY = this.GetComponent<Transform>().eulerAngles.y;
        Isgameover = GameObject.FindGameObjectWithTag("plane").GetComponent<GameOver>();
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAdjustingCamera == false)
        {
            cameraTrack(lastPlaying);
        }
        //cameraTrack_Lerp(lastPlaying);

        //targetPos = new Vector3(mainCamera.transform.position.x, lastPlaying.transform.position.y, mainCamera.transform.position.z);
        //iTween.LookTo(mainCamera, lastPlaying.transform.position, 0.2f);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            lastPlaying.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            lastPlaying.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            lastPlaying.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            //lastPlaying.GetComponent<Animator>().enabled = false;
            _isRotating = true;
            rotateTween(120);
            
            //StartCoroutine(MyCoroutine());
            
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            lastPlaying.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            lastPlaying.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            lastPlaying.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            //lastPlaying.GetComponent<Animator>().enabled = false;
            _isRotating = true;
            rotateTween(-120);
            //StartCoroutine(MyCoroutine());
        }
    }

    private void rotateTween(float amount)
    {
        if (_isTweening == false)
        {
            _isTweening = true;
            //_disablePlayer.disable();
            Vector3 rot = new Vector3(0, amount, 0);
            iTween.RotateAdd(gameObject, iTween.Hash(iT.RotateAdd.time, rotateTime, iT.RotateAdd.amount, rot, iT.RotateAdd.easetype, iTween.EaseType.easeInOutSine, iT.RotateAdd.oncomplete, "onColorTweenComplete"));
        }
        
    }

    private void onColorTweenComplete()
    {
        _isTweening = false;
        _isRotating = false;
        //_disablePlayer.enable();
        jump();
        _isAdjustingCamera = true;
        Debug.Log("Rotate_isAdjustingCamera: " + _isAdjustingCamera);
        cameraMove_Lerp(lastPlaying);
    }

    IEnumerator MyCoroutine()
    {
        //This is a coroutine
        yield return new WaitForSeconds(1);
        jump();
        yield return new WaitForSeconds(1);
    }

    public IEnumerator enablePlayersStart()
    {
        //This is a coroutine
        yield return new WaitForSeconds(0.10f);
        enablePlayers();
        yield return new WaitForSeconds(0.10f);
    }

    public IEnumerator disablePlayersStart()
    {
        //This is a coroutine
        yield return new WaitForSeconds(0.1f);
        disablePlayers();
        yield return new WaitForSeconds(0.1f);
    }

    void jump()
    {
        worldCenterY = this.GetComponent<Transform>().eulerAngles.y;
        Debug.Log(worldCenterY);
        if ((worldCenterY > -20.0f && worldCenterY < 20.0f) || (worldCenterY > 340.0f && worldCenterY < 380.0f))
        {
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;

            player1.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
            player1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            //player1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;


            //player1.GetComponent<Rigidbody>().constraints &= (~RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ);

            player1.GetComponent<Animator>().enabled = true;
            player2.GetComponent<Animator>().enabled = false;
            player3.GetComponent<Animator>().enabled = false;
            lastPlaying = player1;
           
        }
       
        else if (worldCenterY > 100.0f && worldCenterY < 140.0f)
        {
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;

            player3.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
            //player3.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY
            player3.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionZ;

            player3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            //player3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;

            //player3.GetComponent<Rigidbody>().constraints &= (~RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | ~RigidbodyConstraints.FreezePositionZ);

            player1.GetComponent<Animator>().enabled = false;
            player2.GetComponent<Animator>().enabled = false;
            player3.GetComponent<Animator>().enabled = true;
            lastPlaying = player3;
           
        }
        else if (worldCenterY > 220.0f && worldCenterY < 260.0f)
        {
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;

            player2.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
            //player2.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY
            player2.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionZ;

            player2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            //player2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;

            //player2.GetComponent<Rigidbody>().constraints &= (~RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | ~RigidbodyConstraints.FreezePositionZ);

            player1.GetComponent<Animator>().enabled = false;
            player2.GetComponent<Animator>().enabled = true;
            player3.GetComponent<Animator>().enabled = false;
            lastPlaying = player2;
           
        }
    }

    void enablePlayers()
    {
        player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
        player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
        player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
        player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
        player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
        player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
    }

    void disablePlayers()
    {
        player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
        player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
        player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
        player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
        player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
        player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
    }

    private void cameraTrack(GameObject player)
    {
        //Vector3 playerPos = 
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, player.transform.position.y, mainCamera.transform.position.z);
        /*float wantedHeight = player.transform.position.y;
        float currentHeight = mainCamera.transform.position.y;
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);*/
    }

    //void cameraTrack_Lerp(GameObject player)
    //{
    //    //Vector3 playerPos = 
    //    //mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, player.transform.position.y, mainCamera.transform.position.z);
    //    Debug.Log("cameraTrack_Lerp called");
    //    Debug.Log("player available while rotation:     " + player.ToString());

    //    float wantedHeight = player.transform.position.y;        
    //    Vector3 targetPos = new Vector3(mainCamera.transform.position.x, wantedHeight, mainCamera.transform.position.z);
    //    mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPos, heightDamping * Time.deltaTime);
    //}

    private void cameraMove_Lerp(GameObject player)
    {
        if(_isAdjustingCamera == true)
        {
            //_isAdjustingCamera = true;
            //mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, player.transform.position.y, mainCamera.transform.position.z);
            Debug.Log("cameraMove_Lerp called");
            Debug.Log("player available while rotation:     " + player.ToString());

            float wantedHeight = player.transform.position.y;
            float currentHeight = mainCamera.transform.position.y;
            
            //Vector3 targetPos = new Vector3(mainCamera.transform.position.x, wantedHeight, mainCamera.transform.position.z);
            Vector3 amount = new Vector3(0, wantedHeight - currentHeight, 0);
            Debug.Log("amount" + amount);
            //mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, targetPos, heightDamping * Time.deltaTime);
            //iTween.MoveAdd(mainCamera, amount, timeAdjustingCamera);
            iTween.MoveAdd(mainCamera, iTween.Hash(iT.MoveAdd.time, timeAdjustingCamera, iT.MoveAdd.amount, amount, iT.MoveAdd.oncomplete, "onAdjustCameraComplete", iT.MoveAdd.oncompletetarget, gameObject));
        }

    }

    private void onAdjustCameraComplete()
    {
        _isAdjustingCamera = false;
        Debug.Log("_isAdjustingCamera: "+_isAdjustingCamera);
        
    }
}

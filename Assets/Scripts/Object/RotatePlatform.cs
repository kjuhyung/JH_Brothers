using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    private bool Active = false;
    private bool RotateDirection = true;
    private bool TopDown = true;
    private Collider2D Player;
    private float startZRotate;
    private float endZRotate;
    private float curTime = 0;

    private void Update()
    {
        if(Active)
        {
            curTime += Time.deltaTime;
            float zRotate = Mathf.Lerp(startZRotate, endZRotate, curTime);
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotate));
                
            if(curTime > 1.0f)
                Active = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerInputController>(out PlayerInputController playerInputController))
        {
            Player = collision;

            if ((Player.gameObject.transform.position.y - gameObject.transform.position.y) > 0)
                TopDown = true;
            else
                TopDown = false;

            playerInputController.OnDownEvent += Rotate;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerInputController>(out PlayerInputController playerInputController))
        {
            Player = null;
            playerInputController.OnDownEvent -= Rotate;
        }
    }

    private void Rotate()
    {
        if (!Active)
        {
            Debug.Log(gameObject.transform.position.x);
            Debug.Log(Player.gameObject.transform.position.x);
            Active = true;
            curTime = 0;
            if ((Player.gameObject.transform.position.x - gameObject.transform.position.x) > 0)
                RotateDirection = true;
            else
                RotateDirection = false;

            startZRotate = gameObject.transform.rotation.eulerAngles.z;
            endZRotate = startZRotate + (RotateDirection ? -180.0f : 180.0f);
        }
    }


}

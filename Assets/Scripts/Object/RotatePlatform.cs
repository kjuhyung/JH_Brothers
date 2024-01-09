using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    private bool Active = false;
    private bool RotateDirection = true;
    private bool TopDown = true;
    private Collider2D Player;
    private Quaternion rotationAngle;
    private float curTime = 0;

    private void Update()
    {
        if(Active)
        {
            curTime += Time.deltaTime;
            Debug.Log(curTime);
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, rotationAngle, curTime);
            if(curTime > 2.0f)
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
            Active = true;
            curTime = 0;
            if ((Player.gameObject.transform.position.x - gameObject.transform.position.x) > 0)
                RotateDirection = true;
            else
                RotateDirection = false;

            Vector3 rotateAngle = gameObject.transform.rotation.eulerAngles + (RotateDirection ? new Vector3(0, 0, 180) : new Vector3(0, 0, -180));
            rotationAngle = Quaternion.Euler(rotateAngle);
        }
    }


}

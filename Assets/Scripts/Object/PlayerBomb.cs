using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    private float _timer = 0f;

    private void OnEnable()
    {
        _timer = 0f;
    }

    void Update()
    {
        _timer += Time.deltaTime; // TODO - Explosion 함수 - 폭발하고 사라지는 기능

        if ( _timer > 2f)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        ObjectPoolManager.Instance.ReturnObject(this.gameObject, ObjectPoolType.Bomb);
    }
}

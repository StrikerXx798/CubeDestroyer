using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private int _minMultiplyCount = 2;
    [SerializeField] private int _maxMultiplyCount = 6;
    [SerializeField] private GameObject _cubePrefab;

    private Ray _ray;

    void OnValidate()
    {
        if (_minMultiplyCount > _maxMultiplyCount)
            _minMultiplyCount = _maxMultiplyCount - 1;
    }

    void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Input.GetMouseButtonDown(0)) return;

        RaycastHit hit;

        if (!Physics.Raycast(_ray, out hit)) return;

        if (hit.collider.gameObject.CompareTag(_cubePrefab.tag)) OnClick(hit.collider.gameObject);

    }

    private void MultiplyObject(GameObject cube)
    {
        var newElementsCount = RandomUtils.Next(_minMultiplyCount, _maxMultiplyCount);

        for (var i = 0; i < newElementsCount; i++)
        {
            var newObject = Instantiate(_cubePrefab, cube.transform.position, Quaternion.identity);
            newObject.transform.localScale = Vector3.one / 2;
        }

        DestroyObject(cube);
    }

    private void DestroyObject(GameObject cube)
    {
        Destroy(cube);
    }

    private void OnClick(GameObject cube)
    {
        var isMultiply = RandomUtils.NextBool();

        if (isMultiply) MultiplyObject(cube);
        else DestroyObject(cube);
    }
}

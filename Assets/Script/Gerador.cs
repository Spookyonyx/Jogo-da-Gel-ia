using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    public GameObject modeloPlataforma;

    public List<Transform> plataformas;
    public Transform cameraTransform;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GerarPlataforma();
        }
    }

    void GerarPlataforma()
    {
        var x = Random.Range(-2.2f, 2.2f);
        var y = plataformas.Last().position.y + 1;
        var transformPlataforma = Instantiate(modeloPlataforma, new Vector3(x, y), Quaternion.identity).transform;
        plataformas.Add(transformPlataforma);
    }
    void Update()
    {
        var primeira = plataformas.First();
        if (primeira.position.y < cameraTransform.position.y - 6)
        {
            plataformas.RemoveAt(0);
            Destroy(primeira.gameObject);
            GerarPlataforma();
        }
    }
}

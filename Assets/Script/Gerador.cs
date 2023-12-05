using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    public GameObject modeloPlataforma;
    public GameObject modeloMosca;
    public GameObject modeloPowerUp;
    public GameObject modeloFallingPlatform;

    public List<Transform> plataformas;
    public Transform cameraTransform;

    float distancia = 1;
    float chanceDeTerMosca = 6;
    float chanceDeTerPowerUp = 5;
    float chanceDeTerPlataformaCair = 85;

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
        var y = plataformas.Last().position.y + distancia;
        distancia += 0.01f;
        if (distancia > 3f)
        {
            distancia = 3f;
        }
        float SortearPlataforma = Random.Range(0f, 100f);
        Vector3 position = new Vector3();
        if (SortearPlataforma < chanceDeTerPlataformaCair)
        {
            var transformPlataforma = Instantiate(modeloPlataforma, new Vector3(x, y), Quaternion.identity).transform;
            plataformas.Add(transformPlataforma);
            position = transformPlataforma.position;
        }
        else
        {
            var transformPlataforma = Instantiate(modeloFallingPlatform, new Vector3(x, y), Quaternion.identity).transform;
            plataformas.Add(transformPlataforma);
            position = transformPlataforma.position;
        }

        float valorSorteado = Random.Range(0f, 100f);
        if (valorSorteado < chanceDeTerMosca)
        {
            Instantiate(modeloMosca, position + Vector3.up * 0.7f, Quaternion.identity);
            chanceDeTerMosca += 1;
            if (chanceDeTerMosca > 50)
            {
                chanceDeTerMosca = 50;
            }
        }

        float SortearPowerUp = Random.Range(0f, 100f);
        if (SortearPowerUp < chanceDeTerPowerUp)
        {
            Instantiate(modeloPowerUp, position + Vector3.up * 0.7f, Quaternion.identity);
            chanceDeTerPowerUp += 1;
            if (chanceDeTerPowerUp > 15)
            {
                chanceDeTerPowerUp = 15;
            }
        }

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

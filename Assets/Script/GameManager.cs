using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text gameOverText;
    public TMP_Text pressioneEspaco;
    public TMP_Text titulo;
    public TMP_Text credito;
    public TMP_Text EscolhaOPersonagem;
    public TMP_Text melhorText;

    int melhorPontuacao;


    public Rigidbody2D playerRig;
    public Player Jogador;
    public Sprite Roxie;
    public Sprite Limme;
    public SpriteRenderer player;

    bool jogando = false;
    void Start()
    {
        melhorPontuacao = PlayerPrefs.GetInt("melhorPontuacao");
        melhorText.text = "Best Score: " + melhorPontuacao;

        gameOverText.gameObject.SetActive(false);
        pressioneEspaco.gameObject.SetActive(false);

        titulo.gameObject.SetActive(true);
        credito.gameObject.SetActive(true);
        melhorText.gameObject.SetActive(true);
        EscolhaOPersonagem.gameObject.SetActive(true);
    }

    void Inicia()
    {
        titulo.gameObject.SetActive(false);
        credito.gameObject.SetActive(false);
        EscolhaOPersonagem.gameObject.SetActive(false);
        melhorText.gameObject.SetActive(false);
        playerRig.bodyType = RigidbodyType2D.Dynamic;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void selecionarRoxie()
    {
        player.sprite = Roxie;
        jogando = true;
        Inicia();

    }
    public void selecionarLimme()
    {
        player.sprite = Limme;
        jogando = true;
        Inicia();
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        pressioneEspaco.gameObject.SetActive(true);
        melhorText.gameObject.SetActive(true);
        playerRig.bodyType = RigidbodyType2D.Static;

        if (Jogador.pontos > melhorPontuacao)
        {
            melhorPontuacao = Jogador.pontos;
            melhorText.text = "Best Score: " + melhorPontuacao;
            PlayerPrefs.SetInt("melhorPontuacao", melhorPontuacao);
        }
    }
}

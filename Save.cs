using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save : MonoBehaviour
{

    private string filePath; // Caminho do arquivo de salvamento
    private int highScore; // Variável que será salva e carregada
    private int currentScore = 0; // Variável de exemplo que pode ser incrementada

    private void Start()
    {
        filePath = Application.persistentDataPath + "/savefile.txt"; // Caminho do arquivo de salvamento
        LoadData(); // Carrega os dados salvos
    }

    GameObject player;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            currentScore++; // Incrementa a pontuação de exemplo
            if (currentScore > highScore)
            {
                highScore = currentScore; // Atualiza a pontuação mais alta
            }
            SaveData(); // Salva os dados atualizados
        }
    }

    private void SaveData()
    {
        player = GameObject.FindWithTag("Player");
        AtaquePlayer treco = player.GetComponent<AtaquePlayer>();
        Subitens coisa = player.GetComponent<Subitens>();
        // Cria um StreamWriter para escrever as variáveis no arquivo
        StreamWriter writer = new StreamWriter(filePath);

        // Escreve as variáveis no arquivo
        writer.WriteLine(treco.MaxHp);
        writer.WriteLine(coisa.maxSec);

        // Fecha o StreamWriter
        writer.Flush();
        writer.Close();
    }

    private void LoadData()
    {
        player = GameObject.FindWithTag("Player");
        AtaquePlayer treco = player.GetComponent<AtaquePlayer>();
        Subitens coisa = player.GetComponent<Subitens>();
        // Verifica se o arquivo de salvamento existe
        if (File.Exists(filePath))
        {
            // Cria um StreamReader para ler as variáveis do arquivo
            StreamReader reader = new StreamReader(filePath);

            // Lê as variáveis do arquivo
            treco.MaxHp = int.Parse(reader.ReadLine());
            coisa.maxSec = int.Parse(reader.ReadLine());

            // Fecha o StreamReader
            reader.Close();
        }
    }
}



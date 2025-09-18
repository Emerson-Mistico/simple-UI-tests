using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<GameObject> listPlayerPrefabs;
    public List<GameObject> listTargetsToSpawn;

    public string playerName = "Jogador n� 1";
    public int speed = 10;
    public int multiplySpeed = 2;

    private GameObject _playerPrefab;
    private Vector3 _targetPositiontoSpawn;


    public int TotalSpeed
    {
        get { return speed * multiplySpeed; }
    }

    public void CreatePlayer()
    {
        // busca item aleat�rio da minha exten��o
        _playerPrefab = listPlayerPrefabs.GetRandomItem();
        Debug.Log("Selecionei um prefab aleat�rio.");
        _targetPositiontoSpawn = listTargetsToSpawn.GetRandomItem().transform.position;
        Debug.Log("Localizei um dos 4 pontos aleat�rios para clonar.");

        var a = Instantiate(_playerPrefab);
        //a.transform.position = Vector3.zero;
        a.transform.position = _targetPositiontoSpawn;
    }


}

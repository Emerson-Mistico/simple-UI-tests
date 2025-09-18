using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class EditorGameManager : Editor
{
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        GameManager myTagert = (GameManager)target;
        // myTagert.playerPrefab = (GameObject)EditorGUILayout.ObjectField(myTagert.playerPrefab, typeof(GameObject), true);

        #region PLAYER PREFABS
        // Atualizando lista PLAYER PREFABS em modo manual na GUI
        for (int i = 0; i < myTagert.listPlayerPrefabs.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            myTagert.listPlayerPrefabs[i] = (GameObject)EditorGUILayout.ObjectField(
                "Adicionar novo Prefab " + i,
                myTagert.listPlayerPrefabs[i],
                typeof(GameObject),
                true
            );

            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                myTagert.listPlayerPrefabs.RemoveAt(i);
                break;
            }

            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Adicionar Prefab"))
        {
            myTagert.listPlayerPrefabs.Add(null);
        }
        EditorGUILayout.HelpBox("Acima: Objeto aleatório para ser clonado.", MessageType.Info);
        #endregion

        #region TARTGET TO SPAWN PREFABS
        // Atualizando lista PLAYER PREFABS em modo manual na GUI
        for (int i = 0; i < myTagert.listTargetsToSpawn.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            myTagert.listTargetsToSpawn[i] = (GameObject)EditorGUILayout.ObjectField(
                "Adicionar novo Target " + i,
                myTagert.listTargetsToSpawn[i],
                typeof(GameObject),
                true
            );

            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                myTagert.listTargetsToSpawn.RemoveAt(i);
                break;
            }

            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Adicionar Target"))
        {
            myTagert.listTargetsToSpawn.Add(null);
        }
        EditorGUILayout.HelpBox("Acima: Um dos 4 locais algo para clonagem.", MessageType.Info);
        #endregion

        myTagert.playerName = EditorGUILayout.TextField ("Nome Jogador", myTagert.playerName);
        myTagert.speed = EditorGUILayout.IntField ("Velocidade Base", myTagert.speed);
        myTagert.multiplySpeed = EditorGUILayout.IntField ("Multiplicador de velocidade", myTagert.multiplySpeed);

        EditorGUILayout.LabelField("Velocidade Total = ", myTagert.TotalSpeed.ToString());
        EditorGUILayout.HelpBox("Velocidade total não deve superar 300 km/h a velocidade normal", MessageType.Info);

        if (myTagert.TotalSpeed > 300)
        {
            EditorGUILayout.HelpBox("Velocidade total superou 300 km/h a velocidade normal", MessageType.Error);
        }

        GUI.color = Color.yellow;
        if(GUILayout.Button("Clone Player Prefab"))
        {
            myTagert.CreatePlayer();
        }

    }
}

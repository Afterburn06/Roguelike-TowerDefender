using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer (PlayerStats playerStats)
    {
        // Create a new binary formatter
        BinaryFormatter formatter = new BinaryFormatter();

        // Get the path to store the save file
        string path = Application.persistentDataPath + "/playerstats.bin";

        // Open a file stream in that path
        FileStream stream = new FileStream(path, FileMode.Create);

        // Get the player stats, save it in a variable
        PlayerData data = new PlayerData(playerStats);

        // Turn the information into binary
        formatter.Serialize(stream, data);
        // Close the file stream
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        // Get the path the save file is stored
        string path = Application.persistentDataPath + "/playerstats.bin";

        // If there is a file
        if (File.Exists(path))
        {
            // Create a new binary formatter
            BinaryFormatter formatter = new BinaryFormatter();

            // Open a file stream in that path
            FileStream stream = new FileStream(path, FileMode.Open);

            // Turn binary into player data
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            // Close the file stream
            stream.Close();
            // Return player data
            return data;
        }
        else
        {
            // Throw an error
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}

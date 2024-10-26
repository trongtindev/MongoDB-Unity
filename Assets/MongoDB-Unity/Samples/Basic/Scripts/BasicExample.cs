#if UNITY_EDITOR
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine;

public class CreateConnection
{
  public MongoClient Client;
  public IMongoDatabase Database;

  public CreateConnection(string uri, string database)
  {
    Client = new MongoClient(uri);
    Database = Client.GetDatabase(database);
  }
}

public class BasicExample : MonoBehaviour
{
  #region Fields
  [SerializeField] private string _uri = "mongodb://localhost:27017";
  [SerializeField] private string _database = "default";
  #endregion

  private async void Start()
  {
    Debug.Log("CreateConnection");
    var database = new CreateConnection(_uri, _database).Database;

    Debug.Log("GetCollection");
    var collection = database.GetCollection<BsonDocument>("bar");

    Debug.Log("InsertOneAsync");
    await collection.InsertOneAsync(new BsonDocument("Name", "Jack"));

    Debug.Log("Find");
    var list = await collection.Find(new BsonDocument("Name", "Jack")).ToListAsync();

    Debug.Log("ToListAsync");
    foreach (var document in list) Debug.Log(document["Name"]);
  }
}
#endif
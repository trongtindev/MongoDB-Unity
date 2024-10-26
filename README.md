# MongoDB-Unity

**MongoDB-Unity** is a Unity package that simplifies the use of the [MongoDB.Driver](https://www.nuget.org/packages/MongoDB.Driver/) within Unity projects. It allows developers to seamlessly integrate MongoDB for data storage, enabling robust game features and persistence.

## Features

- Connect to MongoDB databases directly from Unity.
- Perform CRUD operations easily.
- Supports asynchronous operations for improved performance.
- Lightweight and easy to set up.

## How are DLLs extracted?

```bash
dotnet new classlib --framework "netstandard2.0" -o MongoDBUnity
cd MongoDBUnity
dotnet add package MongoDB.Driver
dotnet publish
```

## Installation

### Unity Package

1. Download the latest release of the package from the [latest release](https://github.com/trongtindev/MongoDB-Unity/releases) and import it to your project.
2. Import the `.unitypackage` file into your Unity project.

### UPM Package

MongoDB-Unity can also be installed via UPM package.

```
https://github.com/trongtindev/MongoDB-Unity.git?path=/Assets/MongoDB-Unity
```

## Getting Started

```csharp
using MongoDB.Bson;
using MongoDB.Driver;
```

```csharp
var client = new MongoClient("mongodb://localhost:27017");
var database = client.GetDatabase("foo");
var collection = database.GetCollection<BsonDocument>("bar");

await collection.InsertOneAsync(new BsonDocument("Name", "Jack"));

var list = await collection.Find(new BsonDocument("Name", "Jack"))
    .ToListAsync();

foreach(var document in list)
{
    Console.WriteLine(document["Name"]);
}
```

## Documentation

- [MongoDB](https://www.mongodb.com/docs)
- [Documentation](https://www.mongodb.com/docs/drivers/csharp/current/)

## Supported Platform

Currently, MongoDB-Unity supports Windows, macOS and Linux.

## Contributing

Contributions are welcome! Please open issues or submit pull requests for any improvements or bug fixes.

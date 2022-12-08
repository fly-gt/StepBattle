using System.Collections.Generic;

public class PlayerData {
    public string Name { get; }
    public int HP { get; }

    public PlayerData(string name, int hp) {
        Name = name;
        HP = hp;
    }
}

public interface IGameRoomService {
    IReadOnlyList<PlayerData> GetEnemies();
    IReadOnlyList<PlayerData> GetPlayers();
}

public class FakeGameRoomService : IGameRoomService {
    public IReadOnlyList<PlayerData> GetEnemies() {
        return new List<PlayerData> {
            new PlayerData("Bot1", 30),
            new PlayerData("Bot2", 30),
            new PlayerData("Bot3", 30),
        };
    }

    public IReadOnlyList<PlayerData> GetPlayers() {
        return new List<PlayerData> {
            new PlayerData("Alexander", 30),
            new PlayerData("Valer4ik", 30),
            new PlayerData("Potap", 30),
        };
    }
}

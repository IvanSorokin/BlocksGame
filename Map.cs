using System;
using System.IO;
using System.Linq;
using System.Text;

namespace BoxesGame
{
    public class Map
    {
        private GameObject[][] map { get; }

        public static Map ReadFromFile(string path)
        {
            var content = File.ReadAllLines(path);
            var map = new GameObject[content.Length][];
            for (var i = 0; i < content.Length; i++)
            {
                map[i] = new GameObject[content[i].Length];
                for (var j = 0; j < content[i].Length; j++)
                {
                    map[i][j] = GameObject.FromChar(content[i][j]);
                }
            }

            return new Map(map);
        }

        public Vector FindHeroPosition()
        {
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[i].Length; j++)
                    if (map[i][j].Type == GameObjectType.Hero)
                        return new Vector(i, j);

            throw new ArgumentException("No hero on map");
        }

        public GameObject Get(int x, int y) => map[x][y];

        public void Set(int x, int y, GameObject obj) => map[x][y] = obj;

        public int Width => map.Length;

        public int Height => map[0].Length;  

        public string ToFrame()
        {
            var builder = new StringBuilder();
            foreach (var row in map)
            {
                builder.Append(string.Join("", row.Select(x => x.Symbol)));
                builder.Append("\n");
            }

            return builder.ToString();
        }

        private Map(GameObject[][] map)
        {
            this.map = map;
        }
    }
}
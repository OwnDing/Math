using System.Collections.Generic;
using System.Text;

namespace dijktra
{
    public class Graph
    {
        Dictionary<char, Dictionary<char, int>> vertices = new Dictionary<char, Dictionary<char, int>>();

        public void AddVertex(char node, Dictionary<char, int> edges)
        {
            vertices[node] = edges;
        }

        public StringBuilder ShortestPath(char start, char end)
        {
            Dictionary<char, char> prePathStore = new Dictionary<char, char>();
            Dictionary<char, int> distances = new Dictionary<char, int>();
            List<char> nodes = new List<char>();
            int cost = 0;

            StringBuilder path = new StringBuilder();
            path.Append("Final Path: ");

            foreach (var vertex in vertices)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
                }
                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                char smallestNode = nodes[0];
                nodes.Remove(smallestNode);

                if (smallestNode == end)
                {
                    cost = distances[smallestNode];
                    while (prePathStore.ContainsKey(smallestNode))
                    {
                        path.Append(smallestNode.ToString()+" <--- ");
                        smallestNode = prePathStore[smallestNode];
                    }
                    break;
                }

                if (distances[smallestNode] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighborNode in vertices[smallestNode])
                {
                    int temp = distances[smallestNode] + neighborNode.Value;
                    if (temp < distances[neighborNode.Key])
                    {
                        distances[neighborNode.Key] = temp;
                        prePathStore[neighborNode.Key] = smallestNode;
                    }
                }
            }
            
            return path.Append(start+"  Min Cost:"+cost.ToString());
        }
    }
    
    class Program
    {        
        static void Main(string[] args)
        {
            Graph g = new Graph();
            g.AddVertex('a', new Dictionary<char, int>() { { 'b', 2 }, { 'h', 8 },{ 'g', 1 } });
            g.AddVertex('b', new Dictionary<char, int>() { { 'h', 6 }, { 'c', 1 } });
            g.AddVertex('c', new Dictionary<char, int>() { { 'h', 5 }, { 'i', 3 }, { 'j', 9 }, { 'd', 2 } });
            g.AddVertex('d', new Dictionary<char, int>() { { 'j', 7 }, { 'e', 9 } });
            g.AddVertex('e', new Dictionary<char, int>() { { 'e', 0 } });
            g.AddVertex('f', new Dictionary<char, int>() { { 'e', 4 }, { 'j', 1 }, { 'k', 1 } });
            g.AddVertex('g', new Dictionary<char, int>() { { 'k', 9 }, { 'h', 7 } });
            g.AddVertex('h', new Dictionary<char, int>() { { 'c', 5 }, { 'i', 1 }, { 'g', 7 }, { 'k', 2 }, { 'b', 6 } });
            g.AddVertex('i', new Dictionary<char, int>() { { 'c', 3 }, { 'h', 1 }, { 'k', 4 }, { 'j', 9 }});
            g.AddVertex('j', new Dictionary<char, int>() { { 'd', 7 }, { 'f', 1 }, { 'e', 2 }, { 'i', 9 }, { 'c', 9 },{ 'k',3} });
            g.AddVertex('k', new Dictionary<char, int>() { { 'i', 4 }, { 'j', 3 }, { 'f', 1 }, { 'h', 2 }});

            StringBuilder sb = new StringBuilder();
            char start = 'a';
            char end = 'e';
            
            sb=g.ShortestPath(start, end);

            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }
   }
}

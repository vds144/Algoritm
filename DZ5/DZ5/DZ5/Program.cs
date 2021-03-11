using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ4
{
    //Представление списка смежности
    class clsGraph
    {
        //общее количество вершин
        private int Vertices;
        //массив списка смежности для всех вершин.
        private List<Int32>[] adj;
        /* Пример : вершины=4
         *      0->[1,2]
         *      1->[2]
         *      2->[0,3]
         *      3->[]
         */

        //конструктов
        public clsGraph(int v)
        {
            Vertices = v;
            adj = new List<Int32>[v];
            //Создать экземпляр списка смежности для всех вершин
            for (int i = 0; i < v; i++)
            {
                adj[i] = new List<Int32>();
            }

        }

        //Добавить ребро из v->w
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }

        //Печать обхода BFS
        //s-> старт node
        //BFS использует очередь в качестве базы.
        void BFS(int s)
        {
            bool[] visited = new bool[Vertices];

            //create queue for BFS
            Queue<int> queue = new Queue<int>();
            visited[s] = true;
            queue.Enqueue(s);

            //цикл через все узлы в очереди
            while (queue.Count != 0)
            {
                //Извлеките вершину из очереди и распечатайте ее.
                s = queue.Dequeue();
                Console.WriteLine("next->" + s);

                //Получить все соседние вершины s
                foreach (Int32 next in adj[s])
                {
                    if (!visited[next])
                    {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }

            }
        }

        //DFS обход 
        // DFS использует стек в качестве базы.
        public void DFS(int s)
        {
            bool[] visited = new bool[Vertices];

            //For DFS use stack
            Stack<int> stack = new Stack<int>();
            visited[s] = true;
            stack.Push(s);

            while (stack.Count != 0)
            {
                s = stack.Pop();
                Console.WriteLine("next->" + s);
                foreach (int i in adj[s])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
            }
        }

        public void PrintAdjacecnyMatrix()
        {
            for (int i = 0; i < Vertices; i++)
            {
                Console.Write(i + ":[");
                string s = "";
                foreach (var k in adj[i])
                {
                    s = s + (k + ",");
                }
                s = s.Substring(0, s.Length - 1);
                s = s + "]";
                Console.Write(s);
                Console.WriteLine();
            }
        }
        //Вызывающие методы
        public static void Main()
        {
            clsGraph graph = new clsGraph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);
            //Печать матрицы смежности
            graph.PrintAdjacecnyMatrix();

            Console.WriteLine("BFS обход, начинающийся с вершины 2:");
            graph.BFS(2);
            Console.WriteLine("DFS обход, начинающийся с вершины 2:");
            graph.DFS(2);
        }
    }
}   
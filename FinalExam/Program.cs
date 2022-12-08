using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    //Number 1
    public class MyStack
    {
        public List<int> myStack = new List<int>();

        public void Push(int n)
        {
            myStack.Add(n);
        }

        public int? Peek()
        {
            if (myStack.Count > 0)
            {
                return myStack[myStack.Count - 1];
            }
            else
            {
                return null;
            }
        }

        public int? Pop()
        {
            if (myStack.Count > 0)
            {
                int? r = myStack[myStack.Count - 1];
                myStack.Remove(myStack.Count - 1);
                return r;
            }
            else
            {
                return null;
            }
        }
        //Number 2
        public class MyQueue
        {
            public List<int> myQueue = new List<int>();

            public void Enqueue(int n)
            {
                myQueue.Insert(0, n);
            }

            public int? Peek()
            {
                if (myQueue.Count > 0)
                {
                    return myQueue[0];
                }
                else
                {
                    return null;
                }
            }

            public int? Dequeue()
            {
                if (myQueue.Count > 0)
                {
                    int? r = myQueue[0];
                    myQueue.RemoveAt(0);
                    return r;
                }
                else
                {
                    return null;
                }
            }
        }

        //Number 4

        enum EColor
        {
            red,
            blue,
            yellow,
            cyan,
            gray,
            purple,
            orange,
            green
        }
        public class Node: IComparable<Node>
        {
            public EColor nState;

            public List<Edge> edges = new List<Edge>();

            public int minCostToStart;
            public Node nearestToStart;
            public bool visited;

            public Node(int nState)
            {
                this.nState = nState;
                this.minCostToStart = int.MaxValue;
            }

            public void AddEdge(int cost, Node connection)
            {
                AddEdge e = new Edge(cost, connection);
                edges.Add(e);
            }

            public int CompareTo(Node n)
            {
                return this.minCostToStart.CompareTo(n.minCostToStart);
            }

            public class Edge : IComparable<Edge>
            {
                public int cost;
                public Node connectedNode;

                public Edge(int cost, Node connectedNode){
                    this.cost = cost;
                    this.connectedNode = connectedNode;
                }

                public int CompareTo(Edge e){
                    return this.cost.CompareTo(e.cost);
                }
            }
        }


        internal class Program
        {
            //Number 4
            static void DFS(EColor eState)
            {
                bool[] visited = new bool[colorAGraph.Length];
                DFSUtil(eState, visited);
            }

            static void DFSUtil(EColor v, bool[] visited)
            {
                visited[(int)v] = true;

                Console.Write(v.ToString() + " ");

                int[] thisStateList = colorAGraph[(int)v];
                if (thisStateList != null)
                {
                    foreach (int n in thisStateList)
                    {
                        if (!visited[n])
                        {
                            DFSUtil((EColor)n, visited);
                        }
                    }
                }
            }
            //Number 3
            static int[,] colorMGraph = new[,]
            {
                /*red blue yellow cyan gray purple orange green*/
                /*red*/{-1, 1, -1, -1, 5, -1, -1, -1 },
                /*blue*/ {-1,-1,8,1,-1,-1,-1,-1},
                /*yellow*/{-1,-1,-1,-1,-1,-1,-1,6},
                /*cyan*/ {-1,-1,1,-1,0,-1,-1,-1},
                /*gray*/ {-1,-1,-1,0,-1,-1,1,-1},
                /*purple*/ {-1,-1,1,-1,-1,-1,-1,-1},
                /*orange*/ {-1,-1,-1,-1,-1,1,-1,-1},

                /*green*/ {-1,-1,-1,-1,-1,-1,-1,-1 }
            };
            //Color
            static int[][] colorAGraph = new int[][]
            {
                /*red*/ new int[]{(int)EColor.blue, (int)EColor.gray},
                /*blue*/ new int[]{2, 3},
                /*yellow*/ new int[]{7},
                /*cyan*/ new int[]{1,4},
                /*gray*/ new int[]{3,6},
                /*purple*/ new int[]{2},
                /*orange*/ new int[]{5},

                /*green*/ null
            };
            //Weight
            static int[][] colorWGraph = new int[][]
            {
                /*red*/ new int[]{1, 5},
                /*blue*/ new int[]{8, 1},
                /*yellow*/ new int[]{6},
                /*cyan*/ new int[]{1,0},
                /*gray*/ new int[]{0,1},
                /*purple*/ new int[]{1},
                /*orange*/ new int[]{1},

                /*green*/ null
            };

            static void Main(string[] args)
            {
                DFS(EColor.red);
            }
        }
    }
}

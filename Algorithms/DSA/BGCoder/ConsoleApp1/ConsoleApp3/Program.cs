using System;
using System.Collections.Generic;

namespace GraphsInGeneral
{
    public class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();


        }

    }



    public class Graph
    {
        private HashSet<Node> childNodes;
        private HashSet<Edge> graphedges;

        public Graph()
        {
        }

        public Graph(HashSet<Edge> graphedges)
        {
            this.graphedges = graphedges;
        }

        public Graph(HashSet<Node> nodes)
        {
            this.childNodes = nodes;
        }
        public void AddEnge(Edge edge)
        {
            this.graphedges.Add(edge);
        }

        public static void PurelyItterative(List<List<int>> graph)
        {
        }

        public static void DFSItterativeWithStack()
        {
        }

        public static void DFSRecursive(List<List<int>> graph)
        {
        }

        public static void BFSItterativeWithQueue(List<List<int>> graph)
        {
        }

    }

    public class Node
    {
        //private string name;
        private int index;
        private HashSet<Node> adjacentNodes;

        public Node(int index)
        {
            this.index = index;
        }

        public Node(int index, HashSet<Node> adjacentNodes)
        {
            this.index = index;
            this.AdjacentNodes = adjacentNodes;
        }

        public int Index
        {
            get
            {
                return this.index;
            }
            set
            {
                this.index = value;
            }
        }

        public HashSet<Node> AdjacentNodes
        {
            get
            {
                return this.adjacentNodes;
            }
            set
            {
                this.adjacentNodes = value;
            }
        }

    }

    public class Edge
    {
        private Node[] edgeBetweenTwoNodes = new Node[2];
        //private bool directed;
        //private bool weighted;
        //private string name;
        //private int value;

        public Edge(Node node1, Node node2)
        {
            this.edgeBetweenTwoNodes[0] = node1;
            this.edgeBetweenTwoNodes[1] = node2;
        }

    }

}


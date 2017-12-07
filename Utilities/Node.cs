using System.Collections.Generic;
using System.Linq;

public class Node {
    public int Weight { get; }

    public string Name { get; }

    public Node ParentNode { get; set; }

    public List<Node> ChildNodes { get; }

    private int _totalWeight;

    public int TotalWeight() {
        if(this._totalWeight == 0) {
            this._totalWeight = this.Weight;
            this._totalWeight += this.ChildNodes.Sum(c => c.TotalWeight());
        }

        return this._totalWeight;
    }

    public bool IsBalanced() {
        if(this.ChildNodes.Count() < 2) {
            return true;
        }

        for(int i = 1; i < this.ChildNodes.Count(); i++) {
            if(this.ChildNodes[i].TotalWeight() != this.ChildNodes[i -1].TotalWeight()) {
                return false;
            }
        }

        return true;
    }

    public int Depth() {
        int count = 0;
        var current = this;
        while(current != null) {
            current = current.ParentNode;
            count++;
        }

        return count;
    }

    public Node(string name, int weight) {
        this.Name = name;
        this.Weight = weight;
        this.ChildNodes = new List<Node>();
    }
}
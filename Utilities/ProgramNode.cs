using System.Collections.Generic;
using System.Linq;

public class ProgramNode {
    public string Id { get; }

    public List<ProgramNode> Connections { get; set; }

    public ProgramNode(string id) {
        this.Id = id;
        this.Connections = new List<ProgramNode>();
    }

    public Dictionary<string, ProgramNode> FindGroup() {
        return this.FindGroup(new Dictionary<string, ProgramNode>());
    }

    public Dictionary<string, ProgramNode> FindGroup(Dictionary<string, ProgramNode> currentGroup) {
        if(currentGroup.ContainsKey(this.Id)) {
            return currentGroup;
        }

        currentGroup.Add(this.Id, this);

        foreach(var child in Connections) {
            if(!currentGroup.ContainsKey(child.Id)) {
                var childGroup = child.FindGroup(currentGroup);
                childGroup.ToList().ForEach(g => currentGroup[g.Key] = g.Value);
            }
        }

        return currentGroup;
    }
}
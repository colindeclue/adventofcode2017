using System.Linq;

public class KnotRunner {
    public int[] List { get; }

    private int[] _lengths;

    private int _index;

    private int _skip;

    public KnotRunner(int listSize, int[] lengths) {
        this.List = Enumerable.Range(0, listSize).ToArray();
        this._lengths = lengths;
        this._index = 0;
        this._skip = 0;
    }

    public void DoRound() {
        var listSize = this.List.Length;
        foreach(var length in this._lengths) {
            var current = this.List.Skip(this._index).Take(length).ToArray();
            if(this._index + length > listSize) {
                current = current.Concat(this.List.Take((this._index + length) % listSize)).ToArray();
            }
            current = current.Reverse().ToArray();
            for(int i = 0; i < length; i++) {
                this.List[(i + this._index) % listSize] = current[i];
            }

            this._index = (this._index + length + this._skip) % listSize;
            this._skip++;
        }
    }
}
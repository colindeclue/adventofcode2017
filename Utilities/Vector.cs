using System;

public class Vector {
    public int Id { get; }

    public long X { get; private set; }
    
    public long Y { get; private set; }

    public long Z { get; private set; }

    public long Length => Math.Abs(this.X) + Math.Abs(this.Y) + Math.Abs(this.Z);

    public Vector _velocity;

    public Vector(int id, (long x, long y, long z) points, Vector velocity, Vector acceleration) {
        this.Id = id;
        this.X = points.x;
        this.Y = points.y;
        this.Z = points.z;
        this._velocity = velocity;
        if(velocity != null && acceleration != null) {
            this._velocity._velocity = acceleration;
        }
    }

    public (long x, long y, long z) ToTuple() {
        return (this.X, this.Y, this.Z);
    }

    public long Tick() {
        if(this._velocity != null) {
            this._velocity.Tick();
            this.X += this._velocity.X;
            this.Y += this._velocity.Y;
            this.Z += this._velocity.Z;
        }

        return this.Length;
    }
}
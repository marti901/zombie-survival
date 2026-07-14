class Vector2D {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }
}

class Player
{
    constructor(location) {
        this.location = new Vector2D(50, 50)
    }

    draw() {
        ctx.beginPath();
        ctx.arc(this.location.x, this.location.y, 32, 0, 2 * Math.PI);
        ctx.fillStyle = "orange";
        ctx.fill();
    }
}

class Zombie
{
    constructor(location) {
        this.location = location
    }

    draw() {
        ctx.beginPath();
        ctx.arc(this.location.x, this.location.y, 32, 0, 2 * Math.PI);
        ctx.fillStyle = "green";
        ctx.fill();
    }
}
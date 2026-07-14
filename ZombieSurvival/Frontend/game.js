
const canvas = document.getElementById("gameCanvas");
const ctx = canvas.getContext("2d");

var zombies = [];

const gameServerWebsocket = new WebSocket("ws:127.0.0.1:5123");
gameServerWebsocket.addEventListener("open", (event) => {
    gameServerWebsocket.send("Hello Server!");
});

// TODO: Handle error properly
fetch("https://zombiesurvival-worldservice-zombiesurvival.dev.localhost:7020/world-state")
    .then(x => x.json())
    .then(gameState => {

    gameState.zombieLocations.forEach(zl => {
        zombies.push(new Zombie(zl));
    });

    const player = new Player();

    player.draw();
    zombies.forEach(x => x.draw());
});



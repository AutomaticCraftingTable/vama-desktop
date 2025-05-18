# [vama-desktop](https://github.dev/AutomaticCraftingTable/vama-desktop)

## Zależności
- Linux/WSL with [Nix](https://nixos.org/download/)

## Uruchomienie projektu
Aby uruchomić powłokę z zaleznosciami:
```sh
nix-shell
```

Aby uruchomić preferowane środowisko IDE:
```sh
nix-shell --argstr run "<your-ide>"
```

Jeśli środowisko IDE nie jest zainstalowane, jest możliwość uruchomienia Ridera:
```sh
nix-shell rider.nix
```

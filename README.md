# [vama-desktop](https://github.dev/AutomaticCraftingTable/vama-desktop)

## Dependencies
- [nix](https://nixos.org/download/)

## Run the project
### Linux/WSL with Nix
To run the shell environment:
```bash
nix-shell
```
To run your IDE of choice for the development:
```bash
nix-shell --run "<your-ide>"
```

### NixOS:
Use premaid Rider environment:
```bash
nix-shell rider.nix
```
Or use an IDE of your choice, as described [above](#linuxwsl-with-nix)

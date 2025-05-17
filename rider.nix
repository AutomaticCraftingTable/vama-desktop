{ pkgs ? import <nixpkgs> { config.allowUnfree = true; }}:

(pkgs.buildFHSEnv {
  name = "rider-env";
  targetPkgs = pkgs: [ pkgs.jetbrains.rider ];
  runScript = "nix-shell shell.nix --run ${pkgs.jetbrains.rider}/bin/rider";
}).env

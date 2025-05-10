{ pkgs ? import <nixpkgs> {} }:

pkgs.buildFHSEnv {
  name = "rider-env";
  targetPkgs = pkgs: [ pkgs.rider ];
  runScript = "nix-shell shell.nix --run rider";
}

{ pkgs ? import <nixpkgs> {} }:

(pkgs.buildFHSEnv {
  name = "rider-env";
  targetPkgs = pkgs: (with pkgs; [
    rider
    dotnetCorePackages.dotnet_9.sdk
    fontconfig
  ]);
  runScript = "rider";
}).env

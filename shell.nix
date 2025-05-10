{ pkgs ? import <nixpkgs> {} }:

pkgs.mkShell {
  packages = with pkgs; [
    dotnetCorePackages.dotnet_9.sdk
    fontconfig
  ];
}

{ pkgs ? import <nixpkgs> { allowUnfree = true; } }:

(pkgs.buildFHSEnv {
  name = "dotnet-env";
  targetPkgs = pkgs: with pkgs; [
    dotnetCorePackages.dotnet_9.sdk
    
    corefonts
    fontconfig
    freetype
    harfbuzz
    libGL

    xorg.libX11
    xorg.libICE
    xorg.libSM
    xorg.libXi
    xorg.libXcursor
    xorg.libXext
    xorg.libXrandr
    xorg.libXrender
    xorg.libXfixes
    
    openssl
    zlib
    icu
    libunwind
    stdenv.cc.cc.lib
  ];
  runScript = "bash";
}).env

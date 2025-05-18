{ pkgs ? import <nixpkgs> { config.allowUnfree = true; } }:

(pkgs.buildFHSEnv {
  name = "rider-env";
  targetPkgs = pkgs: with pkgs; [
    pkgs.jetbrains.rider

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
  runScript = "${pkgs.jetbrains.rider}/bin/rider &";
}).env

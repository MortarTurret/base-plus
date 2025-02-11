function getVisibleRange( %fallback ) {
  %terrain = nameToID("MissionGroup/Landscape/Terrain");

  if(%terrain) {
    %lockDistance = (%terrain.hazeDistance + %terrain.visibleDistance) / 2;
    
    return round(%lockDistance);
  }

  else {
    if(%fallback) {
      return %fallback;
    }

    else {
      return 150;
    }
  }
}
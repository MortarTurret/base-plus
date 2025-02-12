//------------------------------------------------------------------------------
//-  Get the average visible distance of the current mission
//------------------------------------------------------------------------------
function getAVR( %lowerBound, %upperBound ) {
  %terrain = nameToID("MissionGroup/Landscape/Terrain");
  %range = round((%terrain.hazeDistance + %terrain.visibleDistance) / 2);

  return (%lowerBound && %upperBound) ? 
    clamp(%lowerBound, %range, %upperBound) : (%lowerBound) ? 
      max(%lowerBound, %range) : (%upperBound) ? 
        min(%range, %upperBound) : %range;
}
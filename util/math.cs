//------------------------------------------------------------------------------
//-  New methods for player math 
//------------------------------------------------------------------------------
function GameBase::adjustFloatPrecision(%floatValue, %precision) {
  // Default precision to 2 if not provided.
  %precision = %precision ? %precision : 2;
  %multiplier = 1;
  
  //- Adjust the multiplier to 10^precision.
  for (%i = 0; %i < %precision; %i++) {
    %multiplier *= 10;
  }

  //- Multiply by the precision multiplier, truncate, then divide back.
  %adjustedValue = floor(%floatValue * %multiplier + 0.5) / %multiplier;

  //- Typecast to string to clean up the float.
  %adjustedValue = %adjustedValue @ "";  

  //- Find the decimal point using String::findSubStr.
  %decimalPos = String::findSubStr(%adjustedValue, ".");
  
  //- If there's a decimal point in the string.
  if(%decimalPos != -1) {
    // Get the current number of decimal places.
    %currentDecimals = String::len(%adjustedValue) - %decimalPos - 1;
    
    // If the number of decimal places exceeds the desired precision, truncate.
    if(%currentDecimals > %precision) {
      %adjustedValue = String::getSubStr(%adjustedValue, 0, %decimalPos + %precision + 1);
    }
  } 
  
  //- If there's no decimal point, just append one. It's fine.
  else {
    %adjustedValue = %adjustedValue @ ".";
  }

  //- Apply aggressive rounding and normalization
  %adjustedValueAsFloat = %adjustedValue;
  %epsilon = 0.0000001; // Small epsilon threshold for very small differences

  //- If very close to an integer, adjust it.
  if(abs(%adjustedValueAsFloat - floor(%adjustedValueAsFloat)) < %epsilon) {
    %adjustedValue = floor(%adjustedValueAsFloat);
  }
  
  //- If there's a small discrepancy, apply rounding again...
  else {
    %adjustedValue = floor(%adjustedValueAsFloat * %multiplier + 0.5) / %multiplier;
  }

  //- Return our new precision-adjusted value! #VGY
  return %adjustedValue;
} 
export class ForgeUtils{
   static getEncodedURN = function (urn) {
    let encoded;

    if (urn.indexOf('adsk') != -1) {
        encoded = `urn:${btoa(urn)}`;
    }
    else if (urn.indexOf('urn') == -1) {
        encoded = `urn:${urn}`;
    }
    else {
        encoded = urn;
    }

    return encoded;
} 
}
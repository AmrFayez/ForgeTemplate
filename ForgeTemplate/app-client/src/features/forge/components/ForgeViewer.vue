<template>
  <div>
      <div id="forge-viewer"></div>
  </div>
</template>

<script>

import ForgeAuthService from '../services/ForgeAuthService'
export default {
 data(){
     return {
       viewer: Autodesk.Viewing.GuiViewer3D,
       options:null
     }

 },
 created(){
 this.options = {
    env: 'AutodeskProduction2',
    api: 'streamingV2',  // for models uploaded to EMEA change this option to 'streamingV2_EU'
    getAccessToken:async function(onTokenReady) {
        var tokenObj=(await ForgeAuthService.getAccessTokenAsync()).data;
        debugger;
        onTokenReady(tokenObj.accessToken, tokenObj.expiresIn);
    }
};
 },
 mounted(){
Autodesk.Viewing.Initializer(this.options, function() {

    var htmlDiv = document.getElementById('forge-viewer');
    this.viewer = new Autodesk.Viewing.GuiViewer3D(htmlDiv);
    debugger;
    var startedCode = this.viewer.start();
    if (startedCode > 0) {
        console.error('Failed to create a Viewer: WebGL not supported.');
        return;
    }
var documentId = 'urn:dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6dHVwbWk4cGkwZGFoeHFwdXNhZTZ6aG9hMG1scjdtNmJfYmFyeS9BcmNoUHJvamVjdC5ydnQ';
var self=this;
Autodesk.Viewing.Document.load(documentId, this.onDocumentLoadSuccess.bind(this), this.onDocumentLoadFailure.bind(this));
    console.log('Initialization complete, loading a model next...');

}.bind(this));
 },
 methods:{
     onDocumentLoadSuccess(viewerDocument) {
    var defaultModel = viewerDocument.getRoot().getDefaultGeometry();
    debugger;
    this.viewer.loadDocumentNode(viewerDocument, defaultModel);
},onDocumentLoadFailure() {
    console.error('Failed fetching Forge manifest');
}
 },destroyed(){
     console.log("Dispose Viewer")
   this.viewer.finish();
this.viewer = null;
 Autodesk.Viewing.shutdown();
 }
 

}
</script>

<style>

</style>
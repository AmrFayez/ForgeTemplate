<template>
  <div class="home">
    <ForgeViewer />
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue';
import  ForgeViewer from '@/features/forge/components/ForgeViewer.vue'
export default {
  name: 'Home',
  components: {
    HelloWorld,
    ForgeViewer,
  },
};
</script>

    ForgeViewer
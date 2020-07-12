<template>
  <div id="app">
    <!-- <div class="bg"></div> -->
    <aside>
      <add-folder-button />
    </aside>
    <main>
      <div>
        <input placeholder="Enter search keyword." type="text" />
        search bar
      </div>
    </main>
    <!-- <img alt="Vue logo" src="./assets/logo.png" />
    <HelloWorld msg="Welcome to Your Vue.js + TypeScript App" />-->
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import HelloWorld from "./components/HelloWorld.vue";
import AddFolderButton from "./components/AddFolderButton.vue";
import { mitter } from "./main";

@Component({
  components: {
    HelloWorld,
    AddFolderButton
  }
})
export default class App extends Vue {
  public folderPath: string[] = [];

  mounted() {
    mitter.on("folderSelected", path => {
      this.folderPath.push(path);
    });
    // nw.App.
    console.log();
    // @ts-ignore
    let input = document.getElementById("folderSelector");
  }
}
</script>

<style lang="scss">
@import url("assets/bootstrap/bootstrap.css");

@mixin flex-row {
  display: flex;
  flex-flow: row nowrap;
}
@mixin flex-col {
  display: flex;
  flex-flow: column nowrap;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  height: 100vh;

  // margin-top: 60px;
  background-color: transparent;
  z-index: 999;
  @include flex-row();
  // .bg {
  //   position: absolute;
  //   width: 100vw;
  //   height: 100vh;
  //   // filter: blur(10px);
  //   background-color: rgba(100, 100, 100, 0.9);
  //   z-index: -1;
  // }
  main {
    background-color: lightcoral;
    flex: 2;
    z-index: 1;
  }
  aside {
    overflow: visible;
    background-color: lightblue;
    max-width: 200px;
    padding: 0;
    flex: 1;
    // border-left: grey 0.5px solid;
    // box-shadow: #00000080 2px 0 5px 2px;
    z-index: 2;

    // appearance: none;;
    // backdrop-filter: ;
  }
}
</style>

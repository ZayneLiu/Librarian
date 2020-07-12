<template>
  <div id="app">
    <!-- <div class="bg"></div> -->
    <aside>
      <add-folder-button />
      <folder-list :pathList="folderList" />
    </aside>
    <main>
      <search-bar />
      <result-view :keyword="searchkKeyword" />
    </main>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { mitter } from "./main";
import HelloWorld from "./components/HelloWorld.vue";
import AddFolderButton from "./components/AddFolderButton.vue";
import FolderList from "./components/FolderList.vue";
import SearchBar from "./components/SearchBar.vue";
import ResultView from "./components/ResultView.vue";

@Component({
  components: {
    HelloWorld,
    AddFolderButton,
    FolderList,
    SearchBar,
    ResultView
  }
})
export default class App extends Vue {
  public folderList: string[] = [];
  public searchkKeyword: string = "";

  mounted() {
    mitter.on("folderSelected", path => {
      if (!path) return;
      if (this.folderList.indexOf(path) >= 0) {
        alert("folder already selected!");
        return;
      }
      this.folderList.push(path);
    });

    mitter.on("keywordSubmission", keyword => {
      this.searchkKeyword = keyword;
      // TODO:
      console.log(keyword);
    });

    // TODO: Load indexed fodlers from backend
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
    @include flex-col();
    background-color: lightcoral;
    flex: 2;
    z-index: 1;
  }
  aside {
    @include flex-col();
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
